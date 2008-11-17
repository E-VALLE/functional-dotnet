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

namespace FPTests
{
    public partial class RASequenceTests {
        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_Reverse01() {
            int[] ints = new int[0];
            this.Test_Reverse<int>(ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_Reverse02() {
            int[] ints = new int[1];
            this.Test_Reverse<int>(ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_Reverse03() {
            int[] ints = new int[2];
            this.Test_Reverse<int>(ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_Reverse04() {
            int[] ints = new int[3];
            this.Test_Reverse<int>(ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_Reverse05() {
            int[] ints = new int[6];
            this.Test_Reverse<int>(ints);
        }

        [Fact]
        public void Test_Reverse06() {
            int[] ints = new int[6];
            ints[3] = 1;
            this.Test_Reverse<int>(ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_Reverse07() {
            int[] ints = new int[14];
            this.Test_Reverse<int>(ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(RASequenceTests))]
        public void Test_Reverse08() {
            int[] ints = new int[25];
            this.Test_Reverse<int>(ints);
        }

        [Fact]
        public void Test_Reverse09() {
            int[] ints = new int[25];
            ints[11] = 1;
            this.Test_Reverse<int>(ints);
        }

    }
}
