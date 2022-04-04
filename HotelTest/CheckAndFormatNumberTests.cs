using Xunit;
using HotelAccounting.Classes;
using System.Linq;

namespace HotelTest
{
    public class CheckNumberTests
    {
        CheckAndFormatNumber checkAndFormatNumber = new CheckAndFormatNumber();

        [Fact]
        public void CheckBadNumber1()
        {

            var actual = checkAndFormatNumber.CheckNumber("123", out string str);
            Assert.Equal(false, actual);
        }

        [Fact]
        public void CheckBadNumber2()
        {
            var actual = checkAndFormatNumber.CheckNumber("lo34567", out string str);
            Assert.Equal(false, actual);
        }

        [Fact]
        public void CheckBadNumber3()
        {
            var actual = checkAndFormatNumber.CheckNumber("889955", out string str);
            Assert.Equal(false, actual);
        }

        [Fact]
        public void CheckBadNumber4()
        {
            var actual = checkAndFormatNumber.CheckNumber("gsdfse", out string str);
            Assert.Equal(false, actual);
        }

        [Fact]
        public void CheckBadNumber5()
        {
            var actual = checkAndFormatNumber.CheckNumber(".554...", out string str);
            Assert.Equal(false, actual);
        }

        [Fact]
        public void CheckGoodNumber1()
        {
            var actual = checkAndFormatNumber.CheckNumber("60890202273", out string str);
            Assert.Equal(true, actual);
        }

        [Fact]
        public void CheckGoodNumber2()
        {
            var actual = checkAndFormatNumber.CheckNumber("97478110693", out string str);
            Assert.Equal(true, actual);
        }

        [Fact]
        public void CheckGoodNumber3()
        {
            var actual = checkAndFormatNumber.CheckNumber("11890679212", out string str);
            Assert.Equal(true, actual);
        }

        [Fact]
        public void CheckGoodNumber4()
        {
            var actual = checkAndFormatNumber.CheckNumber(" 291481042248 ", out string str);
            Assert.Equal(true, actual);
        }

        [Fact]
        public void CheckGoodNumber5()
        {
            var actual = checkAndFormatNumber.CheckNumber("+75051652925", out string str);
            Assert.Equal(true, actual);
        }
    }
    public class FormatNumberTests
    {
        CheckAndFormatNumber checkAndFormatNumber = new CheckAndFormatNumber();

        private string correctFormatStringNumber(string number) => new string(number.Where(char.IsDigit).ToArray());

        [Fact]
        public void CheckNumber1()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber("253376893481"), out string str);

            Assert.Equal("+25 337 689-34-81", str);
        }
        [Fact]
        public void CheckNumber2()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber(" +25337689-34-81  "), out string str);
            Assert.Equal("+25 337 689-34-81", str);
        }
        [Fact]
        public void CheckNumber3()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber("+2(53376893481"), out string str);
            Assert.Equal("+25 337 689-34-81", str);
        }
        [Fact]
        public void CheckNumber4()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber("38045954023"), out string str);
            Assert.Equal("+3 804 595-40-23", str);
        }
        [Fact]
        public void CheckNumber5()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber("+38045954023    "), out string str);
            Assert.Equal("+3 804 595-40-23", str);
        }
        [Fact]
        public void CheckNumber6()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber("3 8 0 4 5 9 5 4 0 2 3 "), out string str);
            Assert.Equal("+3 804 595-40-23", str);
        }
        [Fact]
        public void CheckNumber7()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber("-3-8-04-5-9-5-4-0-23"), out string str);
            Assert.Equal("+3 804 595-40-23", str);
        }
        [Fact]
        public void CheckNumber8()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber("75051652925"), out string str);
            Assert.Equal("+7 505 165-29-25", str);
        }
        [Fact]
        public void CheckNumber9()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber("  +7505-1652925"), out string str);
            Assert.Equal("+7 505 165-29-25", str);
        }

        [Fact]
        public void CheckNumber10()
        {
            checkAndFormatNumber.CheckNumber(correctFormatStringNumber("75051 6529ООО25"), out string str);
            Assert.Equal("+7 505 165-29-25", str);
        }
    }
}
