using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyStarsApp.Controllers;
using MyStarsApp.Models;

namespace MyStarsApp.Data
{
    public class MYStarAppDBContext : DbContext
    {
        public MYStarAppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CustomersViewModel>CustomersInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<CustomersViewModel>().HasKey(c=>c.CustomerId);
        }

        internal object FindUser(CustomersInfo myuser)
        {
            throw new NotImplementedException();
        }

    }
}
