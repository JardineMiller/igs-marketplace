using System;

namespace marketplace.Features.Products.Helpers
{
    public static class ProductPriceHelpers
    {
        public static decimal RoundToTwoPlaces(decimal price)
        {
            return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
        }
    }
}
