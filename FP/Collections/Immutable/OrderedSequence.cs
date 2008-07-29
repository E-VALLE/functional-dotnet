using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using FP.HaskellNames;

namespace FP.Collections.Immutable {
    /// <summary>
    /// A finger-tree-based ordered (by keys) sequence.
    /// </summary>
    /// <typeparam name="K">The type of the keys.</typeparam>
    /// <typeparam name="T">The type of the elements of the sequence.</typeparam>
    /// <remarks>Do not use the default constructor.</remarks>
    public struct OrderedSequence<K, T> : IEnumerable<T>, IEquatable<OrderedSequence<K, T>> {
        private readonly K _noKey;
        private readonly IComparer<K> _comparer;

        /// <summary>
        /// Gets the comparer used to compare keys.
        /// </summary>
        public IComparer<K> Comparer {
            get { return _comparer; }
        }

        private readonly Monoid<Pair<K, int>> _monoid;
        private readonly FingerTree<Element, Pair<K, int>> _ft;

        /// <summary>
        /// The sentinel value for keys. Never add an element with this value!
        /// </summary>
        public K NoKey {
            get { return _noKey; }
        }

        [DebuggerDisplay("Key = {Key}, Value = {Value}")]
        internal struct Element : IMeasured<Pair<K, int>> {
            internal readonly K Key;
            internal readonly T Value;

            public Element(K key, T value) {
                Key = key;
                Value = value;
            }

