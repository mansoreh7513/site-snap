﻿using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.DataAccessLayer.Entites
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "انتخاب نقش")]
        public Guid RoleId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required]
        [MaxLength(11)]
        public string Username { get; set; }

        [Display(Name = "کد ورود")]
        [MaxLength(100)]
        public string Password { get; set; }

        [Display(Name = "توکن")]
        public string Token { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "کیف پول")]
        public long Wallet { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public virtual UserDetail UserDetail { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual ICollection<Factor> Factors { get; set; }

        public virtual ICollection<UserAddresse> UserAddresses { get; set; }

        public virtual ICollection<Transact>Transacts { get; set; }
    }
}
 