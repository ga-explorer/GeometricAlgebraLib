﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DataStructuresLib.BitManipulation;
using GeometricAlgebraFulcrumLib.Algebra.Multivectors.Terms;

namespace GeometricAlgebraFulcrumLib.Algebra.Basis
{
    public readonly struct GaBasisFull 
        : IGaBasisBlade
    {
        public static GaBasisFull ScalarBasis { get; }
            = new(0);


        public ulong Id { get; }

        public int Grade { get; }

        public ulong Index { get; }

        public bool IsUniform 
            => true;

        public bool IsGraded 
            => true;

        public bool IsFull 
            => true;

        
        public GaBasisFull(ulong id)
        {
            id.BasisBladeGradeIndex(out var grade, out var index);

            Id = id;
            Grade = grade;
            Index = index;
        }
        
        public GaBasisFull(int grade, ulong index)
        {
            Id = GaBasisUtils.BasisBladeId(grade, index);
            Grade = grade;
            Index = index;
        }
        
        public GaBasisFull(Tuple<int, ulong> gradeIndexTuple)
        {
            var (grade, index) = gradeIndexTuple;

            Id = GaBasisUtils.BasisBladeId(grade, index);
            Grade = grade;
            Index = index;
        }
        
        public GaBasisFull(Tuple<ulong, int, ulong> idGradeIndexTuple)
        {
            var (id, grade, index) = idGradeIndexTuple;

            Debug.Assert(id == GaBasisUtils.BasisBladeId(grade, index));

            Id = id;
            Grade = grade;
            Index = index;
        }
        
        public GaBasisFull(IGaBasisBlade basisBlade)
        {
            basisBlade.GetGradeIndex(out var grade, out var index);

            Id = basisBlade.Id;
            Grade = grade;
            Index = index;
        }


        public Tuple<int, ulong> GetGradeIndex()
        {
            return new(Grade, Index);
        }

        public Tuple<ulong, int, ulong> GetIdGradeIndex()
        {
            return new(Id, Grade, Index);
        }

        public IReadOnlyList<ulong> GetBasisVectorIndices()
        {
            return Id.BasisVectorIDsInside().ToArray();
        }


        public void GetGradeIndex(out int grade, out ulong index)
        {
            Id.BasisBladeGradeIndex(out grade, out index);
        }

        public void GetIdGradeIndex(out ulong id, out int grade, out ulong index)
        {
            id = Id;

            Id.BasisBladeGradeIndex(out grade, out index);
        }


        public GaBasisUniform ToUniformBasisBlade()
        {
            return new(Id);
        }

        public GaBasisGraded ToGradedBasisBlade()
        {
            return new(Grade, Index);
        }

        public GaBasisFull ToFullBasisBlade()
        {
            return this;
        }


        public IEnumerable<ulong> GetBasisVectorsIndices()
        {
            return Id.PatternToPositions().Select(i => (ulong) i);
        }

        public GaTerm<T> CreateTerm<T>(T scalar)
        {
            return new(this, scalar);
        }


        public override string ToString()
        {
            var basisVectorIndicesText = 
                string.Join(',', GetBasisVectorsIndices());

            return new StringBuilder()
                .Append('<')
                .Append(basisVectorIndicesText)
                .Append('>')
                .ToString();
        }


        public bool Equals(IGaBasisBlade other)
        {
            return other is not null && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return obj is IGaBasisBlade other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(GaBasisFull left, IGaBasisBlade right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(GaBasisFull left, IGaBasisBlade right)
        {
            return !left.Equals(right);
        }
    }
}