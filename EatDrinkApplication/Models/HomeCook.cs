using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.Models
{
    public class HomeCook
    {
        public int HomeCookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


    }
}
