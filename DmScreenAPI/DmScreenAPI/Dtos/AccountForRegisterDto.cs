using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Dtos
{
    public class AccountForRegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Your password must be at least 8 characters.")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
