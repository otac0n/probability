// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods on distributions.
    /// </summary>
    public static class Distribution
    {
        public static string Histogram(this IDistribution<double> values, double low, double high) => values.Samples().Histogram(low, high);

        public static IEnumerable<T> Samples<T>(this IDistribution<T> distribution)
        {
            while (true)
            {
                yield return distribution.Sample();
            }
        }
    }
}
