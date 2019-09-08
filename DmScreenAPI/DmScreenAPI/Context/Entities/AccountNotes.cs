using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Context.Entities
{
    public class AccountNotes
    {
        public int AccountNotesId { get; set; }
        public int AccountId { get; set; }
        public string Notes { get; set; }
    }
}
