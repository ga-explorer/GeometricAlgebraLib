﻿using System.Diagnostics.CodeAnalysis;
using DataStructuresLib.Basic;
using GraphicsComposerLib.Rendering.BabylonJs.Values;
using TextComposerLib;

namespace GraphicsComposerLib.Rendering.BabylonJs.Meshes;

public abstract class GrBabylonJsMesh :
    GrBabylonJsObject
{
    public class MeshProperties :
        GrBabylonJsObjectProperties
    {
        public GrBabylonJsMaterialValue? Material { get; set; }

        public GrBabylonJsVector3Value? Position { get; set; }

        public GrBabylonJsVector3Value? Scaling { get; set; }

        public GrBabylonJsQuaternionValue? RotationQuaternion { get; set; }

        public GrBabylonJsColor3Value? EdgesColor { get; set; }

        public GrBabylonJsFloat32Value? EdgesWidth { get; set; }

        public GrBabylonJsBooleanValue? RenderOutline { get; set; }

        public GrBabylonJsColor3Value? OutlineColor { get; set; }

        public GrBabylonJsFloat32Value? OutlineWidth { get; set; }

        public GrBabylonJsBooleanValue? RenderOverlay { get; set; }

        public GrBabylonJsColor3Value? OverlayColor { get; set; }

        public GrBabylonJsFloat32Value? OverlayAlpha { get; set; }

        public GrBabylonJsInt32Value? AlphaIndex { get; set; } //= 0;

        public GrBabylonJsBooleanValue? ShowBoundingBox { get; set; }

        public GrBabylonJsBooleanValue? IsVisible { get; set; }

        public GrBabylonJsBooleanValue? IsPickable { get; set; }

        public GrBabylonJsBooleanValue? IsNearPickable { get; set; }

        public GrBabylonJsBooleanValue? IsNearGrabbable { get; set; }

        public GrBabylonJsBillboardModeValue? BillboardMode { get; set; }


        protected override IEnumerable<Pair<string>?> GetNameValuePairs()
        {
            yield return Material.GetNameValueCodePair("material");
            yield return Position.GetNameValueCodePair("position");
            yield return Scaling.GetNameValueCodePair("scaling");
            yield return RotationQuaternion.GetNameValueCodePair("rotationQuaternion");
            yield return EdgesColor.GetNameValueCodePair("edgesColor");
            yield return EdgesWidth.GetNameValueCodePair("edgesWidth");
            yield return RenderOutline.GetNameValueCodePair("renderOutline");
            yield return OutlineColor.GetNameValueCodePair("outlineColor");
            yield return OutlineWidth.GetNameValueCodePair("outlineWidth");
            yield return RenderOverlay.GetNameValueCodePair("renderOverlay");
            yield return OverlayColor.GetNameValueCodePair("overlayColor");
            yield return OverlayAlpha.GetNameValueCodePair("overlayAlpha");
            yield return AlphaIndex.GetNameValueCodePair("alphaIndex");
            yield return ShowBoundingBox.GetNameValueCodePair("showBoundingBox");
            yield return IsVisible.GetNameValueCodePair("isVisible");
            yield return IsPickable.GetNameValueCodePair("isPickable");
            yield return IsNearPickable.GetNameValueCodePair("isNearPickable");
            yield return IsNearGrabbable.GetNameValueCodePair("isNearGrabbable");
            yield return BillboardMode.GetNameValueCodePair("billboardMode");
        }
    }

    public GrBabylonJsSceneValue ParentScene { get; set; }

    public string SceneVariableName 
        => ParentScene.Value.ConstName;

    public MeshProperties? Properties { get; protected set; }
        = new MeshProperties();

    public override GrBabylonJsObjectProperties? ObjectProperties 
        => Properties;
    

    protected GrBabylonJsMesh(string constName) 
        : base(constName)
    {
    }
    
    protected GrBabylonJsMesh(string constName, [NotNull] GrBabylonJsSceneValue scene) 
        : base(constName)
    {
        ParentScene = scene;
    }


    protected override IEnumerable<string> GetConstructorArguments()
    {
        yield return ConstName.DoubleQuote();

        var optionsCode = 
            ObjectOptions is null 
                ? "{}" 
                : ObjectOptions.GetCode();

        yield return optionsCode;

        if (ParentScene.IsNullOrEmpty()) yield break;
        yield return ParentScene.Value.ConstName;
    }
}