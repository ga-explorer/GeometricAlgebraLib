﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DataStructuresLib.BitManipulation;
using GeometricAlgebraFulcrumLib.Algebra.Basis;
using GeometricAlgebraFulcrumLib.Processing.Matrices;
using GeometricAlgebraFulcrumLib.Processing.Multivectors;
using GeometricAlgebraFulcrumLib.Processing.Scalars;
using GeometricAlgebraFulcrumLib.Storage;
using GeometricAlgebraFulcrumLib.Storage.Composers;
using GeometricAlgebraFulcrumLib.Storage.GuidedBinaryTraversal.Outermorphisms;

namespace GeometricAlgebraFulcrumLib.Algebra.Outermorphisms.Computed
{
    public sealed class GaOmComputed<T> 
        : IGaOutermorphism<T>
    {
        public static GaOmComputed<T> Create(IGaMultivectorProcessor<T> multivectorProcessor, T[,] mappedBasisVectorsArray)
        {
            var mappedBasisVectors =
                mappedBasisVectorsArray.ColumnsToVectorStoragesArray(
                    multivectorProcessor.ScalarProcessor
                );

            return new GaOmComputed<T>(multivectorProcessor, mappedBasisVectors);
        }

        public static GaOmComputed<T> Create(IGaMultivectorProcessor<T> multivectorProcessor, IReadOnlyList<IGaVectorStorage<T>> mappedBasisVectors)
        {
            return new GaOmComputed<T>(multivectorProcessor, mappedBasisVectors);
        }


        public int DomainVSpaceDimension 
            => MappedBasisVectors.Count;

        public ulong DomainGaSpaceDimension 
            => MappedBasisVectors.Count.ToGaSpaceDimension();

        public IGaMultivectorProcessor<T> MultivectorProcessor { get; }

        public IGaScalarProcessor<T> ScalarProcessor 
            => MultivectorProcessor.ScalarProcessor;

        public IReadOnlyList<IGaVectorStorage<T>> MappedBasisVectors { get; }
        

        private GaOmComputed([NotNull] IGaMultivectorProcessor<T> multivectorProcessor, [NotNull] IReadOnlyList<IGaVectorStorage<T>> mappedBasisVectors)
        {
            MultivectorProcessor = multivectorProcessor;
            MappedBasisVectors = mappedBasisVectors;
        }


        public T GetDeterminant()
        {
            var mappedPseudoScalar = 
                ScalarProcessor.Op(MappedBasisVectors);

            return MultivectorProcessor.Sp(
                mappedPseudoScalar, 
                MultivectorProcessor.PseudoScalarInverse
            );
        }

        public IReadOnlyList<IGaVectorStorage<T>> GetMappedBasisVectors()
        {
            return MappedBasisVectors;
        }

        public IGaVectorStorage<T> MapBasisVector(int index)
        {
            return MappedBasisVectors[index];
        }

        public IGaVectorStorage<T> MapBasisVector(ulong index)
        {
            return MappedBasisVectors[(int)index];
        }

        public IGaKVectorStorage<T> MapBasisBlade(ulong id)
        {
            if (id == 0)
                return GaScalarTermStorage<T>.CreateBasisScalar(ScalarProcessor);

            if (id.IsBasicPattern())
                return MappedBasisVectors[(int)id.BasisBladeIndex()];

            var kVectorStorageList = 
                MappedBasisVectors.PickItemsUsingPattern(id);

            return ScalarProcessor.Op(kVectorStorageList);
        }

        public IGaKVectorStorage<T> MapBasisBlade(int grade, ulong index)
        {
            if (grade == 0)
                return GaScalarTermStorage<T>.CreateBasisScalar(ScalarProcessor);

            if (grade == 1)
                return MappedBasisVectors[(int)index];

            var id = GaBasisUtils.BasisBladeId(grade, index);

            var kVectorStorageList = 
                MappedBasisVectors.PickItemsUsingPattern(id);

            return ScalarProcessor.Op(kVectorStorageList);
        }
        
        public IGaVectorStorage<T> MapVector(IGaVectorStorage<T> vector)
        {
            var storage = new GaKVectorStorageComposer<T>(ScalarProcessor, 1);

            foreach (var (index, scalar) in vector.GetIndexScalarPairs())
                storage.AddLeftScaledTerms(
                    scalar, 
                    MappedBasisVectors[(int)index].GetIndexScalarPairs()
                );

            storage.RemoveZeroTerms();

            return storage.GetVectorStorage();
        }
        
        public IGaKVectorStorage<T> MapKVector(IGaKVectorStorage<T> kVector)
        {
            var scaledKVectorsList = GaGbtKVectorOutermorphismStack<T>
                .Create(MappedBasisVectors, kVector)
                .TraverseForScaledKVectors();

            var storage = new GaKVectorStorageComposer<T>(ScalarProcessor, kVector.Grade);

            foreach (var (scalingFactor, kVectorStorage) in scaledKVectorsList)
                storage.AddLeftScaledTerms(
                    scalingFactor, 
                    kVectorStorage.GetIndexScalarPairs()
                );

            storage.RemoveZeroTerms();

            return storage.GetKVectorStorage();
        }

        public IGaMultivectorStorage<T> MapMultivector(IGaMultivectorStorage<T> mv)
        {
            var scaledKVectorsList = GaGbtMultivectorOutermorphismStack<T>
                .Create(MappedBasisVectors, mv)
                .TraverseForScaledKVectors();

            var storage = new GaMultivectorGradedStorageComposer<T>(ScalarProcessor);

            storage.AddLeftScaledKVectors(scaledKVectorsList);

            storage.RemoveZeroTerms();

            return storage.GetCompactStorage();
        }


        //public override GaNumMapUnilinear<T, TArray> Adjoint()
        //{
        //    return new GaNumOutermorphism<T, TArray>(
        //        ArraysDomain.Adjoint(VectorsMappingMatrix)
        //    );
        //}

        //public override GaNumMapUnilinear<T, TArray> Inverse()
        //{
        //    return new GaNumOutermorphism<T, TArray>(
        //        ArraysDomain.Inverse(VectorsMappingMatrix)
        //    );
        //}

        //public override GaNumMapUnilinear<T, TArray> InverseAdjoint()
        //{
        //    return new GaNumOutermorphism<T, TArray>(
        //        ArraysDomain.InverseAdjoint(VectorsMappingMatrix)
        //    );
        //}
        

        //public override IEnumerable<Tuple<ulong, GaMultivector<T>>> BasisBladeMaps()
        //{
        //    var mvStack = new Stack<Tuple<int, int>>();
        //    mvStack.Push(
        //        Tuple.Create(0, DomainVSpaceDimension)
        //    );

        //    var opStack = new Stack<GaMultivector<T>>();
        //    opStack.Push(
        //        GaMultivector<T>.CreateScalar(TargetGaSpaceDimension, 1)
        //    );

        //    while (mvStack.Count > 0)
        //    {
        //        var mvNode = mvStack.Pop();
        //        var opNode = opStack.Pop();

        //        if (mvNode.Item2 == 0)
        //        {
        //            yield return Tuple.Create(
        //                mvNode.Item1, 
        //                (GaMultivector<T>) opNode
        //            );

        //            continue;
        //        }

        //        var childNodeTreeDepth = mvNode.Item2 - 1;
        //        var basisVectorMv = 
        //            MappedBasisVectors[mvNode.Item2 - 1];

        //        mvStack.Push(Tuple.Create(
        //            mvNode.Item1 | (1 << childNodeTreeDepth), 
        //            childNodeTreeDepth
        //        ));
        //        opStack.Push(basisVectorMv.Op(opNode));

        //        mvStack.Push(Tuple.Create(
        //            mvNode.Item1, 
        //            childNodeTreeDepth
        //        ));
        //        opStack.Push(opNode);
        //    }
        //}

        //public override IEnumerable<Tuple<ulong, GaMultivector<T>>> BasisVectorMaps()
        //{
        //    return MappedBasisVectors.Select(
        //        (mv, i) => Tuple.Create(i, (GaMultivector<T>) mv)
        //    );
        //}
    }
}