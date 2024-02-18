using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.Panel
{
    public class UserDetailProfileViewModel
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string FullName { get; set; }

        [Display(Name = "تاریخ تولد")]        
        public string BirthDate { get; set; }
    }
}
