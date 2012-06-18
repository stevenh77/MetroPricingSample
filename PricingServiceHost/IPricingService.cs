using System;
using System.ServiceModel;

namespace PricingServiceHost
{
    [ServiceContract(CallbackContract=typeof(IPricingServiceCallback))]
    public interface IPricingService
    {
        [OperationContract(IsOneWay = true)]
        void Subscribe();

        [OperationContract(IsOneWay = true)]
        void UnSubscribe();
    }

    public interface IPricingServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        [ServiceKnownType("GetKnownServiceTypes", typeof(ServiceKnownTypeGetter))]
        void PriceUpdate(FxRate fxRate);
    }
}
