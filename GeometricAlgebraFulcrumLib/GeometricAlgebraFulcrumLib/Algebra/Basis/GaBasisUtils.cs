﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DataStructuresLib.BitManipulation;
using DataStructuresLib.Combinations;

namespace GeometricAlgebraFulcrumLib.Algebra.Basis
{
    public static class GaBasisUtils
    {
        /// <summary>
        /// The maximum allowed GA vector space dimension
        /// </summary>
        public static int MaxVSpaceDimension { get; } 
            = 63;

        /// <summary>
        /// The maximum possible basis blade ID in the maximum allowed GA vector space dimension
        /// </summary>
        public static ulong MaxVSpaceBasisBladeId { get; } 
            = (1ul << MaxVSpaceDimension) - 1ul;

        public static IReadOnlyList<string> DefaultBasisVectorsNames { get; } 
            = Enumerable.Range(1, MaxVSpaceDimension)
                .Select(i => "e" + i)
                .ToArray();

        /// <summary>
        /// The number of basis blades in a GA with dimension vSpaceDim
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <returns></returns>
        public static ulong ToGaSpaceDimension(this int vSpaceDim)
        {
            return 1ul << vSpaceDim;
        }

        /// <summary>
        /// The number of basis vectors in a GA with dimension gaSpaceDim
        /// </summary>
        /// <param name="gaSpaceDim"></param>
        /// <returns></returns>
        public static int ToVSpaceDimension(this int gaSpaceDim)
        {
            return gaSpaceDim.LastOneBitPosition();
        }

        /// <summary>
        /// The number of basis vectors in a GA with dimension gaSpaceDim
        /// </summary>
        /// <param name="gaSpaceDim"></param>
        /// <returns></returns>
        public static int ToVSpaceDimension(this ulong gaSpaceDim)
        {
            return gaSpaceDim.LastOneBitPosition();
        }

        /// <summary>
        /// The max basis blade ID in a GA space with a given dimension
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <returns></returns>
        public static ulong MaxBasisBladeId(int vSpaceDim)
        {
            return (1ul << vSpaceDim) - 1ul;
        }

        /// <summary>
        /// The number of grades in a GA space with a given dimension
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <returns></returns>
        public static int GradesCount(int vSpaceDim)
        {
            return vSpaceDim + 1;
        }

        /// <summary>
        /// The dimension of k-vectors subspace of some grade of a GA with a given dimension
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static ulong KvSpaceDimension(int vSpaceDim, int grade)
        {
            return vSpaceDim.GetBinomialCoefficient(grade);
        }

        /// <summary>
        /// The grades of k-vectors in a GA with the given dimension
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <returns></returns>
        public static IEnumerable<int> Grades(int vSpaceDim)
        {
            return Enumerable.Range(0, vSpaceDim + 1);
        }

        /// <summary>
        /// The Basis blade IDs of a GA space with the given dimension
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <returns></returns>
        public static IEnumerable<ulong> BasisBladeIDs(int vSpaceDim)
        {
            var maxBasisBladeId = MaxBasisBladeId(vSpaceDim);

            for (var id = 0ul; id <= maxBasisBladeId; id++)
                yield return id;
        }
        
        /// <summary>
        /// The basis vector IDs of a GA with the given dimension
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <returns></returns>
        public static IEnumerable<ulong> BasisVectorIDs(int vSpaceDim)
        {
            return Enumerable.Range(0, vSpaceDim).Select(i => (1ul << i));
        }

        /// <summary>
        /// Find all basis blade IDs with the given grade in a GA of dimension vSpaceDim
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static IEnumerable<ulong> BasisBladeIDsOfGrade(int vSpaceDim, int grade)
        {
            return UInt64BitUtils.OnesPermutations(
                vSpaceDim, 
                grade
            );
        }

        /// <summary>
        /// Find all basis blade IDs with the given grade and indexes
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="indexSeq"></param>
        /// <returns></returns>
        public static IEnumerable<ulong> BasisBladeIDsOfGradeIndex(int grade, IEnumerable<ulong> indexSeq)
        {
            return indexSeq.Select(index => BasisBladeId(grade, index));
        }
        
        /// <summary>
        /// Find all basis blade IDs with the given grade and indexes
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="indexSeq"></param>
        /// <returns></returns>
        public static IEnumerable<ulong> BasisBladeIDsOfGradeIndex(int grade, params ulong[] indexSeq)
        {
            return indexSeq.Select(index => BasisBladeId(grade, index));
        }
        
        /// <summary>
        /// The basis blade IDs of a GA space with the given dimension sorted by their grade and index
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <param name="startGrade"></param>
        /// <returns></returns>
        public static IEnumerable<ulong> BasisBladeIDsSortedByGrade(int vSpaceDim, int startGrade = 0)
        {
            for (var grade = startGrade; grade <= vSpaceDim; grade++)
                foreach (var id in BasisBladeIDsOfGrade(vSpaceDim, grade))
                    yield return id;
        }
        
