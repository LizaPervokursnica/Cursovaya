using Xunit;
using HotelAccounting.Classes;

namespace HotelTest
{
    public class CheckAuth
    {
        [Fact]
        public void CheckAuthTrue1()
        {
            var actual = Authorization.CheckLogAndPass("admin1", "admin1");
            Assert.Equal("true", actual);
        }

        [Fact]
        public void CheckAuthTrue2()
        {
            var actual = Authorization.CheckLogAndPass("  admin1", "       admin1 ");
            Assert.Equal("true", actual);
        }

        [Fact]
        public void CheckAuthTrue3()
        {
            var actual = Authorization.CheckLogAndPass(" admin1     ", "       admin1   ");
            Assert.Equal("true", actual);
        }

        [Fact]
        public void CheckAuthTrue4()
        {
            var actual = Authorization.CheckLogAndPass("admin1", "admin1 ");
            Assert.Equal("true", actual);
        }

        [Fact]
        public void CheckAuthTrue5()
        {
            var actual = Authorization.CheckLogAndPass(" admin1", "admin1");
            Assert.Equal("true", actual);
        }

        [Fact]
        public void CheckAuthFalse1()
        {
            var actual = Authorization.CheckLogAndPass("aDmin1", "ADmin1");
            Assert.Equal("false", actual);
        }

        [Fact]
        public void CheckAuthFalse2()
        {
            var actual = Authorization.CheckLogAndPass("ADMIN1", "ADMIN1");
            Assert.Equal("false", actual);
        }

        [Fact]
        public void CheckAuthFalse3()
        {
            var actual = Authorization.CheckLogAndPass("AdMIN1", "ADMIn1");
            Assert.Equal("false", actual);
        }

        [Fact]
        public void CheckAuthFalse4()
        {
            var actual = Authorization.CheckLogAndPass("aDmin1_", "admin1");
            Assert.Equal("false", actual);
        }

        [Fact]
        public void CheckAuthFalse5()
        {
            var actual = Authorization.CheckLogAndPass("admin1", "admln1");
            Assert.Equal("false", actual);
        }
    }
}