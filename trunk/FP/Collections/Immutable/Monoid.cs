#region License
/*
* Monoid.cs is part of functional-dotnet project
* 
* Copyright (c) 2008 Alexey Romanov
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
#endregion

using System;
using System.Collections.Generic;
using FP.Core;

namespace FP.Collections.Immutable {
    /// <summary>
    /// A monoid structure on the type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type of the elements of the monoid.</typeparam>
    public class Monoid<T> {
        /// <summary>
        /// The zero of the monoid. It should always be the case that <code>forall x. Zero.Add(x) == x</code>
        /// and <code>x.Add(Zero) == x</code>.
        /// </summary>
        public readonly T Zero;

        /// <summary>
        /// The addition operation. It should always be associative, that is, <code>forall x y z. x.Add(y).Add(z) == x.Add(y.Add(z))</code>.
        /// </summary>
        public readonly Func<T, T, T> Plus;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monoid&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="zero">The zero.</param>
        /// <param name="add">The add.</param>
        public Monoid(T zero, Func<T, T, T> add) {
            Zero = zero;
            Plus = add;
        }
    }

    /// <summary>
    /// Predefined monoids.
    /// </summary>
    public static class Monoids {
        /// <summary>
        /// The monoid used for <see cref="RandomAccessSequence{T}"/>.
        /// </summary>
        public static readonly Monoid<int> Size = new Monoid<int>(0, (x, y) => x + y);

        /// <summary>
        /// The monoid used for <see cref="PriorityQueue{P,T}"/>.
        /// </summary>
        public static readonly Monoid<double> Priority =
            new Monoid<double>(double.NegativeInfinity, Math.Max);

        /// <summary>
        /// The product of two monoids.
        /// </summary>
        public static Monoid<Tuple<T1, T2>> Product<T1, T2>(this Monoid<T1> monoid1, Monoid<T2> monoid2) {
            return new Monoid<Tuple<T1, T2>>(Pair.New(monoid1.Zero, monoid2.Zero),
                (p1, p2) => Pair.New(monoid1.Plus(p1.Item1, p2.Item1), monoid2.Plus(p1.Item2, p2.Item2)));
        }

        /// <summary>
        /// The monoid used for <see cref="PriorityQueue{P,T}"/>.
        /// </summary>
        public static Monoid<P> PriorityM<P>(P min, IComparer<P> comparer) {
            return new Monoid<P>(min, (x, y) => comparer.Max(x, y));
        }
    }
}