        /// <summary>
        /// Returns the basis blade IDs of having the given grades
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <param name="gradesSeq"></param>
        /// <returns></returns>
        public static IEnumerable<ulong> BasisBladeIDsOfGrades(int vSpaceDim, IEnumerable<int> gradesSeq)
        {
            return gradesSeq
                .OrderBy(g => g)
                .SelectMany(grade => BasisBladeIDsOfGrade(vSpaceDim, grade));
        }
        
        /// <summary>
        /// Returns the basis blade IDs of having the given grades
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <param name="gradesSeq"></param>
        /// <returns></returns>
        public static IEnumerable<ulong> BasisBladeIDsOfGrades(int vSpaceDim, params int[] gradesSeq)
        {
            return gradesSeq
                .OrderBy(g => g)
                .SelectMany(grade => BasisBladeIDsOfGrade(vSpaceDim, grade));
        }
        
        /// <summary>
        /// Returns the basis blade IDs of having the given grades grouped by their grade
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <param name="startGrade"></param>
        /// <returns></returns>
        public static Dictionary<int, IReadOnlyList<ulong>> BasisBladeIDsGroupedByGrade(int vSpaceDim, int startGrade = 0)
        {
            var result = new Dictionary<int, IReadOnlyList<ulong>>();

            for (var grade = startGrade; grade <= vSpaceDim; grade++)
            {
                result.Add(
                    grade, 
                    BasisBladeIDsOfGrade(vSpaceDim, grade).ToArray()
                );
            }

            return result;
        }
        
        /// <summary>
        /// Returns the basis blade IDs of having the given grades grouped by their grade
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <param name="gradesSeq"></param>
        /// <returns></returns>
        public static Dictionary<int, IReadOnlyList<ulong>> BasisBladeIDsGroupedByGrade(int vSpaceDim, IEnumerable<int> gradesSeq)
        {
            var result = new Dictionary<int, IReadOnlyList<ulong>>();

            foreach (var grade in gradesSeq)
            {
                result.Add(
                    grade, 
                    BasisBladeIDsOfGrade(vSpaceDim, grade).ToArray()
                );
            }

            return result;
        }
        
        /// <summary>
        /// Returns the basis blade IDs of having the given grades grouped by their grade
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <param name="gradesSeq"></param>
        /// <returns></returns>
        public static Dictionary<int, IReadOnlyList<ulong>> BasisBladeIDsGroupedByGrade(int vSpaceDim, params int[] gradesSeq)
        {
            var result = new Dictionary<int, IReadOnlyList<ulong>>();

            foreach (var grade in gradesSeq)
            {
                result.Add(
                    grade, 
                    BasisBladeIDsOfGrade(vSpaceDim, grade).ToArray()
                );
            }

            return result;
        }
        
        /// <summary>
        /// Find the ID of a basis blade given its grade and index
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ulong BasisBladeId(int grade, ulong index)
        {
            if (grade < GaLookupTables.GradeIndexToIdTable.Count)
            {
                var table = GaLookupTables.GradeIndexToIdTable[grade];

                if (index < (ulong) table.Length)
                    return table[index];
            }

            return index.IndexToCombinadicPattern(grade);
        }

        
        /// <summary>
        /// Get the largest basis vector index of the given basis blade
        /// </summary>
        /// <param name="basisBlade"></param>
        /// <returns></returns>
        public static int BasisBladeMaxVectorIndex(this IGaBasisBlade basisBlade)
        {
            var (grade, index) = basisBlade.GetGradeIndex();

            if (grade >= GaLookupTables.GradeIndexToMaxBasisVectorIndexTable.Count)
                return CombinationsUtilsUInt64.GetMaximalRowIndex(index, grade);

            var table = 
                GaLookupTables.GradeIndexToMaxBasisVectorIndexTable[grade];

            return index < (ulong) table.Length 
                ? table[index] 
                : CombinationsUtilsUInt64.GetMaximalRowIndex(index, grade);
        }

        /// <summary>
        /// Get the largest basis vector index of the given basis blade
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int BasisBladeMaxVectorIndex(int grade, ulong index)
        {
            if (grade >= GaLookupTables.GradeIndexToMaxBasisVectorIndexTable.Count)
                return CombinationsUtilsUInt64.GetMaximalRowIndex(index, grade);

            var table = 
                GaLookupTables.GradeIndexToMaxBasisVectorIndexTable[grade];

            return index < (ulong) table.Length 
                ? table[index] 
                : CombinationsUtilsUInt64.GetMaximalRowIndex(index, grade);
        }
        
        /// <summary>
        /// Find the ID of a basis vector given its index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ulong BasisVectorId(ulong index)
        {
            return 1UL << (int) index;
        }
        
        /// <summary>
        /// Find the grade of a basis blade given its ID
        /// </summary>
        /// <param name="basisBladeId"></param>
        /// <returns></returns>
        public static int BasisBladeGrade(this ulong basisBladeId)
        {
            return basisBladeId < (ulong)GaLookupTables.IdToGradeTable.Length
                ? GaLookupTables.IdToGradeTable[basisBladeId]
                : basisBladeId.CountOnes();
        }
        
        /// <summary>
        /// Find the index of a basis blade given its ID
        /// </summary>
        /// <param name="basisBladeId"></param>
        /// <returns></returns>
        public static ulong BasisBladeIndex(this ulong basisBladeId)
        {
            return basisBladeId < (ulong)GaLookupTables.IdToIndexTable.Length
                ? GaLookupTables.IdToIndexTable[basisBladeId]
                : basisBladeId.CombinadicPatternToIndex();
        }

