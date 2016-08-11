using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBWebAPp.Models
{
    public class Person
    {
        public int? Id { get; set; }

        [Required(ErrorMessage="Name can't be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Password length must be 5 to 10 character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [Compare("Password")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Password length must be 5 to 10 character")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Select your gender")]
        public string Gender { get; set; }

        public string Address { get; set; }
        public string School { get; set; }
        public string Relationship { get; set; }
        public string Work { get; set; }
        public string Hobby { get; set; }
        public string Language { get; set; }
    }
}