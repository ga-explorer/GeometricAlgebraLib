﻿using System.Runtime.CompilerServices;
using GeometricAlgebraFulcrumLib.Algebra.LinearAlgebra.Float64.Vectors.Space2D;
using GeometricAlgebraFulcrumLib.Algebra.LinearAlgebra.Float64.Vectors.Space3D;
using GeometricAlgebraFulcrumLib.Modeling.Geometry.CGa.Float64.Blades;
using GeometricAlgebraFulcrumLib.Modeling.Geometry.CGa.Float64.Encoding;

namespace GeometricAlgebraFulcrumLib.Modeling.Geometry.CGa.Float64.Interpolation;

public static class CGaFloat64LerpIpnsDirectionUtils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CGaFloat64Blade LerpIpnsDirectionLine2D(this double t, CGaFloat64Blade blade1, CGaFloat64Blade blade2)
    {
        return t.LerpLine2D(
            blade1.DecodeIpnsDirection.Element(),
            blade2.DecodeIpnsDirection.Element()
        ).EncodeIpnsBlade();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CGaFloat64Blade LerpIpnsDirectionLine2D(this double t, CGaFloat64Blade blade1, CGaFloat64Blade blade2, LinFloat64Vector2D egaProbeLine)
    {
        return t.LerpLine2D(
            blade1.DecodeIpnsDirection.Element(egaProbeLine.EncodeVGaVector(blade1.GeometricSpace)),
            blade2.DecodeIpnsDirection.Element(egaProbeLine.EncodeVGaVector(blade1.GeometricSpace))
        ).EncodeIpnsBlade();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CGaFloat64Blade LerpIpnsDirectionLine2D(this double t, CGaFloat64Blade blade1, CGaFloat64Blade blade2, CGaFloat64Blade egaProbeLine)
    {
        return t.LerpLine2D(
            blade1.DecodeIpnsDirection.Element(egaProbeLine),
            blade2.DecodeIpnsDirection.Element(egaProbeLine)
        ).EncodeIpnsBlade();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CGaFloat64Blade LerpIpnsDirectionLine3D(this double t, CGaFloat64Blade blade1, CGaFloat64Blade blade2)
    {
        return t.LerpLine3D(
            blade1.DecodeIpnsDirection.Element(),
            blade2.DecodeIpnsDirection.Element()
        ).EncodeIpnsBlade();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CGaFloat64Blade LerpIpnsDirectionLine3D(this double t, CGaFloat64Blade blade1, CGaFloat64Blade blade2, LinFloat64Vector3D egaProbeLine)
    {
        return t.LerpLine3D(
            blade1.DecodeIpnsDirection.Element(egaProbeLine.EncodeVGaVector(blade1.GeometricSpace)),
            blade2.DecodeIpnsDirection.Element(egaProbeLine.EncodeVGaVector(blade1.GeometricSpace))
        ).EncodeIpnsBlade();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CGaFloat64Blade LerpIpnsDirectionLine3D(this double t, CGaFloat64Blade blade1, CGaFloat64Blade blade2, CGaFloat64Blade egaProbeLine)
    {
        return t.LerpLine3D(
            blade1.DecodeIpnsDirection.Element(egaProbeLine),
            blade2.DecodeIpnsDirection.Element(egaProbeLine)
        ).EncodeIpnsBlade();
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CGaFloat64Blade LerpIpnsDirectionPlane3D(this double t, CGaFloat64Blade blade1, CGaFloat64Blade blade2)
    {
        return t.LerpPlane3D(
            blade1.DecodeIpnsDirection.Element(),
            blade2.DecodeIpnsDirection.Element()
        ).EncodeIpnsBlade();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CGaFloat64Blade LerpIpnsDirectionPlane3D(this double t, CGaFloat64Blade blade1, CGaFloat64Blade blade2, LinFloat64Vector3D egaProbePlane)
    {
        return t.LerpPlane3D(
            blade1.DecodeIpnsDirection.Element(egaProbePlane.EncodeVGaVector(blade1.GeometricSpace)),
            blade2.DecodeIpnsDirection.Element(egaProbePlane.EncodeVGaVector(blade1.GeometricSpace))
        ).EncodeIpnsBlade();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CGaFloat64Blade LerpIpnsDirectionPlane3D(this double t, CGaFloat64Blade blade1, CGaFloat64Blade blade2, CGaFloat64Blade egaProbePlane)
    {
        return t.LerpPlane3D(
            blade1.DecodeIpnsDirection.Element(egaProbePlane),
            blade2.DecodeIpnsDirection.Element(egaProbePlane)
        ).EncodeIpnsBlade();
    }
}