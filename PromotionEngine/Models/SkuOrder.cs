using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class SkuOrder
    {
        private double promotionalPrice;

        public SkuOrder()
        {
        }

        public SkuOrder(Dictionary<string, int> skus, double promotionalPrice)
        {
            Skus = skus;
            this.promotionalPrice = promotionalPrice;
        }

        public Dictionary<string, int> Skus { get; set; }
        public double Cost { get; set; }
    }
}
