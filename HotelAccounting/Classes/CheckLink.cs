namespace HotelAccounting.Classes;

public class CheckLink
{
    public static string CheckCorrectLink(string link) =>
       link.Length > 8 && link.StartsWith("https://") || link.StartsWith("http://") ? link : "https://www.kindpng.com/picc/m/52-526072_unknown-character-hd-png-download.png";
}