using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace PricingServiceHost
{
    public static class ServiceKnownTypeGetter
    {
        public static List<Type> GetKnownServiceTypes(ICustomAttributeProvider provider)
        {
            var knownTypes = new List<Type>();
            var modelAssembly = typeof(FxRate).Assembly;

            //Iterate through types
            foreach (var type in modelAssembly.GetTypes())
            {
                //This is a short way of checking to see if a type has a DataContractAttribute (can be passed across WCF)
                if (type.GetCustomAttributes(true).Where(attribute => attribute is DataContractAttribute).ToList().Count > 0)
                {
                    knownTypes.Add(type);
                }
            }

            return knownTypes;
        }
    }
}
