using Moq;
using NUnit.Framework;
using PromotionEngine.Engine;
using System.Collections.Generic;

namespace PromotionEngine.Tests
{
    [TestFixture]
    public class PromotionCalculaterTests
    {
        //ivate MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
           //his.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private PromotionCalculater CreatePromotionCalculater()
        {
            return new PromotionCalculater();
        }

        [Test]
        public void GetPromotionalPrice_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var promotionCalculater = this.CreatePromotionCalculater();
            Dictionary<string, int> skus = new Dictionary<string, int>();
            skus.Add("A", 1);
            skus.Add("B", 1);
            skus.Add("C", 1);

            // Act
            var result = promotionCalculater.GetPromotionalPrice(
                skus);

            // Assert
            Assert.AreEqual(100, result);
        }
    }
}
