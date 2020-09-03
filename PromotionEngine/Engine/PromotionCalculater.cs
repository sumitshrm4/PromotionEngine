using PromotionEngine.Helper;
using PromotionEngine.Models;
using PromotionEngine.PromotionRules;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Engine
{
    public class PromotionCalculater : IPromotionCalculater
    {
        public double GetPromotionalPrice(Dictionary<string, int> skus)
        {
            SkuOrder skuOrder = new SkuOrder(skus, 0);

            skuOrder = new Promotion1().Apply("A", skuOrder);

            skuOrder = new Promotion1().Apply("B", skuOrder);

            skuOrder = new Promotion2().Apply("C", "D", skuOrder);

            if (skus.Any())
            {
                skuOrder.Cost += EngineHelper.GetDefaultPricingForSkus(skus);
            }

            return skuOrder.Cost;
        }
    }
}
