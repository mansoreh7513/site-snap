using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.Panel
{
    public class UserAddressViewModel
    {
        [Display(Name = "عنوان یا نام")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public string Desc { get; set; }
    }
}
