﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FP.HaskellNames;

namespace FP {
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for querying objects that 
    /// implement <see cref="IEnumerable{T}"/>. Contains the methods from the Haskell Data.List 
    /// module which are absent in LINQ. For alternate names for methods present in LINQ see 
    /// <see cref="Enumerable3"/>.
    /// </summary>
    /// <remarks>
    /// The source of each method includes the Haskell version as a comment at the end.
    /// Some methods are not safe to use with mutable collections. These cases are mentioned in the 
    /// documentation for the method. The order of arguments has generally been inverted compared 
    /// to the Haskell versions to facilitate method chaining.
    /// 
    /// See also the Remarks for <see cref="Enumerable"/>.
    /// </remarks>
    public static class Enumerable2 {
        #region Basic Functions

        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns></returns>
        /// <remarks>
        /// If the sequence has been modified between calling this method and iterating 
        /// over its result, an <see cref="InvalidOperationException"/> will be thrown.
        /// If you wish to prevent this and are not concerned about not getting an
        /// exception for the empty list, use <c>sequence.Skip(1)</c> instead.
        /// </remarks>
        public static IEnumerable<T> Tail<T>(
            this IEnumerable<T> sequence) {
            using (
                IEnumerator<T> enumerator = sequence.GetEnumerator()) {
                if (!enumerator.MoveNext())
                    throw new EmptySequenceException("tail");
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
            }

            //tail                    :: [a] -> [a]
            //tail (_:xs)             =  xs
            //tail []                 =  errorEmptyList "tail"
        }

        /// <summary>
        /// Return all the elements of a sequence except the last one. The sequence must be non-empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns></returns>
        /// <remarks>
        /// If the sequence has been modified between calling this method and iterating 
        /// over its result, an <see cref="InvalidOperationException"/> will be thrown.
        /// If you wish to prevent this and are not concerned about not getting an
        /// exception for the empty list, use <c>sequence.Skip(1)</c> instead.
        /// </remarks>
        public static IEnumerable<T> Init<T>(
            this IEnumerable<T> sequence) {
            using (
                IEnumerator<T> enumerator = sequence.GetEnumerator()) {
                if (!enumerator.MoveNext())
                    throw new EmptySequenceException("init");
                while (true) {
                    T current = enumerator.Current;
                    if (enumerator.MoveNext())
                        yield return current;
                    else
                        yield break;
                }
            }

            //
            //init []                 =  errorEmptyList "init"
            //init (x:xs)             =  init' x xs
            //  where init' _ []     = []
            //	init' y (z:zs) = y : init' z zs
        }

        /// <summary>
        /// Determines whether the specified sequence is empty. Called <c>null</c> in Haskell.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns>
        /// 	<c>true</c> if the specified sequence is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty<T>(this IEnumerable<T> sequence) {
            return !sequence.Any();

            //null                    :: [a] -> Bool
            //null []                 =  True
            //null (_:_)              =  False
        }

        #endregion

        #region List Transformations

        /// <summary>
        /// Intersperses an element between all members of the specified sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        /// <example>
        /// <c>"abcde".Intersperse(',').AsString() == "a,b,c,d,e"</c>
        /// </example>
        public static IEnumerable<T> Intersperse<T>(
            this IEnumerable<T> sequence, T separator) {
            using (
                IEnumerator<T> enumerator = sequence.GetEnumerator()) {
                if (!enumerator.MoveNext()) yield break;
                yield return enumerator.Current;
                while (enumerator.MoveNext()) {
                    yield return separator;
                    yield return enumerator.Current;
                }
            }

            //intersperse		:: a -> [a] -> [a]
            //intersperse _   []      = []
            //intersperse _   [x]     = [x]
            //intersperse sep (x:xs)  = x : sep : intersperse sep xs
        }

        /// <summary>
        /// Equivalent to <c>sequence.Intersperse(separator).ConcatAll()</c>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequences">The sequence.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        /// <remarks>
        /// This is a more general form of <see cref="string.Join(string,string[])"/></remarks>
        public static IEnumerable<T> Intercalate<T>(
            this IEnumerable<IEnumerable<T>> sequences,
            IEnumerable<T> separator) {
            return sequences.Intersperse(separator).Concat();

            //intercalate :: [a] -> [[a]] -> [a]
            //intercalate xs xss = concat (intersperse xs xss)
        }

