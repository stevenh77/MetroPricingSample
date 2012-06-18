using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MetroPricingSample.ServiceReference1;

namespace MetroPricingSample.Design
{
    public class DesignPricingService : IPricingService
    {
        public IAsyncResult BeginSubscribe(AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndSubscribe(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUnSubscribe(AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUnSubscribe(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }

    public class DesignPricingCallbackService : IPricingServiceCallback
    {
        public void PriceUpdate(FxRate fxRate)
        {
            throw new NotImplementedException();
        }
    }
}
