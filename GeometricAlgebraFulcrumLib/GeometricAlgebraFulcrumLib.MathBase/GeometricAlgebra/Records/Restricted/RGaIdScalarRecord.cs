﻿namespace GeometricAlgebraFulcrumLib.MathBase.GeometricAlgebra.Records.Restricted
{
    public sealed record RGaIdScalarRecord(ulong Id, double Scalar) :
        IRGaIdScalarRecord<double>;

    public sealed record RGaIdScalarRecord<T>(ulong Id, T Scalar) :
        IRGaIdScalarRecord<T>;
}