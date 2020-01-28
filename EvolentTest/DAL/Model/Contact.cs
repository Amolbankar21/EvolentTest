using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EvolentTest.Filter;
using EvolentTest.Utility;
//using FluentValidation.Attributes;

namespace EvolentTest.DAL.Model
{
    //[Validator(typeof(ValidatorActionFilter))]
    public class Contact
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage = Constants.FirstNameRequired)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = Constants.LastNameRequired)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = Constants.EmailRequired)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = Constants.PhoneNumberRequired)]
        public string PhoneNumber { get; set; }

        public bool Status { get; set; }

    }
}

