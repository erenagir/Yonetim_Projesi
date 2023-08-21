using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Yönetim.Application.Models.Dtos.UserImages
{
    public class UserImageDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Path { get; set; }
    }
}
