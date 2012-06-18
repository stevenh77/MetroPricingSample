using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace MetroPricingSample.Models
{
    public class DisplayFxRate : ObservableObject
    {
        public static ObservableCollection<DisplayFxRate> InitialRates = new ObservableCollection<DisplayFxRate>
            {
                new DisplayFxRate("AUD", (decimal) 0.93272),
                new DisplayFxRate("BRL", (decimal) 1.58100),
                new DisplayFxRate("CAD", (decimal) 0.97495),
                new DisplayFxRate("CHF", (decimal) 0.83603),
                new DisplayFxRate("CNY", (decimal) 0.15425),
                new DisplayFxRate("EUR", (decimal) 0.68103),
                new DisplayFxRate("GBP", (decimal) 0.60819),
                new DisplayFxRate("INR", (decimal) 44.6300),
                new DisplayFxRate("JPY", (decimal) 80.0032),
                new DisplayFxRate("NZD", (decimal) 1.21847),
                new DisplayFxRate("RUB", (decimal) 27.7411),
                new DisplayFxRate("THB", (decimal) 0.03303),
                new DisplayFxRate("ZAR", (decimal) 6.71610)
            };

        public DisplayFxRate() { }

        public DisplayFxRate(string isoCode, decimal rate)
        {
            IsoCode = isoCode;
            PreviousRate = rate;
            CurrentRate = rate;
            Updated = DateTime.Now;
        }

        public const string IsoCodePropertyName = "IsoCode";
        private string _isoCode = string.Empty;
        public string IsoCode
        {
            get
            {
                return _isoCode;
            }

            set
            {
                if (_isoCode == value)
                {
                    return;
                }

                _isoCode = value;
                RaisePropertyChanged(IsoCodePropertyName);
            }
        }

        public const string PreviousRatePropertyName = "PreviousRate";
        private decimal _previousRate = 0;
        public decimal PreviousRate
        {
            get
            {
                return _previousRate;
            }

            set
            {
                if (_previousRate == value)
                {
                    return;
                }

                _previousRate = value;
                RaisePropertyChanged(PreviousRatePropertyName);
            }
        }

        public const string CurrentRatePropertyName = "CurrentRate";
        private decimal _currentRate = 0;
        public decimal CurrentRate
        {
            get
            {
                return _currentRate;
            }

            set
            {
                if (_currentRate == value)
                {
                    return;
                }

                _previousRate = _currentRate;
                _currentRate = value;

                RaisePropertyChanged(PreviousRatePropertyName);
                RaisePropertyChanged(CurrentRatePropertyName);
                RaisePropertyChanged(DeltaPropertyName);
                RaisePropertyChanged(StatusPropertyName);
            }
        }


        public const string DeltaPropertyName = "Delta";
        public decimal Delta
        {
            get
            {
                decimal result;
                
                if (PreviousRate == 0 || CurrentRate == 0)
                    result = 0;
                else
                    result = Math.Round(((CurrentRate / PreviousRate) - 1), 2);

                return result;
            }
        }

        public const string StatusPropertyName = "Status";
        public Status Status
        {
            get
            {
                Status status;
                var delta = Delta;

                if (delta > 0)
                    status = Status.Increase;
                else if (delta < 0)
                    status = Status.Decrease;
                else
                    status = Status.NoChange;

                return status;
            }
        }

        public const string UpdatedPropertyName = "Updated";
        private DateTime _updated = DateTime.MinValue;
        public DateTime Updated
        {
            get
            {
                return _updated;
            }

            set
            {
                if (_updated == value)
                {
                    return;
                }

                _updated = value;
                RaisePropertyChanged(UpdatedPropertyName);
            }
        }

    }
}