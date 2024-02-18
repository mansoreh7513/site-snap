using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.Admin
{
    public class UserViewModel
    {
        [Display(Name = "نقش کاربر")]
        public Guid RoleId { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(11, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(11, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        [Phone(ErrorMessage = "شماره همراه معتبر وارد نمایید")]
        public string Username { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }
    }
}
