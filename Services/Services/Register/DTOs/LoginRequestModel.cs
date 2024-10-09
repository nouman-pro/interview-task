using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Register.DTOs
{
    public class LoginRequestModel
    {
        [Phone(ErrorMessage = "Invalid mobile number format.")]
        public string? Mobile { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }

        [Range(1000, 9999, ErrorMessage = "Pin must be a 4-digit number.")]
        public int? Pin { get; set; }
    }
}
