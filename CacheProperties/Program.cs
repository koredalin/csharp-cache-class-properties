using CacheProperties.Estimations;
using Newtonsoft.Json;
using System;

namespace CacheProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            FedEstimation feObj = new FedEstimation();
            //feObj.SetStrVal("FedOutA2", "A2 Calculated twice.");
            feObj.CalculateAll();
            feObj.ClearNotZeroValues();

            string fedEstimationsJson = JsonConvert.SerializeObject(feObj);
            string fedEstimationsZeroPropertiesValuesJson = JsonConvert.SerializeObject(FedEstimation.ZeroValues);

            Console.WriteLine(feObj.FedOutA2);
        }
    }
}
