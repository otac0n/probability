// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods on distributions.
    /// </summary>
    public static class Distribution
    {
        public static string Histogram(this IDistribution<double> values, double low, double high) => values.Samples().Histogram(low, high);

        public static string Histogram<T>(this IDiscreteDistribution<T> d) => d.Samples().DiscreteHistogram();

        public static IEnumerable<T> Samples<T>(this IDistribution<T> distribution)
        {
            while (true)
            {
                yield return distribution.Sample();
            }
        }

        public static string ShowWeights<T>(this IDiscreteDistribution<T> distribution)
        {
            var labelMax = distribution.Support()
                .Select(x => x.ToString().Length)
                .Max();
            return distribution.Support()
                .Select(s => $"{ToLabel(s)}:{distribution.Weight(s)}")
                .NewlineSeparated();
            string ToLabel(T t) =>
                t.ToString().PadLeft(labelMax);
        }
    }
}
