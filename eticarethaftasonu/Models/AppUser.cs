﻿using Microsoft.AspNetCore.Identity;

namespace eticarethaftasonu.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string City { get; set; }
        public int ConfirmCode { get; set; }    


    }
}
