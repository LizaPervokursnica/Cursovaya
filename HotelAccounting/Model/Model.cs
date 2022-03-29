using System;

namespace HotelAccounting
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }

    public class Room
    {
        public int Id { get; set; }
        public string Equipment { get; set; }
        public string Photo { get; set; }
        public int RoomNumber { get; set; }
        public string NameOfRoom { get; set; }

        public Guest Guest { get; set; }
        public int? GuestId { get; set; }
    }

    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public string? Photo { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
    }
}
