using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace Snapp.Core.ViewModels.Admin
{
    public class DriverImgViewModel
    {
        [Display(Name = "تصویر گواهینامه")]
        public IFormFile Img { get; set; }

        public string ImgName { get; set; }

        [Display(Name = "تأیید")]
        public bool IsConfirm { get; set; }
    }
}
