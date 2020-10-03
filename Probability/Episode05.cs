// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System;

    internal static class Episode05
    {
        public static void DoIt()
        {
            Console.WriteLine("Episode 05");
            Console.WriteLine("Bernoulli 75% chance of 1");
            Console.WriteLine(Bernoulli.Distribution(1, 3).Histogram());
        }
    }
}
