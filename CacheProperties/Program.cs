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
            FedEstimation feObj = new FedEstimation();
            feObj.CalculateAll();
            feObj.ClearNotZeroValues();

            string fedEstimationsJson = JsonConvert.SerializeObject(feObj,
                Formatting.Indented,
                new JsonConverter[] { new StringEnumConverter() });
            string fedEstimationsZeroPropertiesValuesJson = JsonConvert.SerializeObject(FedEstimation.OutZeroValues,
                Formatting.Indented,
                new JsonConverter[] { new StringEnumConverter() });

            Console.WriteLine("Object Output Properties");
            Console.WriteLine(fedEstimationsJson);
            Console.WriteLine("Object Output Zero Values");
            Console.WriteLine(fedEstimationsZeroPropertiesValuesJson);
        }
    }
}
