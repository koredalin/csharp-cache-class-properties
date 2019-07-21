using System.Collections.Generic;

namespace CacheProperties.Estimations
{
    public class FedProperties
    {
        public static readonly Dictionary<string, List<string>> AllProperties = new Dictionary<string, List<string>>()
        {
            { "StrProperties", new List<string>()
                {
                    "OutA1",
                    "OutA2",
                    "OutA3",
                    "OutA4",
                    "OutA5",
                    "OutA6",
                    "OutA7",
                    "OutA8",
                    "OutA9",
                }
            },
            { "IntProperties", new List<string>()
                {
                    "OutB1",
                    "OutB2",
                    "OutB3",
                    "OutB4",
                    "OutB5",
                    "OutB6",
                    "OutB7",
                    "OutB8",
                    "OutB9",
                }
            },
            { "DecimalProperties", new List<string>()
                {
                    "OutC1",
                    "OutC2",
                    "OutC3",
                    "OutC4",
                    "OutC5",
                    "OutC6",
                    "OutC7",
                    "OutC8",
                    "OutC9",
                }
            },
            { "BoolProperties", new List<string>()
                {
                    "OutD1",
                    "OutD2",
                    "OutD3",
                    "OutD4",
                    "OutD5",
                    "OutD6",
                    "OutD7",
                    "OutD8",
                    "OutD9",
                }
            },
        };
    }
}
