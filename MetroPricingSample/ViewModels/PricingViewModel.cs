using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MetroPricingSample.Models;
using MetroPricingSample.ServiceReference1;

namespace MetroPricingSample.ViewModels
{
    public class PricingViewModel : ViewModelBase
    {
        public ObservableCollection<DisplayFxRate> Rates { get; set; }

        private const string SubscribedPropertyName = "Subscribed";
        private bool _subscribed = false;
        
        public bool Subscribed
        {
            get { return _subscribed; }

            set
            {
                if (_subscribed == value)
                {
                    return;
                }

                _subscribed = value;
                RaisePropertyChanged(SubscribedPropertyName);
            }
        }
        
        private const string ErrorTextPropertyName = "ErrorText";
        private string _errorText = string.Empty;

        public string ErrorText
        {
            get { return _errorText; }

            set
            {
                if (_errorText == value)
                {
                    return;
                }

                _errorText = value;
                RaisePropertyChanged(ErrorTextPropertyName);
            }
        }
    

        public ICommand SubscriptionCommand { get; set; }

        private bool _subscriptionCommand_CanExecute = true;

        private PricingServiceClient _client;

        public PricingViewModel()
        {
            Rates = DisplayFxRate.InitialRates;

            if (IsInDesignMode) return;

            _client = new PricingServiceClient();
            _client.SubscribeCompleted += _client_SubscribeCompleted;
            _client.UnSubscribeCompleted += _client_UnSubscribeCompleted;
            _client.PriceUpdateReceived += PriceUpdate;
            SubscriptionCommand = new RelayCommand(SubscriptionCommand_Execute, () => _subscriptionCommand_CanExecute);
        }

        void SubscriptionCommand_Execute()
        {
            if (!Subscribed)
            {
                _client.SubscribeAsync();
            }
            else
            {
                _client.UnSubscribeAsync();
            }

            _subscriptionCommand_CanExecute = false;
        }
        
        void _client_UnSubscribeCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Subscribed = false;
                ErrorText = "";
            }
            else
            {
                ErrorText = "Unable to connect to service.";
            }

            _subscriptionCommand_CanExecute = true;
        }

        void _client_SubscribeCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Subscribed = true;
                ErrorText = "";
            }
            else
            {
                ErrorText = "Unable to connect to service.";
            }

            _subscriptionCommand_CanExecute = true;
        }

        public void PriceUpdate(object sender, PriceUpdateReceivedEventArgs e)
        {
            if (Subscribed)
            {
                PriceUpdate(e.fxRate);
            }
        }

        public void PriceUpdate(FxRate fxRate)
        {
            try
            {
                foreach (var rate in Rates.Where(rate => rate.IsoCode == fxRate.IsoCode))
                {
                    rate.CurrentRate = fxRate.Rate;
                    rate.Updated = fxRate.Updated;
                }

            }
            catch (Exception e)
            {
                //log here
            }

        }
    }

    
}
