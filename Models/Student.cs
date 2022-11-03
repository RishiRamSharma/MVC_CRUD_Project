using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace MVCnewProject.Models
{
    public class Student
    { 
        public int Id { get; set; }
        [Required(ErrorMessage ="Student name is required!")]
        [Display(Name="Student's Name ")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Student's Address")]
        public string Address { get; set; }
        [Display(Name = "Student's Age")]
        [Required]
        [Range(18,27, ErrorMessage ="Age must be between 18 - 27!")]
        public int Age { get; set; }
        [Display(Name = "Student's Email")]
        [Required]
        [EmailAddress]
        
        public string Email { get; set; }
    }
}