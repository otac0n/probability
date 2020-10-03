// Copyright © Eric Lippert and Contributors. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Probability
{
    public interface IDistribution<T>
    {
        T Sample();
    }
}
