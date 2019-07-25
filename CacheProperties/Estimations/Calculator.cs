using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CacheProperties.Estimations
{
    public class Calculator
    {
        public static readonly string OutputPropertyPrefix = "Out";
        public static readonly string CalculateMethodPrefix = "Calculate";

        public static readonly string NotEstimatedStringYet = "NotEstimatedStringYet";
        public static readonly int? NotEstimatedIntYet = null;
        public static readonly decimal? NotEstimatedDecimalYet = null;
        public static readonly bool? NotEstimatedBoolYet = null;

        public static readonly string DefaultString = "";
        public static readonly int DefaultInt = 0;
        public static readonly decimal DefaultDecimal = 0m;
        public static readonly bool DefaultBool = false;

        private static readonly string StringTypeDef = "System.String";
        private static readonly string IntTypeDef = "System.Int";
        private static readonly string DecimalTypeDef = "System.Decimal";
        private static readonly string BoolTypeDef = "System.Bool";

        /*******************************************************************************/

        #region Estimated Class Properties
        public static List<string> OutZeroValues = new List<string>();
        public string OutA1 { get; private set; } = NotEstimatedStringYet;
        public string OutA2 { get; private set; } = NotEstimatedStringYet;
        public string OutA3 { get; private set; } = NotEstimatedStringYet;
        public string OutA4 { get; private set; } = NotEstimatedStringYet;
        public string OutA5 { get; private set; } = NotEstimatedStringYet;
        public string OutA6 { get; private set; } = NotEstimatedStringYet;
        public string OutA7 { get; private set; } = NotEstimatedStringYet;
        public string OutA8 { get; private set; } = NotEstimatedStringYet;
        public string OutA9 { get; private set; } = NotEstimatedStringYet;
        public int? OutB1 { get; private set; } = NotEstimatedIntYet;
        public int? OutB2 { get; private set; } = NotEstimatedIntYet;
        public int? OutB3 { get; private set; } = NotEstimatedIntYet;
        public int? OutB4 { get; private set; } = NotEstimatedIntYet;
        public int? OutB5 { get; private set; } = NotEstimatedIntYet;
        public int? OutB6 { get; private set; } = NotEstimatedIntYet;
        public int? OutB7 { get; private set; } = NotEstimatedIntYet;
        public int? OutB8 { get; private set; } = NotEstimatedIntYet;
        public int? OutB9 { get; private set; } = NotEstimatedIntYet;
        public decimal? OutC1 { get; private set; } = NotEstimatedDecimalYet;
        public decimal? OutC2 { get; private set; } = NotEstimatedDecimalYet;
        public decimal? OutC3 { get; private set; } = NotEstimatedDecimalYet;
        public decimal? OutC4 { get; private set; } = NotEstimatedDecimalYet;
        public decimal? OutC5 { get; private set; } = NotEstimatedDecimalYet;
        public decimal? OutC6 { get; private set; } = NotEstimatedDecimalYet;
        public decimal? OutC7 { get; private set; } = NotEstimatedDecimalYet;
        public decimal? OutC8 { get; private set; } = NotEstimatedDecimalYet;
        public decimal? OutC9 { get; private set; } = NotEstimatedDecimalYet;
        public bool? OutD1 { get; private set; } = NotEstimatedBoolYet;
        public bool? OutD2 { get; private set; } = NotEstimatedBoolYet;
        public bool? OutD3 { get; private set; } = NotEstimatedBoolYet;
        public bool? OutD4 { get; private set; } = NotEstimatedBoolYet;
        public bool? OutD5 { get; private set; } = NotEstimatedBoolYet;
        public bool? OutD6 { get; private set; } = NotEstimatedBoolYet;
        public bool? OutD7 { get; private set; } = NotEstimatedBoolYet;
        public bool? OutD8 { get; private set; } = NotEstimatedBoolYet;
        public bool? OutD9 { get; private set; } = NotEstimatedBoolYet;
        #endregion

        /********************************************************************************************/

        /// <summary>
        /// Class Constructor
        /// </summary>
        public Calculator()
        {

        }

        /********************************************************************************************/

        #region General Helpers
        /// <summary>
        /// Returns property value as an object.
        /// </summary>
        private object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        /// <summary>
        /// Get Property Type as String.
        /// </summary>
        private string GetPropertyType(string propertyName)
        {
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);
            string propertyType = this.GetType().GetProperty(propertyName).PropertyType.ToString();
            return propertyType;
        }

        private string GetCalcMethodName(string outputPropertyName)
        {
            return CalculateMethodPrefix + outputPropertyName;
        }

        /// <summary>
        /// Returns method value as an object.
        /// </summary>
        private object GetMethodVal(string methodName)
        {
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            return method.Invoke(this, null);
        }

        /// <summary>
        /// Throws an exception if not appropriate property type used.
        /// </summary>
        private void ThrowWrongTypePropertyException(string classPropName, string propertyType, string neededType, string methodName)
        {
            if (!propertyType.Contains(neededType))
            {
                throw new Exception(methodName + "(" + classPropName + "). Not supported type of property.");
            }
        }

        private string GetStrPropName(StrProperties property)
        {
            return OutputPropertyPrefix + Enum.GetName(typeof(StrProperties), property);
        }
        private string GetIntPropName(IntProperties property)
        {
            return OutputPropertyPrefix + Enum.GetName(typeof(IntProperties), property);
        }
        private string GetDecimalPropName(DecimalProperties property)
        {
            return OutputPropertyPrefix + Enum.GetName(typeof(DecimalProperties), property);
        }
        private string GetBoolPropName(BoolProperties property)
        {
            return OutputPropertyPrefix + Enum.GetName(typeof(BoolProperties), property);
        }
        #endregion

        /********************************************************************************************/

        #region General Functionalities
        public void CalculateAll()
        {
            foreach (StrProperties classProp in (StrProperties[]) Enum.GetValues(typeof(StrProperties)))
            {
                GetStrVal(classProp);
            };
            foreach (IntProperties classProp in (IntProperties[])Enum.GetValues(typeof(IntProperties)))
            {
                GetIntVal(classProp);
            };
            foreach (DecimalProperties classProp in (DecimalProperties[])Enum.GetValues(typeof(DecimalProperties)))
            {
                GetDecimalVal(classProp);
            };
            foreach (BoolProperties classProp in (BoolProperties[])Enum.GetValues(typeof(BoolProperties)))
            {
                GetBoolVal(classProp);
            };
        }

        /// <summary>
        /// this.OutZeroValues
        /// Clears all properties names, which values are different than zero.
        /// </summary>
        public void ClearOutputNotZeros()
        {
            foreach (IntProperties classProp in (IntProperties[])Enum.GetValues(typeof(IntProperties)))
            {
                if (GetIntVal(classProp) != 0)
                {
                    OutZeroValues.Remove(GetIntPropName(classProp));
                }
            };
            foreach (DecimalProperties classProp in (DecimalProperties[])Enum.GetValues(typeof(DecimalProperties)))
            {
                if (GetDecimalVal(classProp) != 0)
                {
                    OutZeroValues.Remove(GetDecimalPropName(classProp));
                }
            };
        }
        #endregion

        /********************************************************************************************/

        #region Get (Set value if not estimated) values with general types
        public string GetStrVal(StrProperties strEnumId)
        {
            string classPropName = GetStrPropName(strEnumId);
            string propertyType = GetPropertyType(classPropName);
            ThrowWrongTypePropertyException(classPropName, propertyType, StringTypeDef, "GetStrVal");
            string val = (string)this[classPropName];
            if (val != NotEstimatedStringYet)
            {
                return val;
            }
            string classMethod = GetCalcMethodName(Enum.GetName(typeof(StrProperties), strEnumId));
            string result = (string)GetMethodVal(classMethod);
            return result;
        }

        public int GetIntVal(IntProperties intEnumId)
        {
            string classPropName = GetIntPropName(intEnumId);
            string propertyType = GetPropertyType(classPropName);
            ThrowWrongTypePropertyException(classPropName, propertyType, IntTypeDef, "GetIntVal");
            int? val = (int?)this[classPropName];
            int result;
            if (val != NotEstimatedIntYet)
            {
                result = (int)val;
                return result;
            }
            string classMethod = GetCalcMethodName(Enum.GetName(typeof(IntProperties), intEnumId));
            result = (int)GetMethodVal(classMethod);
            return result;
        }

        public decimal GetDecimalVal(DecimalProperties decimalEnumId)
        {
            string classPropName = GetDecimalPropName(decimalEnumId);
            string propertyType = GetPropertyType(classPropName);
            ThrowWrongTypePropertyException(classPropName, propertyType, DecimalTypeDef, "GetDecVal");
            decimal? val = (decimal?)this[classPropName];
            decimal result;
            if (val != NotEstimatedDecimalYet)
            {
                result = (decimal)val;
                return result;
            }
            string classMethod = GetCalcMethodName(Enum.GetName(typeof(DecimalProperties), decimalEnumId));
            result = (decimal)GetMethodVal(classMethod);
            return result;
        }

        public bool GetBoolVal(BoolProperties boolEnumId)
        {
            string classPropName = GetBoolPropName(boolEnumId);
            string propertyType = GetPropertyType(classPropName);
            ThrowWrongTypePropertyException(classPropName, propertyType, BoolTypeDef, "GetBoolVal");
            bool? val = (bool?)this[classPropName];
            bool result;
            if (val != NotEstimatedBoolYet)
            {
                result = (bool)val;
                return result;
            }
            string classMethod = GetCalcMethodName(Enum.GetName(typeof(BoolProperties), boolEnumId));
            result = (bool)GetMethodVal(classMethod);
            return result;
        }
        #endregion

        /********************************************************************************************/

        #region String Calculate Methods
        private string CalculateA1()
        {
            string result = "A1 String.";
            return OutA1 = result ?? DefaultString;
        }
        private string CalculateA2()
        {
            string result = "A2 String.";
            return OutA2 = result ?? DefaultString;
        }
        private string CalculateA3()
        {
            string result = "A3 String.";
            return OutA3 = result ?? DefaultString;
        }
        private string CalculateA4()
        {
            string result = "A4 String.";
            if (GetBoolVal(BoolProperties.D2)) {
                result = OutA4 = GetStrVal(StrProperties.A2) + " "
                    + GetStrVal(StrProperties.A3);
                return result ?? DefaultString;
            }
            return OutA4 = result ?? DefaultString;
        }
        private string CalculateA5()
        {
            string result = "A5 String.";
            return OutA5 = result ?? DefaultString;
        }
        private string CalculateA6()
        {
            string result = "A6 String.";
            return OutA6 = result ?? DefaultString;
        }
        private string CalculateA7()
        {
            string result = "A7 String.";
            return OutA7 = result ?? DefaultString;
        }
        private string CalculateA8()
        {
            string result = "A8 String.";
            return OutA8 = result ?? DefaultString;
        }
        private string CalculateA9()
        {
            string result = "A9 String.";
            return OutA9 = result ?? DefaultString;
        }
        #endregion

        /********************************************************************************************/

        #region Integer Calculate Methods
        private int? CalculateB1()
        {
            int? result = 1;
            return OutB1 = result ?? DefaultInt;
        }
        private int? CalculateB2()
        {
            int? result = 2;
            return OutB2 = result ?? DefaultInt;
        }
        private int? CalculateB3()
        {
            int? result = GetIntVal(IntProperties.B1);
            result += GetIntVal(IntProperties.B2);
            OutZeroValues.Add(GetIntPropName(IntProperties.B3));
            return OutB3 = result ?? DefaultInt;
        }
        private int? CalculateB4()
        {
            OutZeroValues.Add(GetIntPropName(IntProperties.B4));
            int? result = 0;
            return OutB4 = result ?? DefaultInt;
        }
        private int? CalculateB5()
        {
            int? result = GetIntVal(IntProperties.B3) + GetIntVal(IntProperties.B4);
            return OutB5 = result ?? DefaultInt;
        }
        private int? CalculateB6()
        {
            int? result = GetIntVal(IntProperties.B4);
            if (result == 0)
            {
                OutZeroValues.Add(GetIntPropName(IntProperties.B6));
            }
            return OutB6 = result ?? DefaultInt;
        }
        private int? CalculateB7()
        {
            OutZeroValues.Add(GetIntPropName(IntProperties.B7));
            int? result = 7;
            return OutB7 = result ?? DefaultInt;
        }
        private int? CalculateB8()
        {
            int b8MaxVal = 5;
            int? result;
            if (GetIntVal(IntProperties.B7) > b8MaxVal)
            {
                if (OutZeroValues.Contains(GetIntPropName(IntProperties.B7)))
                {
                    OutZeroValues.Add(GetIntPropName(IntProperties.B8));
                }
                result = b8MaxVal;
                return OutB8 = result ?? DefaultInt;
            }
            result = 8;
            return OutB8 = result ?? DefaultInt;
        }
        private int? CalculateB9()
        {
            int? result = 9;
            return OutB9 = result ?? DefaultInt;
        }
        #endregion

        /********************************************************************************************/

        #region Decimal Calculate Methods
        private decimal? CalculateC1()
        {
            decimal? result = 1.1m;
            return OutC1 = result ?? DefaultDecimal;
        }
        private decimal? CalculateC2()
        {
            OutC3 = 3.3m;
            OutC4 = 4.4m;
            decimal? result = 2.2m;
            return OutC2 = result ?? DefaultDecimal;
        }
        private decimal? CalculateC3()
        {
            GetDecimalVal(DecimalProperties.C2);
            return OutC3;
        }
        private decimal? CalculateC4()
        {
            GetDecimalVal(DecimalProperties.C2);
            return OutC4;
        }
        private decimal? CalculateC5()
        {
            decimal? result = 5.5m;
            return OutC5 = result ?? DefaultDecimal;
        }
        private decimal? CalculateC6()
        {
            decimal? result = 6.6m;
            return OutC6 = result ?? DefaultDecimal;
        }
        private decimal? CalculateC7()
        {
            decimal? result = 7.7m;
            return OutC7 = result ?? DefaultDecimal;
        }
        private decimal? CalculateC8()
        {
            decimal? result = 8.8m;
            return OutC8 = result ?? DefaultDecimal;
        }
        private decimal? CalculateC9()
        {
            decimal? result = 9.9m;
            return OutC9 = result ?? DefaultDecimal;
        }
        #endregion

        /********************************************************************************************/

        #region Bool Calculate Methods
        private bool? CalculateD1()
        {
            bool? result = false;
            return OutD1 = result ?? DefaultBool;
        }
        private bool? CalculateD2()
        {
            bool? result = true;
            return OutD2 = result ?? DefaultBool;
        }
        private bool? CalculateD3()
        {
            bool? result = true;
            return OutD3 = result ?? DefaultBool;
        }
        private bool? CalculateD4()
        {
            bool? result = true;
            return OutD4 = result ?? DefaultBool;
        }
        private bool? CalculateD5()
        {
            bool? result = false;
            return OutD5 = result ?? DefaultBool;
        }
        private bool? CalculateD6()
        {
            bool? result = false;
            if (GetIntVal(IntProperties.B4) + GetDecimalVal(DecimalProperties.C4) > 66)
            {
                result = true;
                return OutD6 = result ?? DefaultBool;
            }
            return OutD6 = result ?? DefaultBool;
        }
        private bool? CalculateD7()
        {
            bool? result = true;
            return OutD7 = result ?? DefaultBool;
        }
        private bool? CalculateD8()
        {
            bool? result = false;
            return OutD8 = result ?? DefaultBool;
        }
        private bool? CalculateD9()
        {
            bool? result = false;
            return OutD9 = result ?? DefaultBool;
        }
        #endregion

        /********************************************************************************************/
    }
}
