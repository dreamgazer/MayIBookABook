using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mayibookabook.Models
{
    public class borrowerinfo
    {
        [Required]
        [Display(Name = "学号")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "联系方式")]
        public string contact { get; set; }
        [Required]
        [Display(Name = "姓名")]
        public string name { get; set; }
    }
}