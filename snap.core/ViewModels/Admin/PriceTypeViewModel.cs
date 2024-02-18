using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.Admin
{
    public class PriceTypeViewModel
    {
        [Display(Name = "عنوان تعرفه")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "از مسافت")]
        public int Start { get; set; }

        [Display(Name = "تا مسافت")]
        public int End { get; set; }

        [Display(Name = "نرخ ثابت")]
        public long Price { get; set; }
    }
}
