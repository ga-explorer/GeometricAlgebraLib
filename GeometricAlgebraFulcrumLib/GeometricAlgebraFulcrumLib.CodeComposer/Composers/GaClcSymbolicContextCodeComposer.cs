﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using CodeComposerLib.SyntaxTree;
using GeometricAlgebraFulcrumLib.CodeComposer.LanguageServers;
using GeometricAlgebraFulcrumLib.Processing.SymbolicExpressions.Context;
using GeometricAlgebraFulcrumLib.Processing.SymbolicExpressions.Variables;
using TextComposerLib.Loggers.Progress;

namespace GeometricAlgebraFulcrumLib.CodeComposer.Composers
{
    /// <summary>
    /// This abstract class can be used to implement a sub-process of macro-based computational code generation 
    /// using the main code library generator components and a macro binding component
    /// </summary>
    public sealed class GaClcSymbolicContextCodeComposer : 
        GaClcCodeStringComposerBase
    {
        private static void GenerateDeclareIntermediateVariablesCode(GaClcSymbolicContextCodeComposer contextCodeComposer)
        {
            var tempVarNames =
                contextCodeComposer
                    .Context
                    .IntermediateVariables
                    .Select(item => item.ExternalName)
                    .Distinct();

            //Add temp variables declaration code
            foreach (var tempVarName in tempVarNames)
                contextCodeComposer.SyntaxList.Add(
                    contextCodeComposer
                        .GaClcLanguage
                        .SyntaxFactory
                        .DeclareLocalVariable(contextCodeComposer.GaClcLanguage.ScalarTypeName, tempVarName)
                    );

            contextCodeComposer.SyntaxList.AddEmptyLine();
        }

        public static void DefaultGenerateCommentsBeforeComputations(GaClcSymbolicContextCodeComposer contextCodeComposer)
        {
            contextCodeComposer.SyntaxList.Add(
                contextCodeComposer.SyntaxFactory.Comment(
                    "Begin GaClc SymbolicContext Code Generation, " + DateTime.Now.ToString("O")
                    )
                );

            contextCodeComposer.SyntaxList.Add(
                contextCodeComposer.SyntaxFactory.Comment("SymbolicContext: " + contextCodeComposer.Context.ContextOptions.ContextName)
                );

            contextCodeComposer.SyntaxList.Add(
                contextCodeComposer.SyntaxFactory.Comment(
                    contextCodeComposer
                        .Context
                        .GetStatisticsReport()
                        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    )
                );

            ISymbolicVariableParameter paramVar;

            var commentTextLines = 
                contextCodeComposer
                    .Context
                    .IndependentAtomics
                    .Select(p =>
                        {
                            var s = new StringBuilder();

                            s.Append("   ").Append(p.InternalName);

                            if (p.IsNumber) 
                                return s.Append(" = constant: '").Append(p.RhsExpressionText).Append("'").ToString();

                            if (!contextCodeComposer.Context.TryGetParameterVariable(p.InternalName, out paramVar))
                                return s.Append(" = constant: '0', the parameter binding was not found in the code block!!").ToString();

                            return (string.IsNullOrEmpty(paramVar.ExternalName))
                                ? s.ToString()
                                : s.Append(" = parameter: ").Append(paramVar.ExternalName).ToString();
                        })
                    .ToArray();

            contextCodeComposer.SyntaxList.Add(
                contextCodeComposer.SyntaxFactory.Comment()
                );

            contextCodeComposer.SyntaxList.Add(
                contextCodeComposer.SyntaxFactory.Comment("SymbolicContext Binding Data: ")
                );

            contextCodeComposer.SyntaxList.Add(contextCodeComposer.SyntaxFactory.Comment(commentTextLines));

            contextCodeComposer.SyntaxList.AddEmptyLine();
        }

        public static void DefaultGenerateCommentsAfterComputations(GaClcSymbolicContextCodeComposer contextCodeComposer)
        {
            contextCodeComposer.SyntaxList.Add(
                contextCodeComposer.SyntaxFactory.Comment(
                    "Finish GaClc SymbolicContext Code Generation, " + DateTime.Now.ToString("O")
                    )
                );
        }

        public static bool DefaultActionBeforeGenerateComputations(GaClcSymbolicContextCodeComposer contextCodeComposer)
        {
            DefaultGenerateCommentsBeforeComputations(contextCodeComposer);

            //GenerateDeclareTempsCode(contextCodeComposer);

            return true;
        }

        public static void DefaultActionAfterGenerateComputations(GaClcSymbolicContextCodeComposer contextCodeComposer)
        {
            DefaultGenerateCommentsAfterComputations(contextCodeComposer);
        }
        

        /// <summary>
        /// The expression converter object used in this class
        /// </summary>
        public GaClcLanguageExpressionConverter ExpressionConverter 
            => LibraryComposer.GaClcLanguage.ExpressionConverter;

        public override string ProgressSourceId 
            => "SymbolicContext Code Composer";

        /// <summary>
        /// The text composer object where all generated macro code is written
        /// </summary>
        public SteSyntaxElementsList SyntaxList { get; }

        /// <summary>
        /// The base macro used for code generation
        /// </summary>
        public SymbolicContext Context { get; private set; }


        public GaClcSymbolicContextCodeComposerOptions ComposerOptions { get; }
            = new GaClcSymbolicContextCodeComposerOptions();


        public GaClcSymbolicContextCodeComposer([NotNull] GaCodeLibraryComposerBase codeLibraryComposer, [NotNull] SymbolicContext context)
            : base(codeLibraryComposer)
        {
            SyntaxList = new SteSyntaxElementsList();

            Context = context;
        }

        public GaClcSymbolicContextCodeComposer([NotNull] GaCodeLibraryComposerBase codeLibraryComposer, [NotNull] SymbolicContext context, [NotNull] GaClcSymbolicContextCodeComposerOptions options)
            : this(codeLibraryComposer, context)
        {
            ComposerOptions.SetOptions(options);
        }


        /// <summary>
        /// Used to replace the context by another one. This clears the internal code composer
        /// </summary>
        /// <param name="context"></param>
        public void SetContext([NotNull] SymbolicContext context)
        {
            SyntaxList.Clear();

            Context = context;
        }

        /// <summary>
        /// Generate the code for a single computation
        /// </summary>
        /// <param name="codeInfo"></param>
        public void GenerateSingleComputationCode(GaClcComputationCodeInfo codeInfo)
        {
            //Generate comment to show symbolic form for this computation
            if (ComposerOptions.AllowGenerateComputationComments)
                SyntaxList.Add(
                    GaClcLanguage
                        .SyntaxFactory
                        .Comment(codeInfo.ComputedVariable.ToString())
                );

            //Generate assignment statement for this computation
            var code =
                codeInfo.ComputedVariable.IsIntermediateVariable && !codeInfo.ComputedVariable.IsReused
                ? (ISyntaxTreeElement)GaClcLanguage
                    .SyntaxFactory
                    .DeclareLocalVariable("var", codeInfo.ExternalName, codeInfo.RhsSimpleTextExpression)
                : GaClcLanguage
                    .SyntaxFactory
                    .AssignToLocalVariable(codeInfo.ExternalName, codeInfo.RhsSimpleTextExpression);

            SyntaxList.Add(code);

            //Add an empty line
            if (ComposerOptions.AllowGenerateComputationComments || codeInfo.ComputedVariable.IsOutputVariable)
                SyntaxList.Add(GaClcLanguage.SyntaxFactory.EmptyLine());
        }

        /// <summary>
        /// Generate the low-level assignments code from the low-level optimized macro code
        /// </summary>
        private void GenerateProcessingCode()
        {
            ExpressionConverter.ActiveContext = Context;

            //Iterate over optimized low-level computations
            foreach (var computedVar in Context.ComputedVariables)
            {
                //Convert the rhs text expression tree into target language code
                var rhsExprCode = 
                    ExpressionConverter.Convert(
                        computedVar.RhsExpression.ToSimpleTextExpression()
                    );

                //Create the codeInfo object
                var codeInfo = new GaClcComputationCodeInfo()
                {
                    ComputedVariable = computedVar,
                    RhsSimpleTextExpression = rhsExprCode,
                    LanguageServer = GaClcLanguage,
                    EnableCodeGeneration = true
                };

                //Generate the assignment target code based on the codeInfo object
                //Execute this action before generating computation code
                ComposerOptions.ActionBeforeGenerateSingleComputation?.Invoke(SyntaxList, codeInfo);

                //If the action prevented generation of code don't generating computation code
                if (codeInfo.EnableCodeGeneration)
                    GenerateSingleComputationCode(codeInfo);

                //Execute this action after generating computation code
                ComposerOptions.ActionAfterGenerateSingleComputation?.Invoke(SyntaxList, codeInfo);
            }

            //SyntaxList.AddEmptyLine();
        }

        /// <summary>
        /// Generate optimized macro code in the target language given a list of macro parameters bindings
        /// </summary>
        /// <returns></returns>
        public override string Generate()
        {
            //Initialize components of macro code generator
            SyntaxList.Clear();

            if (Context.ContextOptions.AllowGenerateCode == false) 
                return string.Empty;

            LibraryComposer.CheckProgressRequestStop();

            var progressId = this.ReportStart(
                "Generating SymbolicContext Code For: " + Context.ContextOptions.ContextName
                );

            try
            {
                this.ReportNormal(
                    "SymbolicContext Binding Ready", 
                    Context.ContextOptions.ToString()
                );
                
                //Generate code before computations for comments, temp declarations, and the like
                var result =
                    ComposerOptions.ActionBeforeGenerateComputations?.Invoke(this) 
                    ?? DefaultActionBeforeGenerateComputations(this);

                //Generate computations code if allowed by last action result
                if (result) 
                    GenerateProcessingCode();

                //Generate code after computations for comments, temp destruction, and the like
                if (ComposerOptions.ActionAfterGenerateComputations == null)
                    DefaultActionAfterGenerateComputations(this);
                else
                    ComposerOptions.ActionAfterGenerateComputations(this);
            }
            catch (Exception e)
            {
                this.ReportError(e);
            }

            //Clean everything up and return final generated code
            ExpressionConverter.ActiveContext = null;

            //Un-parse the SyntaxList into the final code
            var codeText = 
                CodeComposer.GenerateCode(SyntaxList);

            this.ReportFinish(progressId, codeText);

            return codeText;
        }
    }
}