        public static ulong BasisVectorIndex(this ulong basisVectorId)
        {
            return basisVectorId < (ulong)GaLookupTables.IdToIndexTable.Length
                ? GaLookupTables.IdToIndexTable[basisVectorId]
                : (ulong) basisVectorId.FirstOneBitPosition();
        }
        
        /// <summary>
        /// Find the grade and index of a basis blade given its ID
        /// </summary>
        /// <param name="basisBladeId"></param>
        /// <param name="grade"></param>
        /// <param name="index"></param>
        public static void BasisBladeGradeIndex(this ulong basisBladeId, out int grade, out ulong index)
        {
            if (basisBladeId < (ulong) GaLookupTables.IdToIndexTable.Length)
            {
                grade = GaLookupTables.IdToGradeTable[basisBladeId];
                index = GaLookupTables.IdToIndexTable[basisBladeId];

                return;
            }

            basisBladeId.CombinadicPatternToIndex(out grade, out index);
        }

        public static Tuple<int, ulong> BasisBladeGradeIndex(this ulong basisBladeId)
        {
            if (basisBladeId < (ulong) GaLookupTables.IdToIndexTable.Length)
            {
                var grade = GaLookupTables.IdToGradeTable[basisBladeId];
                var index = GaLookupTables.IdToIndexTable[basisBladeId];

                return new Tuple<int, ulong>(grade, index);
            }
            else
            {
                basisBladeId.CombinadicPatternToIndex(out var grade, out var index);

                return new Tuple<int, ulong>(grade, index);
            }
        }
        
        public static string BasisBladeName(this ulong basisBladeId)
        {
            return DefaultBasisVectorsNames.ConcatenateUsingPattern(basisBladeId, "E0", "^");
        }

        public static string BasisBladeName(int grade, ulong index)
        {
            return DefaultBasisVectorsNames.ConcatenateUsingPattern(BasisBladeId(grade, index), "E0", "^");
        }

        public static string BasisBladeName(this ulong basisBladeId, params string[] basisVectorNames)
        {
            return basisVectorNames.ConcatenateUsingPattern(basisBladeId, "E0", "^");
        }

        public static string BasisBladeName(int grade, ulong index, params string[] basisVectorNames)
        {
            return basisVectorNames.ConcatenateUsingPattern(BasisBladeId(grade, index), "E0", "^");
        }
        
        public static string BasisBladeIndexedName(this ulong basisBladeId)
        {
            return "E" + basisBladeId;
        }
        
        public static string BasisBladeIndexedName(int grade, ulong index)
        {
            return "E" + BasisBladeId(grade, index);
        }

        public static string BasisBladeBinaryIndexedName(int vSpaceDim, ulong basisBladeId)
        {
            return "B" + basisBladeId.PatternToString(vSpaceDim);
        }
        
        public static string BasisBladeBinaryIndexedName(int vSpaceDim, int grade, ulong index)
        {
            return "B" + BasisBladeId(grade, index).PatternToString(vSpaceDim);
        }

        public static string BasisBladeGradeIndexName(this ulong basisBladeId)
        {
            return
                new StringBuilder(32)
                .Append('G')
                .Append(basisBladeId.BasisBladeGrade())
                .Append('I')
                .Append(basisBladeId.BasisBladeIndex())
                .ToString();
        }
        
        public static string BasisBladeGradeIndexName(int grade, ulong index)
        {
            return
                new StringBuilder(32)
                .Append('G')
                .Append(grade)
                .Append('I')
                .Append(index)
                .ToString();
        }

        public static IEnumerable<ulong> BasisVectorIDsInside(this ulong basisBladeId)
        {
            return basisBladeId.GetBasicPatterns();
        }
        
        public static IEnumerable<ulong> BasisVectorIDsInside(int grade, ulong index)
        {
            return BasisBladeId(grade, index).GetBasicPatterns();
        }

        public static IEnumerable<ulong> BasisVectorIndexesInside(this ulong basisBladeId)
        {
            return basisBladeId.PatternToPositions().Select(i => (ulong)i);
        }
        
        public static IEnumerable<ulong> BasisVectorIndexesInside(int grade, ulong index)
        {
            return BasisBladeId(grade, index).PatternToPositions().Select(i => (ulong)i);
        }

        public static IEnumerable<ulong> BasisBladeIDsInside(this ulong basisBladeId)
        {
            return basisBladeId.GetSubPatterns();
        }
        
        public static IEnumerable<ulong> BasisBladeIDsInside(int grade, ulong index)
        {
            return BasisBladeId(grade, index).GetSubPatterns();
        }

        public static IEnumerable<ulong> BasisBladeIDsContaining(int vSpaceDim, ulong basisBladeId)
        {
            return basisBladeId.GetSuperPatterns(vSpaceDim);
        }
        
        public static IEnumerable<ulong> BasisBladeIDsContaining(int vSpaceDim, int grade, ulong index)
        {
            return BasisBladeId(grade, index).GetSuperPatterns(vSpaceDim);
        }
        
