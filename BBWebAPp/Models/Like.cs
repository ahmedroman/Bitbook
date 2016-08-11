using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBWebAPp.Models
{
    public class Like
    {
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string PersonName { get; set; }

    }
}