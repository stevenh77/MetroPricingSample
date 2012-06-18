using System;
using System.Runtime.Serialization;

namespace PricingServiceHost
{
    [DataContract] public class FxRate
    {
        [DataMember] public string IsoCode { get; set; }
        [DataMember] public decimal Rate { get; set; }
        [DataMember] public DateTime Updated { get; set; }
    }
}
