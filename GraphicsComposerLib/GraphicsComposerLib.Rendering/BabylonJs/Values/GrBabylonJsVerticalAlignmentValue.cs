﻿using GraphicsComposerLib.Rendering.BabylonJs.Constants;

namespace GraphicsComposerLib.Rendering.BabylonJs.Values;

public sealed class GrBabylonJsVerticalAlignmentValue :
    GrBabylonJsValue<GrBabylonJsVerticalAlignment>
{
    public static implicit operator GrBabylonJsVerticalAlignmentValue(string valueText)
    {
        return new GrBabylonJsVerticalAlignmentValue(valueText);
    }

    public static implicit operator GrBabylonJsVerticalAlignmentValue(GrBabylonJsVerticalAlignment value)
    {
        return new GrBabylonJsVerticalAlignmentValue(value);
    }


    private GrBabylonJsVerticalAlignmentValue(string valueText)
        : base(valueText)
    {
    }

    private GrBabylonJsVerticalAlignmentValue(GrBabylonJsVerticalAlignment value)
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