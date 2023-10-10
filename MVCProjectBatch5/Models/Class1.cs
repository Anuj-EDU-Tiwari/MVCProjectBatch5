using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProjectBatch5.Models
{
    public class Class1
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Hello enter your name please")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Hello enter your email please")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hello enter your mobile please")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Hello enter your address please")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Hello enter your salary please")]
        public int? Sal { get; set; }
        [Required(ErrorMessage = "Hello enter your zipcode please")]
        public int? Zipcode { get; set; }
    }
}