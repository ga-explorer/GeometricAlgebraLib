﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using GeometricAlgebraFulcrumLib.MathBase.GeometricAlgebra.Restricted.Basis;
using GeometricAlgebraFulcrumLib.MathBase.GeometricAlgebra.Restricted.Generic.Multivectors.Composers;
using GeometricAlgebraFulcrumLib.MathBase.GeometricAlgebra.Restricted.Generic.Processors;
using GeometricAlgebraFulcrumLib.MathBase.ScalarAlgebra;

namespace GeometricAlgebraFulcrumLib.MathBase.GeometricAlgebra.Restricted.Generic.Multivectors
{
    public sealed partial class RGaScalar<T> :
        RGaKVector<T>
    {
        public override string MultivectorClassName
            => "Generic Scalar";

        [NotNull]
        public T ScalarValue
            => Scalar.ScalarValue;

        public Scalar<T> Scalar { get; }

        public override int Count
            => IsZero ? 0 : 1;

        public override IEnumerable<int> KVectorGrades
        {
            get
            {
                if (!IsZero) yield return 0;
            }
        }

        public override int Grade
            => 0;

        public override bool IsZero { get; }

        public bool IsOne
            => ScalarProcessor.IsOne(ScalarValue);
    
        public bool IsMinusOne
            => ScalarProcessor.IsMinusOne(ScalarValue);

        public override IEnumerable<RGaBasisBlade> BasisBlades
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (!IsZero) yield return Processor.BasisScalar;
            }
        }

        public override IEnumerable<ulong> Ids
        {
            get
            {
                if (!IsZero) yield return 0UL;
            }
        }

        public override IEnumerable<T> Scalars
        {
            get
            {
                if (!IsZero) yield return ScalarValue;
            }
        }

        public override IEnumerable<KeyValuePair<RGaBasisBlade, T>> BasisScalarPairs
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (!IsZero)
                    yield return new KeyValuePair<RGaBasisBlade, T>(
                        Processor.BasisScalar,
                        ScalarValue
                    );
            }
        }

        public override IEnumerable<KeyValuePair<ulong, T>> IdScalarPairs
        {
            get
            {
                if (!IsZero)
                    yield return new KeyValuePair<ulong, T>(
                        0UL,
                        ScalarValue
                    );
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal RGaScalar(RGaProcessor<T> processor, Scalar<T> scalar)
            : base(processor)
        {
            Debug.Assert(
                scalar.IsValid()
            );

            Scalar = scalar;
            IsZero = scalar.IsZero();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal RGaScalar(RGaProcessor<T> processor)
            : base(processor)
        {
            Scalar = processor.ScalarProcessor.CreateScalarZero();
            IsZero = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal RGaScalar(RGaProcessor<T> processor, T scalarValue)
            : base(processor)
        {
            Debug.Assert(
                processor.ScalarProcessor.IsValid(scalarValue)
            );

            Scalar = processor.ScalarProcessor.CreateScalar(scalarValue);
            IsZero = processor.ScalarProcessor.IsZero(ScalarValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal RGaScalar(RGaProcessor<T> processor, IReadOnlyDictionary<ulong, T> idScalarDictionary)
            : base(processor)
        {
            Scalar = processor.ScalarProcessor.CreateScalar(
                idScalarDictionary.TryGetValue(0UL, out var scalar)
                    ? scalar
                    : processor.ScalarProcessor.ScalarZero
            );

            Debug.Assert(
                Scalar.IsValid()
            );

            IsZero = Scalar.IsZero();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool IsValid()
        {
            return ScalarProcessor.IsValid(ScalarValue);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override IReadOnlyDictionary<ulong, T> GetIdScalarDictionary()
        {
            return this;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool ContainsKey(ulong key)
        {
            return key == 0UL && !IsZero;
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override RGaScalar<T> GetScalarPart()
        {
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override RGaVector<T> GetVectorPart()
        {
            return Processor.CreateZeroVector();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override RGaBivector<T> GetBivectorPart()
        {
            return Processor.CreateZeroBivector();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override RGaHigherKVector<T> GetHigherKVectorPart(int grade)
        {
            return Processor.CreateZeroHigherKVector(grade);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RGaScalar<T> GetPart(Func<ulong, bool> filterFunc)
        {
            return IsZero || filterFunc(0) 
                ? this 
                : Processor.CreateZeroScalar();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RGaScalar<T> GetPart(Func<T, bool> filterFunc)
        {
            return IsZero || filterFunc(ScalarValue) 
                ? this 
                : Processor.CreateZeroScalar();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RGaScalar<T> GetPart(Func<ulong, T, bool> filterFunc)
        {
            return IsZero || filterFunc(0, ScalarValue) 
                ? this 
                : Processor.CreateZeroScalar();
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override Scalar<T> GetScalarTermScalar()
        {
            return Scalar;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override Scalar<T> GetTermScalar(ulong basisBladeId)
        {
            return basisBladeId == 0UL
                ? Scalar
                : ScalarProcessor.CreateScalarZero();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool TryGetScalarTermScalar(out T scalar)
        {
            if (!IsZero)
            {
                scalar = ScalarValue;
                return true;
            }

            scalar = ScalarProcessor.ScalarZero;
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool TryGetTermScalar(ulong basisBlade, out T scalar)
        {
            if (basisBlade == 0UL)
            {
                scalar = ScalarValue;
                return true;
            }

            scalar = ScalarProcessor.ScalarZero;
            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override RGaMultivector<T> Simplify()
        {
            return this;
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool Equals(RGaScalar<T> other)
        {
            return Equals(Scalar, other.Scalar);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) || obj is RGaScalar<T> other && Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            return Scalar.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return IsZero ? string.Empty : $"'{ScalarValue:G}'<>";
        }
    }
}