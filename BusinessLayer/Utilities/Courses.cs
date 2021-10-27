using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessLayer.Utilities
{
    public class Courses
    {
        // <summary>
        // Database Entity properties for Course Data
        // <summary>

        [Key]
        public int CourseId { get; set; }

        [Required]
        [Range(1,3,ErrorMessage ="Credit Hours should be between 1 and 3")]
        public int CreditHours { get; set; }


        //Regular expression to accept only alphabets as input
        [Required(ErrorMessage = "Please provide Course Name")]
        [MaxLength(20)]
        [RegularExpression(@"^[A-Za-z]+[\s]*$", ErrorMessage = "Please Enter Valid Course Name")]
        public string CourseName { get; set; }


        [Range(1, 4, ErrorMessage = "Grade Points should be between 1 and 4")]
        [Column(TypeName ="float")]
        public float GradePoint { get; set; }


        [ForeignKey("Students")]
        public int StudentId { get; set; }

        //Navigational property of Students class
        public Students Students { get; set; }
    }
}
