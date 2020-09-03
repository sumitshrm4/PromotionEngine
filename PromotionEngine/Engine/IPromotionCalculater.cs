using System.Collections.Generic;

namespace PromotionEngine.Engine
{
    public interface IPromotionCalculater
    {
        double GetPromotionalPrice(Dictionary<string, int> skus);
    }
}