using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Engine
{
    public class PromotionCalculater
    {
        bool isPromotionApplied = false;

        public int GetPromotionalPrice(Dictionary<string, int> skus)
        {
            int promotionalPrice = 0;

            promotionalPrice += ApplyPromotionRule1("A", skus);
            skus.Remove("A");

            promotionalPrice += ApplyPromotionRule1("B", skus);
            skus.Remove("B");

            promotionalPrice += ApplyPromotionRule2("C", "D", skus);
            skus.Remove("C");
            skus.Remove("D");

            if (skus.Any())
            {
                promotionalPrice += GetDefaultPricingForSkus(skus);
            }

            return promotionalPrice;
        }


        private int GetDefaultPricingForSkus(Dictionary<string, int> skus)
        {
            int totalPrice = 0;

            foreach (var sku in skus)
            {
                totalPrice += sku.Value * GetFixedPriceForSku(sku.Key);
            }

            return totalPrice;
        }

        private int GetFixedPriceForSku(string key)
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

        // n SKU's for Fixed price 
        private int ApplyPromotionRule1(string SkuKey, Dictionary<string, int> skus)
        {
            int promotionalPrice = 0;
            int numberOfItemRequired = -1;
            int priceInPromotion = -1;
            int fixedPriceForSku = -1;

            int count = skus.GetValueOrDefault(SkuKey, 0);

            switch (SkuKey)
            {
                case "A":
                    numberOfItemRequired = 3;
                    priceInPromotion = 130;
                    fixedPriceForSku = GetFixedPriceForSku("A");
                    break;
                case "B":
                    numberOfItemRequired = 2;
                    priceInPromotion = 45;
                    fixedPriceForSku = GetFixedPriceForSku("B");
                    break;
            }

            while (count >= numberOfItemRequired)
            {
                promotionalPrice += priceInPromotion;
                count -= numberOfItemRequired;

                // set promotion applied to true, so that no other promotion will apply
                isPromotionApplied = true;
            }

            if (count > 0)
            {
                promotionalPrice += fixedPriceForSku * count;
            }

            return promotionalPrice;
        }


        // Buy SKU1 and SKU2 for Fixed price
        private int ApplyPromotionRule2(string SkuKey1, string SkuKey2, Dictionary<string, int> skus)
        {

            int countSku1 = skus.GetValueOrDefault(SkuKey1, 0);
            int countSku2 = skus.GetValueOrDefault(SkuKey2, 0);

            int promotionalPrice = 0;
            int fixedPriceForSku1 = GetFixedPriceForSku(SkuKey1);
            int fixedPriceForSku2 = GetFixedPriceForSku(SkuKey2);

            while (countSku1 > 0 && countSku2 > 0)
            {
                promotionalPrice += 30; // ToDo : get this from settings
                countSku1--;
                countSku2--;

                // set promotion applied to true, so that no other promotion will apply
                isPromotionApplied = true;
            }

            if (countSku1 > 0)
            {
                promotionalPrice = (fixedPriceForSku1 * countSku1);
            }
            if (countSku2 > 0)
            {
                promotionalPrice = (fixedPriceForSku2 * countSku2);
            }

            return promotionalPrice;
        }
    }
}
