using _0_Framwork.Application;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.Account
{
    public class Register
    {
        [Required(ErrorMessage =ValidaionMessages.IsRequired)]
        public string FullName { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string UserName { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Password { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Mobile { get; set; }
        [Range(1,1000000,ErrorMessage = ValidaionMessages.IsRequired)]

        public long RoleId { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
