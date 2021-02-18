using System;

namespace StandardTask2
{
    public class Utilities
    {
        public static string EnrichString(string name)
        {
            var enrichString = $"{DateTime.UtcNow}: Hello {name}";
            return enrichString;
        }
    }
}
