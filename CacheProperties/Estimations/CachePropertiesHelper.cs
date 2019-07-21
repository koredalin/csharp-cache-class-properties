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

        /// <summary>
        /// Throws an exception if not appropriate property type used.
        /// </summary>
        /// <param name="propertyType"></param>
        /// <param name="neededType"></param>
        /// <param name="methodName"></param>
        public static void ThrowWrongTypePropertyException(string propertyType, string neededType, string methodName)
        {
            if (!propertyType.Contains(neededType))
            {
                throw new Exception(methodName + "(). Not supported type of property.");
            }
        }
    }
}
