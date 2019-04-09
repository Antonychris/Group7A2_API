using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group7A2_API.Controllers.Models
{
    public class Post
    {
        private DateTime _date = DateTime.Now;

        public  int PostId { get; set; }
        [Required]
        public  String Subject { get; set; }

        [Required(ErrorMessage = "Give us more details about your topic.")]
        public  String Content { get; set; }

        public  int CategoryId { get; set; }

        public  Category Category { get; set; }

        public  String Author { get; set; }

        //Set PostTime dafault value.
        public DateTime PostTime
        {
            get { return _date; }
            set { _date = value; }
        }

        //A post may has zero or more comments
        public  List<Comment> Comments { get; set; }
    }
}
