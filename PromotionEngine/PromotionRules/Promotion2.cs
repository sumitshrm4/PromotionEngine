using PromotionEngine.Helper;
using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine.PromotionRules
{
    public class Promotion2
    {
        // Buy SKU1 and SKU2 for Fixed price
        public SkuOrder Apply(string SkuKey1, string SkuKey2, SkuOrder skuOrder)
        {
            int countSku1 = skuOrder.Skus.GetValueOrDefault(SkuKey1, 0);
            int countSku2 = skuOrder.Skus.GetValueOrDefault(SkuKey2, 0);

            int fixedPriceForSku1 = EngineHelper.GetFixedPriceForSku(SkuKey1);
            int fixedPriceForSku2 = EngineHelper.GetFixedPriceForSku(SkuKey2);

            while (countSku1 > 0 && countSku2 > 0)
            {
                skuOrder.Cost += 30; // ToDo : get this from settings
                countSku1--;
                countSku2--;
            }

            skuOrder.Cost += countSku1 > 0 ? (fixedPriceForSku1 * countSku1) : 0;

            skuOrder.Cost += countSku2 > 0 ? (fixedPriceForSku2 * countSku2) : 0;

            skuOrder.Skus.Remove(SkuKey1);
            skuOrder.Skus.Remove(SkuKey2);

            return skuOrder;
        }
    }
}
