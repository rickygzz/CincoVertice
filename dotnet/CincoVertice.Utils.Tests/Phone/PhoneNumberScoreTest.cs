using VerticeLib.Utils.Phone;
using Xunit;

namespace CincoVertice.Utils.Tests.Phone
{
    public class PhoneNumberScoreTest
    {
        [Fact]
        public void Score()
        {
            var a = new PhoneNumberScore(@"B:\Comercio\Ventas\_PhoneRules.xlsx");

            a.LoadPhones(@"B:\Comercio\Ventas\_Phone2023.xlsx");

            Assert.Equal("8125974788", a.PhonesList[0].Phone);

            foreach (PhoneModel model in a.PhonesList)
            {
                a.Score(model);
            }

            //Assert.Equal(10, a.PhonesList[0].Score);

            a.Save(@"B:\Comercio\Ventas\_Phone2023_result.xlsx");
        }

        [Theory]
        [InlineData("10", 1)]
        [InlineData("1010", 2)]
        [InlineData("1985", 5)]
        [InlineData("19851985", 10)]
        public void Scores(string phone, int expectedScore)
        {
            var a = new PhoneNumberScore(@"B:\Comercio\Ventas\_PhoneRules.xlsx");

            var model = new PhoneModel()
            {
                Phone = phone,
                Batch = "A"
            };

            a.Score(model);

            Assert.Equal(expectedScore, model.Score);
        }
    }
}
