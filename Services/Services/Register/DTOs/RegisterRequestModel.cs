using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Register.DTOs
{
    public class RegisterRequestModel
    {
       
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }  

        [Required(ErrorMessage = "IC Number is required.")]
        public string IcNumber { get; set; } 

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid mobile number format.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pin is required.")]
        [Range(1000, 9999, ErrorMessage = "Pin must be a 4-digit number.")]
        public int Pin { get; set; }

        [Required(ErrorMessage = "Confirm Pin is required.")]
        [Range(1000, 9999, ErrorMessage = "Confirm Pin must be a 4-digit number.")]
        [Compare("Pin", ErrorMessage = "Confirm Pin must match the Pin.")]
        public int? ConfirmPin { get; set; }
    }
}
