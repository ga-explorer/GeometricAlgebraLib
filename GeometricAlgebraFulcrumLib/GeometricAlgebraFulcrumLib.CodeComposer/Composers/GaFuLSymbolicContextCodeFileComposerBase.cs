﻿using GeometricAlgebraFulcrumLib.Processors.SymbolicAlgebra.Context;

namespace GeometricAlgebraFulcrumLib.CodeComposer.Composers
{
    /// <summary>
    /// This class can be used to generate a single base macro or a set of related macros into a single code file. 
    /// Several related bindings of the same macro or related macros can be generated by several calls to the 
    /// GenerateComputationsCode() method with varying binding and target naming results depending on more derived 
    /// class parameters. The SetBaseSymbolicContext() method can be called to change the base macro before calling the
    /// GenerateComputationsCode() method.
    /// </summary>
    public abstract class GaFuLSymbolicContextCodeFileComposerBase : 
        GaFuLCodePartFileComposerBase
    {
        protected GaFuLSymbolicContextCodeFileComposerBase(GaFuLCodeLibraryComposerBase codeLibraryComposer)
            : base(codeLibraryComposer)
        {
        }


        protected virtual void SetContextOptions(SymbolicContextOptions options)
        {
        }

        protected abstract void DefineContextParameters(SymbolicContext context);

        protected abstract void DefineContextComputations(SymbolicContext context);

        protected abstract void DefineContextExternalNames(SymbolicContext context);

        protected virtual void SetContextCodeComposerOptions(GaFuLSymbolicContextCodeComposerOptions options)
        {
        }


        protected string GenerateCode()
        {
            var context = 
                new SymbolicContext(
                    CodeComposer.DefaultContextOptions
                );

            SetContextOptions(context.ContextOptions);

            DefineContextParameters(context);

            DefineContextComputations(context);

            context.OptimizeContext();

            DefineContextExternalNames(context);

            var symbolicContextCodeComposer = 
                new GaFuLSymbolicContextCodeComposer(
                    GeoLanguage, 
                    context, 
                    CodeComposer.DefaultContextCodeComposerOptions
                );

            SetContextCodeComposerOptions(symbolicContextCodeComposer.ComposerOptions);

            return symbolicContextCodeComposer.Generate();
        }
    }
}