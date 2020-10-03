// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class StandardDiscreteUniform :
      IDiscreteDistribution<int>
    {
        private StandardDiscreteUniform(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }

        public int Max { get; }

        public int Min { get; }

        public static StandardDiscreteUniform Distribution(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException(nameof(max));
            }

            return new StandardDiscreteUniform(min, max);
        }

        public int Sample() => (int)(StandardContinuousUniform.Distribution.Sample() * (1.0 + this.Max - this.Min)) + this.Min;

        public IEnumerable<int> Support() => Enumerable.Range(this.Min, 1 + this.Max - this.Min);

        public override string ToString() => $"StandardDiscreteUniform[{this.Min}, {this.Max}]";

        public int Weight(int i) => (this.Min <= i && i <= this.Max) ? 1 : 0;
    }
}