        public static IEnumerable<ulong> SortBasisBladeIDsByGrade(this IEnumerable<ulong> idsSeq)
        {
            return idsSeq.OrderBy(BasisBladeGrade).ThenBy(BasisBladeIndex);
        }

        public static IEnumerable<IGrouping<int, ulong>> GroupBasisBladeIDsByGrade(this IEnumerable<ulong> idsSeq)
        {
            return idsSeq.GroupBy(BasisBladeGrade);
        }


        /// <summary>
        /// Returns true if the given id contains subId as a binary pattern 
        /// (i.e. whenever subId has a 1 we find id has 1 at the same bit position)
        /// </summary>
        /// <param name="basisBladeId"></param>
        /// <param name="subId"></param>
        /// <returns></returns>
        public static bool BasisBladeIdContains(this ulong basisBladeId, ulong subId)
        {
            return (basisBladeId | subId) == basisBladeId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basisBladeId"></param>
        /// <param name="basisVectorId"></param>
        /// <param name="subBasisBladeId"></param>
        public static void SplitBySmallestBasisVectorId(this ulong basisBladeId, out ulong basisVectorId, out ulong subBasisBladeId)
        {
            basisBladeId.SplitBySmallestBasicPattern(out basisVectorId, out subBasisBladeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basisBladeId"></param>
        /// <param name="basisVectorId"></param>
        /// <param name="subBasisBladeId"></param>
        public static void SplitByLargestBasisVectorId(this ulong basisBladeId, out ulong basisVectorId, out ulong subBasisBladeId)
        {
            basisBladeId.SplitByLargestBasicPattern(out basisVectorId, out subBasisBladeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basisVectorsIds"></param>
        /// <param name="idIndex"></param>
        /// <returns></returns>
        public static ulong ComposeGaSubspaceBasisBladeId(List<ulong> basisVectorsIds, ulong idIndex)
        {
            return idIndex
                .PatternToPositions()
                .Aggregate(
                    0UL, 
                    (current, pos) => current | basisVectorsIds[pos]
                );
        }


        public static bool IsValidVSpaceDimension(this int vaSpaceDim)
        {
            return vaSpaceDim >= 2 && vaSpaceDim < MaxVSpaceDimension;
        }

        /// <summary>
        /// Test if the given integer is a legal GA space dimension (i.e. positive power of 2 less than or 
        /// equal to 2 ^ MaxVSpaceDim)
        /// </summary>
        /// <param name="gaSpaceDim"></param>
        /// <returns></returns>
        public static bool IsValidGaSpaceDimension(this ulong gaSpaceDim)
        {
            return
                gaSpaceDim == (MaxVSpaceBasisBladeId & gaSpaceDim) &&
                gaSpaceDim.CountOnes() == 1;
        }

        public static bool IsValidGaSpaceDimension(this int gaSpaceDim)
        {
            return IsValidGaSpaceDimension((ulong) gaSpaceDim);
        }
        
        public static bool IsValidBasisVectorId(this ulong basisBladeId)
        {
            return basisBladeId.IsValidBasisBladeId() && basisBladeId.IsBasicPattern();
        }

        public static bool TryGetValidBasisVectorIndex(this ulong basisBladeId, out ulong basisVectorIndex)
        {
            var onesCount = 0;
            basisVectorIndex = 0;

            var i = 0UL;
            while (basisBladeId != 0 && onesCount <= 1)
            {
                if ((basisBladeId & 1) != 0)
                {
                    basisVectorIndex = (onesCount == 0) ? i : 0UL;
                    onesCount++;
                }

                i++;
                basisBladeId >>= 1;
            }

            return onesCount == 1;
        }
        
        public static bool IsValidBasisVectorIndex(ulong index)
        {
            return index < (ulong)MaxVSpaceDimension;
        }
        
        public static bool IsValidBasisBladeId(this ulong basisBladeId)
        {
            return basisBladeId <= MaxVSpaceBasisBladeId;
        }

        public static bool IsValidBasisBladeGradeIndex(int vSpaceDim, int grade, ulong index)
        {
            if (grade < 0 || grade > vSpaceDim) return false;

            var kvDim = KvSpaceDimension(vSpaceDim, grade);

            return index < kvDim;
        }
        
        public static bool IsValidGrade(int vSpaceDim, int grade)
        {
            return (grade >= 0 && grade <= vSpaceDim);
        }
        
        /// <summary>
        /// Test if the clifford conjugate of a basis blade with a given grade is -1 the original basis blade
        /// Sign Pattern: +--+
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static bool GradeHasNegativeCliffordConjugate(this int grade)
        {
            var v = grade % 4;
            return v == 1 || v == 2;

            //return ((grade * (grade + 1)) & 2) != 0;
        }
        
        /// <summary>
        /// Test if the grade inverse of a basis blade with a given grade is -1 the original basis blade
        /// Sign Pattern: +-+-
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static bool GradeHasNegativeGradeInvolution(this int grade)
        {
            return (grade & 1) != 0;
        }
        
        /// <summary>
        /// Test if the reverse of a basis blade with a given grade is -1 the original basis blade
        /// Sign Pattern: ++--
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static bool GradeHasNegativeReverse(this int grade)
        {
            return grade % 4 > 1;

            //return ((grade * (grade - 1)) & 2) != 0;
        }


        public static bool BasisBladeHasEvenGrade(this ulong basisBladeId)
        {
            return (basisBladeId.BasisBladeGrade() & 1) == 0;
        }

        public static bool BasisBladeHasOddGrade(this ulong basisBladeId)
        {
            return (basisBladeId.BasisBladeGrade() & 1) != 0;
        }
        
        /// <summary>
        /// Test if the clifford conjugate of a given basis blade is -1 the original basis blade 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool BasisBladeIdHasNegativeCliffordConjugate(this ulong id)
        {
            return id < (ulong)GaLookupTables.IsNegativeCliffConjTable.Length
                ? GaLookupTables.IsNegativeCliffConjTable.Get((int)id)
                : id.CountOnes().GradeHasNegativeCliffordConjugate();
        }
        
        /// <summary>
        /// Test if the grade inverse of a given basis blade is -1 the original basis blade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool BasisBladeIdHasNegativeGradeInvolution(this ulong id)
        {
            return id < (ulong)GaLookupTables.IsNegativeGradeInvTable.Length
                ? GaLookupTables.IsNegativeGradeInvTable.Get((int)id)
                : id.CountOnes().GradeHasNegativeGradeInvolution();
        }
        
        /// <summary>
        /// Test if the reverse of a given basis blade is -1 the original basis blade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool BasisBladeIdHasNegativeReverse(this ulong id)
        {
            return id < (ulong) GaLookupTables.IsNegativeReverseTable.Length
                ? GaLookupTables.IsNegativeReverseTable.Get((int) id)
                : id.CountOnes().GradeHasNegativeReverse();
        }


        /// <summary>
        /// True if the outer product of the given euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNonZeroOp(ulong id1, ulong id2)
        {
            return (id1 & id2) == 0;
        }

        /// <summary>
        /// True if the outer product of the given euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="id3"></param>
        /// <returns></returns>
        public static bool IsNonZeroOp(ulong id1, ulong id2, ulong id3)
        {
            return (id1 & id2 & id3) == 0;
        }

        /// <summary>
        /// True if the Euclidean geometric product of the given euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNonZeroEGp(ulong id1, ulong id2)
        {
            return true;
        }

        /// <summary>
        /// True if the scalar product of the given Euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNonZeroESp(ulong id1, ulong id2)
        {
            return id1 == id2;
        }

        /// <summary>
        /// True if the left contraction product of the given Euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNonZeroELcp(ulong id1, ulong id2)
        {
            return (id1 & ~id2) == 0;
        }

        /// <summary>
        /// True if the right contraction product of the given Euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNonZeroERcp(ulong id1, ulong id2)
        {
            return (id2 & ~id1) == 0;
        }

        /// <summary>
        /// True if the fat-dot product of the given Euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNonZeroEFdp(ulong id1, ulong id2)
        {
            return (id1 & ~id2) == 0 || (id2 & ~id1) == 0;
        }

        /// <summary>
        /// True if the Hestenes inner product of the given Euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNonZeroEHip(ulong id1, ulong id2)
        {
            return id1 != 0 && id2 != 0 && ((id1 & ~id2) == 0 || (id2 & ~id1) == 0);
        }

        /// <summary>
        /// True if the anti-commutator product of the given Euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNonZeroEAcp(ulong id1, ulong id2)
        {
            //A acp B = (AB + BA) / 2
            return IsNegativeEGp(id1, id2) == IsNegativeEGp(id2, id1);
        }

        /// <summary>
        /// True if the commutator product of the given Euclidean basis blades is non-zero
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNonZeroECp(ulong id1, ulong id2)
        {
            //A cp B = (AB - BA) / 2
            return IsNegativeEGp(id1, id2) != IsNegativeEGp(id2, id1);
        }

        public static bool IsNonZeroTriProductLeftAssociative(ulong id1, ulong id2, ulong id3, Func<ulong, ulong, bool> isNonZeroProductFunc1, Func<ulong, ulong, bool> isNonZeroProductFunc2)
        {
            return isNonZeroProductFunc1(id1, id2) && isNonZeroProductFunc2(id1 ^ id2, id3);
        }

        public static bool IsNonZeroTriProductRightAssociative(ulong id1, ulong id2, ulong id3, Func<ulong, ulong, bool> isNonZeroProductFunc1, Func<ulong, ulong, bool> isNonZeroProductFunc2)
        {
            return isNonZeroProductFunc1(id1, id2 ^ id3) && isNonZeroProductFunc2(id2, id3);
        }

        public static bool IsNonZeroELcpELcpLa(ulong id1, ulong id2, ulong id3)
        {
            return IsNonZeroTriProductLeftAssociative(id1, id2, id3, IsNonZeroELcp, IsNonZeroELcp);
        }

        public static bool IsNonZeroELcpELcpRa(ulong id1, ulong id2, ulong id3)
        {
            return IsNonZeroTriProductRightAssociative(id1, id2, id3, IsNonZeroELcp, IsNonZeroELcp);
        }


        /// <summary>
        /// Given a bit pattern in id1 and id2 this shifts id2 by MaxVSpaceDimension bits to the left and 
        /// appends id1 to combine the two patterns using an OR bitwise operation
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static ulong JoinIDs(ulong id1, ulong id2)
        {
            return id1 | (id2 << MaxVSpaceDimension);
        }

        /// <summary>
        /// Given a bit pattern in id1 and id2 this shifts id2 by VSpaceDim bits to the left and 
        /// appends id1 to combine the two patterns using an OR bitwise operation
        /// </summary>
        /// <param name="vSpaceDim"></param>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static ulong JoinIDs(int vSpaceDim, ulong id1, ulong id2)
        {
            return id1 | (id2 << vSpaceDim);
        }
        
        //TODO: Try optimizing this
        /// <summary>
        /// Compute if the Euclidean Geometric Product of two basis blades is -1.
        /// This method is slower than lookup, but can be used for GAs with dimension
        /// more than 15
        /// </summary>
        /// <param name="id1"></param>
        /// <returns></returns>
        public static bool ComputeIsNegativeEGp(ulong id1)
        {
            if (id1 == 0ul) 
                return false;

            var flag = false;
            var id = id1;

            //Find largest 1-bit of ID1 and create a bit mask
            var initMask1 = 1ul;
            while (initMask1 <= id1)
                initMask1 <<= 1;

            initMask1 >>= 1;

            var mask2 = 1ul;
            while (mask2 <= id1)
            {
                //If the current bit in ID2 is one:
                if ((id1 & mask2) != 0ul)
                {
                    //Count number of swaps, each new swap inverts the final sign
                    var mask1 = initMask1;

                    while (mask1 > mask2)
                    {
                        if ((id & mask1) != 0ul)
                            flag = !flag;

                        mask1 >>= 1;
                    }
                }

                //Invert the corresponding bit in ID1
                id ^= mask2;

                mask2 <<= 1;
            }

            return flag;
        }

        /// <summary>
        /// Compute if the Euclidean Geometric Product of two basis blades is -1.
        /// This method is slower than lookup, but can be used for GAs with dimension
        /// more than 15
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool ComputeIsNegativeEGp(ulong id1, ulong id2)
        {
            if (id1 == 0ul || id2 == 0ul) return false;

            var flag = false;
            var id = id1;

            //Find largest 1-bit of ID1 and create a bit mask
            var initMask1 = 1ul;
            while (initMask1 <= id1)
                initMask1 <<= 1;

            initMask1 >>= 1;

            var mask2 = 1ul;
            while (mask2 <= id2)
            {
                //If the current bit in ID2 is one:
                if ((id2 & mask2) != 0ul)
                {
                    //Count number of swaps, each new swap inverts the final sign
                    var mask1 = initMask1;

                    while (mask1 > mask2)
                    {
                        if ((id & mask1) != 0ul)
                            flag = !flag;

                        mask1 >>= 1;
                    }
                }

                //Invert the corresponding bit in ID1
                id ^= mask2;

                mask2 <<= 1;
            }

            return flag;
        }
        
        //TODO: Try optimizing this
        public static int ComputeEGpSignature(ulong id1)
        {
            if (id1 == 0ul) return 1;

            var signature = 1;
            var id = id1;

            //Find largest 1-bit of ID1 and create a bit mask
            var initMask1 = 
                id1.PatternToMask();

            //var initMask1 = 1ul;
            //while (initMask1 <= id1)
            //    initMask1 <<= 1;

            //initMask1 >>= 1;

            var mask2 = 1ul;
            while (mask2 <= id1)
            {
                //If the current bit in ID2 is one:
                if ((id1 & mask2) != 0ul)
                {
                    //Count number of swaps, each new swap inverts the final sign
                    var mask1 = initMask1;

                    while (mask1 > mask2)
                    {
                        if ((id & mask1) != 0ul)
                            signature = -signature;

                        mask1 >>= 1;
                    }
                }

                //Invert the corresponding bit in ID1
                id ^= mask2;

                mask2 <<= 1;
            }

            return signature;
        }

        public static int ComputeEGpSignature(ulong id1, ulong id2)
        {
            if (id1 == 0ul || id2 == 0ul) return 1;

            var signature = 1;
            var id = id1;

            //Find largest 1-bit of ID1 and create a bit mask
            var initMask1 = 1ul;
            while (initMask1 <= id1)
                initMask1 <<= 1;

            initMask1 >>= 1;

            var mask2 = 1ul;
            while (mask2 <= id2)
            {
                //If the current bit in ID2 is one:
                if ((id2 & mask2) != 0ul)
                {
                    //Count number of swaps, each new swap inverts the final sign
                    var mask1 = initMask1;

                    while (mask1 > mask2)
                    {
                        if ((id & mask1) != 0ul)
                            signature = -signature;

                        mask1 >>= 1;
                    }
                }

                //Invert the corresponding bit in ID1
                id ^= mask2;

                mask2 <<= 1;
            }

            return signature;
        }

        /// <summary>
        /// Find if the Euclidean Geometric Product of two basis blades is -1.
        /// For GAs with dimension less or equal to 16 this is 4 to 24 times faster than computing.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsNegativeEGp(ulong id)
        {
            if (id >= (ulong) GaLookupTables.IsNegativeEgpLookupTables.Length) 
                return ComputeIsNegativeEGp(id);

            var lookupTable = 
                GaLookupTables.IsNegativeEgpLookupTables[id];

            return id < (ulong) lookupTable.Count 
                ? lookupTable[(int) id] 
                : ComputeIsNegativeEGp(id);
        }

        /// <summary>
        /// Find if the Euclidean Geometric Product of two basis blades is -1.
        /// For GAs with dimension less or equal to 16 this is 4 to 24 times faster than computing.
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNegativeEGp(ulong id1, ulong id2)
        {
            if (id1 >= (ulong) GaLookupTables.IsNegativeEgpLookupTables.Length) 
                return ComputeIsNegativeEGp(id1, id2);

            var lookupTable = 
                GaLookupTables.IsNegativeEgpLookupTables[id1];

            return id2 < (ulong)lookupTable.Count 
                ? lookupTable[(int) id2] 
                : ComputeIsNegativeEGp(id1, id2);
        }
        
        /// <summary>
        /// Find if the Geometric Product of two basis blades is -1, given the total non-degenerate
        /// metric signature value of their common basis vectors.
        /// For GAs with dimension less or equal to 16 this is 4 to 24 times faster than computing.
        /// </summary>
        /// <param name="basisBladeSignature">The total non-degenerate metric signature value of their common basis vectors. Must be non-zero.</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsNegativeGp(int basisBladeSignature, ulong id)
        {
            Debug.Assert(basisBladeSignature is 1 or -1);

            var isNegativeEGp = IsNegativeEGp(id);

            return (basisBladeSignature > 0)
                ? isNegativeEGp 
                : !isNegativeEGp;
        }

        /// <summary>
        /// Find if the Geometric Product of two basis blades is -1, given the total non-degenerate
        /// metric signature value of their common basis vectors.
        /// For GAs with dimension less or equal to 16 this is 4 to 24 times faster than computing.
        /// </summary>
        /// <param name="basisBladeSignature">The total non-degenerate metric signature value of their common basis vectors. Must be non-zero.</param>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNegativeGp(int basisBladeSignature, ulong id1, ulong id2)
        {
            Debug.Assert(basisBladeSignature is 1 or -1);

            var isNegativeEGp = IsNegativeEGp(id1, id2);

            return (basisBladeSignature > 0)
                ? isNegativeEGp 
                : !isNegativeEGp;
        }

        public static int EGpSignature(ulong id)
        {
            if (id >= (ulong) GaLookupTables.IsNegativeEgpLookupTables.Length) 
                return ComputeEGpSignature(id);

            var lookupTable = 
                GaLookupTables.IsNegativeEgpLookupTables[id];

            if (id < (ulong) lookupTable.Count)
                return lookupTable[(int) id] ? -1 : 1;

            return ComputeEGpSignature(id);
        }

        public static int ENormSquaredSignature(ulong id)
        {
            var reverseSignature = 
                id.BasisBladeIdHasNegativeReverse() ? -1 : 1;

            if (id >= (ulong) GaLookupTables.IsNegativeEgpLookupTables.Length) 
                return reverseSignature * ComputeEGpSignature(id);

            var lookupTable = 
                GaLookupTables.IsNegativeEgpLookupTables[id];

            if (id < (ulong) lookupTable.Count)
                return lookupTable[(int) id] 
                    ? -reverseSignature 
                    : reverseSignature;

            return reverseSignature * ComputeEGpSignature(id);
        }

        public static int EGpSignature(ulong id1, ulong id2)
        {
            if (id1 >= (ulong) GaLookupTables.IsNegativeEgpLookupTables.Length) 
                return ComputeEGpSignature(id1, id2);

            var lookupTable = 
                GaLookupTables.IsNegativeEgpLookupTables[id1];

            if (id2 < (ulong) lookupTable.Count)
                return lookupTable[(int) id2] ? -1 : 1;

            return ComputeEGpSignature(id1, id2);
        }

        public static int EGpReverseSignature(ulong id1, ulong id2)
        {
            var signature = EGpSignature(id1, id2);

            return id2.BasisBladeIdHasNegativeReverse()
                ? -signature
                : signature;
        }

        public static int OpSignature(ulong id1, ulong id2)
        {
            return (id1 & id2) == 0
                ? EGpSignature(id1, id2)
                : 0;
        }

        public static int ESpSignature(ulong id)
        {
            return EGpSignature(id);
        }

        public static int ESpSignature(ulong id1, ulong id2)
        {
            return id1 == id2
                ? EGpSignature(id1, id2)
                : 0;
        }

        public static int ELcpSignature(ulong id1, ulong id2)
        {
            return (id1 & ~id2) == 0
                ? EGpSignature(id1, id2)
                : 0;
        }

        public static int ERcpSignature(ulong id1, ulong id2)
        {
            return (~id1 & id2) == 0
                ? EGpSignature(id1, id2)
                : 0;
        }

        public static int EFdpSignature(ulong id1, ulong id2)
        {
            return (id1 & ~id2) == 0 || (id2 & ~id1) == 0
                ? EGpSignature(id1, id2)
                : 0;
        }

        public static int EHipSignature(ulong id1, ulong id2)
        {
            return id1 != 0 && id2 != 0 && ((id1 & ~id2) == 0 || (id2 & ~id1) == 0)
                ? EGpSignature(id1, id2)
                : 0;
        }

        public static int EAcpSignature(ulong id1, ulong id2)
        {
            //A acp B = (AB + BA) / 2
            return IsNegativeEGp(id1, id2) == IsNegativeEGp(id2, id1)
                ? EGpSignature(id1, id2)
                : 0;
        }

        public static int ECpSignature(ulong id1, ulong id2)
        {
            //A cp B = (AB - BA) / 2
            return IsNegativeEGp(id1, id2) != IsNegativeEGp(id2, id1)
                ? EGpSignature(id1, id2)
                : 0;
        }

        /// <summary>
        /// Find if the Euclidean Geometric Product of the given basis blades is -1.
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="id3"></param>
        /// <returns></returns>
        public static bool IsNegativeEGp(ulong id1, ulong id2, ulong id3)
        {
            return IsNegativeEGp(id1, id2) != IsNegativeEGp(id1 ^ id2, id3);
        }

        /// <summary>
        /// Find if the Euclidean Geometric Product of a basis vector and a basis blade is -1.
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsNegativeVectorEGp(ulong index1, ulong id2)
        {
            if (index1 < (ulong)GaLookupTables.IsNegativeVectorEgpLookupTables.Length)
            {
                var lookupTable = GaLookupTables.IsNegativeEgpLookupTables[index1];

                if (id2 < (ulong)lookupTable.Count)
                    return lookupTable[(int)id2];
            }

            var id1 = 1UL << (int)index1;

            return ComputeIsNegativeEGp(id1, id2);
        }


        public static ulong GetMaxBasisBladeId(this IEnumerable<ulong> idList)
        {
            return idList.Any()
                ? idList.Max()
                : 0UL;
        }

        public static ulong GetMaxBasisBladeId(this IEnumerable<ulong> indexList, int grade)
        {
            return indexList.Any()
                ? GaBasisUtils.BasisBladeId(grade, indexList.Max()) 
                : 0UL;
        }
        
        public static ulong GetMaxBasisBladeId<T>(this IReadOnlyDictionary<int, Dictionary<ulong, T>> gradeIndexScalarDictionary)
        {
            var maxBasisBladeId = 0UL;

            foreach (var (grade, indexScalarDictionary) in gradeIndexScalarDictionary)
            {
                var id = BasisBladeId(
                    grade,
                    indexScalarDictionary.Keys.Max()
                );

                if (id > maxBasisBladeId)
                    maxBasisBladeId = id;
            }

            return maxBasisBladeId;
        }

        public static IEnumerable<GaBasisUniform> IdToBasisUniform(this IEnumerable<ulong> idList)
        {
            return idList.Select(id => new GaBasisUniform(id));
        }

        public static IEnumerable<GaBasisGraded> IdToBasisGraded(this IEnumerable<ulong> idList)
        {
            return idList.Select(id => new GaBasisGraded(id));
        }

        public static IEnumerable<GaBasisFull> IdToBasisFull(this IEnumerable<ulong> idList)
        {
            return idList.Select(id => new GaBasisFull(id));
        }


        public static IEnumerable<GaBasisUniform> IndexToBasisUniform(this IEnumerable<ulong> indexList, int grade)
        {
            return indexList.Select(index => new GaBasisUniform(grade, index));
        }

        public static IEnumerable<GaBasisGraded> IndexToBasisGraded(this IEnumerable<ulong> indexList, int grade)
        {
            return indexList.Select(index => new GaBasisGraded(grade, index));
        }

        public static IEnumerable<GaBasisFull> IndexToBasisFull(this IEnumerable<ulong> indexList, int grade)
        {
            return indexList.Select(index => new GaBasisFull(grade, index));
        }

        public static IEnumerable<GaBasisVector> IndexToBasisVector(this IEnumerable<ulong> indexList)
        {
            return indexList.Select(index => new GaBasisVector(index));
        }

        public static IEnumerable<GaBasisBivector> IndexToBasisBivector(this IEnumerable<ulong> indexList)
        {
            return indexList.Select(index => new GaBasisBivector(index));
        }


        public static IEnumerable<GaBasisUniform> GradeIndexToBasisUniform(this IEnumerable<Tuple<int, ulong>> gradeIndexList)
        {
            return gradeIndexList.Select(tuple => new GaBasisUniform(tuple.Item1, tuple.Item2));
        }

        public static IEnumerable<GaBasisGraded> GradeIndexToBasisGraded(this IEnumerable<Tuple<int, ulong>> gradeIndexList)
        {
            return gradeIndexList.Select(tuple => new GaBasisGraded(tuple.Item1, tuple.Item2));
        }

        public static IEnumerable<GaBasisFull> GradeIndexToBasisFull(this IEnumerable<Tuple<int, ulong>> gradeIndexList)
        {
            return gradeIndexList.Select(tuple => new GaBasisFull(tuple.Item1, tuple.Item2));
        }
    }
}