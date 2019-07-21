using CacheProperties.Estimations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace CacheProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator feObj = new Calculator();
            feObj.CalculateAll();
            feObj.ClearOutputNotZeros();

            string fedEstimationsJson = JsonConvert.SerializeObject(feObj,
                Formatting.Indented,
                new JsonConverter[] { new StringEnumConverter() });
            string fedEstimationsZeroPropertiesValuesJson = JsonConvert.SerializeObject(Calculator.OutZeroValues,
                Formatting.Indented,
                new JsonConverter[] { new StringEnumConverter() });

            Console.WriteLine("Object Output Properties");
            Console.WriteLine(fedEstimationsJson);
            Console.WriteLine("Object Output Zero Values");
            Console.WriteLine(fedEstimationsZeroPropertiesValuesJson);
        }
    }
}