            public Pair<K, int> Measure {
                get { return Pair.New(Key, 1); }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedSequence{K,T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer used to check for equality to <paramref name="noKey"/>.</param>
        /// <param name="noKey">The sentinel value.</param>
        public OrderedSequence(IComparer<K> comparer, K noKey) {
            _comparer = comparer;
            _monoid = OrderedSequence.MakeMonoid(noKey, comparer);
            _ft = FingerTree.Empty<Element, Pair<K, int>>(_monoid);
            _noKey = noKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedSequence{K,T}"/> class.
        /// </summary>
        /// <param name="noKey">The sentinel value.</param>
        public OrderedSequence(K noKey) : this(Comparer<K>.Default, noKey) { }

        internal OrderedSequence(IComparer<K> comparer, K noKey, FingerTree<Element, Pair<K, int>> ft) {
            _comparer = comparer;
            _ft = ft;
            _monoid = ft.MeasureMonoid;
            _noKey = noKey;
        }

        private OrderedSequence<K, T> MakeOrderedSequence(FingerTree<Element, Pair<K, int>> ft) {
            return new OrderedSequence<K, T>(_comparer, _noKey, ft);
        }

        /// <summary>
        /// Inserts the specified item with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns>The sequence with the inserted item.</returns>
        public OrderedSequence<K, T> Insert(K key, T item) {
            var comparer = _comparer;
            var split = _ft.Split(pair => comparer.Compare(pair.First, key) >= 0);
            return MakeOrderedSequence(split.First.Append(new Element(key, item)).Concat(split.Second));
        }

        /// <summary>
        /// Deletes a single item with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A pair. The first element is <c>true</c> if there were items with key equal to <paramref name="key"/>
        /// in the original sequence, and <c>false</c> otherwise. The second element is the result of deletion.</returns>
        /// <remarks>Key equality 
        /// If there are several elements with key equal to <paramref name="key"/>, the first of them shall be deleted.</remarks>
        public Pair<bool, OrderedSequence<K, T>> Delete(K key) {
            return DeleteHelper(key, false);
        }

        /// <summary>
        /// Deletes all items with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A pair. The first element is <c>true</c> if there were items with key equal to <paramref name="key"/>
        /// in the original sequence, and <c>false</c> otherwise. The second element is the result of deletion.</returns>
        public Pair<bool, OrderedSequence<K, T>> DeleteAll(K key) {
            return DeleteHelper(key, true);
        }

        private Pair<bool, OrderedSequence<K, T>> DeleteHelper(K key, bool deleteAll) {
            var comparer = _comparer;
            var split = _ft.Split(pair => comparer.Compare(pair.First, key) >= 0);
            var split2 = split.Second.Split(pair => comparer.Compare(pair.First, key) > 0);
            if (split2.First.IsEmpty)
                return Pair.New(false, this);
            var newFt = deleteAll ? split.First : split.First.Concat(split2.First.Tail);
            return Pair.New(true, MakeOrderedSequence(newFt.Concat(split2.Second)));
        }

        /// <summary>
        /// Merges the sequence with <paramref name="otherSequence"/>.
        /// </summary>
        /// <param name="otherSequence">The other sequence.</param>
        /// <returns></returns>
        /// <remarks>The other sequence <b>must</b> use the same comparer.</remarks>
        public OrderedSequence<K, T> Union(OrderedSequence<K, T> otherSequence) {
            return MakeOrderedSequence(MergeTrees(_ft, otherSequence._ft));
        }

        private FingerTree<Element, Pair<K, int>> MergeTrees(FingerTree<Element, Pair<K, int>> ft1,
            FingerTree<Element, Pair<K, int>> ft2) {
            if (ft2.IsEmpty)
                return ft1;
            var comparer = _comparer;
            var ft2head = ft2.Head;
            var ft2tail = ft2.Tail;
            var ft1split = ft1.Split(pair => comparer.Compare(pair.First, ft2head.Key) > 0);
            var newRight = ft2head | MergeTrees(ft2tail, ft1split.Second);
            return ft1split.First.Concat(newRight);
        }

        /// <summary>
        /// Merges the sequence with <paramref name="otherSequence"/>.
        /// </summary>
        /// <param name="otherSequence">The other sequence.</param>
        /// <returns></returns>
        /// <remarks>The other sequence <b>must</b> use the same comparer.</remarks>
        public OrderedSequence<K, T> Intersect(OrderedSequence<K, T> otherSequence) {
            return MakeOrderedSequence(IntersectTrees(_ft, otherSequence._ft));
        }

        private FingerTree<Element, Pair<K, int>> IntersectTrees(FingerTree<Element, Pair<K, int>> ft1,
            FingerTree<Element, Pair<K, int>> ft2) {
            if (ft2.IsEmpty)
                return ft2;
            var comparer = _comparer;
            var ft2head = ft2.Head;
            var ft2tail = ft2.Tail;
            var ft1split = ft1.Split(pair => comparer.Compare(pair.First, ft2head.Key) > 0);
            var recursive = IntersectTrees(ft2tail, ft1split.Second);
            var ft1_LE_ft2head = ft1split.First;
            return ft1_LE_ft2head.IsEmpty ||
                   comparer.Compare(ft1_LE_ft2head.Last.Key, ft2head.Key) < 0 //Does ft1_LE_ft2head contain ft2head?
                       ? recursive
                       : ft2head | recursive;
        }

        /// <summary>
        /// Returns the element with the maximal key without removing it.
        /// </summary>
        /// <remarks>If several elements have the maximal key, the element inserted last will be returned.</remarks>
        /// <exception cref="EmptySequenceException">There are no elements in the sequence.</exception>
        public Pair<K, T> PeekMax() {
            Element item = _ft.Last;
            return Pair.New(item.Key, item.Value);
        }

        /// <summary>
        /// Returns the element with the minimal key without removing it.
        /// </summary>
        /// <remarks>If several elements have the minimal key, the element inserted first will be returned.</remarks>
        /// <exception cref="EmptySequenceException">There are no elements in the sequence.</exception>
        public Pair<K, T> PeekMin() {
            Element item = _ft.Head;
            return Pair.New(item.Key, item.Value);
        }

        /// <summary>
        /// Removes the element with the maximal key.
        /// </summary>
        /// <remarks>If several elements have the maximal key, the element inserted last will be removed.</remarks>
        /// <exception cref="EmptySequenceException">There are no elements in the sequence.</exception>
        public OrderedSequence<K, T> RemoveMax() {
            return MakeOrderedSequence(_ft.Init);
        }

        /// <summary>
        /// Removes the element with the minimal key.
        /// </summary>
        /// <remarks>If several elements have the minimal key, the element inserted first will be removed.</remarks>
        /// <exception cref="EmptySequenceException">There are no elements in the sequence.</exception>
        public OrderedSequence<K, T> RemoveMin() {
            return MakeOrderedSequence(_ft.Tail);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator() {
            foreach (var element in _ft)
                yield return element.Value;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the number of elements in the sequence.
        /// </summary>
        public int Count { get { return _ft.Measure.Second; } }

        /// <summary>
        /// Gets the <see cref="FP.Collections.Immutable.Pair{K,T}"/> at the specified index.
        /// </summary>
        /// <remarks><c>this[0]</c> is the element with the smallest key, <c>this[Count - 1]</c> is the
        /// element with the greatest key.</remarks>
        /// <exception cref="ArgumentOutOfRangeException"><c>index</c> is out of range.</exception>
        public Pair<K, T> this[int index] {
            get {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");
                Element result = _ft.SplitTree(pair => pair.Second > index, _monoid.Zero).Middle;
                return Pair.New(result.Measure.First, result.Value);
            }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        /// <remarks>It is possible to have two unequal sequences with the same elements and comparers.</remarks>
        public bool Equals(OrderedSequence<K, T> other) {
            return Equals(other._comparer, _comparer) && Equals(other._noKey, _noKey) &&
                   Equals(other._ft, _ft);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj) {
            if (obj.GetType() != typeof (OrderedSequence<K, T>)) return false;
            return Equals((OrderedSequence<K, T>) obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode() {
            return _ft.GetHashCode();
        }

        public static bool operator ==(OrderedSequence<K, T> left, OrderedSequence<K, T> right) {
            return left.Equals(right);
        }

        public static bool operator !=(OrderedSequence<K, T> left, OrderedSequence<K, T> right) {
            return !left.Equals(right);
        }

        /// <summary>
        /// Appends <paramref name="item"/> to <paramref name="tree"/>.
        /// </summary>
        public static OrderedSequence<K, T> operator |(OrderedSequence<K, T> tree, Pair<K, T> item) {
            return tree.Insert(item.First, item.Second);
        }

        /// <summary>
        /// Merges <paramref name="tree1"/> and <paramref name="tree2"/>.
        /// </summary>
        public static OrderedSequence<K, T> operator +(OrderedSequence<K, T> tree1, OrderedSequence<K, T> tree2) {
            return tree1.Union(tree2);
        }
    }

    /// <summary>
    /// Utility methods for creating <see cref="OrderedSequence{K,T}"/>.
    /// </summary>
    /// <seealso cref="OrderedSequence{K,T}"/>
    public static class OrderedSequence {
        internal static Monoid<Pair<T, int>> MakeMonoid<T>(T noKey, IComparer<T> comparer) {
            return new Monoid<T>(noKey, (x, y) => comparer.Compare(y, noKey) == 0 ? x : y).Product(Monoids.Size);
        }

        /// <summary>
        /// Creates an empty <see cref="OrderedSequence{K,T}"/>.
        /// </summary>
        /// <param name="comparer">Used to compare keys.</param>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.
        /// </remarks>
        public static OrderedSequence<K, T> Empty<K, T>(IComparer<K> comparer, K noKey) {
            return new OrderedSequence<K, T>(comparer, noKey);
        }

        /// <summary>
        /// Creates an empty <see cref="OrderedSequence{K,T}"/>.
        /// </summary>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.</remarks>
        public static OrderedSequence<K, T> Empty<K, T>(K noKey) where K : IComparable<K> {
            return Empty<K, T>(Comparer<K>.Default, noKey);
        }

        /// <summary>
        /// Creates an empty <see cref="OrderedSequence{K,T}"/> where the keys are the same as items.
        /// </summary>
        /// <param name="comparer">Used to compare keys.</param>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.
        /// </remarks>
        public static OrderedSequence<T, T> Empty<T>(IComparer<T> comparer, T noKey) {
            return new OrderedSequence<T, T>(comparer, noKey);
        }

        /// <summary>
        /// Creates an empty <see cref="OrderedSequence{K,T}"/> where the keys are the same as items.
        /// </summary>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.</remarks>
        public static OrderedSequence<T, T> Empty<T>(T noKey) where T : IComparable<T> {
            return Empty<T, T>(Comparer<T>.Default, noKey);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedSequence{K,T}"/> class.
        /// </summary>
        /// <remarks>If an element with priority equal to <see cref="double.NegativeInfinity"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.</remarks>
        public static OrderedSequence<double, T> Empty<T>() {
            return Empty<double, T>(double.NegativeInfinity);
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/>.
        /// </summary>
        /// <param name="comparer">Used to compare keys.</param>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <param name="sequence">The sequence of pairs (key, element) placed into the sequence initially.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.
        /// 
        /// <paramref name="sequence"/> is not required to be ordered.</remarks>
        public static OrderedSequence<K, T> FromEnumerable<K, T>(IEnumerable<Pair<K, T>> sequence, IComparer<K> comparer, K noKey) {
            var empty = Empty<K, T>(comparer, noKey);
            Func<OrderedSequence<K, T>, Pair<K, T>, OrderedSequence<K, T>> insert = (seq, pair) => seq | pair;
            return sequence.FoldLeft(insert, empty);
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/>.
        /// </summary>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <param name="sequence">The sequence of pairs (key, element) placed into the sequence initially.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.
        /// 
        /// <paramref name="sequence"/> is not required to be ordered.</remarks>
        public static OrderedSequence<K, T> FromEnumerable<K, T>(IEnumerable<Pair<K, T>> sequence, K noKey) where K : IComparable<K> {
            return FromEnumerable(sequence, Comparer<K>.Default, noKey);
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/> where the keys are the same as items.
        /// </summary>
        /// <param name="comparer">Used to compare keys.</param>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <param name="sequence">The sequence of pairs (key, element) placed into the sequence initially.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.
        /// 
        /// <paramref name="sequence"/> is not required to be ordered.</remarks>
        public static OrderedSequence<T, T> FromEnumerable<T>(IEnumerable<T> sequence, IComparer<T> comparer, T noKey) {
            var empty = Empty<T, T>(comparer, noKey);
            Func<OrderedSequence<T, T>, T, OrderedSequence<T, T>> insert = (seq, t) => seq | Pair.New(t, t);
            return sequence.FoldLeft(insert, empty);
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/> where the keys are the same as items.
        /// </summary>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <param name="sequence">The sequence of pairs (key, element) placed into the sequence initially.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.
        /// 
        /// <paramref name="sequence"/> is not required to be ordered.</remarks>
        public static OrderedSequence<T, T> FromEnumerable<T>(IEnumerable<T> sequence, T noKey) where T : IComparable<T> {
            return FromEnumerable(sequence, Comparer<T>.Default, noKey);
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/>.
        /// </summary>
        /// <param name="sequence">The sequence of pairs (key, element) inserted into the sequence.</param>
        /// <remarks>If an element with priority equal to <see cref="double.NegativeInfinity"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.
        /// 
        /// <paramref name="sequence"/> is not required to be ordered.</remarks>
        public static OrderedSequence<double, T> FromEnumerable<T>(IEnumerable<Pair<double, T>> sequence) {
            return FromEnumerable(sequence, double.NegativeInfinity);
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/>.
        /// </summary>
        /// <param name="comparer">Used to compare keys.</param>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <param name="sequence">The sequence of pairs (key, element) placed into the sequence initially.
        /// Must be ordered by keys.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.</remarks>
        public static OrderedSequence<K, T> FromOrderedEnumerable<K, T>(IEnumerable<Pair<K, T>> sequence, IComparer<K> comparer, K noKey) {
            Func<FingerTree<OrderedSequence<K, T>.Element, Pair<K, int>>, Pair<K, T>,
                    FingerTree<OrderedSequence<K, T>.Element, Pair<K, int>>> append =
                        (tree, pair) => tree.Append(new OrderedSequence<K, T>.Element(pair.First, pair.Second));
            var empty = FingerTree.Empty<OrderedSequence<K, T>.Element, Pair<K, int>>(MakeMonoid(noKey, comparer));
            return new OrderedSequence<K, T>(comparer, noKey, sequence.FoldLeft(append, empty));
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/>.
        /// </summary>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <param name="sequence">The sequence of pairs (key, element) placed into the sequence initially.
        /// Must be ordered by keys.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.</remarks>
        public static OrderedSequence<K, T> FromOrderedEnumerable<K, T>(IEnumerable<Pair<K, T>> sequence, K noKey)
            where K : IComparable<K> {
            return FromOrderedEnumerable(sequence, Comparer<K>.Default, noKey);
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/>.
        /// </summary>
        /// <param name="comparer">Used to compare keys.</param>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <param name="sequence">The sequence of pairs (key, element) placed into the sequence initially.
        /// Must be ordered by keys.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.</remarks>
        public static OrderedSequence<T, T> FromOrderedEnumerable<T>(IEnumerable<T> sequence, IComparer<T> comparer, T noKey) {
            Func<FingerTree<OrderedSequence<T, T>.Element, Pair<T, int>>, T,
                FingerTree<OrderedSequence<T, T>.Element, Pair<T, int>>> append =
                    (tree, t) => tree.Append(new OrderedSequence<T, T>.Element(t, t));
            var empty = FingerTree.Empty<OrderedSequence<T, T>.Element, Pair<T, int>>(MakeMonoid(noKey, comparer));
            return new OrderedSequence<T, T>(comparer, noKey, sequence.FoldLeft(append, empty));
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/>.
        /// </summary>
        /// <param name="noKey">The sentinel value. Do <b>not</b> add elements with this key to the sequence.</param>
        /// <param name="sequence">The sequence of pairs (key, element) placed into the sequence initially.
        /// Must be ordered by keys.</param>
        /// <remarks>If an element with priority equal to <paramref name="noKey"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.</remarks>
        public static OrderedSequence<T, T> FromOrderedEnumerable<T>(IEnumerable<T> sequence, T noKey)
            where T : IComparable<T> {
            return FromOrderedEnumerable(sequence, Comparer<T>.Default, noKey);
        }

        /// <summary>
        /// Creates a <see cref="OrderedSequence{K,T}"/> with the elements from <paramref name="sequence"/>.
        /// </summary>
        /// <param name="sequence">The sequence of pairs (key, element) placed into the sequence initially.
        /// Must be ordered by keys.</param>
        /// <remarks>If an element with priority equal to <see cref="double.NegativeInfinity"/> is ever inserted into the sequence,
        /// the behaviour of the resulting sequence is undefined.</remarks>
        public static OrderedSequence<double, T> FromOrderedEnumerable<T>(IEnumerable<Pair<double, T>> sequence) {
            return FromOrderedEnumerable(sequence, double.NegativeInfinity);
        }
    }
}