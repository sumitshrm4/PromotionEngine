using NUnit.Framework;
using PromotionEngine.Engine;
using System.Collections.Generic;

namespace PromotionEngine.Test
{
    [TestFixture]
    public class PromotionCalculaterTests
    {

        [SetUp]
        public void SetUp()
        { }

        private PromotionCalculater CreatePromotionCalculater()
        {
            return new PromotionCalculater();
        }

        [Test]
        public void GetPromotionalPrice_Scenario1()
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

        [Test]
        public void GerPromotionalPrice_Scenario2()
        {
            // Arrange
            var promotionCalculater = this.CreatePromotionCalculater();
            Dictionary<string, int> skus = new Dictionary<string, int>();
            skus.Add("A", 5);
            skus.Add("B", 5);
            skus.Add("C", 1);

            // Act
            var result = promotionCalculater.GetPromotionalPrice(
                skus);

            // Assert
            Assert.AreEqual(370, result);
        }

        [Test]
        public void GerPromotionalPrice_Scenario3()
        {
            // Arrange
            var promotionCalculater = this.CreatePromotionCalculater();
            Dictionary<string, int> skus = new Dictionary<string, int>();
            skus.Add("A", 3);
            skus.Add("B", 5);
            skus.Add("C", 1);
            skus.Add("D", 1);

            // Act
            var result = promotionCalculater.GetPromotionalPrice(
                skus);

            // Assert
            Assert.AreEqual(280, result);
        }
    }
}