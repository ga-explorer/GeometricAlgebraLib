﻿using System.Collections.Immutable;
using DataStructuresLib.Files;
using GraphicsComposerLib.Geometry.ParametricShapes.Curves;
using GraphicsComposerLib.Geometry.ParametricShapes.Curves.Roulettes;
using GraphicsComposerLib.Geometry.ParametricShapes.Curves.Sampled;
using GraphicsComposerLib.Rendering.BabylonJs;
using GraphicsComposerLib.Rendering.BabylonJs.Constants;
using GraphicsComposerLib.Rendering.BabylonJs.GUI;
using NumericalGeometryLib.BasicMath;
using NumericalGeometryLib.Borders.Space1D.Immutable;
using SixLabors.ImageSharp;

namespace GeometricAlgebraFulcrumLib.Applications.Graphics;

public class RouletteParametricVisualizer3D :
    GrBabylonJsSnapshotComposer3D
{
    private GrRouletteCurve3D? _activeCurve;


    public Func<double, GrRouletteCurve3D> CurveFunction { get; }
    
    public int FixedCurveFrameCount { get; }
    
    public int MovingCurveFrameCount { get; }


    public RouletteParametricVisualizer3D(IReadOnlyList<double> cameraAlphaValues, IReadOnlyList<double> cameraBetaValues, Func<double, GrRouletteCurve3D> curveFunction, int fixedCurveFrameCount, int movingCurveFrameCount)
        : base(cameraAlphaValues, cameraBetaValues)
    {
        CurveFunction = curveFunction;
        FixedCurveFrameCount = fixedCurveFrameCount;
        MovingCurveFrameCount = movingCurveFrameCount;
    } 

    
    protected override GrBabylonJsHtmlComposer3D InitializeSceneComposers(int index)
    {
        var mainSceneComposer = new GrBabylonJsSceneComposer3D(
            "mainScene",
            new GrBabylonJsSnapshotSpecs
            {
                Enabled = true,
                Width = CanvasWidth,
                Height = CanvasHeight,
                Precision = 1,
                UsePrecision = true,
                Delay = index == 0 ? 2000 : 1000,
                FileName = $"Frame-{index:D6}.png"
            }
        )
        {
            BackgroundColor = Color.AliceBlue,
            ShowDebugLayer = false,
        };

        //mainSceneComposer.SceneObject.SceneProperties.UseOrderIndependentTransparency = true;

        var htmlComposer = new GrBabylonJsHtmlComposer3D(mainSceneComposer)
        {
            CanvasWidth = CanvasWidth,
            CanvasHeight = CanvasHeight,
            CanvasFullScreen = false
        };

        return htmlComposer;
    }

    protected override void InitializeImageCache()
    {
        var workingPath = Path.Combine(WorkingPath, "images");

        Console.Write("Generating images cache .. ");

        ImageCache.MarginSize = 0;
        ImageCache.BackgroundColor = Color.FromRgba(255, 255, 255, 0);

        ImageCache.AddPngFromFile(
            "copyright",
            workingPath.GetFilePath("Copyright-1.png")
        );
        
        Console.WriteLine("done.");
        Console.WriteLine();
    }

    protected override void AddCamera(int index)
    {
        base.AddCamera(index);
    }

    protected override void AddEnvironment()
    {
        base.AddEnvironment();
    }

    protected override void AddGrid()
    {
        base.AddGrid();
    }

    protected override void AddGuiLayer(int index)
    {
        var scene = MainSceneComposer.SceneObject;

        // Add GUI layer
        var uiTexture = scene.AddGuiFullScreenUi("uiTexture");
        
        if (ShowCopyright)
        {
            var copyrightImage = ImageCache["copyright"];
            var copyrightImageWidth = 0.4d * HtmlComposer.CanvasWidth;
            var copyrightImageHeight = 0.4d * HtmlComposer.CanvasWidth * copyrightImage.HeightToWidthRatio;

            uiTexture.AddGuiImage(
                "copyrightImage",
                copyrightImage.GetBase64HtmlString(),
                new GrBabylonJsGuiImage.GuiImageProperties
                {
                    Stretch = GrBabylonJsImageStretch.Uniform,
                    //Alpha = 0.75d,
                    WidthInPixels = copyrightImageWidth,
                    HeightInPixels = copyrightImageHeight,
                    PaddingLeftInPixels = 10,
                    PaddingBottomInPixels = 10,
                    HorizontalAlignment = GrBabylonJsHorizontalAlignment.Left,
                    VerticalAlignment = GrBabylonJsVerticalAlignment.Bottom,
                }
            );
        }
    }

    private void AddFixedCurve()
    {
        if (_activeCurve is null)
            throw new NullReferenceException();

        var tMin = _activeCurve.FixedCurve.ParameterValueMin;
        var tMax = _activeCurve.FixedCurve.ParameterValueMax;

        var tValues =
            tMin.GetLinearRange(tMax, 501, false).ToImmutableArray();

        var tValuesFrames = 
            tMin.GetLinearRange(tMax, FixedCurveFrameCount, false).ToImmutableArray();
        
        MainSceneComposer.AddParametricCurve(
            "fixedCurve", 
            _activeCurve.FixedCurve, 
            tValues, 
            tValuesFrames,
            Color.DarkRed,
            0.035
        );
    }
    
    private void AddMovingCurve()
    {
        if (_activeCurve is null)
            throw new NullReferenceException();

        var tMin = _activeCurve.MovingCurve.ParameterValueMin;
        var tMax = _activeCurve.MovingCurve.ParameterValueMax;

        var tValues =
            tMin.GetLinearRange(tMax, 501, false).ToImmutableArray();
        
        var tValuesFrames = 
            tMin.GetLinearRange(tMax, MovingCurveFrameCount, false).ToImmutableArray();
        
        MainSceneComposer.AddParametricCurve(
            "movingCurve",
            _activeCurve.MovingCurve,
            tValues,
            tValuesFrames,
            Color.DarkGreen,
            0.035
        );

        //var frame = _activeCurve.FixedCurve.GetFrame(_activeCurve.FixedCurve.LengthToParameter(t));
        //MainSceneComposer.AddElement(
        //    new GrVisualFrame3D("frame")
        //    {
        //        Origin = frame.Point,

        //        Direction1 = frame.Tangent,
        //        Direction2 = frame.Normal1,
        //        Direction3 = frame.Normal2,

        //        Style = new GrVisualFrameStyle3D
        //        {
        //            OriginThickness = 0.075,
        //            DirectionThickness = 0.035,
        //            OriginMaterial = scene.AddSimpleMaterial("frameOrigin", Color.Gray),
        //            DirectionMaterial1 = scene.AddSimpleMaterial("frameTangent", Color.DarkRed),
        //            DirectionMaterial2 = scene.AddSimpleMaterial("frameNormal1", Color.DarkGreen),
        //            DirectionMaterial3 = scene.AddSimpleMaterial("frameNormal2", Color.DarkBlue)
        //        }
        //    }
        //);
    }

    private void AddGeneratorPoint()
    {
        if (_activeCurve is null)
            throw new NullReferenceException();

        var scene = MainSceneComposer.SceneObject;

        var material = scene.AddStandardMaterial(
            "generatorPointMaterial", 
            Color.Blue
        );

        MainSceneComposer.AddPoint(
            "generatorPoint", 
            _activeCurve.GeneratorPoint, 
            material, 
            0.2
        );
    }

    private void AddRouletteCurve()
    {
        if (_activeCurve is null)
            throw new NullReferenceException();
        
        var sampledCurve = _activeCurve.CreateSampledCurve3D(
            BoundingBox1D.Create(
                _activeCurve.ParameterValueMin, 
                _activeCurve.ParameterValueMax
            ), 
            new GrParametricCurveTreeOptions3D(5.DegreesToAngle(), 3, 16)
        );

        var pointList =
            sampledCurve.GetPoints().ToImmutableArray();

        MainSceneComposer.AddLinePath(
            "rouletteCurve",
            pointList,
            Color.Blue,
            0.08
        );
    }

    protected override GrBabylonJsHtmlComposer3D GenerateSnapshotCode(int index)
    {
        base.GenerateSnapshotCode(index);

        _activeCurve = CurveFunction(index / (FrameCount - 1d));

        AddFixedCurve();
        AddMovingCurve();
        AddGeneratorPoint();
        AddRouletteCurve();

        return HtmlComposer;
    }
}