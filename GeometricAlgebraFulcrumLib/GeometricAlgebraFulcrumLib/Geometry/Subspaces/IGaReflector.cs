﻿using GeometricAlgebraFulcrumLib.Algebra.Outermorphisms;
using GeometricAlgebraFulcrumLib.Storage.Multivectors;

namespace GeometricAlgebraFulcrumLib.Geometry.Subspaces
{
    public interface IGaReflector<T> : 
        IGaOutermorphism<T>
    {
        IGaStorageKVector<T> BladeStorage { get; }

        T BladeNormSquared { get; }
    }
}