using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mayibookabook.Models
{
    public class person
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string contact { get; set; }

    }
    public class book
    {
        public long ID { get; set; }

        [Required]
        [Display(Name = "书名")]
        public string title { get; set; }

        [Display(Name = "作者")]
        public string author { get; set; }
        [Required]
        [Display(Name = "出版社")]
        public string press { get; set; }
        [Display(Name = "借书者学号")]
        public int borrowerID { get; set; }
        [Display(Name = "借书者联系方式")]
        public string borrowercontact { get; set; }
        [Display(Name = "借书者姓名")]
        public string borrowername { get; set; }
        [Display(Name = "出借者学号")]
        public int lenderID { get; set; }
        [Display(Name = "出借者联系方式")]
        public string lendercontact { get; set; }
        [Display(Name = "出借者姓名")]
        public string lendername { get; set; }



    }
}