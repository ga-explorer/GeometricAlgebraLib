﻿using System.Runtime.CompilerServices;
using GeometricAlgebraFulcrumLib.Algebra.ScalarAlgebra;
using GeometricAlgebraFulcrumLib.Processors.GeometricAlgebra;
using GeometricAlgebraFulcrumLib.Storage.GeometricAlgebra;

namespace GeometricAlgebraFulcrumLib.Algebra.GeometricAlgebra.Multivectors
{
    public static class GaKVectorFdpUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this IGeometricAlgebraProcessor<T> processor, ulong id1, ulong id2)
        {
            return processor.Fdp(
                processor.CreateKVectorStorageBasis(id1),
                processor.CreateKVectorStorageBasis(id2)
            ).CreateKVector(processor);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, int mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this int mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, uint mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this uint mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, long mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this long mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, ulong mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this ulong mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, float mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this float mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, double mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this double mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, T mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    mv2
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this T mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1,
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, Scalar<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    mv2.ScalarValue
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this Scalar<T> mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.ScalarValue,
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, GaVector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Fdp(
                    mv1.KVectorStorage,
                    mv2.VectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaVector<T> mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Fdp(
                    mv1.VectorStorage,
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, GaBivector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Fdp(
                    mv1.KVectorStorage,
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaBivector<T> mv1, GaKVector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Fdp(
                    mv1.BivectorStorage,
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> Fdp<T>(this GaKVector<T> mv1, GaKVector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Fdp(
                    mv1.KVectorStorage,
                    mv2.KVectorStorage
                )
            );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, int mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this int mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, uint mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this uint mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, long mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this long mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, ulong mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this ulong mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, float mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this float mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, double mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    processor.GetScalarFromNumber(mv2)
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this double mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    processor.GetScalarFromNumber(mv1),
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, T mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    mv2
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this T mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1,
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, Scalar<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.KVectorStorage,
                    mv2.ScalarValue
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this Scalar<T> mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.Times(
                    mv1.ScalarValue,
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, GaVector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.EFdp(
                    mv1.KVectorStorage,
                    mv2.VectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaVector<T> mv1, GaKVector<T> mv2)
        {
            var processor = mv2.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.EFdp(
                    mv1.VectorStorage,
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, GaBivector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.EFdp(
                    mv1.KVectorStorage,
                    mv2.BivectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaBivector<T> mv1, GaKVector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.EFdp(
                    mv1.BivectorStorage,
                    mv2.KVectorStorage
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GaKVector<T> EFdp<T>(this GaKVector<T> mv1, GaKVector<T> mv2)
        {
            var processor = mv1.GeometricProcessor;

            return new GaKVector<T>(
                processor,
                processor.EFdp(
                    mv1.KVectorStorage,
                    mv2.KVectorStorage
                )
            );
        }
    }
}