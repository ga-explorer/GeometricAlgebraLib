﻿using GeometricAlgebraFulcrumLib.Core.Algebra.GeometricAlgebra.Restricted.Float64.LinearMaps.Outermorphisms;
using GeometricAlgebraFulcrumLib.Core.Algebra.GeometricAlgebra.Restricted.Float64.Multivectors;
using GeometricAlgebraFulcrumLib.Core.Algebra.GeometricAlgebra.Restricted.Float64.Multivectors.Composers;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using GeometricAlgebraFulcrumLib.Utilities.Structures.BitManipulation;
using GeometricAlgebraFulcrumLib.Core.Algebra.GeometricAlgebra.Basis;
using GeometricAlgebraFulcrumLib.Core.Algebra.LinearAlgebra.Float64.Vectors.Space2D;
using GeometricAlgebraFulcrumLib.Core.Algebra.LinearAlgebra.Float64.Vectors.Space3D;
using GeometricAlgebraFulcrumLib.Core.Algebra.LinearAlgebra.Float64.Vectors.SpaceND;
using GeometricAlgebraFulcrumLib.Core.Algebra.Scalars.Float64;

namespace GeometricAlgebraFulcrumLib.Core.Algebra.GeometricAlgebra.Restricted.Float64.Processors;

/// <summary>
/// https://en.wikipedia.org/wiki/Conformal_geometric_algebra
/// </summary>
public class RGaFloat64ConformalProcessor :
    RGaFloat64Processor
{
    public static RGaFloat64ConformalProcessor Instance { get; }
        = new RGaFloat64ConformalProcessor();


    public RGaFloat64Vector En { get; }

    public RGaFloat64Vector Ep { get; }

    public RGaFloat64Vector Eo { get; }

    public RGaFloat64Vector Ei { get; }
    
    public RGaFloat64MusicalAutomorphism MusicalAutomorphism 
        => RGaFloat64MusicalAutomorphism.Instance;
    

    private RGaFloat64ConformalProcessor()
        : base(1, 0)
    {
        En = this
            .CreateComposer()
            .SetVectorTerm(0, 1)
            .GetVector();
        
        Ep = this
            .CreateComposer()
            .SetVectorTerm(1, 1)
            .GetVector();

        Eo = this
            .CreateComposer()
            .SetVectorTerm(0, 0.5d)
            .SetVectorTerm(1, 0.5d)
            .GetVector();

        Ei = this
            .CreateComposer()
            .SetVectorTerm(0, 1d)
            .SetVectorTerm(1, -1d)
            .GetVector();
    }
    

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsValidHGaPoint(RGaFloat64Vector hgaPoint)
    {
        var sn = hgaPoint[0];
        var sp = hgaPoint[1];

        return sn.IsNearEqual(sp);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsValidPGaPoint(RGaFloat64KVector pgaPoint, int vSpaceDimensions)
    {
        var hgaPoint = 
            PGaDual(pgaPoint, vSpaceDimensions);

        return hgaPoint.Grade == 1 && 
               IsValidHGaPoint(
                   hgaPoint.GetVectorPart()
               );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsValidIpnsPoint(RGaFloat64Vector ipnsPoint)
    {
        var sn = ipnsPoint[0];
        var sp = ipnsPoint[1];

        return sn.IsNearEqual(sp);
    }
    
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64KVector PGaDual(RGaFloat64KVector mv, int vSpaceDimensions)
    {
        //Debug.Assert(
        //    IsValidPGaElement(mv)
        //);

        var icInv = 
            this.PseudoScalarInverse(vSpaceDimensions);

        return MusicalAutomorphism.OmMap(
            mv.Op(Ei).Lcp(icInv)
            // Also can be mv.Op(Ei).Lcp(Ic)
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Multivector PGaDual(RGaFloat64Multivector mv, int vSpaceDimensions)
    {
        //Debug.Assert(
        //    IsValidPGaElement(mv)
        //);

        var icInv = 
            this.PseudoScalarInverse(vSpaceDimensions);

        return MusicalAutomorphism.OmMap(
            mv.Op(Ei).Lcp(icInv)
            // Also can be mv.Op(Ei).Lcp(Ic)
        );
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeEGaVector(double x, double y)
    {
        return this
            .CreateComposer()
            .SetVectorTerm(2, x)
            .SetVectorTerm(3, y)
            .GetVector();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeEGaVector(double x, double y, double z)
    {
        return this
            .CreateComposer()
            .SetVectorTerm(2, x)
            .SetVectorTerm(3, y)
            .SetVectorTerm(4, z)
            .GetVector();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeEGaVector(LinFloat64Vector2D egaVector)
    {
        return this
            .CreateComposer()
            .SetVectorTerm(2, egaVector.X.ScalarValue)
            .SetVectorTerm(3, egaVector.Y.ScalarValue)
            .GetVector();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeEGaVector(LinFloat64Vector3D egaVector)
    {
        return this
            .CreateComposer()
            .SetVectorTerm(2, egaVector.X.ScalarValue)
            .SetVectorTerm(3, egaVector.Y.ScalarValue)
            .SetVectorTerm(4, egaVector.Z.ScalarValue)
            .GetVector();
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeHGaPoint(double x, double y)
    {
        return this
            .CreateComposer()
            .SetVectorTerm(0, 0.5)
            .SetVectorTerm(1, 0.5)
            .SetVectorTerm(2, x)
            .SetVectorTerm(3, y)
            .GetVector();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeHGaPoint(double x, double y, double z)
    {
        return this
            .CreateComposer()
            .SetVectorTerm(0, 0.5)
            .SetVectorTerm(1, 0.5)
            .SetVectorTerm(2, x)
            .SetVectorTerm(3, y)
            .SetVectorTerm(4, z)
            .GetVector();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeHGaPoint(LinFloat64Vector2D egaVector)
    {
        return this
            .CreateComposer()
            .SetVectorTerm(0, 0.5)
            .SetVectorTerm(1, 0.5)
            .SetVectorTerm(2, egaVector.X.ScalarValue)
            .SetVectorTerm(3, egaVector.Y.ScalarValue)
            .GetVector();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeHGaPoint(LinFloat64Vector3D egaVector)
    {
        return this
            .CreateComposer()
            .SetVectorTerm(0, 0.5)
            .SetVectorTerm(1, 0.5)
            .SetVectorTerm(2, egaVector.X.ScalarValue)
            .SetVectorTerm(3, egaVector.Y.ScalarValue)
            .SetVectorTerm(4, egaVector.Z.ScalarValue)
            .GetVector();
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64KVector EncodePGaPoint(double x, double y)
    {
        return PGaDual(
            EncodeHGaPoint(x, y), 
            4
        );
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64KVector EncodePGaPoint(double x, double y, double z)
    {
        return PGaDual(
            EncodeHGaPoint(x, y, z), 
            5
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64KVector EncodePGaPoint(LinFloat64Vector2D egaPoint)
    {
        return PGaDual(
            EncodeHGaPoint(egaPoint), 
            4
        );
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64KVector EncodePGaPoint(LinFloat64Vector3D egaPoint)
    {
        return PGaDual(
            EncodeHGaPoint(egaPoint), 
            5
        );
    }

    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeIpnsPoint(double x, double y)
    {
        var x2 = x * x + y * y;
        var sn = 0.5 * (1 + x2);
        var sp = 0.5 * (1 - x2);

        return this
            .CreateComposer()
            .SetVectorTerm(0, sn)
            .SetVectorTerm(1, sp)
            .SetVectorTerm(2, x)
            .SetVectorTerm(3, y)
            .GetVector();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeIpnsPoint(double x, double y, double z)
    {
        var x2 = x * x + y * y + z * z;
        var sn = 0.5 * (1 + x2);
        var sp = 0.5 * (1 - x2);

        return this
            .CreateComposer()
            .SetVectorTerm(0, sn)
            .SetVectorTerm(1, sp)
            .SetVectorTerm(2, x)
            .SetVectorTerm(3, y)
            .SetVectorTerm(4, z)
            .GetVector();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeIpnsPoint(LinFloat64Vector2D egaPoint)
    {
        var x2 = egaPoint.VectorENormSquared();
        var sn = 0.5 * (1 + x2);
        var sp = 0.5 * (1 - x2);

        return this
            .CreateComposer()
            .SetVectorTerm(0, sn)
            .SetVectorTerm(1, sp)
            .SetVectorTerm(2, egaPoint.X.ScalarValue)
            .SetVectorTerm(3, egaPoint.Y.ScalarValue)
            .GetVector();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector EncodeIpnsPoint(LinFloat64Vector3D egaPoint)
    {
        var x2 = egaPoint.VectorENormSquared();
        var sn = 0.5 * (1 + x2);
        var sp = 0.5 * (1 - x2);

        return this
            .CreateComposer()
            .SetVectorTerm(0, sn)
            .SetVectorTerm(1, sp)
            .SetVectorTerm(2, egaPoint.X.ScalarValue)
            .SetVectorTerm(3, egaPoint.Y.ScalarValue)
            .SetVectorTerm(4, egaPoint.Z.ScalarValue)
            .GetVector();
    }
    
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector2D DecodeEGaVectorAsVector2D(RGaFloat64Vector egaVector)
    {
        return LinFloat64Vector2D.Create(
            egaVector[2],
            egaVector[3]
        );
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector2D DecodeEGaVectorAsVector2D(RGaFloat64Vector egaVector, double scalingFactor)
    {
        return LinFloat64Vector2D.Create(
            egaVector[2] * scalingFactor,
            egaVector[3] * scalingFactor
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector3D DecodeEGaVectorAsVector3D(RGaFloat64Vector egaVector)
    {
        return LinFloat64Vector3D.Create(
            egaVector[2],
            egaVector[3],
            egaVector[4]
        );
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector3D DecodeEGaVectorAsVector3D(RGaFloat64Vector egaVector, double scalingFactor)
    {
        return LinFloat64Vector3D.Create(
            egaVector[2] * scalingFactor,
            egaVector[3] * scalingFactor,
            egaVector[4] * scalingFactor
        );
    }
    
    public LinFloat64Vector DecodeEGaVectorAsVector(RGaFloat64Vector egaVector)
    {
        var composer = LinFloat64VectorComposer.Create();

        foreach (var (id, scalar) in egaVector.IdScalarPairs)
        {
            var index = id.FirstOneBitPosition();

            if (index is 0 or 1) continue;

            composer.SetTerm(
                index - 2, 
                scalar
            );
        }

        return composer.GetVector();
    }

    public LinFloat64Vector DecodeEGaVectorAsVector(RGaFloat64Vector egaVector, double scalingFactor)
    {
        var composer = LinFloat64VectorComposer.Create();

        foreach (var (id, scalar) in egaVector.IdScalarPairs)
        {
            var index = id.FirstOneBitPosition();

            if (index is 0 or 1) continue;

            composer.SetTerm(
                index - 2, 
                scalar * scalingFactor
            );
        }

        return composer.GetVector();
    }

    public RGaFloat64Vector DecodeEGaVector(RGaFloat64Vector egaVector)
    {
        var composer = RGaFloat64EuclideanProcessor.Instance.CreateComposer();

        foreach (var (id, scalar) in egaVector.IdScalarPairs)
        {
            var index = id.FirstOneBitPosition();

            if (index is 0 or 1) continue;

            composer.SetTerm(
                (index - 2).BasisVectorIndexToId(), 
                scalar
            );
        }

        return composer.GetVector();
    }
    
    public RGaFloat64Vector DecodeEGaVector(RGaFloat64Vector egaVector, double scalingFactor)
    {
        var composer = RGaFloat64EuclideanProcessor.Instance.CreateComposer();

        foreach (var (id, scalar) in egaVector.IdScalarPairs)
        {
            var index = id.FirstOneBitPosition();

            if (index is 0 or 1) continue;

            composer.SetTerm(
            (index - 2).BasisVectorIndexToId(), 
                scalar * scalingFactor
            );
        }

        return composer.GetVector();
    }

    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector2D DecodeHGaPointAsVector2D(RGaFloat64Vector hgaPoint)
    {
        Debug.Assert(IsValidHGaPoint(hgaPoint));

        return DecodeEGaVectorAsVector2D(
            hgaPoint, 
            1d / (hgaPoint[0] + hgaPoint[1])
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector3D DecodeHGaPointAsVector3D(RGaFloat64Vector hgaPoint)
    {
        Debug.Assert(IsValidHGaPoint(hgaPoint));

        return DecodeEGaVectorAsVector3D(
            hgaPoint, 
            1d / (hgaPoint[0] + hgaPoint[1])
        );
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector DecodeHGaPoint(RGaFloat64Vector hgaPoint)
    {
        Debug.Assert(IsValidHGaPoint(hgaPoint));

        return DecodeEGaVector(
            hgaPoint, 
            1d / (hgaPoint[0] + hgaPoint[1])
        );
    }

    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector2D DecodePGaPointAsVector2D(RGaFloat64KVector pgaPoint)
    {
        if (pgaPoint.Grade != 2)
            throw new InvalidOperationException();

        var hgaPoint = 
            PGaDual(pgaPoint, 4).GetVectorPart();

        return DecodeHGaPointAsVector2D(hgaPoint);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector3D DecodePGaPointAsVector3D(RGaFloat64KVector pgaPoint)
    {
        if (pgaPoint.Grade != 3)
            throw new InvalidOperationException();

        var hgaPoint = 
            PGaDual(pgaPoint, 5).GetVectorPart();
        
        return DecodeHGaPointAsVector3D(hgaPoint);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector DecodePGaPoint(RGaFloat64KVector pgaPoint, int vSpaceDimensions)
    {
        if (pgaPoint.Grade != vSpaceDimensions - 2)
            throw new InvalidOperationException();

        var hgaPoint = 
            PGaDual(pgaPoint, vSpaceDimensions).GetVectorPart();
        
        return DecodeHGaPoint(hgaPoint);
    }

    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector2D DecodeIpnsPointAsVector2D(RGaFloat64Vector ipnsPoint)
    {
        Debug.Assert(IsValidIpnsPoint(ipnsPoint));

        return DecodeEGaVectorAsVector2D(
            ipnsPoint, 
            1d / (ipnsPoint[0] + ipnsPoint[1])
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LinFloat64Vector3D DecodeIpnsPointAsVector3D(RGaFloat64Vector ipnsPoint)
    {
        Debug.Assert(IsValidIpnsPoint(ipnsPoint));

        return DecodeEGaVectorAsVector3D(
            ipnsPoint, 
            1d / (ipnsPoint[0] + ipnsPoint[1])
        );
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RGaFloat64Vector DecodeIpnsPoint(RGaFloat64Vector ipnsPoint)
    {
        Debug.Assert(IsValidIpnsPoint(ipnsPoint));

        return DecodeEGaVector(
            ipnsPoint, 
            1d / (ipnsPoint[0] + ipnsPoint[1])
        );
    }


    public RGaFloat64KVector PGaRp(RGaFloat64KVector mv1, RGaFloat64KVector mv2, int vSpaceDimensions)
    {
        var icInv = 
            this.PseudoScalarInverse(vSpaceDimensions);

        var mv1Dual = MusicalAutomorphism.OmMap(
            mv1.Op(Ei).Lcp(icInv)
        );
        
        var mv2Dual = MusicalAutomorphism.OmMap(
            mv2.Op(Ei).Lcp(icInv)
        );

        return MusicalAutomorphism.OmMap(
            mv1Dual.Op(mv2Dual).Op(Ei).Lcp(icInv)
        );
    }

    public RGaFloat64Multivector PGaRp(RGaFloat64Multivector mv1, RGaFloat64Multivector mv2, int vSpaceDimensions)
    {
        var icInv = 
            this.PseudoScalarInverse(vSpaceDimensions);

        var mv1Dual = MusicalAutomorphism.OmMap(
            mv1.Op(Ei).Lcp(icInv)
        );
        
        var mv2Dual = MusicalAutomorphism.OmMap(
            mv2.Op(Ei).Lcp(icInv)
        );

        return MusicalAutomorphism.OmMap(
            mv1Dual.Op(mv2Dual).Op(Ei).Lcp(icInv)
        );
    }
}