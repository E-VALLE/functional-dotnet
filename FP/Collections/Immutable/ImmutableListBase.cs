/* (C) Alexey Romanov 2008 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FP.Collections.Immutable {
    /// <summary>
    /// A base class for immutable lists. It's not necessary for other implementations to inherit from it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ImmutableListBase<T> : IImmutableList<T> {
        /// <summary>
        /// Gets the "head" (first element) of the list.
        /// </summary>
        /// <value>The head of the list.</value>
        /// <exception cref="EmptySequenceException">is the current list <see cref="IsEmpty"/>.</exception>
        public abstract T Head { get; }
        /// <summary>
        /// Gets the "tail" (all elements but the first) of the list.
        /// </summary>
        /// <value>The tail of the list.</value>
        /// <exception cref="EmptySequenceException">is the current list <see cref="IsEmpty"/>.</exception>
        public abstract IImmutableList<T> Tail { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        public abstract bool IsEmpty { get; }
        /// <summary>
        /// Prepends a new head.
        /// </summary>
        /// <param name="newHead">The new head.</param>
        /// <returns>
        /// The list with <paramref name="newHead"/> as <see cref="Head"/>
        /// and the current list as <see cref="Tail"/>.
        /// </returns>
        public abstract IImmutableList<T> Prepend(T newHead);

        ///<summary>
        ///Returns an enumerator that iterates through a collection.
        ///</summary>
        ///
        ///<returns>
        ///An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<T>) this).GetEnumerator();
        }

        ///<summary>
        ///Returns an enumerator that iterates through the collection.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        ///</returns>
        ///<filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator() {
            IImmutableList<T> list = this;
            while (list != null && !list.IsEmpty) {
                yield return list.Head;
                list = list.Tail;
            }
        }

        /// <summary>
        /// Gets the wlement at the specified index.
        /// </summary>
        /// <value></value>
        public T this[int index] {
            get { return this.ElementAt(index); }
        }
    }
}