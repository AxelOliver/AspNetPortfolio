using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models
{
    public class StubbyUserViewModel
    {
        public IdentityUser User { get; set; }
        public List<Stubby> Stubbies { get; set; }
    }
}