        /// <summary>
        /// Transposes the "rows" and "columns" of the specified sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns></returns>
        /// <example>
        /// <c>
        /// new[] { new[] {1, 2}, new[] {1, 2}, new[] {1, 2} }.Transpose().
        ///     SequenceEquals(new[] { new[] {1, 1, 1}, new[] {2, 2, 2} }).
        /// </c>
        /// </example>
        /// <remarks>
        /// This method currently isn't fully lazy; it has to construct each column fully before yielding it.
        /// </remarks>
        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> sequence) {
            var enumerators = sequence.Map(seq => seq.GetEnumerator());
            var currentColumn = new List<T>();
            while (true) {
                foreach (var enumerator in enumerators) {
                    if (enumerator.MoveNext())
                        currentColumn.Add(enumerator.Current);
                }
                if (currentColumn.Any()) {
                    yield return currentColumn;
                    currentColumn.Clear();
                }
                else
                    yield break;
            }
            


            //transpose		:: [[a]] -> [[a]]
            //transpose []		 = []
            //transpose ([]	: xss)   = transpose xss
            //transpose ((x:xs) : xss) = (x : [h | (h:t) <- xss]) : transpose (xs : [ t | (h:t) <- xss])
        }

        #endregion

        #region Folds

        /// <summary>
        /// Reduces the sequence from right to left using the specified binary function
        /// starting with the specified accumulator value.
        /// In Haskell notation:
        /// <c>
        /// foldr f z [x1, x2, ..., xn] == x1 `f` (x2 `f` ... (xn `f` z)...)
        /// </c>
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TAcc">The type of the accumulator.</typeparam>
        /// <param name="sequence">The sequence to fold.</param>
        /// <param name="func">The binary function used to calculate .</param>
        /// <param name="initialAcc">The initial value of the accumulator.</param>
        /// <returns>The final accumulator value.</returns>
        /// <remarks>
        /// Unlike Haskell, <paramref name="func"/> usually won't be lazy, so this
        /// should not be used for associative <paramref name="func"/>.
        /// </remarks>
        public static TAcc FoldRight<T, TAcc>(
            this IEnumerable<T> sequence, TAcc initialAcc,
            Func<T, TAcc, TAcc> func) {
            return sequence.Reverse().Aggregate(initialAcc,
                                                func.Flip());

            //foldr            :: (a -> b -> b) -> b -> [a] -> b
            //foldr k z xs = go xs
            //	     where
            //	       go []     = z
            //	       go (y:ys) = y `k` go ys
        }

        /// <summary>
        /// Reduces the sequence from right to left using the specified binary function and
        /// starting with the last element of the sequence.
        /// In Haskell notation:
        /// <c>
        /// foldr1 f [x1, x2, ..., xn] == x1 `f` (x2 `f` ... (x{n-1} `f` xn)...)
        /// </c>
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence to fold.</param>
        /// <param name="func">The binary function used to calculate .</param>
        /// <returns>The final accumulator value.</returns>
        /// <remarks>
        /// Unlike Haskell, <paramref name="func"/> usually won't be lazy, so this
        /// should not be used for associative <paramref name="func"/>.
        /// </remarks>
        public static T FoldRight<T>(this IEnumerable<T> sequence,
                                     Func<T, T, T> func) {
            return sequence.Reverse().Aggregate(func);

            //foldr1                  :: (a -> a -> a) -> [a] -> a
            //foldr1 _ [x]            =  x
            //foldr1 f (x:xs)         =  f x (foldr1 f xs)
            //foldr1 _ []             =  errorEmptyList "foldr1"
        }

        /// <summary>
        /// Concatenates all elements of <paramref name="sequences"/> together.
        /// </summary>
        /// <param name="sequences">The sequence of sequences.</param>
        /// <returns></returns>
        public static IEnumerable<T> Concat<T>(
            this IEnumerable<IEnumerable<T>> sequences) {
            foreach (var sequence in sequences)
                foreach (T t in sequence)
                    yield return t;

            //concat :: [[a]] -> [a]
            //concat = foldr (++) []
        }

        /// <summary>
        /// Appends all elements of <paramref name="sequences"/> to <paramref name="sequence"/>.
        /// </summary>
        /// <param name="sequence">The first sequence.</param>
        /// <param name="sequences">The sequence of sequences.</param>
        /// <returns></returns>
        public static IEnumerable<T> Concat<T>(
            this IEnumerable<T> sequence,
            IEnumerable<IEnumerable<T>> sequences) {
            return sequence.Concat(sequences.Concat());
        }

        /// <summary>
        /// Returns the conjunction of a list of <see cref="bool"/>.
        /// </summary>
        /// <param name="bools">The bools.</param>
        /// <returns>The conjunction.</returns>
        public static bool And(this IEnumerable<bool> bools) {
            return bools.All(x => x);

            //and []		=  True
            //and (x:xs)	=  x && and xs
        }

        /// <summary>
        /// Returns the disjunction of a list of <see cref="bool"/>.
        /// </summary>
        /// <param name="bools">The bools.</param>
        /// <returns>The disjunction.</returns>
        public static bool Or(this IEnumerable<bool> bools) {
            return bools.Any(x => x);

            //or []		=  False
            //or (x:xs)	=  x || or xs
        }

        /// <summary>Computes the product of a sequence of <see cref="T:System.Double" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of <see cref="T:System.Double" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        public static double Product(this IEnumerable<double> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            double num = 1.0;
            foreach (double num2 in source)
                num *= num2;
            return num;

            //product	l	= prod l 1
            //  where
            //    prod []     a = a
            //    prod (x:xs) a = prod xs (a*x)
            //#endif
        }

        /// <summary>Computes the product of a sequence of nullable <see cref="T:System.Decimal" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of nullable <see cref="T:System.Decimal" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.OverflowException">The sum is larger than <see cref="F:System.Decimal.MaxValue" />.</exception>
        public static decimal? Product(
            this IEnumerable<decimal?> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            decimal num = 1M;
            foreach (var nullable in source)
                if (nullable.HasValue)
                    num *= nullable.GetValueOrDefault();
            return num;
        }

        /// <summary>Computes the product of a sequence of <see cref="T:System.Decimal" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of <see cref="T:System.Decimal" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.OverflowException">The sum is larger than <see cref="F:System.Decimal.MaxValue" />.</exception>
        public static decimal Product(this IEnumerable<decimal> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            decimal num = 1M;
            foreach (decimal num2 in source)
                num *= num2;
            return num;
        }

        /// <summary>Computes the product of a sequence of <see cref="T:System.Int32" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of <see cref="T:System.Int32" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.OverflowException">The sum is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public static int Product(this IEnumerable<int> source) {
            if (source == null) {
                throw new ArgumentNullException("source");
            }
            int num = 1;
            foreach (int num2 in source)
                num *= num2;
            return num;
        }

        /// <summary>Computes the product of a sequence of <see cref="T:System.Int64" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of <see cref="T:System.Int64" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.OverflowException">The sum is larger than <see cref="F:System.Int64.MaxValue" />.</exception>
        public static long Product(this IEnumerable<long> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            long num = 1L;
            foreach (long num2 in source)
                num *= num2;
            return num;
        }

        /// <summary>Computes the product of a sequence of nullable <see cref="T:System.Double" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of nullable <see cref="T:System.Double" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        public static double? Product(this IEnumerable<double?> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            double num = 1.0;
            foreach (var nullable in source)
                if (nullable.HasValue)
                    num *= nullable.GetValueOrDefault();
            return num;
        }

        /// <summary>Computes the product of a sequence of nullable <see cref="T:System.Int32" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of nullable <see cref="T:System.Int32" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.OverflowException">The sum is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public static int? Product(this IEnumerable<int?> source) {
            if (source == null) {
                throw new ArgumentNullException("source");
            }
            int num = 1;
            foreach (var nullable in source) {
                if (nullable.HasValue) {
                    num *= nullable.GetValueOrDefault();
                }
            }
            return num;
        }

        /// <summary>Computes the product of a sequence of nullable <see cref="T:System.Int64" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of nullable <see cref="T:System.Int64" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.OverflowException">The sum is larger than <see cref="F:System.Int64.MaxValue" />.</exception>
        public static long? Product(this IEnumerable<long?> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            long num = 1L;
            foreach (var nullable in source)
                if (nullable.HasValue)
                    num *= nullable.GetValueOrDefault();
            return num;
        }

        /// <summary>Computes the product of a sequence of nullable <see cref="T:System.Single" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of nullable <see cref="T:System.Single" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        public static float? Product(this IEnumerable<float?> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            double num = 1.0;
            foreach (var nullable in source)
                if (nullable.HasValue)
                    num *= nullable.GetValueOrDefault();
            return (float) num;
        }

        /// <summary>Computes the product of a sequence of <see cref="T:System.Single" /> values.</summary>
        /// <returns>the product of the values in the sequence.</returns>
        /// <param name="source">A sequence of <see cref="T:System.Single" /> values to calculate the product of.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="source" /> is null.</exception>
        public static float Product(this IEnumerable<float> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            double num = 1.0;
            foreach (float num2 in source)
                num *= num2;
            return (float) num;
        }

        #endregion

        #region Building lists

        /// <summary>
        /// Reduces the sequence from left to right using the specified binary function
        /// starting with the specified accumulator value, and yields the intermediate
        /// accumulator values.
        /// In Haskell notation:
        /// <c>
        /// scanl f z [x1, x2, ...] == [z, z `f` x1, (z `f` x1) `f` x2, ...]
        /// </c>
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TAcc">The type of the accumulator.</typeparam>
        /// <param name="sequence">The sequence to fold.</param>
        /// <param name="func">The binary function.</param>
        /// <param name="initialAcc">The initial value of the accumulator.</param>
        /// <returns>The list of accumulator values.</returns>
        public static IEnumerable<TAcc> ScanLeft<T, TAcc>(
            this IEnumerable<T> sequence, TAcc initialAcc,
            Func<TAcc, T, TAcc> func) {
            yield return initialAcc;
            foreach (T t in sequence) {
                initialAcc = func(initialAcc, t);
                yield return initialAcc;
            }

            //scanl                   :: (a -> b -> a) -> a -> [b] -> [a]
            //scanl f q ls            =  q : (case ls of
            //                                []   -> []
            //                                x:xs -> scanl f (f q x) xs)
        }

        /// <summary>
        /// Reduces the sequence from left to right using the specified binary function,
        /// starting with the first element of the sequence and yielding the intermediate
        /// accumulator values.
        /// In Haskell notation:
        /// <c>
        /// scanl1 f [x1, x2, ...] == [x1, x1 `f` x2, (x1 `f` x2) `f` x3, ...]
        /// </c>
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence to fold.</param>
        /// <param name="func">The binary function.</param>
        /// <returns>The list of accumulator values.</returns>
        public static IEnumerable<T> ScanLeft<T>(
            this IEnumerable<T> sequence, Func<T, T, T> func) {
            using (
                IEnumerator<T> enumerator = sequence.GetEnumerator()) {
                if (!enumerator.MoveNext())
                    throw new EmptySequenceException("scanleft");
                T acc = enumerator.Current;
                yield return acc;
                while (enumerator.MoveNext()) {
                    acc = func(acc, enumerator.Current);
                    yield return acc;
                }
            }

            //scanl1			:: (a -> a -> a) -> [a] -> [a]
            //scanl1 f (x:xs)	=  scanl f x xs
            //scanl1 _ []		=  []
        }

        /// <summary>
        /// Reduces the sequence from right to left using the specified binary function
        /// starting with the specified accumulator value, and yields the intermediate
        /// accumulator values.
        /// In Haskell notation:
        /// <c>
        /// scanl f z [x1, x2, ...] == [z, z `f` x1, (z `f` x1) `f` x2, ...]
        /// </c>
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TAcc">The type of the accumulator.</typeparam>
        /// <param name="sequence">The sequence to fold.</param>
        /// <param name="func">The binary function.</param>
        /// <param name="initialAcc">The initial value of the accumulator.</param>
        /// <returns>The list of accumulator values.</returns>
        public static IEnumerable<TAcc> ScanRight<T, TAcc>(
            this IEnumerable<T> sequence, TAcc initialAcc,
            Func<T, TAcc, TAcc> func) {
            return
                sequence.Reverse().ScanLeft(initialAcc, func.Flip()).
                    Reverse();

            //scanr                   :: (a -> b -> b) -> b -> [a] -> [b]
            //scanr _ q0 []           =  [q0]
            //scanr f q0 (x:xs)       =  f x q : qs
            //                           where qs@(q:_) = scanr f q0 xs 
        }

        /// <summary>
        /// Reduces the sequence from left to right using the specified binary function,
        /// starting with the first element of the sequence and yielding the intermediate
        /// accumulator values.
        /// In Haskell notation:
        /// <c>
        /// scanl1 f [x1, x2, ...] == [x1, x1 `f` x2, (x1 `f` x2) `f` x3, ...]
        /// </c>
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence to fold.</param>
        /// <param name="func">The binary function.</param>
        /// <returns>The list of accumulator values.</returns>
        public static IEnumerable<T> ScanRight<T>(
            this IEnumerable<T> sequence, Func<T, T, T> func) {
            return sequence.Reverse().ScanLeft(func.Flip()).Reverse();

            //scanr1                  :: (a -> a -> a) -> [a] -> [a]
            //scanr1 f []		=  []
            //scanr1 f [x]		=  [x]
            //scanr1 f (x:xs)		=  f x q : qs
            //                           where qs@(q:_) = scanr1 f xs
        }

        //TODO: MapAccumLeft, MapAccumRight

        /// <summary>
        /// Iterates the specified function, starting with the specified value.
        /// In Haskell notation:
        /// <c>
        /// iterate f x == [x, f x, f (f x), ...]
        /// </c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The function.</param>
        /// <param name="init">The initial value.</param>
        /// <returns></returns>
        public static IEnumerable<T> Iterate<T>(this Func<T, T> func,
                                                T init) {
            T curr = init;
            while (true) {
                yield return curr;
                curr = func(curr);
            }

            //iterate :: (a -> a) -> a -> [a]
            //iterate f x =  x : iterate f (f x)
        }

        /// <summary>
        /// Repeats the specified value the specified number of times.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="times">The number of times to repeat the value.</param>
        /// <returns></returns>
        /// <remarks>Not an extension method in order not to pollute namespace.</remarks>
        public static IEnumerable<T> Replicate<T>( /*this*/
            T value, int times) {
            for (int i = 0; i < times; i++)
                yield return value;

            //replicate     :: Int -> a -> [a]
            //replicate n x =  take n (repeat x)
        }

        /// <summary>
        /// Repeats the specified sequence an infinite number of times.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns></returns>
        public static IEnumerable<T> Cycle<T>(
            this IEnumerable<T> sequence) {
            if (sequence.IsEmpty())
                throw new EmptySequenceException("cycle");
            while (true)
                foreach (T t in sequence)
                    yield return t;

            //cycle    :: [a] -> [a]
            //cycle [] = error "Prelude.cycle: empty list"
            //cycle xs = xs' where xs' = xs ++ xs'
        }

        /// <summary>Generates a sequence of integral numbers starting with a specified number.</summary>
        /// <returns>An <see cref="IEnumerable{int}"/> that contains a range of sequential 
        /// integral numbers up to <see cref="int.MaxValue"/>.</returns>
        /// <param name="start">The value of the first integer in the sequence.</param>
        public static IEnumerable<int> IntsFrom(int start) {
            for (int i = start; i < int.MaxValue; i++)
                yield return i;

            //[start..]
        }

        /// <summary>Generates a sequence of integral numbers starting with a specified number
        /// with a specified step.</summary>
        /// <returns>An <see cref="IEnumerable{int}"/> that contains a range of 
        /// integral numbers up to <see cref="int.MaxValue"/> or down to
        /// <see cref="int.MinValue"/>.</returns>
        /// <param name="start">The value of the first integer in the sequence.</param>
        /// <param name="step">The difference between two consequent elements of the
        /// sequence.</param>
        /// <exception cref="ArgumentException">if <paramref name="step"/> equals 0.</exception>
        public static IEnumerable<int> IntsFrom(int start, int step) {
            if (step == 0)
                throw new ArgumentException();
            if (step > 0) {
                for (int i = start; i < int.MaxValue; i += step)
                    yield return i;
                yield break;
            }
            for (int i = start; i > int.MinValue; i += step)
                yield return i;

            //[start, start + step..]
        }

        /// <summary>Generates a sequence of integral numbers starting and ending with a specified number.</summary>
        /// <returns>An <see cref="IEnumerable{int}"/> that contains a range of sequential 
        /// integral numbers.</returns>
        /// <param name="start">The value of the first integer in the sequence.</param>
        /// <param name="end">The value of the last integer in the sequence.</param>
        public static IEnumerable<int> Range(int start, int end) {
            for (int i = start; i <= end; i++)
                yield return i;

            //[start..end]
        }

        /// <summary>Generates a sequence of integral numbers starting and ending with a specified number
        /// with a specified step.</summary>
        /// <returns>An <see cref="IEnumerable{int}"/> that contains a range of 
        /// sequential integral numbers.</returns>
        /// <param name="start">The value of the first integer in the sequence.</param>
        /// <param name="end">The value of the last integer in the sequence.</param>
        /// <param name="step">The difference between two consequent elements of the
        /// sequence.</param>
        /// <exception cref="ArgumentException">if <paramref name="step"/> equals 0
        /// or has a different sign from <c><paramref name="end"/> - <paramref name="start"/></c>.</exception>
        public static IEnumerable<int> Range(int start, int end,
                                             int step) {
            if (step == 0 || step*(end - start) < 0)
                throw new ArgumentException();
            if (step > 0) {
                for (int i = start; i <= end; i += step)
                    yield return i;
                yield break;
            }
            for (int i = start; i >= end; i += step)
                yield return i;

            //[start, start + step..end]
        }

        /// <summary>
        /// Produces a list from the given seed using the cpecified function.
        /// Function should return <c>null</c> in order to finish constructing the list;
        /// if <paramref name="func"/> returns a pair <c>x, state</c>, then <c>x</c> is added to the list
        /// and <paramref name="func"/> will next be called with <c>state</c> as its argument.
        /// 
        /// It is usually easier to write an iterator instead, since this allows easily working with
        /// quite complicated <typeparamref name="TState"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the sequence.</typeparam>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="func">The function.</param>
        /// <param name="initialState">The initial state.</param>
        /// <returns></returns>
        public static IEnumerable<T> Unfold<T, TState>(
            this Func<TState, Pair<T, TState>?> func,
            TState initialState) {
            Pair<T, TState>? pair = func(initialState);
            while (pair.HasValue) {
                yield return pair.Value.First;
                pair = func(pair.Value.Second);
            }

            //unfoldr      :: (b -> Maybe (a, b)) -> b -> [a]
            //unfoldr f b  =
            //  case f b of
            //   Just (a,new_b) -> a : unfoldr f new_b
            //   Nothing        -> []
        }

        #endregion

        #region Sublists

        //TODO: SplitAt, Span, Break

        /// <summary>
        /// Strips the prefix off the sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="prefix"/> is not a prefix of <paramref name="sequence"/>.
        /// </exception>
        public static IEnumerable<T> StripPrefix<T>(
            this IEnumerable<T> sequence, IEnumerable<T> prefix) {
            using (
                IEnumerator<T> enumerator = sequence.GetEnumerator()) {
                foreach (T t in prefix) {
                    if (!enumerator.MoveNext() ||
                        !t.Equals(enumerator.Current))
                        throw new InvalidOperationException();
                }
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
            }

            //stripPrefix :: Eq a => [a] -> [a] -> Maybe [a]
            //stripPrefix [] ys = Just ys
            //stripPrefix (x:xs) (y:ys)
            // | x == y = stripPrefix xs ys
            //stripPrefix _ _ = Nothing
        }

        //TODO: group, init, tails
        /// <summary>
        /// Determines whether the first sequence is a prefix of the second.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix">The possible prefix.</param>
        /// <param name="sequence">The sequence.</param>
        /// <returns>
        /// 	<c>true</c> if the first sequence is a prefix of the second; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPrefixOf<T>(this IEnumerable<T> prefix,
                                         IEnumerable<T> sequence) {
            if (prefix == null)
                throw new ArgumentNullException("prefix");
            if (sequence == null)
                throw new ArgumentNullException("sequence");
            using (
                IEnumerator<T> enumerator = sequence.GetEnumerator()) {
                foreach (T t in prefix) {
                    if (!enumerator.MoveNext() ||
                        !t.Equals(enumerator.Current))
                        return false;
                }
                return true;
            }

            //isPrefixOf              :: (Eq a) => [a] -> [a] -> Bool
            //isPrefixOf [] _         =  True
            //isPrefixOf _  []        =  False
            //isPrefixOf (x:xs) (y:ys)=  x == y && isPrefixOf xs ys
        }

        /// <summary>
        /// Determines whether the first sequence is a suffix of the second.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="suffix">The possible suffix.</param>
        /// <param name="sequence">The sequence.</param>
        /// <returns>
        /// 	<c>true</c> if the first sequence is a suffix of the second; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSuffixOf<T>(this IEnumerable<T> suffix,
                                         IEnumerable<T> sequence)
            where T : IEquatable<T> {
            return suffix.Reverse().IsPrefixOf(sequence.Reverse());

            //isSuffixOf              :: (Eq a) => [a] -> [a] -> Bool
            //isSuffixOf x y          =  reverse x `isPrefixOf` reverse y
        }

        //TODO: IsInfixOf

        #endregion

        #region Searching lists

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="predicate">The match.</param>
        /// <returns>The first occurrence of an element that matches the conditions defined by 
        /// <paramref name="predicate"/> within <paramref name="sequence"/>.</returns>
        /// <exception cref="NotFoundException">
        /// If no element satisfying <paramref name="predicate"/> is found.
        /// </exception>
        public static T Find<T>(this IEnumerable<T> sequence,
                                Func<T, bool> predicate) {
            if (sequence == null)
                throw new ArgumentNullException("sequence");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            foreach (T t in sequence)
                if (predicate(t))
                    return t;
            throw new NotFoundException();
            //
            //find		:: (a -> Bool) -> [a] -> Maybe a
            //find p          = listToMaybe . filter p
        }

        /// <summary>
        /// Searches for an element which equals the specified element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="element">The match.</param>
        /// <returns>The first occurrence of an element that equals
        /// <paramref name="element"/> within <paramref name="sequence"/>.</returns>
        /// <exception cref="NotFoundException">
        /// If no element satisfying <paramref name="element"/> is found.
        /// </exception>
        public static T Find<T>(this IEnumerable<T> sequence,
                                T element) {
            return sequence.Find(t => t.Equals(element));
        }

        #endregion

        #region Indexing lists

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="predicate">The match.</param>
        /// <returns>The index of first occurrence of an element that matches the conditions defined by 
        /// <paramref name="predicate"/> within <paramref name="sequence"/>.</returns>
        /// <exception cref="NotFoundException">
        /// If no element satisfying <paramref name="predicate"/> is found.
        /// </exception>
        public static int FindIndex<T>(this IEnumerable<T> sequence,
                                       Func<T, bool> predicate) {
            if (sequence == null)
                throw new ArgumentNullException("sequence");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            int i = 0;
            foreach (T t in sequence) {
                if (predicate(t))
                    return i;
                i++;
            }
            throw new NotFoundException();
            //
            //findIndex       :: (a -> Bool) -> [a] -> Maybe Int
            //findIndex p     = listToMaybe . findIndices p
        }

        /// <summary>
        /// Searches for an element which equals the specified element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="element">The match.</param>
        /// <returns>The index of first occurrence of an element that equals
        /// <paramref name="element"/> within <paramref name="sequence"/>.</returns>
        /// <exception cref="NotFoundException">
        /// If no element satisfying <paramref name="element"/> is found.
        /// </exception>
        public static int FindIndex<T>(this IEnumerable<T> sequence,
                                       T element) {
            return sequence.FindIndex(t => t.Equals(element));
            //
            //elemIndex	:: Eq a => a -> [a] -> Maybe Int
            //elemIndex x     = findIndex (x==)
        }

        /// <summary>
        /// Searches for all elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="predicate">The match.</param>
        /// <returns>The sequence of indices of elements that match the conditions defined by 
        /// <paramref name="predicate"/> within <paramref name="sequence"/>.</returns>
        public static IEnumerable<int> FindIndices<T>(
            this IEnumerable<T> sequence, Func<T, bool> predicate) {
            if (sequence == null)
                throw new ArgumentNullException("sequence");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            int i = 0;
            foreach (T t in sequence) {
                if (predicate(t))
                    yield return i;
                i++;
            }
            //
            //findIndices      :: (a -> Bool) -> [a] -> [Int]
            //findIndices p xs = [ i | (x,i) <- zip xs [0..], p x]
        }

        /// <summary>
        /// Searches for an element which equals the specified element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="element">The match.</param>
        /// <returns>The sequence of indices of elements that equal 
        /// <paramref name="element"/> within <paramref name="sequence"/>.</returns>
        public static IEnumerable<int> FindIndices<T>(
            this IEnumerable<T> sequence, T element) {
            return sequence.FindIndices(t => t.Equals(element));
            //
            //elemIndices     :: Eq a => a -> [a] -> [Int]
            //elemIndices x   = findIndices (x==)
        }

        #endregion

        #region Zipping and unzipping lists

        /// <summary>
        /// Takes two sequences and returns a sequence of corresponding pairs. 
        /// If one sequence is short, excess elements of the longer sequence are discarded.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="sequence1">The first sequence.</param>
        /// <param name="sequence2">The second sequence.</param>
        /// <returns></returns>
        public static IEnumerable<Pair<T1, T2>> Zip<T1, T2>(
            this IEnumerable<T1> sequence1, IEnumerable<T2> sequence2) {
            using (
                IEnumerator<T1> enumerator1 =
                    sequence1.GetEnumerator())
            using (
                IEnumerator<T2> enumerator2 =
                    sequence2.GetEnumerator()) {
                while (enumerator1.MoveNext() &&
                       enumerator2.MoveNext()) {
                    yield return
                        Pair.New(enumerator1.Current,
                                 enumerator2.Current);
                }
            }
            //
            //zip :: [a] -> [b] -> [(a,b)]
            //zip (a:as) (b:bs) = (a,b) : zip as bs
            //zip _      _      = []
        }

        /// <summary>
        /// Takes three sequences and returns a sequence of corresponding triples.
        /// If one sequence is short, excess elements of the longer sequences are discarded.
        /// </summary>
        /// <param name="sequence1">The first sequence.</param>
        /// <param name="sequence2">The second sequence.</param>
        /// <param name="sequence3">The third sequence.</param>
        /// <returns></returns>
        public static IEnumerable<Triple<T1, T2, T3>>
            Zip<T1, T2, T3>(this IEnumerable<T1> sequence1,
                            IEnumerable<T2> sequence2,
                            IEnumerable<T3> sequence3) {
            using (
                IEnumerator<T1> enumerator1 =
                    sequence1.GetEnumerator())
            using (
                IEnumerator<T2> enumerator2 =
                    sequence2.GetEnumerator())
            using (
                IEnumerator<T3> enumerator3 =
                    sequence3.GetEnumerator()) {
                while (enumerator1.MoveNext() &&
                       enumerator2.MoveNext() &&
                       enumerator3.MoveNext()) {
                    yield return
                        Triple.New(enumerator1.Current,
                                   enumerator2.Current,
                                   enumerator3.Current);
                }
            }

            //zip3 :: [a] -> [b] -> [c] -> [(a,b,c)]
            //zip3 (a:as) (b:bs) (c:cs) = (a,b,c) : zip3 as bs cs
            //zip3 _      _      _      = []
        }

        /// <summary>
        /// Takes four sequences and returns a sequence of corresponding quadruples.
        /// If one sequence is short, excess elements of the longer sequences are discarded.
        /// </summary>
        /// <param name="sequence1">The first sequence.</param>
        /// <param name="sequence2">The second sequence.</param>
        /// <param name="sequence3">The third sequence.</param>
        /// <param name="sequence4">The fourth sequence.</param>
        /// <returns></returns>
        public static IEnumerable<Quadruple<T1, T2, T3, T4>>
            Zip<T1, T2, T3, T4>(this IEnumerable<T1> sequence1,
                                IEnumerable<T2> sequence2,
                                IEnumerable<T3> sequence3,
                                IEnumerable<T4> sequence4) {
            using (
                IEnumerator<T1> enumerator1 =
                    sequence1.GetEnumerator())
            using (
                IEnumerator<T2> enumerator2 =
                    sequence2.GetEnumerator())
            using (
                IEnumerator<T3> enumerator3 =
                    sequence3.GetEnumerator())
            using (
                IEnumerator<T4> enumerator4 =
                    sequence4.GetEnumerator()) {
                while (enumerator1.MoveNext() &&
                       enumerator2.MoveNext() &&
                       enumerator3.MoveNext() &&
                       enumerator4.MoveNext()) {
                    yield return
                        Quadruple.New(enumerator1.Current,
                                      enumerator2.Current,
                                      enumerator3.Current,
                                      enumerator4.Current);
                }
            }
            //
            //zip4			:: [a] -> [b] -> [c] -> [d] -> [(a,b,c,d)]
            //zip4			=  zipWith4 (,,,)
        }

        /// <summary>
        /// Takes two sequences and a function, calls the function on corresponding pairs
        /// and returns a sequence of the results.
        /// If one sequence is short, excess elements of the longer sequence are discarded.
        /// </summary>
        /// <param name="function">The function used to combine pairs.</param>
        /// <param name="sequence1">The first sequence.</param>
        /// <param name="sequence2">The second sequence.</param>
        /// <returns></returns>
        public static IEnumerable<T> ZipWith<T1, T2, T>(
            this Func<T1, T2, T> function, IEnumerable<T1> sequence1,
            IEnumerable<T2> sequence2) {
            using (
                IEnumerator<T1> enumerator1 =
                    sequence1.GetEnumerator())
            using (
                IEnumerator<T2> enumerator2 =
                    sequence2.GetEnumerator()) {
                while (enumerator1.MoveNext() &&
                       enumerator2.MoveNext())
                    yield return
                        function(enumerator1.Current,
                                 enumerator2.Current);
            }
            //
            //zipWith :: (a->b->c) -> [a]->[b]->[c]
            //zipWith f (a:as) (b:bs) = f a b : zipWith f as bs
            //zipWith _ _      _      = []
        }

        /// <summary>
        /// Takes three sequences and a function, calls the function on corresponding triples
        /// and returns a sequence of the results.
        /// If one sequence is short, excess elements of the longer sequences are discarded.
        /// </summary>
        /// <param name="function">The function used to combine triples.</param>
        /// <param name="sequence1">The first sequence.</param>
        /// <param name="sequence2">The second sequence.</param>
        /// <param name="sequence3">The third sequence.</param>
        /// <returns></returns>
        public static IEnumerable<T> ZipWith<T1, T2, T3, T>(
            this Func<T1, T2, T3, T> function,
            IEnumerable<T1> sequence1, IEnumerable<T2> sequence2,
            IEnumerable<T3> sequence3) {
            using (
                IEnumerator<T1> enumerator1 =
                    sequence1.GetEnumerator())
            using (
                IEnumerator<T2> enumerator2 =
                    sequence2.GetEnumerator())
            using (
                IEnumerator<T3> enumerator3 =
                    sequence3.GetEnumerator()) {
                while (enumerator1.MoveNext() &&
                       enumerator2.MoveNext() &&
                       enumerator3.MoveNext())
                    yield return
                        function(enumerator1.Current,
                                 enumerator2.Current,
                                 enumerator3.Current);
            }
            //
            //zipWith3                :: (a->b->c->d) -> [a]->[b]->[c]->[d]
            //zipWith3 z (a:as) (b:bs) (c:cs)
            //                        =  z a b c : zipWith3 z as bs cs
            //zipWith3 _ _ _ _        =  []
        }

        /// <summary>
        /// Takes four sequences and a function, calls the function on corresponding quadruples
        /// and returns a sequence of the results.
        /// If one sequence is short, excess elements of the longer sequences are discarded.
        /// </summary>
        /// <param name="function">The function used to combine quadruples.</param>
        /// <param name="sequence1">The first sequence.</param>
        /// <param name="sequence2">The second sequence.</param>
        /// <param name="sequence3">The third sequence.</param>
        /// <param name="sequence4">The fourth sequence.</param>
        /// <returns></returns>
        public static IEnumerable<T> ZipWith<T1, T2, T3, T4, T>(
            this Func<T1, T2, T3, T4, T> function,
            IEnumerable<T1> sequence1, IEnumerable<T2> sequence2,
            IEnumerable<T3> sequence3, IEnumerable<T4> sequence4) {
            using (
                IEnumerator<T1> enumerator1 =
                    sequence1.GetEnumerator())
            using (
                IEnumerator<T2> enumerator2 =
                    sequence2.GetEnumerator())
            using (
                IEnumerator<T3> enumerator3 =
                    sequence3.GetEnumerator())
            using (
                IEnumerator<T4> enumerator4 =
                    sequence4.GetEnumerator()) {
                while (enumerator1.MoveNext() &&
                       enumerator2.MoveNext() &&
                       enumerator3.MoveNext() &&
                       enumerator4.MoveNext())
                    yield return
                        function(enumerator1.Current,
                                 enumerator2.Current,
                                 enumerator3.Current,
                                 enumerator4.Current);
            }
        }

        /// <summary>
        /// Returns a sequence of pairs consisting of indices and corresponding elements of the
        /// specified sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns></returns>
        public static IEnumerable<Pair<int, T>> WithIndex<T>(
            this IEnumerable<T> sequence) {
            return Zip(IntsFrom(0), sequence);
        }

        //TODO: Unzip

        #endregion

        #region Lists as Sets

        /// <summary>
        /// Searches for an element
        /// and removes it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="element">The match.</param>
        /// <returns><paramref name="sequence"/> except the first occurrence of <paramref name="element"/>.</returns>
        public static IEnumerable<T> Delete<T>(
            this IEnumerable<T> sequence, T element) {
            return sequence.Delete(t => t.Equals(element));
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate
        /// and removes it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="predicate">The match.</param>
        /// <returns><paramref name="sequence"/> except the first occurrence of an element 
        /// that matches the conditions defined by <paramref name="predicate"/>.</returns>
        public static IEnumerable<T> Delete<T>(
            this IEnumerable<T> sequence, Func<T, bool> predicate) {
            using (
                IEnumerator<T> enumerator = sequence.GetEnumerator()) {
                while (enumerator.MoveNext()) {
                    T current = enumerator.Current;
                    if (predicate(current))
                        break;
                    yield return current;
                }
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
            }
        }

        #endregion

        #region Ordered Lists

        /// <summary>Sorts the elements of a sequence in ascending order.</summary>
        /// <returns>An <see cref="T:System.Linq.IOrderedEnumerable`1" /> whose elements are sorted according to a key.</returns>
        /// <param name="sequence">A sequence of values to sort.</param>
        /// <typeparam name="T">The type of the elements of <paramref name="sequence" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="sequence" /> is null.</exception>
        public static IOrderedEnumerable<T> Sort<T>(
            this IEnumerable<T> sequence) {
            return sequence.Sort(Comparer<T>.Default);
        }

        /// <summary>Sorts the elements of a sequence in ascending order by using a specified comparer.</summary>
        /// <returns>An <see cref="T:System.Linq.IOrderedEnumerable`1" /> whose elements are sorted.</returns>
        /// <param name="sequence">A sequence of values to sort.</param>
        /// <param name="comparer">An <see cref="T:System.Collections.Generic.IComparer`1" /> to compare keys.</param>
        /// <typeparam name="T">The type of the elements of <paramref name="sequence" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="sequence" /> is null.</exception>
        public static IOrderedEnumerable<T> Sort<T>(
            this IEnumerable<T> sequence, IComparer<T> comparer) {
            return sequence.OrderBy(x => x, comparer);
        }

        /// <summary>Sorts the elements of a sequence in descending order according to a key.</summary>
        /// <returns>An <see cref="T:System.Linq.IOrderedEnumerable`1" /> whose elements are sorted in descending order.</returns>
        /// <param name="sequence">A sequence of values to sort.</param>
        /// <typeparam name="T">The type of the elements of <paramref name="sequence" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="sequence" /> is null.</exception>
        public static IOrderedEnumerable<T> SortDescending<T>(
            this IEnumerable<T> sequence) {
            return sequence.SortDescending(Comparer<T>.Default);
        }

        /// <summary>Sorts the elements of a sequence in descending order by using a specified comparer.</summary>
        /// <returns>An <see cref="T:System.Linq.IOrderedEnumerable`1" /> whose elements are sorted in descending order.</returns>
        /// <param name="sequence">A sequence of values to sort.</param>
        /// <param name="comparer">An <see cref="T:System.Collections.Generic.IComparer`1" /> to compare keys.</param>
        /// <typeparam name="T">The type of the elements of <paramref name="sequence" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="sequence" /> is null.</exception>
        public static IOrderedEnumerable<T> SortDescending<T>(
            this IEnumerable<T> sequence, IComparer<T> comparer) {
            return sequence.OrderByDescending(x => x, comparer);
        }

        #endregion

        #region Generalized functions

        #endregion
    }
}