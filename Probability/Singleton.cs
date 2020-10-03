// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Singleton<T> : IDiscreteDistribution<T>
    {
        private readonly T t;

        private Singleton(T t) => this.t = t;

        public static Singleton<T> Distribution(T t) => new Singleton<T>(t);

        public T Sample() => this.t;

        public IEnumerable<T> Support() => Enumerable.Repeat(this.t, 1);

        public override string ToString() => $"Singleton[{this.t}]";

        public int Weight(T t) => EqualityComparer<T>.Default.Equals(this.t, t) ? 1 : 0;
    }
}
