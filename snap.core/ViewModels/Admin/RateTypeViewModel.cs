using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.Admin
{
    public class RateTypeViewModel
    {
        [Display(Name = "گزینه امتیاز")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(40, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "مثبت")]
        public bool OK { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int ViewOrder { get; set; }
    }
}
