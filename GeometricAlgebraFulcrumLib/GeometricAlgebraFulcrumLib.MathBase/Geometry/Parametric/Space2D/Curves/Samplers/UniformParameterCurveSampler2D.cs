﻿using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DataStructuresLib.Basic;
using GeometricAlgebraFulcrumLib.MathBase.Geometry.Borders;
using GeometricAlgebraFulcrumLib.MathBase.Geometry.Parametric.Space2D.Frames;
using GeometricAlgebraFulcrumLib.MathBase.LinearAlgebra.Float64.Vectors.Space2D;

namespace GeometricAlgebraFulcrumLib.MathBase.Geometry.Parametric.Space2D.Curves.Samplers;

public class UniformParameterCurveSampler2D :
    IParametricCurveSampler2D
{
    public IParametricCurve2D Curve { get; private set; }

    public Float64Range1D ParameterRange { get; private set; }

    public bool IsPeriodic { get; private set; }

    public double ParameterSectionLength { get; private set; }

    public int Count { get; private set; }

    public ParametricCurveLocalFrame2D this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                if (IsPeriodic)
                    index = index.Mod(Count);

                else
                    throw new IndexOutOfRangeException();
            }

            return Curve.GetFrame(
                ParameterRange.MinValue + index * ParameterSectionLength
            );
        }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UniformParameterCurveSampler2D(IParametricCurve2D curve, Float64Range1D parameterRange, int count, bool isPeriodic = false)
    {
        if ((isPeriodic && count < 1) || (!isPeriodic && count < 2))
            throw new ArgumentOutOfRangeException(nameof(count));

        Count = count;
        IsPeriodic = isPeriodic;
        Curve = curve;
        ParameterRange = parameterRange;
        ParameterSectionLength = isPeriodic 
            ? parameterRange.Length / count
            : parameterRange.Length / (count - 1);

        Debug.Assert(IsValid());
    }
    
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsValid()
    {
        return ParameterRange.IsValid() &&
               Curve.IsValid() &&
               ((IsPeriodic && Count > 0) || (!IsPeriodic && Count > 1));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UniformParameterCurveSampler2D SetCurve(IParametricCurve2D curve, Float64Range1D parameterRange, int count, bool isPeriodic)
    {
        if ((isPeriodic && count < 1) || (!isPeriodic && count < 2))
            throw new ArgumentOutOfRangeException(nameof(count));

        Curve = curve;
        ParameterRange = parameterRange;
        Count = count;
        IsPeriodic = isPeriodic;
        ParameterSectionLength = isPeriodic 
            ? ParameterRange.Length / count
            : ParameterRange.Length / (count - 1);
        
        Debug.Assert(IsValid());

        return this;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<double> GetParameterValues()
    {
        return Enumerable
            .Range(0, Count)
            .Select(i => 
                ParameterRange.MinValue + i * ParameterSectionLength
            );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<Float64Range1D> GetParameterSections()
    {
        return Enumerable
            .Range(0, Count)
            .Select(i => 
                Float64Range1D.Create(
                    ParameterRange.MinValue + i * ParameterSectionLength,
                    ParameterRange.MinValue + (i + 1) * ParameterSectionLength
                )
            );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<Float64Vector2D> GetPoints()
    {
        return Enumerable
            .Range(0, Count)
            .Select(i => 
                Curve.GetPoint(
                    ParameterRange.MinValue + i * ParameterSectionLength
                )
            );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<Float64Vector2D> GetTangents()
    {
        return Enumerable
            .Range(0, Count)
            .Select(i => 
                Curve.GetTangent(
                    ParameterRange.MinValue + i * ParameterSectionLength
                )
            );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<ParametricCurveLocalFrame2D> GetFrames()
    {
        return Enumerable
            .Range(0, Count)
            .Select(i => 
                Curve.GetFrame(
                    ParameterRange.MinValue + i * ParameterSectionLength
                )
            );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerator<ParametricCurveLocalFrame2D> GetEnumerator()
    {
        return GetFrames().GetEnumerator();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}