﻿using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels
{
    public class ActiveViewModel
    {
        [Display(Name = "کد فعالسازی")]
        [Required(ErrorMessage = "کد فعالسازی 6 رقمی معتبر وارد کنید")]
        [MaxLength(6, ErrorMessage = "کد فعالسازی 6 رقمی معتبر وارد کنید")]
        [MinLength(6, ErrorMessage = "کد فعالسازی 6 رقمی معتبر وارد کنید")]
        [Phone(ErrorMessage = "کد فعالسازی 6 رقمی معتبر وارد کنید")]
        public string Code { get; set; }
    }
}
