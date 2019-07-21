using System.Collections.Generic;

namespace CacheProperties.Estimations
{
    public class FedProperties
    {
        public static readonly Dictionary<string, List<string>> AllProperties = new Dictionary<string, List<string>>()
        {
            { "StrProperties", new List<string>()
                {
                    "FedOutA1",
                    "FedOutA2",
                    "FedOutA3",
                    "FedOutA4",
                    "FedOutA5",
                    "FedOutA6",
                    "FedOutA7",
                    "FedOutA8",
                    "FedOutA9",
                }
            },
            { "IntProperties", new List<string>()
                {
                    "FedOutB1",
                    "FedOutB2",
                    "FedOutB3",
                    "FedOutB4",
                    "FedOutB5",
                    "FedOutB6",
                    "FedOutB7",
                    "FedOutB8",
                    "FedOutB9",
                }
            },
            { "DecimalProperties", new List<string>()
                {
                    "FedOutC1",
                    "FedOutC2",
                    "FedOutC3",
                    "FedOutC4",
                    "FedOutC5",
                    "FedOutC6",
                    "FedOutC7",
                    "FedOutC8",
                    "FedOutC9",
                }
            },
            { "BoolProperties", new List<string>()
                {
                    "FedOutD1",
                    "FedOutD2",
                    "FedOutD3",
                    "FedOutD4",
                    "FedOutD5",
                    "FedOutD6",
                    "FedOutD7",
                    "FedOutD8",
                    "FedOutD9",
                }
            },
        };
    }
}
