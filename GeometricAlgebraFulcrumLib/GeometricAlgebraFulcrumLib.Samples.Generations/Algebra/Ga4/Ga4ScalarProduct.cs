using System.Runtime.CompilerServices;

namespace GeometricAlgebraFulcrumLib.Samples.Generations.Algebra.Ga4;

public static class Ga4ScalarProduct
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector0 mv1, Ga4KVector0 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        return new Ga4KVector0
        {
            Scalar = mv1.Scalar * mv2.Scalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector0 mv1, Ga4KVector1 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector0 mv1, Ga4KVector2 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector0 mv1, Ga4KVector3 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector0 mv1, Ga4KVector4 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    public static Ga4KVector0 Sp(this Ga4KVector0 mv1, Ga4Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector0.IsZero())
        {
            tempScalar += mv1.Scalar * mv2.KVector0.Scalar;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector1 mv1, Ga4KVector0 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector1 mv1, Ga4KVector1 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        return new Ga4KVector0
        {
            Scalar = mv1.Scalar1 * mv2.Scalar1 + mv1.Scalar2 * mv2.Scalar2 + mv1.Scalar3 * mv2.Scalar3 + mv1.Scalar4 * mv2.Scalar4
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector1 mv1, Ga4KVector2 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector1 mv1, Ga4KVector3 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector1 mv1, Ga4KVector4 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    public static Ga4KVector0 Sp(this Ga4KVector1 mv1, Ga4Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector1.IsZero())
        {
            tempScalar += mv1.Scalar1 * mv2.KVector1.Scalar1 + mv1.Scalar2 * mv2.KVector1.Scalar2 + mv1.Scalar3 * mv2.KVector1.Scalar3 + mv1.Scalar4 * mv2.KVector1.Scalar4;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector2 mv1, Ga4KVector0 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector2 mv1, Ga4KVector1 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector2 mv1, Ga4KVector2 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        return new Ga4KVector0
        {
            Scalar = -mv1.Scalar12 * mv2.Scalar12 - mv1.Scalar13 * mv2.Scalar13 - mv1.Scalar23 * mv2.Scalar23 - mv1.Scalar14 * mv2.Scalar14 - mv1.Scalar24 * mv2.Scalar24 - mv1.Scalar34 * mv2.Scalar34
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector2 mv1, Ga4KVector3 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector2 mv1, Ga4KVector4 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    public static Ga4KVector0 Sp(this Ga4KVector2 mv1, Ga4Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector2.IsZero())
        {
            tempScalar += -mv1.Scalar12 * mv2.KVector2.Scalar12 - mv1.Scalar13 * mv2.KVector2.Scalar13 - mv1.Scalar23 * mv2.KVector2.Scalar23 - mv1.Scalar14 * mv2.KVector2.Scalar14 - mv1.Scalar24 * mv2.KVector2.Scalar24 - mv1.Scalar34 * mv2.KVector2.Scalar34;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector3 mv1, Ga4KVector0 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector3 mv1, Ga4KVector1 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector3 mv1, Ga4KVector2 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector3 mv1, Ga4KVector3 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        return new Ga4KVector0
        {
            Scalar = -mv1.Scalar123 * mv2.Scalar123 - mv1.Scalar124 * mv2.Scalar124 - mv1.Scalar134 * mv2.Scalar134 - mv1.Scalar234 * mv2.Scalar234
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector3 mv1, Ga4KVector4 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    public static Ga4KVector0 Sp(this Ga4KVector3 mv1, Ga4Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector3.IsZero())
        {
            tempScalar += -mv1.Scalar123 * mv2.KVector3.Scalar123 - mv1.Scalar124 * mv2.KVector3.Scalar124 - mv1.Scalar134 * mv2.KVector3.Scalar134 - mv1.Scalar234 * mv2.KVector3.Scalar234;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector4 mv1, Ga4KVector0 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector4 mv1, Ga4KVector1 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector4 mv1, Ga4KVector2 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector4 mv1, Ga4KVector3 mv2)
    {
        return Ga4KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga4KVector0 Sp(this Ga4KVector4 mv1, Ga4KVector4 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        return new Ga4KVector0
        {
            Scalar = mv1.Scalar1234 * mv2.Scalar1234
        };
    }
    
    public static Ga4KVector0 Sp(this Ga4KVector4 mv1, Ga4Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector4.IsZero())
        {
            tempScalar += mv1.Scalar1234 * mv2.KVector4.Scalar1234;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga4KVector0 Sp(this Ga4Multivector mv1, Ga4KVector0 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector0.IsZero())
        {
            tempScalar += mv1.KVector0.Scalar * mv2.Scalar;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga4KVector0 Sp(this Ga4Multivector mv1, Ga4KVector1 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector1.IsZero())
        {
            tempScalar += mv1.KVector1.Scalar1 * mv2.Scalar1 + mv1.KVector1.Scalar2 * mv2.Scalar2 + mv1.KVector1.Scalar3 * mv2.Scalar3 + mv1.KVector1.Scalar4 * mv2.Scalar4;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga4KVector0 Sp(this Ga4Multivector mv1, Ga4KVector2 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector2.IsZero())
        {
            tempScalar += -mv1.KVector2.Scalar12 * mv2.Scalar12 - mv1.KVector2.Scalar13 * mv2.Scalar13 - mv1.KVector2.Scalar23 * mv2.Scalar23 - mv1.KVector2.Scalar14 * mv2.Scalar14 - mv1.KVector2.Scalar24 * mv2.Scalar24 - mv1.KVector2.Scalar34 * mv2.Scalar34;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga4KVector0 Sp(this Ga4Multivector mv1, Ga4KVector3 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector3.IsZero())
        {
            tempScalar += -mv1.KVector3.Scalar123 * mv2.Scalar123 - mv1.KVector3.Scalar124 * mv2.Scalar124 - mv1.KVector3.Scalar134 * mv2.Scalar134 - mv1.KVector3.Scalar234 * mv2.Scalar234;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga4KVector0 Sp(this Ga4Multivector mv1, Ga4KVector4 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector4.IsZero())
        {
            tempScalar += mv1.KVector4.Scalar1234 * mv2.Scalar1234;
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga4KVector0 Sp(this Ga4Multivector mv1, Ga4Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga4KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector0.IsZero())
        {
            if (!mv2.KVector0.IsZero())
            {
                tempScalar += mv1.KVector0.Scalar * mv2.KVector0.Scalar;
            }
            
        }
        
        if (!mv1.KVector1.IsZero())
        {
            if (!mv2.KVector1.IsZero())
            {
                tempScalar += mv1.KVector1.Scalar1 * mv2.KVector1.Scalar1 + mv1.KVector1.Scalar2 * mv2.KVector1.Scalar2 + mv1.KVector1.Scalar3 * mv2.KVector1.Scalar3 + mv1.KVector1.Scalar4 * mv2.KVector1.Scalar4;
            }
            
        }
        
        if (!mv1.KVector2.IsZero())
        {
            if (!mv2.KVector2.IsZero())
            {
                tempScalar += -mv1.KVector2.Scalar12 * mv2.KVector2.Scalar12 - mv1.KVector2.Scalar13 * mv2.KVector2.Scalar13 - mv1.KVector2.Scalar23 * mv2.KVector2.Scalar23 - mv1.KVector2.Scalar14 * mv2.KVector2.Scalar14 - mv1.KVector2.Scalar24 * mv2.KVector2.Scalar24 - mv1.KVector2.Scalar34 * mv2.KVector2.Scalar34;
            }
            
        }
        
        if (!mv1.KVector3.IsZero())
        {
            if (!mv2.KVector3.IsZero())
            {
                tempScalar += -mv1.KVector3.Scalar123 * mv2.KVector3.Scalar123 - mv1.KVector3.Scalar124 * mv2.KVector3.Scalar124 - mv1.KVector3.Scalar134 * mv2.KVector3.Scalar134 - mv1.KVector3.Scalar234 * mv2.KVector3.Scalar234;
            }
            
        }
        
        if (!mv1.KVector4.IsZero())
        {
            if (!mv2.KVector4.IsZero())
            {
                tempScalar += mv1.KVector4.Scalar1234 * mv2.KVector4.Scalar1234;
            }
            
        }
        
        return new Ga4KVector0
        {
            Scalar = tempScalar
        };
    }
    
}
