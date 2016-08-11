using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBWebAPp.Models
{
    public class ProfilePic
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public byte[] Pic { get; set; }
        public int? Personid { get; set; }
    }
}