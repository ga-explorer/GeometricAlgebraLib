﻿using GeometricAlgebraFulcrumLib.MathBase.LinearAlgebra.Float64.Vectors.Space3D;

namespace GeometricAlgebraFulcrumLib.MathBase.Graphics.SdfGeometry.Primitives
{
    /// <summary>
    /// http://iquilezles.org/www/articles/distfunctions/distfunctions.htm
    /// </summary>
    public sealed class SdfPlaneYz3D : ScalarDistanceFunction
    {
        public override double GetScalarDistance(IFloat64Vector3D point)
        {
            return point.X;
        }
    }
}