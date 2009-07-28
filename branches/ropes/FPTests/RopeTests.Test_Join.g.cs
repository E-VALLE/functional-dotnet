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
    public partial class RopeTests {

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Join16() {
            string[] ss = new string[0];
            this.Test_Join(ss, "");
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Join17() {
            string[] ss = new string[1];
            ss[0] = "";
            this.Test_Join(ss, "");
        }

        [Fact]
        public void Test_Join02() {
            string[] ss = new string[0];
            this.Test_Join(ss, (string)null);
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Join03() {
            string[] ss = new string[0];
            this.Test_Join(ss, "\0");
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Join05() {
            string[] ss = new string[0];
            this.Test_Join(ss, (string)null);
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Join07() {
            string[] ss = new string[1];
            ss[0] = new string('\0', 22);
            this.Test_Join(ss, (string)null);
        }

    }
}
