namespace HotelAccounting;

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