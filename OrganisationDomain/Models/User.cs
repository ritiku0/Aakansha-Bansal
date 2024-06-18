﻿using System;

namespace Organisation.Domain.Models
{
    public class User : DomainObject
    {
        public string Username { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }       
    }
}
