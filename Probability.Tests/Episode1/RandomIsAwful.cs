// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Xunit;

    /// <summary>
    /// This class highlights some specific problems with <see cref="Random"/>.
    /// </summary>
    /// <remarks>
    /// The real problem though is that this interface is not strong enough
    /// to do all the interesting stuff we want to do with stochastic programming
    /// in the modern era. That's what we'll be exploring in this series.
    /// </remarks>
    public class RandomIsAwful
    {
        /// <summary>
        /// Similarly, in earlier days this would eventually print all zeros;
        /// Random is not thread safe, and its common failure mode
        /// is to get into a state where it can only produce zero.
        /// This bug has also been fixed, though this is still a bad idea.
        /// </summary>
        [Fact(Skip = "Demonstration")]
        public void ConcurrentAccess()
        {
            var shared = new Random();

            var threads = new List<Thread>();
            var values = new List<int>();
            for (var i = 0; i < 100; ++i)
            {
                threads.Add(new Thread(() =>
                {
                    var value = shared.Next(1, 6);
                    lock (values)
                    {
                        values.Add(value);
                    }
                }));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            var expected = (double)values.Count / 6;
            var min = (int)Math.Floor(expected * 0.8);
            var max = (int)Math.Ceiling(expected * 1.25);
            for (var i = 1; i <= 6; i++)
            {
                var count = values.Where(v => v == i).Count();
                Assert.InRange(count, min, max);
            }
        }

        /// <summary>
        /// Episode 1: Random is awful
        /// In earlier days this would print 100 of the same number.
        /// That bug has been fixed, but you'll note we still get no sixes.
        /// </summary>
        [Fact(Skip = "Demonstration")]
        public void OneHundredRandomInstances()
        {
            var values = new List<int>();
            for (var i = 0; i < 100; ++i)
            {
                var random = new Random();
                values.Add(random.Next(1, 6));
            }

            var expected = (double)values.Count / 6;
            var min = (int)Math.Floor(expected * 0.8);
            var max = (int)Math.Ceiling(expected * 1.25);
            for (var i = 1; i <= 6; i++)
            {
                var count = values.Where(v => v == i).Count();
                Assert.InRange(count, min, max);
            }
        }
    }
}
