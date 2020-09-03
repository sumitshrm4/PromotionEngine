using System.Collections.Generic;

namespace PromotionEngine.Helper
{
    public static class EngineHelper
    {
        public static int GetDefaultPricingForSkus(Dictionary<string, int> skus)
        {
            int totalPrice = 0;

            foreach (var sku in skus)
            {
                totalPrice += sku.Value * GetFixedPriceForSku(sku.Key);
            }

            return totalPrice;
        }

        public static int GetFixedPriceForSku(string key)
        {
            int currentSkuPrice = 0;

            switch (key)
            {
                case "A":
                    currentSkuPrice = 50;
                    break;
                case "B":
                    currentSkuPrice = 30;
                    break;
                case "C":
                    currentSkuPrice = 20;
                    break;
                case "D":
                    currentSkuPrice = 15;
                    break;
            }

            return currentSkuPrice;
        }
    }
}
