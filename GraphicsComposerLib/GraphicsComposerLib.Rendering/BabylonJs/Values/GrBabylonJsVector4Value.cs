﻿using DataStructuresLib.Basic;
using NumericalGeometryLib.BasicMath.Tuples.Immutable;

namespace GraphicsComposerLib.Rendering.BabylonJs.Values;

public sealed class GrBabylonJsVector4Value :
    GrBabylonJsValue<IQuad<double>>
{
    internal static GrBabylonJsVector4Value Create(IQuad<double> value)
    {
        return new GrBabylonJsVector4Value(value);
    }


    public static implicit operator GrBabylonJsVector4Value(string valueText)
    {
        return new GrBabylonJsVector4Value(valueText);
    }

    public static implicit operator GrBabylonJsVector4Value(Tuple4D value)
    {
        return new GrBabylonJsVector4Value(value);
    }


    private GrBabylonJsVector4Value(string valueText)
        : base(valueText)
    {
    }

    private GrBabylonJsVector4Value(IQuad<double> value)
        : base(value)
    {
    }


    public override string GetCode()
    {
        return string.IsNullOrEmpty(ValueText) 
            ? Value.GetBabylonJsCode() 
            : ValueText;
    }
}