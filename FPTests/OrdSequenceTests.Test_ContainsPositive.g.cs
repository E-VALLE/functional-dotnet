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
    public partial class OrdSequenceTests {
        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive01() {
            int[] ints = new int[1];
            this.Test_ContainsPositive<int>(ints, 0);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive02() {
            int[] ints = new int[2];
            ints[0] = 4097;
            ints[1] = 2048;
            this.Test_ContainsPositive<int>(ints, 4097);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive06() {
            int[] ints = new int[2];
            ints[0] = 1;
            this.Test_ContainsPositive<int>(ints, 0);
        }

        [Fact]
        public void Test_ContainsPositive13() {
            int[] ints = new int[31];
            ints[0] = 98025505;
            ints[1] = -2641632;
            ints[2] = -805044226;
            ints[3] = 50069490;
            ints[4] = 2013933553;
            ints[5] = -2000480;
            ints[6] = -2641632;
            ints[7] = -264765442;
            ints[22] = 1073741821;
            this.Test_ContainsPositive<int>(ints, 8);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive18() {
            int[] ints = new int[12];
            ints[0] = 2147483521;
            ints[1] = -2147479553;
            ints[2] = -2147483633;
            ints[3] = 2147483516;
            ints[4] = 2147483514;
            ints[5] = -2147483647;
            ints[6] = int.MinValue;
            ints[7] = -1073742079;
            ints[8] = -1073742079;
            ints[9] = -1073742080;
            ints[10] = -1073741825;
            ints[11] = -1073741825;
            this.Test_ContainsPositive<int>(ints, 2147483521);
        }

        [Fact]
        public void Test_ContainsPositive19() {
            int[] ints = new int[30];
            ints[0] = 1082263552;
            ints[1] = -2140717056;
            ints[2] = -2145587206;
            ints[3] = 1073801214;
            ints[4] = 1013771280;
            ints[5] = -202379464;
            ints[6] = -2077540328;
            ints[7] = -611323936;
            ints[8] = -2140717056;
            ints[9] = -1013214;
            ints[10] = -2077499391;
            ints[11] = -1970073831;
            ints[12] = -1970073831;
            ints[13] = -1970073831;
            ints[14] = -1970073831;
            ints[15] = -1970073831;
            ints[16] = -1970073831;
            ints[17] = -1970073831;
            ints[18] = -1970073831;
            ints[19] = -1970073831;
            ints[20] = -1970073831;
            ints[21] = -1970073831;
            ints[22] = -1970073831;
            ints[23] = -1970073831;
            ints[24] = -1970073831;
            ints[25] = -1970073831;
            ints[26] = -1970073831;
            ints[27] = -1970073831;
            ints[28] = -1970073831;
            ints[29] = -1970073831;
            this.Test_ContainsPositive<int>(ints, 16);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive20() {
            int[] ints = new int[6];
            ints[0] = 1082196736;
            ints[1] = -2147090432;
            ints[2] = -2147417346;
            ints[3] = -2147422210;
            ints[4] = -1129670080;
            ints[5] = -1129670080;
            this.Test_ContainsPositive<int>(ints, 1082196736);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive21() {
            int[] ints = new int[3];
            ints[0] = 2147483266;
            ints[1] = -2147483216;
            ints[2] = 2147483246;
            this.Test_ContainsPositive<int>(ints, 2147483266);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive22() {
            int[] ints = new int[15];
            ints[0] = 1082327040;
            ints[1] = -2113872768;
            ints[2] = -2127822722;
            ints[3] = 33833216;
            ints[4] = 1073635424;
            ints[5] = -2113641343;
            ints[7] = -2097139581;
            ints[8] = -2097139581;
            ints[9] = -2097139581;
            ints[10] = 33824771;
            ints[11] = -1074257026;
            ints[12] = -793473;
            ints[13] = -1082121224;
            ints[14] = -8380192;
            this.Test_ContainsPositive<int>(ints, 33824771);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive24() {
            int[] ints = new int[2];
            ints[0] = -2146958209;
            ints[1] = 2146435968;
            this.Test_ContainsPositive<int>(ints, -2146958209);
        }

        [Fact]
        public void Test_ContainsPositive25() {
            int[] ints = new int[31];
            ints[0] = 397312;
            ints[1] = -2139207491;
            ints[2] = -2143697026;
            ints[3] = -1880225851;
            ints[4] = 233224;
            ints[5] = -1492052736;
            ints[6] = -2147473666;
            ints[7] = -267263489;
            ints[8] = -1609572296;
            ints[9] = -1492052736;
            ints[10] = -1594827457;
            ints[11] = -1492052736;
            ints[12] = -1492052736;
            ints[13] = -1492052736;
            ints[14] = -1492052736;
            ints[15] = -1492052736;
            ints[16] = -1492052736;
            ints[17] = -1492052736;
            ints[18] = -1492052736;
            ints[19] = -1492052736;
            ints[20] = -1492052736;
            ints[21] = -1492052736;
            ints[22] = -1492052736;
            ints[23] = -1492052736;
            ints[24] = -1492052736;
            ints[25] = -1492052736;
            ints[26] = -1492052736;
            ints[27] = -1492052736;
            ints[28] = -1492052736;
            ints[29] = -1492052736;
            ints[30] = -1492052736;
            this.Test_ContainsPositive<int>(ints, 16);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive26() {
            int[] ints = new int[14];
            ints[0] = 138412032;
            ints[1] = -268434932;
            ints[2] = -268444162;
            ints[3] = 40586571;
            ints[4] = 22761553;
            ints[5] = -210112220;
            ints[6] = -1879048196;
            ints[7] = -536822216;
            ints[8] = -2146557954;
            ints[9] = -1876426733;
            ints[10] = -7864958;
            ints[11] = -1876426733;
            ints[12] = -2147483647;
            ints[13] = -1876426733;
            this.Test_ContainsPositive<int>(ints, 138412032);
        }

        [Fact]
        public void Test_ContainsPositive27() {
            int[] ints = new int[24];
            ints[0] = 1610612763;
            ints[1] = -1295952637;
            ints[2] = -1711455372;
            ints[3] = 1550852096;
            ints[4] = 1101014142;
            ints[5] = -1039894507;
            ints[6] = -1120094212;
            ints[7] = -2043035802;
            ints[8] = -2097168378;
            ints[9] = -1455563258;
            ints[10] = -1476395007;
            ints[11] = -4160684;
            ints[12] = -4160684;
            ints[13] = -4160684;
            ints[14] = -4160684;
            ints[15] = -4160684;
            ints[16] = -4160684;
            ints[17] = -4160684;
            ints[18] = -4160684;
            ints[19] = -4160684;
            ints[20] = -4160684;
            ints[21] = -4160684;
            ints[22] = -4160684;
            ints[23] = -4160684;
            this.Test_ContainsPositive<int>(ints, 16);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive28() {
            int[] ints = new int[15];
            ints[0] = 1879048196;
            ints[1] = -2126578759;
            ints[2] = int.MinValue;
            ints[3] = 570429440;
            ints[4] = 1862263426;
            ints[5] = 503320517;
            ints[6] = -2126526281;
            ints[7] = -1856714569;
            ints[8] = -1856714569;
            ints[9] = -1856714569;
            ints[10] = -1593901056;
            ints[11] = -1879040000;
            ints[12] = -1711263552;
            ints[13] = -1072750592;
            ints[14] = -1677709312;
            this.Test_ContainsPositive<int>(ints, 1879048196);
        }

        [Fact]
        public void Test_ContainsPositive29() {
            int[] ints = new int[26];
            ints[0] = 1074793985;
            ints[1] = -2067281952;
            ints[2] = -2070938626;
            ints[3] = 1009532799;
            ints[4] = 639121471;
            ints[5] = -134513570;
            ints[6] = -146985343;
            ints[7] = -2128298560;
            ints[8] = -2131820514;
            ints[9] = -2128298560;
            ints[10] = -123911935;
            ints[11] = -1610613000;
            ints[12] = -49151;
            ints[13] = -21896;
            ints[14] = -21896;
            ints[15] = -49151;
            ints[16] = -49151;
            ints[17] = -49151;
            ints[18] = -2082471688;
            ints[19] = -4160684;
            ints[20] = -4160684;
            ints[21] = -4160684;
            ints[22] = -4160684;
            ints[23] = -1476395007;
            ints[24] = -49151;
            ints[25] = -49151;
            this.Test_ContainsPositive<int>(ints, 25);
        }

        [Fact]
        public void Test_ContainsPositive30() {
            int[] ints = new int[24];
            ints[0] = 269557800;
            ints[1] = -267729088;
            ints[2] = -1475748842;
            ints[3] = 142671872;
            ints[4] = 126879253;
            ints[5] = -263151627;
            ints[6] = -263180013;
            ints[7] = -511573964;
            ints[8] = -1753122802;
            ints[9] = -511573964;
            ints[10] = -142606296;
            ints[11] = -805312768;
            ints[12] = -49151;
            ints[13] = -8784;
            ints[14] = -8784;
            ints[15] = -49151;
            ints[16] = -49151;
            ints[17] = -49151;
            ints[18] = -1612676736;
            ints[19] = -4160684;
            ints[20] = -4160684;
            ints[21] = -4160684;
            ints[22] = -4160684;
            ints[23] = -1476395007;
            this.Test_ContainsPositive<int>(ints, -4160684);
        }

    }
}
