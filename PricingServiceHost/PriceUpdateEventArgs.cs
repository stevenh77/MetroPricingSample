using System;

namespace PricingServiceHost
{
    public class PriceUpdateEventArgs : EventArgs
    {
        public FxRate LatestPrice { get; set; }
    }
}
