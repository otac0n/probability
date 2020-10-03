// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Bernoulli : IDiscreteDistribution<int>
    {
        private Bernoulli(int zero, int one)
        {
            this.Zero = zero;
            this.One = one;
        }

        public int One { get; }

        public int Zero { get; }

        public static IDiscreteDistribution<int> Distribution(int zero, int one)
        {
            if (zero < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(zero));
            }
            else if (one < 0 || (zero == 0 && one == 0))
            {
                throw new ArgumentOutOfRangeException(nameof(one));
            }

            if (zero == 0)
            {
                return Singleton<int>.Distribution(1);
            }

            if (one == 0)
            {
                return Singleton<int>.Distribution(0);
            }

            return new Bernoulli(zero, one);
        }

        public int Sample() => (StandardContinuousUniform.Distribution.Sample() <= (double)this.Zero / (this.Zero + this.One)) ? 0 : 1;

        public IEnumerable<int> Support() => Enumerable.Range(0, 2);

        public override string ToString() => $"Bernoulli[{this.Zero}, {this.One}]";

        public int Weight(int x) => x == 0 ? this.Zero : x == 1 ? this.One : 0;
    }
}
