// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using static System.Math;

    public sealed class Normal : IDistribution<double>
    {
        public static readonly Normal Standard = Distribution(0, 1);

        private Normal(double mean, double sigma)
        {
            this.Mean = mean;
            this.Sigma = sigma;
        }

        public double Mean { get; }

        public double Sigma { get; }

        public static Normal Distribution(double mean, double sigma) => new Normal(mean, sigma);

        public double Sample() => this.Mean + this.Sigma * this.StandardSample();

        /// <remarks>
        /// Box-Muller method.
        /// </remarks>
        private double StandardSample() => Sqrt(-2.0 * Log(StandardContinuousUniform.Distribution.Sample())) * Cos(2.0 * PI * StandardContinuousUniform.Distribution.Sample());
    }
}
