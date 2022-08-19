using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace S3.Framework.Common
{
    public static class CommonUtil
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static IEnumerable<string> MustBeLength(this IEnumerable<string> input, int length)
        {
            if (input.Count() >= length)
            {
                return input;
            }

            throw new ArgumentException($"Input array must be of minimum length {length}.");
        }

        public static IEnumerable<string> MustBePrefix(this IEnumerable<string> input, string prefix)
        {
            if (input.First().Equals(prefix, StringComparison.InvariantCultureIgnoreCase))
            {
                return input;
            }

            throw new ArgumentException($"Data prefix must be '{prefix}'.");
        }

        public static float StringToFloat(string input, string name)
        {
            float value;

            if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                return value;
            }

            throw new ArgumentException($"Could not parse {name} parameter as float.");
        }

        public static int StringToInt(string input, string name)
        {
            int value;

            if (int.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                return value;
            }

            throw new ArgumentException($"Could not parse {name} parameter as int.");
        }

        public static int? StringToNullableInt(string input, string name)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            int value;
            if (int.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                return value;
            }

            throw new ArgumentException($"Could not parse {name} parameter as int.");
        }
    }


}