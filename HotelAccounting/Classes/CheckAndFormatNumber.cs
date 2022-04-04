using System.Linq;
using System.Text.RegularExpressions;

namespace HotelAccounting.Classes
{
    public class CheckAndFormatNumber
    {
        public string FormatNumber(string number)
        {
            return number.Length switch
            {
                7 => new Regex("(...)(..)(..)").Replace(number, "$1-$2-$3"),
                11 => new Regex("(.)(...)(...)(..)(..)").Replace(number, "+$1 $2 $3-$4-$5"),
                12 => new Regex("(..)(...)(...)(..)(..)").Replace(number, "+$1 $2 $3-$4-$5"),
                13 => new Regex("(...)(...)(...)(..)(..)").Replace(number, "+$1 $2 $3-$4-$5"),
                _ => number
            };
        }

        public bool CheckNumber(string number, out string formatedNumber)
        {
            string onlyDigitNumber = new string(number.Where(char.IsDigit).ToArray());
                if (long.TryParse(onlyDigitNumber, out long result) && onlyDigitNumber[0] == '8' && onlyDigitNumber.Length == 11)
                {
                    formatedNumber = FormatNumber("7" + onlyDigitNumber.Substring(1));
                    return true;
                }
                else if (onlyDigitNumber.Length >= 7 && long.TryParse(onlyDigitNumber, out long result2))
                {
                    formatedNumber = FormatNumber(onlyDigitNumber);
                    return true;
                }
                else
                {
                    formatedNumber = string.Empty;
                    return false;
                }
        }
    }
}
