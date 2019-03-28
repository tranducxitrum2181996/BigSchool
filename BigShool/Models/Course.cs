using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigShool.Models
{
    public class Course
    {
        public int Id { get; set; }
        public ApplicationUser LecturerId { get; set; }
        [Required]
        [stringLength(255)]
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public Category Category { get; set; }
        [Required]
        public byte CategoryId { get; set; }

    }
   
}