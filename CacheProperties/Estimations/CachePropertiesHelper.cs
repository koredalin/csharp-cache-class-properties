using CacheProperties.Estimations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CacheProperties.Estimations
{
    public static class CachePropertiesHelper
    {
        /// <summary>
        /// Returns method value as an object.
        /// </summary>
        public static object GetMethodVal(in object objRef, string methodName)
        {
            Type type = objRef.GetType();
            MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            return method.Invoke(objRef, null);
        }

        /// <summary>
        /// Get Property Type as String.
        /// </summary>
        public static string GetPropertyType(in object objRef, string propertyName)
        {
            Type type = objRef.GetType();
            MethodInfo method = type.GetMethod(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);
            string propertyType = objRef.GetType().GetProperty(propertyName).PropertyType.ToString();
            return propertyType;
        }
    }
}
