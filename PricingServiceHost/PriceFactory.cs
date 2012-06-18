using System;
using System.Collections.Generic;

namespace PricingServiceHost
{
    public class PriceFactory
    {
        /*
        * AUD = Australian dollars
        * BRL = Brazilian realis
        * GBP = English sterling
        * INR = Indian rupees
        * EUR = Euros
        * CAD = Canadian dollars
        * NZD = New Zealand dollars
        * ZAR = South African rand
        * JPY = Japanese Yen
        * THB = Thai Baht
        * CNY = Chinese Yuan
        * CHF = Swiss Francs
        */
        public readonly List<FxRate> FxBaseRates = new List<FxRate>
        {
            new FxRate() { IsoCode = "AUD", Rate = (decimal) 0.93272, Updated = DateTime.Today },
            new FxRate() { IsoCode = "BRL", Rate = (decimal) 0.63371, Updated = DateTime.Today },
            new FxRate() { IsoCode = "GBP", Rate = (decimal) 0.60819, Updated = DateTime.Today },
            new FxRate() { IsoCode = "INR", Rate = (decimal) 44.6300, Updated = DateTime.Today },
            new FxRate() { IsoCode = "EUR", Rate = (decimal) 0.68103, Updated = DateTime.Today },
            new FxRate() { IsoCode = "CAD", Rate = (decimal) 0.97495, Updated = DateTime.Today },
            new FxRate() { IsoCode = "NZD", Rate = (decimal) 1.21847, Updated = DateTime.Today },
            new FxRate() { IsoCode = "ZAR", Rate = (decimal) 6.71610, Updated = DateTime.Today },
            new FxRate() { IsoCode = "JPY", Rate = (decimal) 80.0032, Updated = DateTime.Today },
            new FxRate() { IsoCode = "THB", Rate = (decimal) 0.03303, Updated = DateTime.Today },
            new FxRate() { IsoCode = "CNY", Rate = (decimal) 0.15425, Updated = DateTime.Today },
            new FxRate() { IsoCode = "RUB", Rate = (decimal) 27.7411, Updated = DateTime.Today },
            new FxRate() { IsoCode = "CHF", Rate = (decimal) 0.83603, Updated = DateTime.Today }
        };

        public FxRate GetNextPrice()
        {
            Random random = new Random();
            var countryIndex = random.Next(FxBaseRates.Count);
            var fxRate = FxBaseRates[countryIndex];

            Random randomChange = new Random();
            decimal change = randomChange.Next(-5, 5);
            // price only changes (up or down) by up to one percent 
            decimal changePercentage = 1 + (change / 100);
            fxRate.Rate = Math.Round(fxRate.Rate * changePercentage, 5);
            fxRate.Updated = DateTime.Now;

            return fxRate;
        }
    }
}
