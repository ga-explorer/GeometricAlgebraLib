﻿using DataStructuresLib.AttributeSet;

namespace GraphicsComposerLib.Rendering.KonvaJs.Values
{
    public class GrKonvaJsCodeValue :
        SparseCodeAttributeValue
    {
        public static implicit operator GrKonvaJsCodeValue(string valueText)
        {
            return new GrKonvaJsCodeValue(valueText);
        }

    
        public GrKonvaJsCodeValue(string valueText) 
            : base(valueText)
        {
        }


        public override bool IsEmpty 
            => string.IsNullOrEmpty(ValueText);

        public override string GetCode()
        {
            return ValueText;
        }
    }
}