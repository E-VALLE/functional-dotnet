// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
using System;
using Xunit;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Framework.Exceptions;

namespace FPTests
{
    public partial class RASequenceTests {
        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt01() {
            int[] ints = new int[1];
            this.Test_SetAt<int>(ints, 0, 3);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt02() {
            int[] ints = new int[2];
            this.Test_SetAt<int>(ints, 0, 3);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt03() {
            int[] ints = new int[2];
            this.Test_SetAt<int>(ints, 1, 3);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt05() {
            int[] ints = new int[3];
            this.Test_SetAt<int>(ints, 1, 3);
        }

        [Fact]
        public void Test_SetAt10() {
            int[] ints = new int[31];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        public void Test_SetAt22() {
            int[] ints = new int[39];
            this.Test_SetAt<int>(ints, 12, 3);
        }

        [Fact]
        public void Test_SetAt31() {
            int[] ints = new int[31];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt17() {
            int[] ints = new int[6];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt21() {
            int[] ints = new int[6];
            this.Test_SetAt<int>(ints, 4, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt23() {
            int[] ints = new int[6];
            this.Test_SetAt<int>(ints, 1, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt24() {
            int[] ints = new int[6];
            this.Test_SetAt<int>(ints, 0, 3);
        }

        [Fact]
        [PexRaisedException(typeof(NullReferenceException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt25() {
            int[] ints = new int[7];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt26() {
            int[] ints = new int[8];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt27() {
            int[] ints = new int[14];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(TraceAssertionException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt28() {
            int[] ints = new int[15];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(NullReferenceException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt29() {
            int[] ints = new int[31];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt30() {
            int[] ints = new int[62];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt32() {
            int[] ints = new int[15];
            this.Test_SetAt<int>(ints, 1, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt33() {
            int[] ints = new int[7];
            this.Test_SetAt<int>(ints, 4, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt34() {
            int[] ints = new int[7];
            this.Test_SetAt<int>(ints, 5, 3);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt35() {
            int[] ints = new int[4];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt37() {
            int[] ints = new int[31];
            this.Test_SetAt<int>(ints, 16, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt39() {
            int[] ints = new int[9];
            this.Test_SetAt<int>(ints, 2, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt40() {
            int[] ints = new int[31];
            this.Test_SetAt<int>(ints, 22, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt41() {
            int[] ints = new int[9];
            this.Test_SetAt<int>(ints, 5, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt42() {
            int[] ints = new int[31];
            this.Test_SetAt<int>(ints, 5, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt43() {
            int[] ints = new int[62];
            this.Test_SetAt<int>(ints, 49, 3);
        }

        [Fact]
        [PexRaisedException(typeof(OverflowException))]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_SetAt44() {
            int[] ints = new int[18];
            this.Test_SetAt<int>(ints, 16, 3);
        }

    }
}
