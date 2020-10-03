// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System;
    using System.Threading;

    /// <summary>
    /// A threadsafe, all-static, crypto-randomized wrapper around Random.
    /// </summary>
    /// <remarks>
    /// Still not great, but a slight improvement.
    /// </remarks>
    public static class Pseudorandom
    {
        private static readonly ThreadLocal<Random> Random = new ThreadLocal<Random>(() => new Random(BetterRandom.NextInt()));

        public static double NextDouble() => Random.Value.NextDouble();

        public static int NextInt() => Random.Value.Next();
    }
}
