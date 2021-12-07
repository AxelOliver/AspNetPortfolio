using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models
{
    public class Stubby
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [Required]
        public string OriginalLink { get; set; }
        public string ShortenedLink { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }
}
