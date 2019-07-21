using CacheProperties.Estimations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CacheProperties.Helpers
{
    public static class CacheEstimationsController
    {
        //public delegate T GetValue<T>(out T property);
        //public static string GetStrVal(this string property)
        //{
        //    if (property != FedEstimation.NotEstimatedYet)
        //    {
        //        property = Calculate
        //    }

        //    re
        //}

        public static bool isStrCalculated(this string property)
        {
            if (property != FedEstimation.NotEstimatedStringYet)
            {
                return true;
            }

            return false;
        }
    }
}
