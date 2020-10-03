// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Miscellaneous extension methods.
    /// </summary>
    internal static class Extensions
    {
        public static string Histogram(this IEnumerable<double> values, double low, double high)
        {
            const int width = 40;
            const int height = 20;
            const int sampleCount = 100000;
            var buckets = new int[width];
            foreach (var c in values.Take(sampleCount))
            {
                var bucket = (int)(buckets.Length * (c - low) / (high - low));
                if (bucket >= 0 && bucket < buckets.Length)
                {
                    buckets[bucket] += 1;
                }
            }

            var max = buckets.Max();
            var scale =
                max < height ? 1.0 : ((double)height) / max;
            return string.Join(string.Empty,
                Enumerable.Range(0, height).Select(
                    r => string.Join(string.Empty, buckets.Select(
                        b => b * scale > (height - r) ? '*' : ' ')) + "\n"))
                + new string('-', width) + "\n";
        }
    }
}
