using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace PricingServiceHost
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class PricingService : IPricingService
    {
        static PricingService()
        {
            Task.Factory.StartNew(() =>
                {
                    var factory = new PriceFactory();
                    while (true)
                    {
                        Thread.Sleep(50);
                        if (PriceUpdate == null) continue;
                        FxRate latestPrice = factory.GetNextPrice();

                        PriceUpdate(
                            null,
                            new PriceUpdateEventArgs
                                {
                                    LatestPrice = latestPrice
                                });
                    }
                });
        }

        static event EventHandler<PriceUpdateEventArgs> PriceUpdate;

        IPricingServiceCallback _callback;

        public void Subscribe()
        {
            _callback = OperationContext.Current.GetCallbackChannel<IPricingServiceCallback>();
            PriceUpdate += PricingService_PriceUpdate;
        }

        public void UnSubscribe()
        {
            PriceUpdate -= PricingService_PriceUpdate;
        }

        void PricingService_PriceUpdate(object sender, PriceUpdateEventArgs e)
        {
            if (((ICommunicationObject)_callback).State == CommunicationState.Opened)
            {
                try
                {
                    _callback.PriceUpdate(e.LatestPrice);
                }
                catch
                {
                    UnSubscribe();
                }
            }
            else
            {
                UnSubscribe();
            }
        }
    }
}
