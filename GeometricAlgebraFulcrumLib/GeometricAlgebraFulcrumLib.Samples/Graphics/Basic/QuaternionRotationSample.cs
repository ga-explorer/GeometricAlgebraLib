﻿using System;
using System.Numerics;
using NumericalGeometryLib.BasicMath;
using NumericalGeometryLib.BasicMath.Constants;
using NumericalGeometryLib.BasicMath.Matrices;
using NumericalGeometryLib.BasicMath.Tuples;
using NumericalGeometryLib.BasicMath.Tuples.Immutable;
using TextComposerLib.Text.Linear;

namespace GeometricAlgebraFulcrumLib.Samples.Graphics.Basic
{
    public static class QuaternionRotationSample
    {
        /// <summary>
        /// Generate switch cases for axis-to-axis rotation quaternions
        /// </summary>
        public static void Example1()
        {
            var axisList = new []
            {
                Axis3D.PositiveX,
                Axis3D.PositiveY,
                Axis3D.PositiveZ,
                Axis3D.NegativeX,
                Axis3D.NegativeY,
                Axis3D.NegativeZ
            };

            var axisNameList = new[]
            {
                "Axis3D.PositiveX",
                "Axis3D.PositiveY",
                "Axis3D.PositiveZ",
                "Axis3D.NegativeX",
                "Axis3D.NegativeY",
                "Axis3D.NegativeZ"
            };

            var composer = new LinearTextComposer();

            composer
                .AppendLine("return axis1 switch")
                .AppendLine("{")
                .IncreaseIndentation();

            for (var i1 = 0; i1 < 6; i1++)
            {
                var axis1 = axisList[i1];
                var axisName1 = axisNameList[i1];
                var axisVector1 = axis1.GetVector3D();

                composer
                    .AppendLineAtNewLine($"{axisName1} => axis2 switch")
                    .AppendLine("{")
                    .IncreaseIndentation();

                for (var i2 = 0; i2 < 6; i2++)
                {
                    var axis2 = axisList[i2];
                    var axisName2 = axisNameList[i2];
                    var axisVector2 = axis2.GetVector3D();

                    if (axis1 == axis2)
                    {
                        composer.AppendLineAtNewLine($"{axisName2} => Quaternion.Identity,");
                    }
                    else if (axis1.IsOppositeTo(axis2))
                    {
                        var rotationAxis = axis1 switch
                        {
                            Axis3D.PositiveX or Axis3D.NegativeX => Vector3.UnitZ,
                            Axis3D.PositiveY or Axis3D.NegativeY => Vector3.UnitX,
                            _ => Vector3.UnitY
                        };

                        var q = Quaternion.CreateFromAxisAngle(rotationAxis, MathF.PI);
                        
                        composer
                            .AppendLineAtNewLine($"{axisName2} => new Quaternion({q.X}, {q.Y}, {q.Z}, {q.W}),");
                    }
                    else
                    {
                        var v3 = axisVector1.VectorCross(axisVector2);
                        var rotationAxis = new Vector3((float) v3.X, (float) v3.Y, (float) v3.Z);

                        var q = Quaternion.CreateFromAxisAngle(rotationAxis, MathF.PI / 2);

                        composer
                            .AppendLineAtNewLine($"{axisName2} => new Quaternion({q.X}, {q.Y}, {q.Z}, {q.W}),");
                    }
                }

                composer
                    .DecreaseIndentation()
                    .AppendLineAtNewLine("},");
            }

            composer
                .DecreaseIndentation()
                .AppendLineAtNewLine("};");

            Console.WriteLine(composer.ToString());
        }

        /// <summary>
        /// Validate axis-to-axis rotation quaternions
        /// </summary>
        public static void Example2()
        {
            var axisList = new []
            {
                Axis3D.PositiveX,
                Axis3D.PositiveY,
                Axis3D.PositiveZ,
                Axis3D.NegativeX,
                Axis3D.NegativeY,
                Axis3D.NegativeZ
            };
            
            for (var i1 = 0; i1 < 6; i1++)
            {
                var axis1 = axisList[i1];

                for (var i2 = 0; i2 < 6; i2++)
                {
                    var axis2 = axisList[i2];

                    var quaternion = axis1.CreateAxisToAxisRotationQuaternion(axis2);

                    var v2 = quaternion.Rotate(axis1).MapComponents(
                        s => Math.Round(s, 3)
                    );

                    if ((v2 - axis2.GetVector3D()).GetLength().IsNearZero(1e-7))
                        continue;

                    Console.WriteLine($"              Axis1: {axis1}");
                    Console.WriteLine($"              Axis2: {axis2}");
                    Console.WriteLine($"Computed Quaternion: {quaternion}");
                    Console.WriteLine($"     Computed Axis2: {v2}");
                    Console.WriteLine();
                }
            }
        }
        
