using Microsoft.EntityFrameworkCore;
using System;

namespace HotelAccounting.DataAccess
{
    public class HotelDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("POPIT_CONNECTION_STRING");

            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }


            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
