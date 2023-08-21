using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Yönetim.Application.Models.RequestModels.UserImages
{
    public class CreateUserImageVM
    {
        public int? UserId { get; set; }
        public string UploadedImage { get; set; }
    }
}
