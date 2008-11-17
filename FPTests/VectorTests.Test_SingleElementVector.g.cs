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
        public void Test_SingleElementVector01() {
            this.Test_SingleElementVector<int>(0, 1);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_SingleElementVector02() {
            this.Test_SingleElementVector<int>(1, 3);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_SingleElementVector03() {
            this.Test_SingleElementVector<int>(1073741824, 3);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_SingleElementVector04() {
            this.Test_SingleElementVector<object>(0, (object)null);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_SingleElementVector05() {
            object boxi = (object)(default(int));
            this.Test_SingleElementVector<object>(0, boxi);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_SingleElementVector06() {
            object s0 = new object();
            this.Test_SingleElementVector<object>(0, s0);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_SingleElementVector07() {
            object s0 = new object();
            this.Test_SingleElementVector<object>(2, s0);
        }

        [Fact]
        [PexGeneratedBy(typeof(VectorTests))]
        public void Test_SingleElementVector08() {
            this.Test_SingleElementVector<object>(1073741824, (object)null);
        }

    }
}
