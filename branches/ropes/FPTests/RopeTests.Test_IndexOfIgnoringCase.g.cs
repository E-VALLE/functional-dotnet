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
    public partial class RopeTests {

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_IndexOfIgnoringCase02() {
            this.Test_IndexOfIgnoringCase("", 'p');
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_IndexOfIgnoringCase03() {
            this.Test_IndexOfIgnoringCase("\0", 'n');
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_IndexOfIgnoringCase04() {
            this.Test_IndexOfIgnoringCase("\0\0", 'n');
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_IndexOfIgnoringCase05() {
            this.Test_IndexOfIgnoringCase("P", 'p');
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_IndexOfIgnoringCase06() {
            this.Test_IndexOfIgnoringCase("\0\0\0", 'n');
        }

    }
}
