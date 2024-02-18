using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.DataAccessLayer.Entites
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public Guid? CarId { get; set; }

        public Guid? ColorId { get; set; }

        [Display(Name = "کد ملی")]
        [MaxLength(10)]
        public string NationalCode { get; set; }

        [Display(Name = "شماره ثابت")]        
        [MaxLength(30)]
        public string Tel { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }        

        [Display(Name = "شماره پلاک")]
        [MaxLength(30)]
        public string CarCode { get; set; }

        [Display(Name = "تصویر گواهینامه")]
        public string Img { get; set; }

        [Display(Name = "تصویر راننده")]
        public string Avatar { get; set; }

        [Display(Name = "تأیید")]
        public bool IsConfirm { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
    }
}
