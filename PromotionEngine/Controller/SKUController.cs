using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Engine;
using System.Collections.Generic;

namespace PromotionEngine.Controller
{
    [Controller]
    public class SKUController
    {
        [HttpGet("GetSkuPricesWithPromotions")]
        public double GetSkuPricesWithPromotions(Dictionary<string, int> skus)
        {
            return new PromotionCalculater().GetPromotionalPrice(skus);
        }
    }
}
