using HotelAccounting.Classes;
using Xunit;

namespace HotelTest
{
    public class CheckLinks
    {
        public string defaultPhoto = "https://www.kindpng.com/picc/m/52-526072_unknown-character-hd-png-download.png";

        [Fact]
        public void CheckBagLink1()
        {
            var badLink = "http:/g";
            var actual = CheckLink.CheckCorrectLink(badLink);
            Assert.Equal(defaultPhoto, actual);
        }

        [Fact]
        public void CheckBagLink2()
        {
            var badLink = "https:/aaa.png";
            var actual = CheckLink.CheckCorrectLink(badLink);
            Assert.Equal(defaultPhoto, actual);
        }

        [Fact]
        public void CheckBagLink3()
        {
            var badLink = "http:/\'";
            var actual = CheckLink.CheckCorrectLink(badLink);
            Assert.Equal(defaultPhoto, actual);
        }

        [Fact]
        public void CheckBagLink4()
        {
            var badLink = "htps://i.pinimg.com/736x/5f/c3/44/5fc3449b654a9281bd66b1b67ec7a2c4.jpg";
            var actual = CheckLink.CheckCorrectLink(badLink);
            Assert.Equal(defaultPhoto, actual);
        }

        [Fact]
        public void CheckBagLink5()
        {
            var badLink = ("https:/i.pinimg.com/736x/5f/c3/44/5fc3449b654a9281bd66b1b67ec7a2c4.jpg'");
            var actual = CheckLink.CheckCorrectLink(badLink);
            Assert.Equal(defaultPhoto, actual);
        }

        [Fact]
        public void CheckGoodLink1()
        {
            var goodLink = "https://i.pinimg.com/736x/5f/c3/44/5fc3449b654a9281bd66b1b67ec7a2c4.jpg";
            var actual = CheckLink.CheckCorrectLink(goodLink);
            Assert.Equal(goodLink, actual);
        }


        [Fact]
        public void CheckGoodLink2()
        {
            var goodLink = "https://i.ytimg.com/vi/a9IP9sC4GzY/maxresdefault.jpg";
            var actual = CheckLink.CheckCorrectLink(goodLink);
            Assert.Equal(goodLink, actual);
        }

        [Fact]
        public void CheckGoodLink3()
        {
            var goodLink = "https://i.ytimg.com/vi/X1anBKL_xJI/maxresdefault.jpg";
            var actual = CheckLink.CheckCorrectLink(goodLink);
            Assert.Equal(goodLink, actual);
        }

        [Fact]
        public void CheckGoodLink4()
        {
            var goodLink = "http://www.vokrug.tv/pic/person/4/c/6/b/4c6b47d58bb94933d422b9bfeb08940a.jpg";
            var actual = CheckLink.CheckCorrectLink(goodLink);
            Assert.Equal(goodLink, actual);
        }

        [Fact]
        public void CheckGoodLink5()
        {
            var goodLink = "https://www.peoples.ru/art/music/pop/dora/sishOeRFyh90K.jpeg";
            var actual = CheckLink.CheckCorrectLink(goodLink);
            Assert.Equal(goodLink, actual);
        }
    }
}
