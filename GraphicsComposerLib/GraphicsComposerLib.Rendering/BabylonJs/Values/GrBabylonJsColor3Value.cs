﻿using GraphicsComposerLib.Rendering.BabylonJs.Constants;
using GraphicsComposerLib.Rendering.Colors;
using SixLabors.ImageSharp;

namespace GraphicsComposerLib.Rendering.BabylonJs.Values;

public sealed class GrBabylonJsColor3Value :
    GrBabylonJsValue<Color>
{
    public static implicit operator GrBabylonJsColor3Value(string valueText)
    {
        return new GrBabylonJsColor3Value(valueText);
    }
    
    public static implicit operator GrBabylonJsColor3Value(System.Drawing.Color value)
    {
        return new GrBabylonJsColor3Value(value.ToImageSharpColor());
    }

    public static implicit operator GrBabylonJsColor3Value(Color value)
    {
        return new GrBabylonJsColor3Value(value);
    }
    
    public static implicit operator GrBabylonJsColor3Value(GrBabylonJsNamedColor3 value)
    {
        return new GrBabylonJsColor3Value(value.GetBabylonJsCode());
    }


    private GrBabylonJsColor3Value(string valueText)
        : base(valueText)
    {
    }

    private GrBabylonJsColor3Value(Color value)
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