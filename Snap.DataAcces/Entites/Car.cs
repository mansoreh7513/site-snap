using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.DataAccessLayer.Entites
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام خودرو")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
