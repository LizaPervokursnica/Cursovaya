using Microsoft.EntityFrameworkCore;
using System;

namespace HotelAccounting
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
        //public string ConectionString() => Environment.GetEnvironmentVariable();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseNpgsql("");

    }
}
