using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
