using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CacheProperties.Helpers;

namespace CacheProperties.Estimations
{
    public class FedEstimation
    {
        public static readonly string NotEstimatedStringYet = "NotEstimatedYet";
        public static readonly int? NotEstimatedIntYet = null;
        public static readonly decimal? NotEstimatedDecimalYet = null;
        public static readonly bool? NotEstimatedBoolYet = null;

        public delegate string CalcStringMethod();

        public string FedOutA1 { get; private set; } = NotEstimatedStringYet;
        public string FedOutA2 { get; private set; } = NotEstimatedStringYet;
        public string FedOutA3 { get; private set; } = NotEstimatedStringYet;
        public string FedOutA4 { get; private set; } = NotEstimatedStringYet;
        public string FedOutA5 { get; private set; } = NotEstimatedStringYet;
        public string FedOutA6 { get; private set; } = NotEstimatedStringYet;
        public string FedOutA7 { get; private set; } = NotEstimatedStringYet;
        public string FedOutA8 { get; private set; } = NotEstimatedStringYet;
        public string FedOutA9 { get; private set; } = NotEstimatedStringYet;
        public int? FedOutB1 { get; private set; }
        public int? FedOutB2 { get; private set; }
        public int? FedOutB3 { get; private set; }
        public int? FedOutB4 { get; private set; }
        public int? FedOutB5 { get; private set; }
        public int? FedOutB6 { get; private set; }
        public int? FedOutB7 { get; private set; }
        public int? FedOutB8 { get; private set; }
        public int? FedOutB9 { get; private set; }
        public decimal? FedOutC1 { get; private set; }
        public decimal? FedOutC2 { get; private set; }
        public decimal? FedOutC3 { get; private set; }
        public decimal? FedOutC4 { get; private set; }
        public decimal? FedOutC5 { get; private set; }
        public decimal? FedOutC6 { get; private set; }
        public decimal? FedOutC7 { get; private set; }
        public decimal? FedOutC8 { get; private set; }
        public decimal? FedOutC9 { get; private set; }
        public bool? FedOutD1 { get; private set; }
        public bool? FedOutD2 { get; private set; }
        public bool? FedOutD3 { get; private set; }
        public bool? FedOutD4 { get; private set; }
        public bool? FedOutD5 { get; private set; }
        public bool? FedOutD6 { get; private set; }
        public bool? FedOutD7 { get; private set; }
        public bool? FedOutD8 { get; private set; }
        public bool? FedOutD9 { get; private set; }


        public FedEstimation()
        {
        }

        /// <summary>
        /// Returns property value as an object.
        /// </summary>
        private object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
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

        public void CalculateAll()
        {
            foreach (string classPropName in FedProperties.AllProperties["StrProperties"])
            {
                GetStrVal(classPropName);
            };
            foreach (string classPropName in FedProperties.AllProperties["IntProperties"])
            {
                GetIntVal(classPropName);
            };
            foreach (string classPropName in FedProperties.AllProperties["DecimalProperties"])
            {
                GetDecVal(classPropName);
            };
            foreach (string classPropName in FedProperties.AllProperties["BoolProperties"])
            {
                GetBoolVal(classPropName);
            };
        }

        public string GetStrVal(string classPropName)
        {
            string classMethod = "Calculate" + classPropName.Replace("FedOut", "");
            var propertyType = this.GetType().GetProperty(classPropName).PropertyType.ToString();
            if (!propertyType.Contains("System.String"))
            {
                throw new Exception("GetStrVal(). Not supported type of property.");
            }
            string val = (string)this[classPropName];
            if (val != NotEstimatedStringYet)
            {
                return val;
            }
            string result = (string)GetMethodVal(classMethod);
            this[classPropName] = result;
            return result;
        }

        public int GetIntVal(string classPropName)
        {
            string classMethod = "Calculate" + classPropName.Replace("FedOut", "");
            string propertyType = this.GetType().GetProperty(classPropName).PropertyType.ToString();
            if (!propertyType.Contains("System.Int"))
            {
                throw new Exception("GetIntVal(). Not supported type of property.");
            }
            int? val = (int?)this[classPropName];
            int result;
            if (val != NotEstimatedIntYet)
            {
                result = (int)val;
                return result;
            }
            result = (int)GetMethodVal(classMethod);
            this[classPropName] = result;
            return result;
        }

        public decimal GetDecVal(string classPropName)
        {
            string classMethod = "Calculate" + classPropName.Replace("FedOut", "");
            string propertyType = this.GetType().GetProperty(classPropName).PropertyType.ToString();
            if (!propertyType.Contains("System.Decimal"))
            {
                throw new Exception("GetDecimalVal(). Not supported type of property.");
            }
            decimal? val = (decimal?)this[classPropName];
            decimal result;
            if (val != NotEstimatedDecimalYet)
            {
                result = (decimal)val;
                return result;
            }
            result = (decimal)GetMethodVal(classMethod);
            this[classPropName] = result;
            return result;
        }

        public bool GetBoolVal(string classPropName)
        {
            string classMethod = "Calculate" + classPropName.Replace("FedOut", "");
            string propertyType = this.GetType().GetProperty(classPropName).PropertyType.ToString();
            if (!propertyType.Contains("System.Bool"))
            {
                throw new Exception("GetBoolVal(). Not supported type of property.");
            }
            bool? val = (bool?)this[classPropName];
            bool result;
            if (val != NotEstimatedBoolYet)
            {
                result = (bool)val;
                return result;
            }
            result = (bool)GetMethodVal(classMethod);
            this[classPropName] = result;
            return result;
        }

        private string CalculateA1()
        {
            return "A1 Calculated.";
        }
        private string CalculateA2() { return "A2 Start 1"; }
        private string CalculateA3() { return "Start"; }
        private string CalculateA4() { return "Start"; }
        private string CalculateA5() { return "Bash Majstora"; }
        private string CalculateA6() { return "Start"; }
        private string CalculateA7() { return "Start"; }
        private string CalculateA8() { return "Start"; }
        private string CalculateA9() { return "Start"; }
        private int CalculateB1() { return 11; }
        private int CalculateB2() { return 22; }
        private int CalculateB3()
        {
            int result = GetIntVal("FedOutB1");
            result += GetIntVal("FedOutB2");
            return result;
        }

        private int CalculateB4() { return 0; }
        private int CalculateB5() { return 0; }
        private int CalculateB6() { return 0; }
        private int CalculateB7() { return 0; }
        private int CalculateB8() { return 0; }
        private int CalculateB9() { return 0; }
        private decimal CalculateC1() { return 0; }
        private decimal CalculateC2() { return 0; }
        private decimal CalculateC3() { return 22; }
        private decimal CalculateC4() { return 0; }
        private decimal CalculateC5() { return 0; }
        private decimal CalculateC6() { return 0; }
        private decimal CalculateC7() { return 0; }
        private decimal CalculateC8() { return 0; }
        private decimal CalculateC9() { return 0; }
        private bool CalculateD1() { return false; }
        private bool CalculateD2() { return false; }
        private bool CalculateD3() { return false; }
        private bool CalculateD4() { return true; }
        private bool CalculateD5() { return false; }
        private bool CalculateD6() { return false; }
        private bool CalculateD7() { return true; }
        private bool CalculateD8() { return false; }
        private bool CalculateD9() { return false; }
    }
}
