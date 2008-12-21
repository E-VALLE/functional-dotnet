/*
* SubstringRope.cs is part of functional-dotnet project
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

using System;

namespace FP.Text {
    /// <summary>
    /// A rope which is a substring of another rope.
    /// </summary>
    /// <typeparam name="TChar">The type of the char.</typeparam>
    /// <typeparam name="TSequence">The type of the character sequence.</typeparam>
    [Serializable]
    public sealed class SubstringRope<TChar, TSequence> :
        CharSequenceRope<TChar, CharSubsequence<TChar, TSequence>>
        where TSequence : ICharSequence<TChar> {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubstringRope&lt;TChar, TSequence&gt;"/> class.
        /// </summary>
        /// <param name="charSequence">The char sequence.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="length">The length.</param>
        public SubstringRope(TSequence charSequence, int offset, int length)
            : base(new CharSubsequence<TChar, TSequence>(charSequence, offset, length)) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="SubstringRope&lt;TChar, TSequence&gt;"/> class.
        /// </summary>
        /// <param name="subsequence">The subsequence.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="length">The length.</param>
        public SubstringRope(CharSubsequence<TChar, TSequence> subsequence, int offset, int length)
            : base(new CharSubsequence<TChar, TSequence>(subsequence, offset, length)) {}

        public override Rope<TChar> SubString(int startIndex, int length) {
            if (startIndex == 0 && length == Length)
                return this;
            if (length <= MAX_SHORT_SIZE) {
                var array = new TChar[length];
                _charSequence.CopyTo(startIndex, array, 0, length);
                return
                    new ArrayRope<TChar>(array);
            }
            return new SubstringRope<TChar, TSequence>(_charSequence, startIndex, length);
        }
        }
}