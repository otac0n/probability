// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    public sealed class StandardContinuousUniform : IDistribution<double>
    {
        public static readonly StandardContinuousUniform Distribution = new StandardContinuousUniform();

        private StandardContinuousUniform()
        {
        }

        public double Sample() => Pseudorandom.NextDouble();
    }
}
