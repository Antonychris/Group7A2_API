using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group7A2_API.Controllers.Models
{
    public class Comment
    {
        private DateTime _date = DateTime.Now;

        public  int CommentId { get; set; }

        [Required]
        public  string Content { get; set; }

        public  int PostId { get; set; }

        public  Post Post { get; set; }

        public  string Author { get; set; }

        //Set PostTime dafault value.
        public DateTime PostTime
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