        /// <summary>
        /// Validate nearest axis-to-vector rotation quaternions
        /// </summary>
        public static void Example3()
        {
            var k = new Tuple3D(1, 1, 1);
            var vectorList = new []
            {
                (Axis3D.PositiveX.GetVector3D() + k).ToUnitVector(),
                (Axis3D.PositiveY.GetVector3D() + k).ToUnitVector(),
                (Axis3D.PositiveZ.GetVector3D() + k).ToUnitVector(),
                (Axis3D.NegativeX.GetVector3D() - k).ToUnitVector(),
                (Axis3D.NegativeY.GetVector3D() - k).ToUnitVector(),
                (Axis3D.NegativeZ.GetVector3D() - k).ToUnitVector()
            };

            for (var i1 = 0; i1 < 6; i1++)
            {
                var vector = vectorList[i1];

                var (axis, quaternion) = 
                    vector.CreateNearestAxisToVectorRotationQuaternion();

                var axisVector = 
                    axis.GetVector3D();

                var (u, a) = 
                    axisVector.CreateVectorToVectorRotationAxisAngle(vector);

                var q = Quaternion.CreateFromAxisAngle(
                    new Vector3((float) u.X, (float) u.Y, (float) u.Z),
                    (float) a
                );
                
                if ((quaternion - q).IsNearZero()) 
                    continue;

                var v2 = quaternion.Rotate(axis);
                var v3 = q.Rotate(axis);

                Console.WriteLine($"             Vector: {vector}");
                Console.WriteLine($"               Axis: {axis}");
                Console.WriteLine($"  Actual Quaternion: {q}");
                Console.WriteLine($"Computed Quaternion: {quaternion}");
                Console.WriteLine($"  Actual Quaternion Rotated Vector: {v3}");
                Console.WriteLine($"Computed Quaternion Rotated Vector: {v2}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Validate axis-to-vector rotation quaternions
        /// </summary>
        public static void Example4()
        {
            var axisList = new []
            {
                Axis3D.PositiveX,
                Axis3D.PositiveY,
                Axis3D.PositiveZ,
                Axis3D.NegativeX,
                Axis3D.NegativeY,
                Axis3D.NegativeZ
            };

            var k = new Tuple3D(1, 1, 1);
            var vectorList = new []
            {
                (Axis3D.PositiveX.GetVector3D() + k).ToUnitVector(),
                (Axis3D.PositiveY.GetVector3D() + k).ToUnitVector(),
                (Axis3D.PositiveZ.GetVector3D() + k).ToUnitVector(),
                (Axis3D.NegativeX.GetVector3D() - k).ToUnitVector(),
                (Axis3D.NegativeY.GetVector3D() - k).ToUnitVector(),
                (Axis3D.NegativeZ.GetVector3D() - k).ToUnitVector()
            };

            for (var i1 = 0; i1 < 6; i1++)
            {
                var vector = vectorList[i1];

                for (var i2 = 0; i2 < 6; i2++)
                {
                    var axis = axisList[i2];
                    var axisVector = 
                        axis.GetVector3D();

                    var quaternion = 
                        axis.CreateAxisToVectorRotationQuaternion(vector);

                    var (u, a) = 
                        axisVector.CreateVectorToVectorRotationAxisAngle(vector);

                    var q = Quaternion.CreateFromAxisAngle(
                        new Vector3((float) u.X, (float) u.Y, (float) u.Z),
                        (float) a
                    );

                    var v1 = quaternion.Rotate(axis);
                    var v2 = q.Rotate(axis);

                    var l1 = (v1 - vector).GetLengthSquared();
                    var l2 = (v2 - vector).GetLengthSquared();

                    var qDiff = (quaternion - q).LengthSquared();

                    if (l1.IsNearZero() && l2.IsNearZero() && qDiff.IsNearZero())
                        continue;
                    
                    var nearestAxisVector = vector.SelectNearestAxis();

                    Console.WriteLine($"              Vector: {vector}");
                    Console.WriteLine($"                Axis: {axis}");
                    Console.WriteLine($"        Nearest Axis: {nearestAxisVector}");
                    Console.WriteLine($"   Actual Quaternion: {q}");
                    Console.WriteLine($" Computed Quaternion: {quaternion}");
                    Console.WriteLine($"   Actual Quaternion Rotated Axis: {v2}");
                    Console.WriteLine($" Computed Quaternion Rotated Axis: {v1}");
                    Console.WriteLine();
                }
            }
        }
    }
}