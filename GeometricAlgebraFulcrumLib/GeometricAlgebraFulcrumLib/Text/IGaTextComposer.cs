﻿using System;
using System.Collections.Generic;
using GeometricAlgebraFulcrumLib.Algebra.Basis;
using GeometricAlgebraFulcrumLib.Algebra.Multivectors.Terms;
using GeometricAlgebraFulcrumLib.Processing.Scalars;
using GeometricAlgebraFulcrumLib.Storage;

namespace GeometricAlgebraFulcrumLib.Text
{
    public interface IGaTextComposer<T>
    {
        IGaScalarProcessor<T> ScalarProcessor { get; }

        string GetBasisVectorText(ulong index);

        string GetBasisBladeText(ulong id);

        string GetBasisBladeText(int grade, ulong index);

        string GetBasisBladeText(IGaBasisBlade basisBlade);

        string GetBasisBladeText(IEnumerable<ulong> indexList);

        string GetScalarText(T scalar);

        string GetTermText(ulong id, T scalar);

        string GetTermText(int grade, int index, T scalar);

        string GetTermText(int grade, ulong index, T scalar);

        string GetTermText(KeyValuePair<ulong, T> idScalarPair);

        string GetTermText(Tuple<ulong, T> idScalarPair);

        string GetTermText(Tuple<int, ulong, T> idScalarPair);

        string GetTermText(IGaBasisBlade basisBlade, T scalar);

        string GetTermText(GaTerm<T> term);

        string GetTermsText(IEnumerable<KeyValuePair<ulong, T>> idScalarPairs);

        string GetTermsText(IEnumerable<Tuple<ulong, T>> idScalarTuples);

        string GetTermsText(IEnumerable<Tuple<int, ulong, T>> idScalarTuples);

        string GetTermsText(int grade, IEnumerable<KeyValuePair<ulong, T>> indexScalarPairs);

        string GetTermsText(int grade, IEnumerable<Tuple<ulong, T>> indexScalarTuples);

        string GetTermsText(IEnumerable<GaTerm<T>> terms);

        string GetArrayText(T[] array);
        
        string GetArrayText(T[,] array);

        string GetMultivectorText(IGaMultivectorStorage<T> storage);
    }
}