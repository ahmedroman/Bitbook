using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBWebAPp.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public string CommentDesc { get; set; }
        public int StatusId { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public DateTime Date { get; set; }
    }
}