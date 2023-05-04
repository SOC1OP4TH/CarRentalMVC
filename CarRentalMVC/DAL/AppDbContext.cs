using CarRentalMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMVC.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }


    
    }
}
