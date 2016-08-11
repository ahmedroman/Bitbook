using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBWebAPp.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Staus can't be empty")]
        public string Post { get; set; }
        public DateTime Date { get; set; }
        public int? PersonId { get; set; }
        public string PersonName { get; set; }
    }
}