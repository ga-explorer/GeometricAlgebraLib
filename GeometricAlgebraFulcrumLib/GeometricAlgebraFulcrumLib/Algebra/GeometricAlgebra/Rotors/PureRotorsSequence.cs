﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using GeometricAlgebraFulcrumLib.Algebra.GeometricAlgebra.Outermorphisms;
using GeometricAlgebraFulcrumLib.Geometry.Frames;
using GeometricAlgebraFulcrumLib.Geometry.Subspaces;
using GeometricAlgebraFulcrumLib.Processors.GeometricAlgebra;
using GeometricAlgebraFulcrumLib.Storage.GeometricAlgebra;
using GeometricAlgebraFulcrumLib.Utilities.Extensions;
using GeometricAlgebraFulcrumLib.Utilities.Factories;

namespace GeometricAlgebraFulcrumLib.Algebra.GeometricAlgebra.Rotors
{
    public sealed class PureRotorsSequence<T> : 
        RotorBase<T>, 
        IReadOnlyList<PureRotor<T>>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PureRotorsSequence<T> CreateIdentity(IGeometricAlgebraProcessor<T> processor)
        {
            return new PureRotorsSequence<T>(processor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PureRotorsSequence<T> Create(IGeometricAlgebraProcessor<T> processor, params PureRotor<T>[] rotorsList)
        {
            return new PureRotorsSequence<T>(processor, rotorsList);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PureRotorsSequence<T> Create(IGeometricAlgebraProcessor<T> processor, IEnumerable<PureRotor<T>> rotorsList)
        {
            return new PureRotorsSequence<T>(processor, rotorsList);
        }

        public static PureRotorsSequence<T> CreateFromOrthonormalFrames(GeoFreeFrame<T> sourceFrame, GeoFreeFrame<T> targetFrame, bool fullRotorsFlag = false)
        {
            Debug.Assert(targetFrame.Count == sourceFrame.Count);
            Debug.Assert(sourceFrame.IsOrthonormal() && targetFrame.IsOrthonormal());
            Debug.Assert(sourceFrame.HasSameHandedness(targetFrame));

            var processor = sourceFrame.GeometricProcessor;

            var rotorsSequence = new PureRotorsSequence<T>(processor);

            var sourceFrameVectors = sourceFrame.ToArray();

            var n = fullRotorsFlag 
                ? sourceFrame.Count 
                : sourceFrame.Count - 1;
            
            for (var i = 0; i < n; i++)
            {
                var sourceVector = sourceFrameVectors[i];
                var targetVector = targetFrame[i];

                var rotor = 
                    processor.CreateEuclideanRotor(sourceVector, targetVector);

                rotorsSequence.AppendRotor(rotor);

                for (var j = i + 1; j < sourceFrame.Count; j++)
                    sourceFrameVectors[j] = rotor.OmMapVector(sourceFrameVectors[j]);
            }

            return rotorsSequence;
        }

        public static PureRotorsSequence<T> CreateFromOrthonormalFrames(GeoFreeFrame<T> sourceFrame, GeoFreeFrame<T> targetFrame, int[] sequenceArray)
        {
            Debug.Assert(targetFrame.Count == sourceFrame.Count);
            Debug.Assert(sourceFrame.IsOrthonormal() && targetFrame.IsOrthonormal());
            Debug.Assert(sourceFrame.HasSameHandedness(targetFrame));

            Debug.Assert(sequenceArray.Length == sourceFrame.Count - 1);
            Debug.Assert(sequenceArray.Min() >= 0);
            Debug.Assert(sequenceArray.Max() < sourceFrame.Count);
            Debug.Assert(sequenceArray.Distinct().Count() == sourceFrame.Count - 1);

            var processor = sourceFrame.GeometricProcessor;

            var rotorsSequence = new PureRotorsSequence<T>(processor);

            var sourceFrameVectors = sourceFrame.ToArray();
            
            for (var i = 0; i < sourceFrame.Count - 1; i++)
            {
                var vectorIndex = sequenceArray[i];

                var sourceVector = sourceFrameVectors[vectorIndex];
                var targetVector = targetFrame[vectorIndex];

                var rotor = processor.CreateEuclideanRotor(
                    sourceVector, 
                    targetVector
                );

                rotorsSequence.AppendRotor(rotor);

                for (var j = i + 1; j < sourceFrame.Count; j++)
                    sourceFrameVectors[j] = 
                        rotor.OmMapVector(sourceFrameVectors[j]);
            }

            return rotorsSequence;
        }

        public static PureRotorsSequence<T> CreateFromFrames(uint baseSpaceDimensions, GeoFreeFrame<T> sourceFrame, GeoFreeFrame<T> targetFrame)
        {
            Debug.Assert(targetFrame.Count == sourceFrame.Count);
            //Debug.Assert(IsOrthonormal() && targetFrame.IsOrthonormal());
            Debug.Assert(sourceFrame.HasSameHandedness(targetFrame));

            var processor = sourceFrame.GeometricProcessor;

            var rotorsSequence = 
                new PureRotorsSequence<T>(processor);

            var pseudoScalarSubspace = 
                GeoSubspace<T>.CreateFromPseudoScalar(processor, baseSpaceDimensions);

            var sourceFrameVectors = new VectorStorage<T>[sourceFrame.Count];
            var targetFrameVectors = new VectorStorage<T>[targetFrame.Count];

            for (var i = 0; i < sourceFrame.Count; i++)
            {
                sourceFrameVectors[i] = sourceFrame[i];
                targetFrameVectors[i] = targetFrame[i];
            }
            
            for (var i = 0U; i < sourceFrame.Count - 1; i++)
            {
                var sourceVector = sourceFrameVectors[i];
                var targetVector = targetFrameVectors[i];

                var rotor = 
                    processor.CreateEuclideanRotor(sourceVector, targetVector);

                rotorsSequence.AppendRotor(rotor);

                pseudoScalarSubspace = 
                    processor.CreateSubspace(
                        pseudoScalarSubspace
                            .Complement(targetVector)
                            .GetKVectorPart(baseSpaceDimensions - i - 1)
                    );

                for (var j = i + 1; j < sourceFrame.Count; j++)
                {
                    sourceFrameVectors[j] =
                        pseudoScalarSubspace
                            .Project(rotor.OmMapVector(sourceFrameVectors[j]))
                            .GetVectorPart();

                    targetFrameVectors[j] =
                        pseudoScalarSubspace
                            .Project(targetFrameVectors[j])
                            .GetVectorPart();
                }
            }

            return rotorsSequence;
        }

        //public static PureRotorsSequence<double> CreateOrthogonalRotors(double[,] rotationMatrix)
        //{
        //    var evdSolver = Matrix<double>.Build.DenseOfArray(rotationMatrix).Evd();

        //    var eigenValuesReal = evdSolver.EigenValues.Real();
        //    var eigenValuesImag = evdSolver.EigenValues.Imaginary();
        //    var eigenVectors = evdSolver.EigenVectors;

        //    //TODO: Complete this

        //    return new PureRotorsSequence<double>(
        //        ScalarAlgebraFloat64Processor.DefaultProcessor.CreateGeometricAlgebraEuclideanProcessor(63)
        //    );
        //}


        private readonly List<PureRotor<T>> _rotorsList
            = new List<PureRotor<T>>();


        public int Count 
            => _rotorsList.Count;

        public PureRotor<T> this[int index]
        {
            get => _rotorsList[index];
            set => _rotorsList[index] = 
                value 
                ?? throw new ArgumentNullException(nameof(value));
        }


        private PureRotorsSequence([NotNull] IGeometricAlgebraProcessor<T> processor)
            : base(processor)
        {
        }

        private PureRotorsSequence([NotNull] IGeometricAlgebraProcessor<T> processor, IEnumerable<PureRotor<T>> rotorsList)
            : base(processor)
        {
            _rotorsList.AddRange(rotorsList);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool IsValid()
        {
            return _rotorsList.All(rotor => rotor.IsValid());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override IMultivectorStorage<T> GetMultivectorStorage()
        {
            return _rotorsList
                .Select(r => r.Multivector)
                .Aggregate(
                    (IMultivectorStorage<T>) GeometricProcessor.CreateKVectorBasisScalarStorage(),
                    GeometricProcessor.Gp
                );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override IMultivectorStorage<T> GetMultivectorInverseStorage()
        {
            return _rotorsList
                .Select(r => r.MultivectorReverse)
                .Reverse()
                .Aggregate(
                    (IMultivectorStorage<T>) GeometricProcessor.CreateKVectorBasisScalarStorage(),
                    GeometricProcessor.Gp
                );
        }

        public bool ValidateRotation(GeoFreeFrame<T> sourceFrame, GeoFreeFrame<T> targetFrame)
        {
            if (sourceFrame.Count != targetFrame.Count)
                return false;

            var rotatedFrame = Rotate(sourceFrame);

            return !rotatedFrame.Select(
                (v, i) => !GeometricProcessor.IsZero(GeometricProcessor.Subtract(targetFrame[i], v))
            ).Any();
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PureRotor<T> GetRotor(int index)
        {
            return _rotorsList[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PureRotorsSequence<T> AppendRotor([NotNull] PureRotor<T> rotor)
        {
            _rotorsList.Add(rotor);

            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PureRotorsSequence<T> PrependRotor([NotNull] PureRotor<T> rotor)
        {
            _rotorsList.Insert(0, rotor);

            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PureRotorsSequence<T> InsertRotor(int index, [NotNull] PureRotor<T> rotor)
        {
            _rotorsList.Insert(index, rotor);

            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PureRotorsSequence<T> GetSubSequence(int startIndex, int count)
        {
            return new PureRotorsSequence<T>(
                GeometricProcessor,
                _rotorsList.Skip(startIndex).Take(count)
            );
        }

        public IEnumerable<IMultivectorStorage<T>> GetRotations([NotNull] IMultivectorStorage<T> storage)
        {
            var v = storage;

            yield return v;

            foreach (var rotor in _rotorsList)
            {
                v = rotor.MapMultivector(v);

                yield return v;
            }
        }

        public IEnumerable<GeoFreeFrame<T>> GetRotations(GeoFreeFrame<T> frame)
        {
            var f = frame;

            yield return f;

            foreach (var rotor in _rotorsList)
            {
                f = rotor.OmMapFreeFrame(f);

                yield return f;
            }
        }

        public IEnumerable<T[,]> GetRotationMatrices(int rowsCount)
        {
            var f = 
                GeometricProcessor.CreateBasisFreeFrame((uint) rowsCount);

            yield return f.GetArray(rowsCount);

            foreach (var rotor in _rotorsList)
                yield return rotor.OmMapFreeFrame(f).GetArray(rowsCount);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override IRotor<T> GetRotorInverse()
        {
            return new PureRotorsSequence<T>(
                GeometricProcessor,
                _rotorsList
                    .Select(r => r.GetPureRotorInverse())
                    .Reverse()
            );
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override VectorStorage<T> OmMapVector(VectorStorage<T> mv)
        {
            return _rotorsList
                .Aggregate(
                    mv, 
                    (bv, rotor) => rotor.OmMapVector(bv)
                );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override BivectorStorage<T> OmMapBivector(BivectorStorage<T> mv)
        {
            return _rotorsList
                .Aggregate(
                    mv, 
                    (bv, rotor) => rotor.OmMapBivector(bv)
                );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override KVectorStorage<T> OmMapKVector(KVectorStorage<T> mv)
        {
            return _rotorsList
                .Aggregate(
                    mv, 
                    (kv, rotor) => rotor.OmMapKVector(kv)
                );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override MultivectorGradedStorage<T> OmMapMultivector(MultivectorGradedStorage<T> mv)
        {
            return _rotorsList
                .Aggregate(
                    mv, 
                    (current, rotor) => rotor.OmMapMultivector(current)
                );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override MultivectorStorage<T> OmMapMultivector(MultivectorStorage<T> mv)
        {
            return _rotorsList
                .Aggregate(
                    mv, 
                    (current, rotor) => rotor.OmMapMultivector(current)
                );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GeoFreeFrame<T> Rotate(GeoFreeFrame<T> frame)
        {
            return _rotorsList
                .Aggregate(
                    frame, 
                    (current, rotor) => rotor.OmMapFreeFrame(current)
                );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rotor<T> GetFinalRotor()
        {
            var storage = _rotorsList
                .Skip(1)
                .Select(r => r.Multivector)
                .Aggregate(
                    _rotorsList[0].Multivector, 
                    (current, rotor) => 
                        GeometricProcessor.Gp(rotor, current)
                );

            return Rotor<T>.Create(GeometricProcessor, storage);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T[,] GetFinalRotorArray(int rowsCount)
        {
            return Rotate(
                GeometricProcessor.CreateBasisFreeFrame((uint) rowsCount)
            ).GetArray(rowsCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerator<PureRotor<T>> GetEnumerator()
        {
            return _rotorsList.GetEnumerator();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<IOutermorphism<T>> GetOutermorphisms()
        {
            return _rotorsList;
        }
    }
}