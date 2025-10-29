using OrderBinSizingWebApi.Domain.Models;

namespace Domain.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 94)]
        [TestCase(4, 94)]
        [TestCase(5, 188)]
        [TestCase(9, 282)]
        public void RequiredBinWidth_ReturnsCorrectWidth(int quantity, float expected)
        {
            var mug = new Mug();
            var result = mug.RequiredBinWidth(quantity);
            Assert.AreEqual(expected, result);
        }
    }
}