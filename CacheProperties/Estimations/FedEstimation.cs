﻿using System;
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
        public int? OutB1 { get; private set; }
        public int? OutB2 { get; private set; }
        public int? OutB3 { get; private set; }
        public int? OutB4 { get; private set; }
        public int? OutB5 { get; private set; }
        public int? OutB6 { get; private set; }
        public int? OutB7 { get; private set; }
        public int? OutB8 { get; private set; }
        public int? OutB9 { get; private set; }
        public decimal? OutC1 { get; private set; }
        public decimal? OutC2 { get; private set; }
        public decimal? OutC3 { get; private set; }
        public decimal? OutC4 { get; private set; }
        public decimal? OutC5 { get; private set; }
        public decimal? OutC6 { get; private set; }
        public decimal? OutC7 { get; private set; }
        public decimal? OutC8 { get; private set; }
        public decimal? OutC9 { get; private set; }
        public bool? OutD1 { get; private set; }
        public bool? OutD2 { get; private set; }
        public bool? OutD3 { get; private set; }
        public bool? OutD4 { get; private set; }
        public bool? OutD5 { get; private set; }
        public bool? OutD6 { get; private set; }
        public bool? OutD7 { get; private set; }
        public bool? OutD8 { get; private set; }
        public bool? OutD9 { get; private set; }


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
        //private object GetMethodVal(string methodName)
        //{
        //    Type type = this.GetType();
        //    MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        //    return method.Invoke(this, null);
        //}

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

        public void ClearNotZeroValues()
        {
            foreach (string classPropName in FedProperties.AllProperties["IntProperties"])
            {
                if (GetIntVal(classPropName) != 0)
                {
                    OutZeroValues.Remove(classPropName);
                }
            };
            foreach (string classPropName in FedProperties.AllProperties["DecimalProperties"])
            {
                if (GetDecVal(classPropName) != 0)
                {
                    OutZeroValues.Remove(classPropName);
                }
            };
        }

        public string GetStrVal(string classPropName)
        {
            string classMethod = "Calculate" + classPropName.Replace("Out", "");
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
            string result = (string)CacheEstimationsController.GetMethodVal(this, classMethod);
            this[classPropName] = result;
            return result;
        }

        public int GetIntVal(string classPropName)
        {
            string classMethod = "Calculate" + classPropName.Replace("Out", "");
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
            result = (int)CacheEstimationsController.GetMethodVal(this, classMethod);
            this[classPropName] = result;
            return result;
        }

        public decimal GetDecVal(string classPropName)
        {
            string classMethod = "Calculate" + classPropName.Replace("Out", "");
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
            result = (decimal)CacheEstimationsController.GetMethodVal(this, classMethod);
            this[classPropName] = result;
            return result;
        }

        public bool GetBoolVal(string classPropName)
        {
            string classMethod = "Calculate" + classPropName.Replace("Out", "");
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
            result = (bool)CacheEstimationsController.GetMethodVal(this, classMethod);
            this[classPropName] = result;
            return result;
        }

        public void SetStrVal(string classPropName, string newValue)
        {
            string classMethod = "Calculate" + classPropName.Replace("Out", "");
            var propertyType = this.GetType().GetProperty(classPropName).PropertyType.ToString();
            if (!propertyType.Contains("System.String"))
            {
                throw new Exception("SetStrVal(). Not supported type of property.");
            }
            this[classPropName] = newValue;
        }

        public void SetIntVal(string classPropName, string newValue)
        {
            string classMethod = "Calculate" + classPropName.Replace("Out", "");
            string propertyType = this.GetType().GetProperty(classPropName).PropertyType.ToString();
            if (!propertyType.Contains("System.Int"))
            {
                throw new Exception("GetIntVal(). Not supported type of property.");
            }
            this[classPropName] = newValue;
        }

        public void SetDecVal(string classPropName, string newValue)
        {
            string classMethod = "Calculate" + classPropName.Replace("Out", "");
            string propertyType = this.GetType().GetProperty(classPropName).PropertyType.ToString();
            if (!propertyType.Contains("System.Decimal"))
            {
                throw new Exception("GetDecimalVal(). Not supported type of property.");
            }
            this[classPropName] = newValue;
        }

        public void SetBoolVal(string classPropName, string newValue)
        {
            string classMethod = "Calculate" + classPropName.Replace("Out", "");
            string propertyType = this.GetType().GetProperty(classPropName).PropertyType.ToString();
            if (!propertyType.Contains("System.Bool"))
            {
                throw new Exception("GetBoolVal(). Not supported type of property.");
            }
            this[classPropName] = newValue;
        }

        private string CalculateA1()
        {
            return "A1 String.";
        }
        private string CalculateA2() { return "A2 String."; }
        private string CalculateA3() { return "A3 String."; }
        private string CalculateA4()
        {
            if (GetBoolVal("OutD2")) {
                return GetStrVal("OutA2") + " " + GetStrVal("OutA3");
            }
            return "A4 String.";
        }
        private string CalculateA5() { return "A5 String."; }
        private string CalculateA6() { return "A6 String."; }
        private string CalculateA7() { return "A7 String."; }
        private string CalculateA8() { return "A8 String."; }
        private string CalculateA9() { return "A9 String."; }
        private int CalculateB1() { return 1; }
        private int CalculateB2() { return 2; }
        private int CalculateB3()
        {
            int result = GetIntVal("OutB1");
            result += GetIntVal("OutB2");
            OutZeroValues.Add("OutB3");
            return result;
        }
        private int CalculateB4()
        {
            OutZeroValues.Add("OutB4");
            return 0;
        }
        private int CalculateB5()
        {
            return GetIntVal("OutB3") + GetIntVal("OutB4");
        }
        private int CalculateB6()
        {
            int result = GetIntVal("OutB4");
            if (result == 0)
            {
                OutZeroValues.Add("OutB6");
            }
            return result;
        }
        private int CalculateB7()
        {
            OutZeroValues.Add("OutB7");
            return 7;
        }
        private int CalculateB8()
        {
            int b8MaxVal = 5;
            if (GetIntVal("OutB7") > b8MaxVal)
            {
                if (OutZeroValues.Contains("OutB7"))
                {
                    OutZeroValues.Add("OutB8");
                }
                return b8MaxVal;
            }
            return 8;
        }
        private int CalculateB9() { return 9; }
        private decimal CalculateC1() { return 1.1m; }
        private decimal CalculateC2() { return 2.2m; }
        private decimal CalculateC3() { return 3.3m; }
        private decimal CalculateC4() { return 4.4m; }
        private decimal CalculateC5() { return 5.5m; }
        private decimal CalculateC6() { return 6.6m; }
        private decimal CalculateC7() { return 7.7m; }
        private decimal CalculateC8() { return 8.8m; }
        private decimal CalculateC9() { return 9.9m; }
        private bool CalculateD1() { return false; }
        private bool CalculateD2() { return true; }
        private bool CalculateD3() { return false; }
        private bool CalculateD4() { return true; }
        private bool CalculateD5() { return false; }
        private bool CalculateD6()
        {
            if (GetIntVal("OutB4") + GetDecVal("OutC4") > 66)
            {
                return true;
            }
            return false;
        }
        private bool CalculateD7() { return true; }
        private bool CalculateD8() { return false; }
        private bool CalculateD9() { return false; }
    }
}
