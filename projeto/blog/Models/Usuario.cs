using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace blog.Models
{
    public class Usuario :  IdentityUser
    {
        public DateTime? UltimoLogin { get; set; } 
        public IList<Post> Posts { get; set; }
    }
}