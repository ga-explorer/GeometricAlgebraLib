using System.Runtime.CompilerServices;

namespace GeometricAlgebraFulcrumLib.Samples.Generations.Algebra.Ga2;

public static class Ga2Norm
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double SpSquared(this Ga2KVector0 mv)
    {
        if (mv.IsZero()) return 0d;
        
        return mv.Scalar * mv.Scalar;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double SpSquared(this Ga2KVector1 mv)
    {
        if (mv.IsZero()) return 0d;
        
        return mv.Scalar1 * mv.Scalar1 + mv.Scalar2 * mv.Scalar2;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double SpSquared(this Ga2KVector2 mv)
    {
        if (mv.IsZero()) return 0d;
        
        return -mv.Scalar12 * mv.Scalar12;
    }
    
    public static double SpSquared(this Ga2Multivector mv)
    {
        if (mv.IsZero()) return 0d;
        
        var normSquared = 0d;
        
        if (!mv.KVector0.IsZero())
        {
            normSquared += mv.KVector0.Scalar * mv.KVector0.Scalar;
        }
        
        if (!mv.KVector1.IsZero())
        {
            normSquared += mv.KVector1.Scalar1 * mv.KVector1.Scalar1 + mv.KVector1.Scalar2 * mv.KVector1.Scalar2;
        }
        
        if (!mv.KVector2.IsZero())
        {
            normSquared += -mv.KVector2.Scalar12 * mv.KVector2.Scalar12;
        }
        
        return normSquared;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double NormSquared(this Ga2KVector0 mv)
    {
        if (mv.IsZero()) return 0d;
        
        return mv.Scalar * mv.Scalar;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double NormSquared(this Ga2KVector1 mv)
    {
        if (mv.IsZero()) return 0d;
        
        return mv.Scalar1 * mv.Scalar1 + mv.Scalar2 * mv.Scalar2;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double NormSquared(this Ga2KVector2 mv)
    {
        if (mv.IsZero()) return 0d;
        
        return mv.Scalar12 * mv.Scalar12;
    }
    
    public static double NormSquared(this Ga2Multivector mv)
    {
        if (mv.IsZero()) return 0d;
        
        var normSquared = 0d;
        
        if (!mv.KVector0.IsZero())
        {
            normSquared += mv.KVector0.Scalar * mv.KVector0.Scalar;
        }
        
        if (!mv.KVector1.IsZero())
        {
            normSquared += mv.KVector1.Scalar1 * mv.KVector1.Scalar1 + mv.KVector1.Scalar2 * mv.KVector1.Scalar2;
        }
        
        if (!mv.KVector2.IsZero())
        {
            normSquared += mv.KVector2.Scalar12 * mv.KVector2.Scalar12;
        }
        
        return normSquared;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Norm(this Ga2KVector0 mv)
    {
        return Math.Sqrt(Math.Abs(mv.NormSquared()));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Norm(this Ga2KVector1 mv)
    {
        return Math.Sqrt(Math.Abs(mv.NormSquared()));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Norm(this Ga2KVector2 mv)
    {
        return Math.Sqrt(Math.Abs(mv.NormSquared()));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Norm(this Ga2Multivector mv)
    {
        return Math.Sqrt(Math.Abs(mv.NormSquared()));
    }
    
}
