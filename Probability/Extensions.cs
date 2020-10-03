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
            return Enumerable.Range(0, height)
                    .Select(r => buckets.Select(b => b * scale > (height - r) ? '*' : ' ').Concatenated() + "\n")
                    .Concatenated()
                    + new string('-', width) + "\n";
        }

        public static string DiscreteHistogram<T>(this IEnumerable<T> d)
        {
            const int sampleCount = 100000;
            const int width = 40;
            var dict = d.Take(sampleCount)
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());
            int labelMax = dict.Keys
                .Select(x => x.ToString().Length)
                .Max();
            var sup = dict.Keys.OrderBy(ToLabel).ToList();
            int max = dict.Values.Max();
            double scale = max < width ? 1.0 : ((double)width) / max;
            return sup.Select(s => $"{ToLabel(s)}|{Bar(s)}").NewlineSeparated();
            string ToLabel(T t) =>
                t.ToString().PadLeft(labelMax);
            string Bar(T t) =>
                new string('*', (int)(dict[t] * scale));
        }

        public static string Separated<T>(this IEnumerable<T> items, string s) =>
            string.Join(s, items);

        public static string Concatenated<T>(this IEnumerable<T> items) =>
            string.Join("", items);

        public static string NewlineSeparated<T>(this IEnumerable<T> items) =>
            items.Separated("\n");
    }
}
