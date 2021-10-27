using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessLayer.Utilities
{
    public class Students 
    {
        // <summary>
        // Database Entity properties for Students Data
        // <summary>

        [Key]
        public int Id { get; set; }

        //Regular expression to accept only alphabets as input
        [Required(ErrorMessage = "Please provide First Name")]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z]+[\s]*$",ErrorMessage = "Please Enter Valid First Name")]
        public string FirstName { get; set; }

        //Regular expression to accept only alphabets as input
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z]+[\s]*$",ErrorMessage = "Please Enter Valid Last Name")]
        public string LastName { get; set; }


        //Regular expression to accept Phone Number only starting with +92,0092,0,3,03.
        [Required(ErrorMessage = "Please provide ContactInfo")]
        [RegularExpression(@"^((\+92)?(0092)?(92)?(0)?)(3)([0-9]{9})$",ErrorMessage = "Please Enter Valid Phone Number")]
        public string ContactInfo { get; set; }

        //Regular expression to accept only alphabets as input
        [Required(ErrorMessage = "Please provide Department")]
        [MaxLength(20)]
        [RegularExpression(@"^[A-Za-z]+[\s]*$",ErrorMessage = "Please Enter Valid Department")]
        public string Department { get; set; }


        //Regular expression to accept only male or female as input
        [Required(ErrorMessage = "Please provide Gender")]
        [MaxLength(10)]
        [RegularExpression(@"(?i)\b(male|female)\b",ErrorMessage = "Please Enter Valid Gender")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Please provide Address")]
        [MaxLength(100)]
        public string Address { get; set; }


        [Column(TypeName = "float")]
        public float CGPA { get; set; }

    }
}
