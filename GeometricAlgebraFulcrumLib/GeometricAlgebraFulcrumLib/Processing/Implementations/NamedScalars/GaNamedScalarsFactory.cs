﻿using System.Diagnostics.CodeAnalysis;
using GeometricAlgebraFulcrumLib.Processing.Scalars;

namespace GeometricAlgebraFulcrumLib.Processing.Implementations.NamedScalars
{
    public abstract class GaNamedScalarsFactory<TScalar>
    {
        public GaNamedScalarsCollection<TScalar> NamedScalarsCollection { get; }

        public IGaScalarProcessorNamedScalar<TScalar> NamedScalarProcessor
            => NamedScalarsCollection.NamedScalarProcessor;

        public IGaSymbolicScalarProcessor<TScalar> SymbolicScalarProcessor
            => NamedScalarsCollection.SymbolicScalarProcessor;


        protected GaNamedScalarsFactory([NotNull] GaNamedScalarsCollection<TScalar> namedScalarsCollection)
        {
            NamedScalarsCollection = namedScalarsCollection;
        }
    }
}