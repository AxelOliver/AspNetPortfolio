using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public class MyPortfolioContext : DbContext
    {
        public MyPortfolioContext(DbContextOptions<MyPortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Stubby> Stubby { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user1 = new ApplicationUser { Id = "1", Email = "test@gmail.com", PasswordHash = "123", UserName = "TestUsername"};
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = "1", Email = "user1@gmail.com", PasswordHash = "123", UserName = "User1" },
                new ApplicationUser { Id = "2", Email = "user2@gmail.com", PasswordHash = "123", UserName = "User2" }
            );
            modelBuilder.Entity<Stubby>().HasData(
                new Stubby { Id = 1, ApplicationUserId = "1", OriginalLink = "www.google.com", ShortenedLink = "stubby.google" },
                new Stubby { Id = 2, ApplicationUserId = "1", OriginalLink = "www.facebook.com", ShortenedLink = "stubby.facebook" },
                new Stubby { Id = 3, ApplicationUserId = "2", OriginalLink = "www.test.com", ShortenedLink = "stubby.test" }
            );
        }
    }
}
