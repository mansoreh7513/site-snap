using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.DataAccessLayer.Entites
{
    public class Humidity 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "از میزان")]
        public int Start { get; set; }

        [Display(Name = "تا میزان")]
        public int End { get; set; }

        [Display(Name = "درصد")]
        public float Precent { get; set; }
    }
}
