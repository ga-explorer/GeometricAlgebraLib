﻿using System.Runtime.CompilerServices;
using GeometricAlgebraFulcrumLib.Algebra.ScalarAlgebra;
using GeometricAlgebraFulcrumLib.Storage.GeometricAlgebra;

namespace GeometricAlgebraFulcrumLib.Algebra.GeometricAlgebra.Multivectors
{
    public static class GaBivectorGpUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this GaBivector<T> mv1, int mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this int mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this GaBivector<T> mv1, uint mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this uint mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this GaBivector<T> mv1, long mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this long mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this GaBivector<T> mv1, ulong mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this ulong mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this GaBivector<T> mv1, float mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this float mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this GaBivector<T> mv1, double mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this double mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this GaBivector<T> mv1, T mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    mv2
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this T mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1,
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this GaBivector<T> mv1, Scalar<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    mv2.ScalarValue
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> Gp<T>(this Scalar<T> mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.ScalarValue,
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaMultivector<T> Gp<T>(this GaBivector<T> mv1, GaVector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaMultivector<T>(
                processor,
                processor.Gp(
                    mv1.BivectorStorage,
                    mv2.VectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaMultivector<T> Gp<T>(this GaVector<T> mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaMultivector<T>(
                processor,
                processor.Gp(
                    mv1.VectorStorage,
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaMultivector<T> Gp<T>(this GaBivector<T> mv1, GaBivector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaMultivector<T>(
                processor,
                processor.Gp(
                    mv1.BivectorStorage,
                    mv2.BivectorStorage
                )
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this GaBivector<T> mv1, int mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this int mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this GaBivector<T> mv1, uint mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this uint mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this GaBivector<T> mv1, long mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this long mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this GaBivector<T> mv1, ulong mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this ulong mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this GaBivector<T> mv1, float mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this float mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this GaBivector<T> mv1, double mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this double mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this GaBivector<T> mv1, T mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    mv2
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this T mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1,
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this GaBivector<T> mv1, Scalar<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.BivectorStorage,
                    mv2.ScalarValue
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaBivector<T> EGp<T>(this Scalar<T> mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaBivector<T>(
                processor,
                processor.Times(
                    mv1.ScalarValue,
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaMultivector<T> EGp<T>(this GaBivector<T> mv1, GaVector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaMultivector<T>(
                processor,
                processor.EGp(
                    mv1.BivectorStorage,
                    mv2.VectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaMultivector<T> EGp<T>(this GaVector<T> mv1, GaBivector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaMultivector<T>(
                processor,
                processor.EGp(
                    mv1.VectorStorage,
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaMultivector<T> EGp<T>(this GaBivector<T> mv1, GaBivector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaMultivector<T>(
                processor,
                processor.EGp(
                    mv1.BivectorStorage,
                    mv2.BivectorStorage
                )
            );
        }
    }
}