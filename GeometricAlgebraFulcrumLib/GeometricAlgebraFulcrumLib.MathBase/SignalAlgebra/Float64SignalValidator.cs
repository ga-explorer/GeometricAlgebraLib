﻿using System.Runtime.CompilerServices;
using GeometricAlgebraFulcrumLib.MathBase.GeometricAlgebra.Extended.Generic.Multivectors;
using GeometricAlgebraFulcrumLib.MathBase.GeometricAlgebra.Restricted.Generic.Multivectors;
using GeometricAlgebraFulcrumLib.MathBase.ScalarAlgebra;

namespace GeometricAlgebraFulcrumLib.MathBase.SignalAlgebra
{
    public class Float64SignalValidator
    {
        public double ZeroEpsilon { get; set; } = 1e-7;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateEqualZero(Scalar<Float64Signal> scalarSignal1)
        {
            return ValidateEqualZero(scalarSignal1.ScalarValue);
        }

        public bool ValidateEqualZero(Float64Signal scalarSignal1)
        {
            if (scalarSignal1.IsNearZero(ZeroEpsilon))
                return true;

            var scalarSignal1Rms =
                scalarSignal1.Select(s => s.Square()).Average().Sqrt();

            if (scalarSignal1Rms.IsNearZero(ZeroEpsilon))
                return true;

            Console.WriteLine($"RMS value: {scalarSignal1Rms:G}");
            Console.WriteLine();

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateEqual(Scalar<Float64Signal> scalarSignal1, Scalar<Float64Signal> scalarSignal2)
        {
            return ValidateEqual(
                scalarSignal1.ScalarValue,
                scalarSignal2.ScalarValue
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateEqual(Scalar<Float64Signal> scalarSignal1, Float64Signal scalarSignal2)
        {
            return ValidateEqual(
                scalarSignal1.ScalarValue,
                scalarSignal2
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateEqual(Float64Signal scalarSignal1, Scalar<Float64Signal> scalarSignal2)
        {
            return ValidateEqual(
                scalarSignal1,
                scalarSignal2.ScalarValue
            );
        }

        public bool ValidateEqual(Float64Signal scalarSignal1, Float64Signal scalarSignal2)
        {
            var errorSignal =
                scalarSignal1 - scalarSignal2;

            if (errorSignal.IsNearZero(ZeroEpsilon))
                return true;

            var snr = 
                scalarSignal1.PeakSignalToNoiseRatioDb(scalarSignal2).NaNToZero();

            if (snr > 50)
                return true;

            var scalarSignal1Rms = scalarSignal1.Select(s => s.Square()).Average().Sqrt();
            var errorSignalRms = errorSignal.Select(s => s.Square()).Average().Sqrt();

            var errorSignalRmsRatio = (errorSignalRms / scalarSignal1Rms).NaNToZero();

            Console.WriteLine($"SNR: {snr:G}, RMS error ratio: {errorSignalRmsRatio:G}");
            Console.WriteLine();

            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateEqual(RGaVector<Float64Signal> scalarSignal1, RGaVector<Float64Signal> scalarSignal2)
        {
            return ValidateZeroNorm(
                scalarSignal1 - scalarSignal2
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateEqual(XGaVector<Float64Signal> scalarSignal1, XGaVector<Float64Signal> scalarSignal2)
        {
            return ValidateZeroNorm(
                scalarSignal1 - scalarSignal2
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateEqual(XGaBivector<Float64Signal> scalarSignal1, XGaBivector<Float64Signal> scalarSignal2)
        {
            return ValidateZeroNormSquared(
                scalarSignal1 - scalarSignal2
            );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateZeroNorm(RGaVector<Float64Signal> scalarSignal1)
        {
            return ValidateEqualZero(
                scalarSignal1.Norm().ScalarValue
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateZeroNorm(XGaVector<Float64Signal> scalarSignal1)
        {
            return ValidateEqualZero(
                scalarSignal1.Norm().ScalarValue
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateZeroNormSquared(XGaVector<Float64Signal> scalarSignal1)
        {
            return ValidateEqualZero(
                scalarSignal1.NormSquared().ScalarValue
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateZeroNormSquared(XGaBivector<Float64Signal> scalarSignal1)
        {
            return ValidateEqualZero(
                scalarSignal1.NormSquared().ScalarValue
            );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateUnitNormSquared(RGaVector<Float64Signal> scalarSignal1)
        {
            return ValidateEqual(
                scalarSignal1.NormSquared().ScalarValue,
                scalarSignal1.ScalarProcessor.GetScalarFromNumber(1)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateUnitNormSquared(XGaVector<Float64Signal> scalarSignal1)
        {
            return ValidateEqual(
                scalarSignal1.NormSquared().ScalarValue,
                scalarSignal1.ScalarProcessor.GetScalarFromNumber(1)
            );
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateOrthogonal(RGaVector<Float64Signal> vectorSignal1, RGaVector<Float64Signal> vectorSignal2)
        {
            return ValidateEqualZero(vectorSignal1.Sp(vectorSignal2).ScalarValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateOrthogonal(XGaVector<Float64Signal> vectorSignal1,
            XGaVector<Float64Signal> vectorSignal2)
        {
            return ValidateEqualZero(vectorSignal1.Sp(vectorSignal2).ScalarValue);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateOrthogonal(IReadOnlyList<RGaVector<Float64Signal>> vectorSignalList)
        {
            var validatedFlag = true;
            for (var i = 0; i < vectorSignalList.Count; i++)
            {
                var vectorSignal1 = vectorSignalList[i];

                for (var j = 0; j < vectorSignalList.Count; j++)
                {
                    if (i == j) continue;

                    var vectorSignal2 = vectorSignalList[j];

                    validatedFlag &= ValidateEqualZero(vectorSignal1.Sp(vectorSignal2).ScalarValue);
                }
            }

            return validatedFlag;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ValidateOrthogonal(IReadOnlyList<XGaVector<Float64Signal>> vectorSignalList)
        {
            var validatedFlag = true;
            for (var i = 0; i < vectorSignalList.Count; i++)
            {
                var vectorSignal1 = vectorSignalList[i];

                for (var j = 0; j < vectorSignalList.Count; j++)
                {
                    if (i == j) continue;

                    var vectorSignal2 = vectorSignalList[j];

                    validatedFlag &= ValidateEqualZero(vectorSignal1.Sp(vectorSignal2).ScalarValue);
                }
            }

            return validatedFlag;
        }

    }
}