/*
* CharSequences.cs is part of functional-dotnet project
* 
* Copyright (c) 2009 Alexey Romanov
* All rights reserved.
*
* This source file is available under The New BSD License.
* See license.txt file for more information.
* 
* THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND 
* CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
* INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
* MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FP.Core;
using FP.Util;

namespace FP.Text {
    /// <summary>
    /// Utility class with extension methods for <see cref="ICharSequence"/>
    /// </summary>
    public static class CharSequences {
        private static Func<char, char, bool> Equal(bool ignoreCase) {
            if (ignoreCase)
                return (c1, c2) => Char.ToUpperInvariant(c1) == Char.ToUpperInvariant(c2);
            else
                return (c1, c2) => c1 == c2;
        }

        /// <summary>
        /// Copies the given <paramref name="sequence"/> to <paramref name="destination"/>.
        /// </summary>
        /// <typeparam name="TSequence">The type of the sequence.</typeparam>
        /// <param name="sequence">The sequence to be copied.</param>
        /// <param name="destination">The destination array.</param>
        /// <param name="destinationIndex">Index of the destination array where the copy
        /// will start.</param>
        public static void CopyTo<TSequence>(
            this TSequence sequence, char[] destination, int destinationIndex)
            where TSequence : ICharSequence {
            sequence.CopyTo(0, destination, destinationIndex, sequence.Count);
        }

        /// <summary>
        /// Converts the <paramref name="sequence"/> to an array.
        /// </summary>
        /// <typeparam name="TSequence">The type of the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The array with the same elements as <paramref name="sequence"/>.</returns>
        public static char[] ToArray<TSequence>(this TSequence sequence) 
            where TSequence : ICharSequence {
            return ToArray(sequence, 0, sequence.Count);
        }

        /// <summary>
        /// Converts the <paramref name="sequence"/> to an array.
        /// </summary>
        /// <typeparam name="TSequence">The type of the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>
        /// The array with the same elements as <paramref name="sequence"/>.
        /// </returns>
        public static char[] ToArray<TSequence>(this TSequence sequence, int startIndex, int count)
            where TSequence : ICharSequence {
            var array = new char[count];
            sequence.CopyTo(startIndex, array, 0, count);
            return array;
        }

        /// <summary>
        /// Converts a character sequence to a string.
        /// </summary>
        /// <typeparam name="TSequence">The type of the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The string with the same characters as <paramref name="sequence"/>.</returns>
        public static string AsString<TSequence>(this TSequence sequence) where TSequence : ICharSequence {
            return sequence.SubStringAsString(0, sequence.Count);
        }

        /// <summary>
        /// Converts a part of a character sequence to a string.
        /// </summary>
        /// <typeparam name="TSequence">The type of the sequence.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="startIndex">The starting index.</param>
        /// <param name="count">The count.</param>
        /// <returns>
        /// The string with the same characters as <paramref name="sequence"/>.
        /// </returns>
        public static string SubStringAsString<TSequence>(
            this TSequence sequence, int startIndex, int count) where TSequence : ICharSequence {
            if (count == 0) 
                return String.Empty;
            return new string(sequence.ToArray(startIndex, count));
        }

        /// <summary>
        /// Writes a part of a character sequence to the specified writer.
        /// </summary>
        /// <typeparam name="TSequence">The type of the sequence.</typeparam>
        /// <param name="writer">The writer.</param>
        /// <param name="charSequence">The char sequence.</param>
        /// <param name="startIndex">The starting index.</param>
        /// <param name="count">The number of characters to write.</param>
        public static void Write<TSequence>(
            this TextWriter writer, TSequence charSequence, int startIndex, int count)
            where TSequence : ICharSequence {
            charSequence.WriteOut(writer, startIndex, count);
        }

        /// <summary>
        /// Writes a character sequence to the specified writer.
        /// </summary>
        /// <typeparam name="TSequence">The type of the sequence.</typeparam>
        /// <param name="writer">The writer.</param>
        /// <param name="charSequence">The char sequence.</param>
        public static void Write<TSequence>(
            this TextWriter writer, TSequence charSequence)
            where TSequence : ICharSequence {
            charSequence.WriteOut(writer, 0, charSequence.Count);
        }

        public static bool IsNullOrEmpty<TSequence>(this TSequence charSequence) 
            where TSequence : ICharSequence{
            return charSequence == null || charSequence.IsEmpty;
        }

        public static bool StartsWithOrdinal<TSequence1, TSequence2>(
            this TSequence1 charSequence1, TSequence2 charSequence2, bool ignoreCase) 
            where TSequence1 : ICharSequence where TSequence2 : ICharSequence {
            if (charSequence2.Count == 0)
                return true;
            if (charSequence2.Count > charSequence1.Count)
                return false;

            return charSequence1.ZipWith(charSequence2, Equal(ignoreCase)).And();
        }

        public static bool EndsWithOrdinal<TSequence1, TSequence2>(
            this TSequence1 charSequence1, TSequence2 charSequence2, bool ignoreCase) 
            where TSequence1 : ICharSequence where TSequence2 : ICharSequence {
            var count1 = charSequence1.Count;
            var count2 = charSequence2.Count;
            if (count2 == 0)
                return true;
            if (count2 > count1)
                return false;

            return charSequence1.IteratorFrom(count1 - count2).ZipWith(charSequence2, Equal(ignoreCase)).And();
        }

        public static int CompareToOrdinal<TSequence1, TSequence2>(
            this TSequence1 charSequence1, TSequence2 charSequence2, bool ignoreCase)
            where TSequence1 : ICharSequence where TSequence2 : ICharSequence {
            Func<char, char, int> compare;
            if (ignoreCase)
                compare = (c1, c2) => Char.ToUpperInvariant(c1).CompareTo(Char.ToUpperInvariant(c2));
            else
                compare = (c1, c2) => c1.CompareTo(c2);

            var stage1 = charSequence1.ZipWith(charSequence2, compare).Where(i => i != 0).FirstOrDefault();
            if (stage1 != 0)
                // We found different characters
                return stage1;
            else
                // Is one of sequences shorter?
                return charSequence1.Count - charSequence2.Count;
        }

        public static Optional<int> IndexOfOrdinal<TSequence1, TSequence2>(
            this TSequence1 charSequence1, TSequence2 charSequence2, bool ignoreCase)
            where TSequence1 : ICharSequence where TSequence2 : ICharSequence {
            throw new System.NotImplementedException();
        }

        public static bool EqualsOrdinal<TSequence1, TSequence2>(
            this TSequence1 rope, TSequence2 charSequence, bool ignoreCase) 
            where TSequence1 : ICharSequence where TSequence2 : ICharSequence {
            if (charSequence.Count != rope.Count)
                return false;

            return rope.ZipWith(charSequence, Equal(ignoreCase)).And();
        }

        public static Optional<int> IndexOf<TEnumerable>(this TEnumerable rope, char c) 
            where TEnumerable : IEnumerable<char> {
            return IndexOf(rope, c, false);
        }

        public static Optional<int> IndexOf<TEnumerable>(this TEnumerable rope, char c, bool ignoreCase) 
            where TEnumerable : IEnumerable<char> {
            int i = 0;
            if (ignoreCase) {
                c = Char.ToUpperInvariant(c);

                foreach (char c1 in rope) {
                    if (c == Char.ToUpperInvariant(c1))
                        return i;
                    i++;
                }
            }
            else {
                foreach (char c1 in rope) {
                    if (c == c1)
                        return i;
                    i++;
                }
            }
            return Optional<int>.None;
        }

        public static Optional<int> IndexOfAny<TEnumerable>(this TEnumerable rope, params char[] anyOf) 
            where TEnumerable : IEnumerable<char> {
            int i = 0;
            foreach (char c in rope) {
                if (anyOf.Contains(c))
                    return i;
                i++;
            }
            return Optional<int>.None;
        }

        public static Optional<int> IndexOfAny<TEnumerable>(this TEnumerable rope, Func<char, bool> predicate)
            where TEnumerable : IEnumerable<char> {
            int i = 0;
            foreach (char c in rope) {
                if (predicate(c))
                    return i;
                i++;
            }
            return Optional<int>.None;
        }

        public static Optional<int> LastIndexOf<TSequence>(this TSequence charSequence, char ch) 
            where TSequence : ICharSequence {
            return LastIndexOf(charSequence, ch, false);
        }

        public static Optional<int> LastIndexOf<TSequence>(this TSequence charSequence, char ch, bool ignoreCase) 
            where TSequence : ICharSequence {
            var index = charSequence.ReverseIterator().IndexOf(ch, ignoreCase);
            return IndexFromEnd(charSequence, index);
        }

        public static Optional<int> LastIndexOfAny<TSequence>(this TSequence charSequence, params char[] anyOf)
            where TSequence : ICharSequence {
            var index = charSequence.ReverseIterator().IndexOfAny(anyOf);
            return IndexFromEnd(charSequence, index);
        }

        public static Optional<int> LastIndexOfAny<TSequence>(this TSequence charSequence, Func<char, bool> predicate)
            where TSequence : ICharSequence {
            var index = charSequence.ReverseIterator().IndexOfAny(predicate);
            return IndexFromEnd(charSequence, index);
        }

        private static Optional<int> IndexFromEnd<TSequence>(TSequence charSequence, Optional<int> index) 
            where TSequence : ICharSequence {
            return index.Map(i => charSequence.Count - 1 - i);
        }

        public static IEnumerable<TRope> Split<TRope>(this TRope rope, char[] separators, StringSplitOptions options)
            where TRope : IRope<TRope> {
            throw new System.NotImplementedException();
        }

        public static IEnumerable<TRope> Split<TRope>(this TRope rope, string[] separators, StringSplitOptions options)
            where TRope : IRope<TRope> {
            throw new System.NotImplementedException();
        }
    }
}