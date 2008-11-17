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
    public partial class VectorTests {
        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_ReplaceSingleElement01() {
            this.Test_ReplaceSingleElement(0, 1);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_ReplaceSingleElement02() {
            this.Test_ReplaceSingleElement(1, 1);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_ReplaceSingleElement03() {
            this.Test_ReplaceSingleElement(0, 4);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_ReplaceSingleElement04() {
            this.Test_ReplaceSingleElement(1073741826, 0);
        }

    }
}
