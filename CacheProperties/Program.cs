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

            string fedEstimationsJson = JsonConvert.SerializeObject(feObj);

            Console.WriteLine(feObj.FedOutA2);
        }
    }
}
