using GalaSoft.MvvmLight.Ioc;

namespace MetroPricingSample.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IPricingService, Design.DesignPricingService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IPricingService, PricingServiceClient>();
            //}

            SimpleIoc.Default.Register<PricingViewModel>();
            // Ensure VM
            var vm = SimpleIoc.Default.GetInstance<PricingViewModel>();
            
        }

        public PricingViewModel PricingViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<PricingViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
