using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using X.Yönetim.Application.Behaviors;
using X.Yönetim.Application.Exceptions;
using X.Yönetim.Application.Models.Dtos.Accounts;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Validators.Accounts;
using X.Yönetim.Application.Wrapper;
using X.Yönetim.Domain.Entities;
using X.Yönetim.Domain.UWork;
using XYönetim.Utils;

namespace X.Yönetim.Application.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUWork _uWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountService(IConfiguration configuration, IMapper mapper, IUWork uWork)
        {
            _configuration = configuration;
            _mapper = mapper;
            _uWork = uWork;
        }
        
        /// <summary>
        /// login işlemi için
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof( LoginValidator))]
        public async Task<Result<TokenDto>> Login(LoginVM loginVM)
        {
            var result = new Result<TokenDto>();
            //gelen parolanın şifrelenmiş karşılığı
            var hashedPassword = CipherUtil.EncryptString(_configuration["AppSettings:SecretKey"], loginVM.Password);
            //account tablosunda eşleşen veri varsa getir
            var existsAccount = await _uWork.GetRepository<Account>()
                .GetSingleByFilterAsync(x => x.Username == loginVM.Username && x.Password == hashedPassword, "User");

            if (existsAccount is null)
            {
                throw new NotFoundException("kullanıcı bulunamadı ya da parola hatalı");
            }
            //Token expire (sona erme süresi) süresini belirle
            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var expireDate = DateTime.Now.AddMinutes(expireMinute);

            //Token'i üret ve return et.
            var tokenString = GenerateJwtToken(existsAccount, expireDate);

            result.Data = new TokenDto
            {
                Token = tokenString,
                ExpireDate = expireDate,
                Role = existsAccount.Role
            };
            _uWork.Dispose();
            return result;
        }

        /// <summary>
        /// yeni kullanıcı oluşturmak için 
        /// </summary>
        /// <param name="registerVM"></param>
        /// <returns></returns>
        /// <exception cref="AlreadyExistsException"></exception>
        [ValidationBehavior(typeof(RegistionValidator))]
        public async Task<Result<bool>> Register(RegisterVM registerVM)
        {
            var result = new Result<bool>();

            //Aynı kullanıcı adı daha önce girilmiş mi.
            var usernameExists = await _uWork.GetRepository<Account>().AnyAsync(x=>x.Username.Trim().ToUpper()==registerVM.Surname.Trim().ToUpper());
            if (usernameExists)
            {
                throw new AlreadyExistsException($"{registerVM.Username} kullanıcı adı daha önce seçilmiştir. Lütfen farklı bir kullanıcı adı belirleyiniz.");
            }

            //Eposta adresi kullanılıyor mu.
            var emailExists = await _uWork.GetRepository<User>().AnyAsync(x => x.Email.Trim().ToUpper() == registerVM.Email.Trim().ToUpper());
            if (emailExists)
            {
                throw new AlreadyExistsException($"{registerVM.Email} eposta adresi kullanılmaktadır. Lütfen farklı bir kullanıcı adı belirleyiniz.");
            }

            //Gelen model Customer türüne maplandi
            var userEntity = _mapper.Map<User>(registerVM);
            //Gelen model Account türüne maplandi.
            var accountEntity = _mapper.Map<Account>(registerVM);
            //Kullanıcının parolasını şifreleyerek kaydedelim.
            accountEntity.Password = CipherUtil
                .EncryptString(_configuration["AppSettings:SecretKey"], accountEntity.Password);

            accountEntity.User = userEntity;

            _uWork.GetRepository<User>().Add(userEntity);
            _uWork.GetRepository<Account>().Add(accountEntity);
            result.Data =await _uWork.CommitAsync();
            _uWork.Dispose();
            return result;
        }
        
        /// <summary>
        /// kullanıcı bilgilerinden bazılarını güncellemek için
        /// </summary>
        /// <param name="updateUserVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof(UpdateUserValidator))]
        public async Task<Result<int>> UpdateUser(UpdateUserVM updateUserVM)
        {
           var result = new Result<int>();
            var existsUser=await _uWork.GetRepository<User>().GetByIdAsync(updateUserVM.Id);
           

            _mapper.Map(updateUserVM,existsUser);
            _uWork.GetRepository<User>().Update(existsUser);
           await _uWork.CommitAsync();
            result.Data = existsUser.Id;
            _uWork.Dispose();
            return result;
        }
       
        /// <summary>
        /// token oluşturmak için
        /// </summary>
        /// <param name="account"></param>
        /// <param name="expireDate"></param>
        /// <returns></returns>
        private string GenerateJwtToken(Account account, DateTime expireDate)
        {
            var secretKey = _configuration["Jwt:SigningKey"];
            var issuer = _configuration["Jwt:Issuer"];
            var audiance = _configuration["Jwt:Audiance"];

            var claims = new Claim[]
            {
                 new Claim(ClaimTypes.Role,account.Role.ToString()),
                new Claim(ClaimTypes.Role,account.Role.ToString()),
                new Claim(ClaimTypes.Name,account.Username),
                new Claim(ClaimTypes.Email,account.User.Email), //Account entity'sini Customer'a bağlayan navigation property
                new Claim(ClaimTypes.Sid,account.UserId.ToString())

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = audiance,
                Issuer = issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = expireDate, // Token süresi (örn: 20 dakika)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
