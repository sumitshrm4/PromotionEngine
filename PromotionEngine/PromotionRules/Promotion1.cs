using PromotionEngine.Helper;
using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine.PromotionRules
{
    public class Promotion1
    {
        // n SKU's for Fixed price 
        public SkuOrder Apply(string SkuKey, SkuOrder skuOrder)
        {
            int numberOfItemRequired = -1;
            int priceInPromotion = -1;
            int fixedPriceForSku = -1;

            int count = skuOrder.Skus.GetValueOrDefault(SkuKey, 0);

            switch (SkuKey)
            {
                case "A":
                    numberOfItemRequired = 3;
                    priceInPromotion = 130;
                    fixedPriceForSku = EngineHelper.GetFixedPriceForSku("A");
                    break;
                case "B":
                    numberOfItemRequired = 2;
                    priceInPromotion = 45;
                    fixedPriceForSku = EngineHelper.GetFixedPriceForSku("B");
                    break;
            }

            while (count >= numberOfItemRequired)
            {
                skuOrder.Cost += priceInPromotion;
                count -= numberOfItemRequired;
            }

            if (count > 0)
            {
                skuOrder.Cost += fixedPriceForSku * count;
            }

            skuOrder.Skus.Remove(SkuKey);

            return skuOrder;
        }
    }
}
