﻿using System.Runtime.CompilerServices;
using GeometricAlgebraFulcrumLib.Algebra.ScalarAlgebra;
using GeometricAlgebraFulcrumLib.Storage.GeometricAlgebra;

namespace GeometricAlgebraFulcrumLib.Algebra.GeometricAlgebra.Multivectors
{
    public static class GaVectorSpUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Scalar<T> Sp<T>(this GaVector<T> v1, Scalar<T> v2)
        {
            return v1.GeometricProcessor.CreateScalarZero();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Scalar<T> Sp<T>(this Scalar<T> v1, GaVector<T> v2)
        {
            return v2.GeometricProcessor.CreateScalarZero();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Scalar<T> Sp<T>(this GaVector<T> v1, GaVector<T> v2)
        {
            var processor = v1.GeometricProcessor;

            return processor.CreateScalar(
                processor.Sp(v1.VectorStorage, v2.VectorStorage)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Scalar<T> SpSquared<T>(this GaVector<T> v1)
        {
            var processor = v1.GeometricProcessor;

            return processor.CreateScalar(
                processor.SpSquared(v1.VectorStorage)
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Scalar<T> ESp<T>(this GaVector<T> v1, Scalar<T> v2)
        {
            return v1.GeometricProcessor.CreateScalarZero();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Scalar<T> ESp<T>(this Scalar<T> v1, GaVector<T> v2)
        {
            return v2.GeometricProcessor.CreateScalarZero();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Scalar<T> ESp<T>(this GaVector<T> v1, GaVector<T> v2)
        {
            var processor = v1.GeometricProcessor;

            return processor.CreateScalar(
                processor.ESp(v1.VectorStorage, v2.VectorStorage)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Scalar<T> ESpSquared<T>(this GaVector<T> v1)
        {
            var processor = v1.GeometricProcessor;

            return processor.CreateScalar(
                processor.ESp(v1.VectorStorage)
            );
        }
    }
}