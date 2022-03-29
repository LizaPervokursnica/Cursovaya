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
            optionsBuilder.UseNpgsql("Host=ec2-34-247-151-118.eu-west-1.compute.amazonaws.com;Port=5432;Database=dtdknmk08fn21;Username=zhaunvowrjulfy;Password=6435b82d6dda58b665420c1c7c3585a8dcf612afa5a60f8d6429452bc7a59704");

    }
}
