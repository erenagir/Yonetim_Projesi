using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Exceptions;
using X.Yönetim.Application.Models.Dtos.UserImages;
using X.Yönetim.Application.Models.RequestModels.UserImages;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Wrapper;
using X.Yönetim.Domain.Entities;
using X.Yönetim.Domain.UWork;
using XYönetim.Utils.Utils;
using X.Yönetim.Application.Behaviors;
using XYönetim.Application.Validators.UserImages;
using X.Yönetim.Application.Validators.UserImages;
using AutoMapper.QueryableExtensions;

namespace X.Yönetim.Application.Services.Implementation
{
    public class UserImageService : IUserImageService
    {
      
        private readonly IMapper _mapper;
        private readonly IUWork _unitWork;
        private readonly IHostingEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public UserImageService(IMapper mapper, IUWork unitWork, IHostingEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _mapper = mapper;
            _unitWork = unitWork;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }




        [ValidationBehavior(typeof(CreateUserImageValidator))]
        public async Task<Result<int>> CreateUserImage(CreateUserImageVM createUserImageVM)
        {
            var result = new Result<int>();

            var userExists = await _unitWork.GetRepository<User>().AnyAsync(x => x.Id == createUserImageVM.UserId);
            if (!userExists)
            {
                throw new NotFoundException($"{createUserImageVM.UserId} numaralı ürün bulunamadı.");
            }
            //Dosyanın ismi belirleniyor.
            var fileName = PathUtil.GenerateFileNameFromBase64File(createUserImageVM.UploadedImage);
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, _configuration["Paths:ProductImages"], fileName);

            //Base64 string olarak gelen dosya byte dizisine çevriliyor.
            var imageDataAsByteArray = Convert.FromBase64String(createUserImageVM.UploadedImage);
            //byte dizisi FileStream'e yazmak üzere FileStream'e aktarılıyor.
            var ms = new MemoryStream(imageDataAsByteArray);
            ms.Position = 0;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                ms.CopyTo(fs);
                fs.Close();
            }

            //Dosyanı yolu [Projenin kök dizininin yolu]+["images"]+"["product-images"]+["dosyanın adı.uzantısı"]

            var UserImageEntity = _mapper.Map<UserImage>(createUserImageVM);
            //images/product-images/14_8_2023_21_56_39_987.png
            UserImageEntity.Path = $"{_configuration["Paths:UserImages"]}/{fileName}";

            //Dosyaya ait bilgileri dbye yaz.
            _unitWork.GetRepository<UserImage>().Add(UserImageEntity);
            await _unitWork.CommitAsync();

            result.Data = UserImageEntity.Id;
            return result;
        }
     
        
        [ValidationBehavior(typeof(DeleteUserImageValidator))]
        public async Task<Result<int>> DeleteUserImage(DeleteUserImageVM deleteUserImageVM)
        {
            var result = new Result<int>();

            var existsUserImage = await _unitWork.GetRepository<UserImage>().GetByIdAsync(deleteUserImageVM.Id);
            if (existsUserImage is null)
            {
                throw new NotFoundException($"{deleteUserImageVM.Id} numaralı ürün resmi bulunamadı.");
            }

            //Ürün resmine ait db kaydı siliniyor.
            _unitWork.GetRepository<UserImage>().Delete(existsUserImage);
            await _unitWork.CommitAsync();

            //Fiziksel resim dosyası siliniyor.
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, existsUserImage.Path);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            result.Data = existsUserImage.Id;
            return result;
        }
      
        
        [ValidationBehavior(typeof(GetUserImageValidator))]
        public async Task<Result<UserImageDto>> GetUserImage(GetUserImageVM getUserImageVM)
        {
            var result = new Result<UserImageDto>();

            var productImageEntities = await _unitWork.GetRepository<UserImage>().GetSingleByFilterAsync(x => x.UserId == getUserImageVM.UserId);
            var UserImageDto=_mapper.Map<UserImageDto>(productImageEntities);
           // var productImageDto =  productImageEntities.ProjectTo<UserImageDto>(_mapper.ConfigurationProvider);

            result.Data = UserImageDto;
            return result;
        }
    }
}
