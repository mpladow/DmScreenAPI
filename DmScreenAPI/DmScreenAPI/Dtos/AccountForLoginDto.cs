﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Dtos
{
    public class AccountForLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
