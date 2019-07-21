using CacheProperties.Estimations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CacheProperties.Helpers
{
    public static class CacheEstimationsController
    {
        /// <summary>
        /// Returns method value as an object.
        /// </summary>
        public static object GetMethodVal(object objRef, string methodName)
        {
            Type type = objRef.GetType();
            MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            return method.Invoke(objRef, null);
        }
    }
}
