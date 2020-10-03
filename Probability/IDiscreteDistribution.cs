// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    using System.Collections.Generic;

    public interface IDiscreteDistribution<T> : IDistribution<T>
    {
        IEnumerable<T> Support();

        int Weight(T t);
    }
}
