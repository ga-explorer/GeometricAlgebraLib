using System.Runtime.CompilerServices;

namespace GeometricAlgebraFulcrumLib.Samples.Generations.Algebra.Ga501;

public static class Ga501ScalarProduct
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector0 mv1, Ga501KVector0 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        return new Ga501KVector0
        {
            Scalar = mv1.Scalar * mv2.Scalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector0 mv1, Ga501KVector1 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector0 mv1, Ga501KVector2 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector0 mv1, Ga501KVector3 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector0 mv1, Ga501KVector4 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector0 mv1, Ga501KVector5 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector0 mv1, Ga501KVector6 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    public static Ga501KVector0 Sp(this Ga501KVector0 mv1, Ga501Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector0.IsZero())
        {
            tempScalar += mv1.Scalar * mv2.KVector0.Scalar;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector1 mv1, Ga501KVector0 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector1 mv1, Ga501KVector1 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        return new Ga501KVector0
        {
            Scalar = mv1.Scalar2 * mv2.Scalar2 + mv1.Scalar3 * mv2.Scalar3 + mv1.Scalar4 * mv2.Scalar4 + mv1.Scalar5 * mv2.Scalar5 + mv1.Scalar6 * mv2.Scalar6
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector1 mv1, Ga501KVector2 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector1 mv1, Ga501KVector3 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector1 mv1, Ga501KVector4 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector1 mv1, Ga501KVector5 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector1 mv1, Ga501KVector6 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    public static Ga501KVector0 Sp(this Ga501KVector1 mv1, Ga501Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector1.IsZero())
        {
            tempScalar += mv1.Scalar2 * mv2.KVector1.Scalar2 + mv1.Scalar3 * mv2.KVector1.Scalar3 + mv1.Scalar4 * mv2.KVector1.Scalar4 + mv1.Scalar5 * mv2.KVector1.Scalar5 + mv1.Scalar6 * mv2.KVector1.Scalar6;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector2 mv1, Ga501KVector0 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector2 mv1, Ga501KVector1 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector2 mv1, Ga501KVector2 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        return new Ga501KVector0
        {
            Scalar = -mv1.Scalar23 * mv2.Scalar23 - mv1.Scalar24 * mv2.Scalar24 - mv1.Scalar34 * mv2.Scalar34 - mv1.Scalar25 * mv2.Scalar25 - mv1.Scalar35 * mv2.Scalar35 - mv1.Scalar45 * mv2.Scalar45 - mv1.Scalar26 * mv2.Scalar26 - mv1.Scalar36 * mv2.Scalar36 - mv1.Scalar46 * mv2.Scalar46 - mv1.Scalar56 * mv2.Scalar56
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector2 mv1, Ga501KVector3 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector2 mv1, Ga501KVector4 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector2 mv1, Ga501KVector5 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector2 mv1, Ga501KVector6 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    public static Ga501KVector0 Sp(this Ga501KVector2 mv1, Ga501Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector2.IsZero())
        {
            tempScalar += -mv1.Scalar23 * mv2.KVector2.Scalar23 - mv1.Scalar24 * mv2.KVector2.Scalar24 - mv1.Scalar34 * mv2.KVector2.Scalar34 - mv1.Scalar25 * mv2.KVector2.Scalar25 - mv1.Scalar35 * mv2.KVector2.Scalar35 - mv1.Scalar45 * mv2.KVector2.Scalar45 - mv1.Scalar26 * mv2.KVector2.Scalar26 - mv1.Scalar36 * mv2.KVector2.Scalar36 - mv1.Scalar46 * mv2.KVector2.Scalar46 - mv1.Scalar56 * mv2.KVector2.Scalar56;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector3 mv1, Ga501KVector0 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector3 mv1, Ga501KVector1 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector3 mv1, Ga501KVector2 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector3 mv1, Ga501KVector3 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        return new Ga501KVector0
        {
            Scalar = -mv1.Scalar234 * mv2.Scalar234 - mv1.Scalar235 * mv2.Scalar235 - mv1.Scalar245 * mv2.Scalar245 - mv1.Scalar345 * mv2.Scalar345 - mv1.Scalar236 * mv2.Scalar236 - mv1.Scalar246 * mv2.Scalar246 - mv1.Scalar346 * mv2.Scalar346 - mv1.Scalar256 * mv2.Scalar256 - mv1.Scalar356 * mv2.Scalar356 - mv1.Scalar456 * mv2.Scalar456
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector3 mv1, Ga501KVector4 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector3 mv1, Ga501KVector5 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector3 mv1, Ga501KVector6 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    public static Ga501KVector0 Sp(this Ga501KVector3 mv1, Ga501Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector3.IsZero())
        {
            tempScalar += -mv1.Scalar234 * mv2.KVector3.Scalar234 - mv1.Scalar235 * mv2.KVector3.Scalar235 - mv1.Scalar245 * mv2.KVector3.Scalar245 - mv1.Scalar345 * mv2.KVector3.Scalar345 - mv1.Scalar236 * mv2.KVector3.Scalar236 - mv1.Scalar246 * mv2.KVector3.Scalar246 - mv1.Scalar346 * mv2.KVector3.Scalar346 - mv1.Scalar256 * mv2.KVector3.Scalar256 - mv1.Scalar356 * mv2.KVector3.Scalar356 - mv1.Scalar456 * mv2.KVector3.Scalar456;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector4 mv1, Ga501KVector0 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector4 mv1, Ga501KVector1 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector4 mv1, Ga501KVector2 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector4 mv1, Ga501KVector3 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector4 mv1, Ga501KVector4 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        return new Ga501KVector0
        {
            Scalar = mv1.Scalar2345 * mv2.Scalar2345 + mv1.Scalar2346 * mv2.Scalar2346 + mv1.Scalar2356 * mv2.Scalar2356 + mv1.Scalar2456 * mv2.Scalar2456 + mv1.Scalar3456 * mv2.Scalar3456
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector4 mv1, Ga501KVector5 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector4 mv1, Ga501KVector6 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    public static Ga501KVector0 Sp(this Ga501KVector4 mv1, Ga501Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector4.IsZero())
        {
            tempScalar += mv1.Scalar2345 * mv2.KVector4.Scalar2345 + mv1.Scalar2346 * mv2.KVector4.Scalar2346 + mv1.Scalar2356 * mv2.KVector4.Scalar2356 + mv1.Scalar2456 * mv2.KVector4.Scalar2456 + mv1.Scalar3456 * mv2.KVector4.Scalar3456;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector5 mv1, Ga501KVector0 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector5 mv1, Ga501KVector1 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector5 mv1, Ga501KVector2 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector5 mv1, Ga501KVector3 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector5 mv1, Ga501KVector4 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector5 mv1, Ga501KVector5 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        return new Ga501KVector0
        {
            Scalar = mv1.Scalar23456 * mv2.Scalar23456
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector5 mv1, Ga501KVector6 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    public static Ga501KVector0 Sp(this Ga501KVector5 mv1, Ga501Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv2.KVector5.IsZero())
        {
            tempScalar += mv1.Scalar23456 * mv2.KVector5.Scalar23456;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector6 mv1, Ga501KVector0 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector6 mv1, Ga501KVector1 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector6 mv1, Ga501KVector2 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector6 mv1, Ga501KVector3 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector6 mv1, Ga501KVector4 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector6 mv1, Ga501KVector5 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector6 mv1, Ga501KVector6 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501KVector6 mv1, Ga501Multivector mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    public static Ga501KVector0 Sp(this Ga501Multivector mv1, Ga501KVector0 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector0.IsZero())
        {
            tempScalar += mv1.KVector0.Scalar * mv2.Scalar;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga501KVector0 Sp(this Ga501Multivector mv1, Ga501KVector1 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector1.IsZero())
        {
            tempScalar += mv1.KVector1.Scalar2 * mv2.Scalar2 + mv1.KVector1.Scalar3 * mv2.Scalar3 + mv1.KVector1.Scalar4 * mv2.Scalar4 + mv1.KVector1.Scalar5 * mv2.Scalar5 + mv1.KVector1.Scalar6 * mv2.Scalar6;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga501KVector0 Sp(this Ga501Multivector mv1, Ga501KVector2 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector2.IsZero())
        {
            tempScalar += -mv1.KVector2.Scalar23 * mv2.Scalar23 - mv1.KVector2.Scalar24 * mv2.Scalar24 - mv1.KVector2.Scalar34 * mv2.Scalar34 - mv1.KVector2.Scalar25 * mv2.Scalar25 - mv1.KVector2.Scalar35 * mv2.Scalar35 - mv1.KVector2.Scalar45 * mv2.Scalar45 - mv1.KVector2.Scalar26 * mv2.Scalar26 - mv1.KVector2.Scalar36 * mv2.Scalar36 - mv1.KVector2.Scalar46 * mv2.Scalar46 - mv1.KVector2.Scalar56 * mv2.Scalar56;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga501KVector0 Sp(this Ga501Multivector mv1, Ga501KVector3 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector3.IsZero())
        {
            tempScalar += -mv1.KVector3.Scalar234 * mv2.Scalar234 - mv1.KVector3.Scalar235 * mv2.Scalar235 - mv1.KVector3.Scalar245 * mv2.Scalar245 - mv1.KVector3.Scalar345 * mv2.Scalar345 - mv1.KVector3.Scalar236 * mv2.Scalar236 - mv1.KVector3.Scalar246 * mv2.Scalar246 - mv1.KVector3.Scalar346 * mv2.Scalar346 - mv1.KVector3.Scalar256 * mv2.Scalar256 - mv1.KVector3.Scalar356 * mv2.Scalar356 - mv1.KVector3.Scalar456 * mv2.Scalar456;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga501KVector0 Sp(this Ga501Multivector mv1, Ga501KVector4 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector4.IsZero())
        {
            tempScalar += mv1.KVector4.Scalar2345 * mv2.Scalar2345 + mv1.KVector4.Scalar2346 * mv2.Scalar2346 + mv1.KVector4.Scalar2356 * mv2.Scalar2356 + mv1.KVector4.Scalar2456 * mv2.Scalar2456 + mv1.KVector4.Scalar3456 * mv2.Scalar3456;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    public static Ga501KVector0 Sp(this Ga501Multivector mv1, Ga501KVector5 mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
        var tempScalar = 0d;
        
        if (!mv1.KVector5.IsZero())
        {
            tempScalar += mv1.KVector5.Scalar23456 * mv2.Scalar23456;
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ga501KVector0 Sp(this Ga501Multivector mv1, Ga501KVector6 mv2)
    {
        return Ga501KVector0.Zero;
    }
    
    public static Ga501KVector0 Sp(this Ga501Multivector mv1, Ga501Multivector mv2)
    {
        if (mv1.IsZero() || mv2.IsZero()) return Ga501KVector0.Zero;
        
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
                tempScalar += mv1.KVector1.Scalar2 * mv2.KVector1.Scalar2 + mv1.KVector1.Scalar3 * mv2.KVector1.Scalar3 + mv1.KVector1.Scalar4 * mv2.KVector1.Scalar4 + mv1.KVector1.Scalar5 * mv2.KVector1.Scalar5 + mv1.KVector1.Scalar6 * mv2.KVector1.Scalar6;
            }
            
        }
        
        if (!mv1.KVector2.IsZero())
        {
            if (!mv2.KVector2.IsZero())
            {
                tempScalar += -mv1.KVector2.Scalar23 * mv2.KVector2.Scalar23 - mv1.KVector2.Scalar24 * mv2.KVector2.Scalar24 - mv1.KVector2.Scalar34 * mv2.KVector2.Scalar34 - mv1.KVector2.Scalar25 * mv2.KVector2.Scalar25 - mv1.KVector2.Scalar35 * mv2.KVector2.Scalar35 - mv1.KVector2.Scalar45 * mv2.KVector2.Scalar45 - mv1.KVector2.Scalar26 * mv2.KVector2.Scalar26 - mv1.KVector2.Scalar36 * mv2.KVector2.Scalar36 - mv1.KVector2.Scalar46 * mv2.KVector2.Scalar46 - mv1.KVector2.Scalar56 * mv2.KVector2.Scalar56;
            }
            
        }
        
        if (!mv1.KVector3.IsZero())
        {
            if (!mv2.KVector3.IsZero())
            {
                tempScalar += -mv1.KVector3.Scalar234 * mv2.KVector3.Scalar234 - mv1.KVector3.Scalar235 * mv2.KVector3.Scalar235 - mv1.KVector3.Scalar245 * mv2.KVector3.Scalar245 - mv1.KVector3.Scalar345 * mv2.KVector3.Scalar345 - mv1.KVector3.Scalar236 * mv2.KVector3.Scalar236 - mv1.KVector3.Scalar246 * mv2.KVector3.Scalar246 - mv1.KVector3.Scalar346 * mv2.KVector3.Scalar346 - mv1.KVector3.Scalar256 * mv2.KVector3.Scalar256 - mv1.KVector3.Scalar356 * mv2.KVector3.Scalar356 - mv1.KVector3.Scalar456 * mv2.KVector3.Scalar456;
            }
            
        }
        
        if (!mv1.KVector4.IsZero())
        {
            if (!mv2.KVector4.IsZero())
            {
                tempScalar += mv1.KVector4.Scalar2345 * mv2.KVector4.Scalar2345 + mv1.KVector4.Scalar2346 * mv2.KVector4.Scalar2346 + mv1.KVector4.Scalar2356 * mv2.KVector4.Scalar2356 + mv1.KVector4.Scalar2456 * mv2.KVector4.Scalar2456 + mv1.KVector4.Scalar3456 * mv2.KVector4.Scalar3456;
            }
            
        }
        
        if (!mv1.KVector5.IsZero())
        {
            if (!mv2.KVector5.IsZero())
            {
                tempScalar += mv1.KVector5.Scalar23456 * mv2.KVector5.Scalar23456;
            }
            
        }
        
        return new Ga501KVector0
        {
            Scalar = tempScalar
        };
    }
    
}
