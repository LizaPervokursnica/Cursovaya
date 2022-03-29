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
}
