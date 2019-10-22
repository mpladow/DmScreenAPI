using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Services
{
    public class UtilitiesService
    {
        public void AutoMap<T>(ref T to, dynamic from, bool forceMatchNullables = true)
        {
            var fromProperties = from.GetType().GetProperties();
            var toProperties = to.GetType().GetProperties();
            foreach (var toProperty in toProperties)
            {
                foreach (var fromProperty in fromProperties)
                {
                    if (fromProperty.Name == toProperty.Name && (forceMatchNullables ? MatchTypesNullables(fromProperty.PropertyType, toProperty.PropertyType) : toProperty.PropertyType == fromProperty.PropertyType))
                    {
                        to.GetType().GetProperty(fromProperty.Name).SetValue(to, fromProperty.GetValue(from));
                    }
                }
            }
        }

        static bool MatchTypesNullables(Type from, Type to)
        {
            bool result = false;
            if (Nullable.GetUnderlyingType(from) != null)
            {
                from = Nullable.GetUnderlyingType(from);
            }
            if (Nullable.GetUnderlyingType(to) != null)
            {
                to = Nullable.GetUnderlyingType(to);
            }
            if (from == to)
            {
                result = true;
            }
            return result;
        }

    }
}
