namespace HotelAccounting.Classes
{
    public class CheckLink
    {
        public static string CheckCorrectLink(string link) => 
           link.Length > 8 && (link.Substring(0, 8) == "https://" || link.Substring(0, 7) == "http://") ? link : "https://www.pngitem.com/pimgs/m/52-526033_unknown-person-icon-png-transparent-png.png";
    }
}
