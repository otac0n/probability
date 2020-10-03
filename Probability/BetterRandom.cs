// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System;
    using System.Security.Cryptography;
    using System.Threading;

    /// <summary>
    /// A crypto-strength, threadsafe, all-static RNG.
    /// </summary>
    /// <remarks>
    /// Still not a great API. We can do better.
    /// </remarks>
    public static class BetterRandom
    {
        private static readonly ThreadLocal<byte[]> Bytes = new ThreadLocal<byte[]>(() => new byte[sizeof(int)]);

        private static readonly ThreadLocal<RandomNumberGenerator> Rng = new ThreadLocal<RandomNumberGenerator>(RandomNumberGenerator.Create);

        public static double NextDouble()
        {
            while (true)
            {
                long x = NextInt() & 0x001FFFFF;
                x <<= 31;
                x |= (long)NextInt();
                double n = x;
                const double d = 1L << 52;
                var q = n / d;
                if (q != 1.0)
                {
                    return q;
                }
            }
        }

        public static int NextInt()
        {
            Rng.Value.GetBytes(Bytes.Value);
            return BitConverter.ToInt32(Bytes.Value, 0) & int.MaxValue;
        }
    }
}
