using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JQueryDemo.Models
{
    public class StudentModel
    {
        public int ID { get; set; }

        [Display(Name = "Student Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }

        [Display(Name = "Total Marks")]
        [Required]
        public decimal? TotalMarks { get; set; }

        [Display(Name = "Birth Date")]
        [Required]
        public DateTime? BirthDate { get; set; }
    }
}