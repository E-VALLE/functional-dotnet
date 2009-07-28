// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
using System;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Framework;
using Xunit;

namespace FPTests
{
    public partial class RopeTests {
        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_TrimEnd01() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            char[] cs = new char[0];
            this.Test_TrimEnd("\u3000", cs);
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_TrimEnd02() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            char[] cs = new char[1];
            this.Test_TrimEnd("\u0001", cs);
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_TrimEnd03() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            char[] cs = new char[0];
            this.Test_TrimEnd("\u3000\u3000", cs);
        }

        [Fact]
        public void Test_TrimEnd07() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            choices.DefaultSession
                .At(0, "requireLarge", (object)true)
                .At(1, "goDeeper", (object)true)
                .At(2, "length1", (object)3)
                .At(3, "goDeeper", (object)true)
                .At(5, "goDeeper", (object)true)
                .At(7, "goDeeper", (object)true);
            char[] cs = new char[6];
            this.Test_TrimEnd
                ("\0\0\0\0\0\0\0\0\0\u0002\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0",
                cs);
        }

        [Fact]
        public void Test_TrimEnd09() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            choices.DefaultSession
                .At(0, "requireLarge", (object)true)
                .At(1, "goDeeper", (object)true)
                .At(2, "length1", (object)100);
            char[] cs = new char[0];
            this.Test_TrimEnd(new string('\ufeff', 100), cs);
        }

        [Fact]
        public void Test_TrimEnd16() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            choices.DefaultSession
                .At(0, "requireLarge", (object)true)
                .At(1, "goDeeper", (object)true)
                .At(2, "length1", (object)3)
                .At(3, "goDeeper", (object)true)
                .At(5, "goDeeper", (object)true)
                .At(7, "goDeeper", (object)true);
            char[] cs = new char[6];
            this.Test_TrimEnd
                ("\0\0\0\0\0\0\0\0\0\u0002\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0",
                cs);
        }

        [Fact]
        public void Test_TrimEnd18() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            choices.DefaultSession
                .At(0, "requireLarge", (object)true)
                .At(1, "goDeeper", (object)true)
                .At(2, "length1", (object)100);
            char[] cs = new char[0];
            this.Test_TrimEnd(new string('\ufeff', 100), cs);
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_TrimEnd13() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            char[] cs = new char[1];
            this.Test_TrimEnd(" \0", cs);
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Trim01() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            char[] cs = new char[0];
            this.Test_Trim("\u3000", cs);
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Trim02() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            this.Test_Trim("\u3000", (char[])((object)null));
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Trim03() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            char[] cs = new char[1];
            this.Test_Trim("\u0001", cs);
        }

        [Fact]
        [PexRaisedException(typeof(EqualException))]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Trim04() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            char[] cs = new char[1];
            cs[0] = '\u0010';
            this.Test_Trim("\u0010", cs);
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Trim05() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            choices.DefaultSession
                .At(0, "requireLarge", (object)true)
                .At(1, "goDeeper", (object)true)
                .At(2, "length1", (object)1);
            char[] cs = new char[14];
            cs[0] = '\u0010';
            cs[1] = '\u0001';
            cs[2] = '\u0010';
            cs[3] = '\u0001';
            cs[4] = '\u0002';
            cs[5] = '\u0001';
            cs[6] = '\u0001';
            cs[7] = '\u0001';
            cs[8] = '\u0001';
            cs[9] = '\u0001';
            cs[10] = '\u0001';
            cs[11] = '\u0001';
            cs[12] = '\u0001';
            cs[13] = '\u0001';
            this.Test_Trim
                ("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\u0800\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0",
                cs);
        }

        [Fact]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Trim06() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            this.Test_Trim("\u3000\u3000", (char[])((object)null));
        }

        [Fact]
        public void Test_Trim07() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            choices.DefaultSession
                .At(0, "requireLarge", (object)true)
                .At(1, "goDeeper", (object)true)
                .At(2, "length1", (object)100);
            char[] cs = new char[0];
            this.Test_Trim(new string('\ufeff', 100), cs);
        }

        [Fact]
        [PexRaisedException(typeof(EqualException))]
        [PexGeneratedBy(typeof(RopeTests))]
        public void Test_Trim08() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            choices.DefaultSession
                .At(0, "requireLarge", (object)true)
                .At(1, "goDeeper", (object)true)
                .At(2, "length1", (object)1);
            char[] cs = new char[1];
            cs[0] = '@';
            this.Test_Trim
                ("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\0@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                cs);
        }

        [Fact]
        public void Test_Trim15() {
            IPexChoiceRecorder choices = PexChoose.NewTest();
            choices.DefaultSession
                .At(0, "requireLarge", (object)true)
                .At(1, "goDeeper", (object)true)
                .At(2, "length1", (object)100);
            char[] cs = new char[0];
            this.Test_Trim(new string('\ufeff', 100), cs);
        }

    }
}
