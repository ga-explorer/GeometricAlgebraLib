﻿using SixLabors.ImageSharp;

namespace GraphicsComposerLib.Rendering.BabylonJs.Values;

public sealed class GrBabylonJsColor3ArrayValue :
    GrBabylonJsValue<IReadOnlyList<Color>>
{
    internal static GrBabylonJsColor3ArrayValue Create(IReadOnlyList<Color> value)
    {
        return new GrBabylonJsColor3ArrayValue(value);
    }


    public static implicit operator GrBabylonJsColor3ArrayValue(string valueText)
    {
        return new GrBabylonJsColor3ArrayValue(valueText);
    }

    public static implicit operator GrBabylonJsColor3ArrayValue(Color[] value)
    {
        return new GrBabylonJsColor3ArrayValue(value);
    }


    private GrBabylonJsColor3ArrayValue(string valueText)
        : base(valueText)
    {
    }

    private GrBabylonJsColor3ArrayValue(IReadOnlyList<Color> value)
        : base(value)
    {
    }


    public override string GetCode()
    {
        return string.IsNullOrEmpty(ValueText) 
            ? Value.GetBabylonJsCode(false)
            : ValueText;
    }
}