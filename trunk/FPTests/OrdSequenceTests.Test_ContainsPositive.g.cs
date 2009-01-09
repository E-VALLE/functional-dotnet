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
        public void Test_ContainsPositive03() {
            int[] ints = new int[3];
            ints[0] = 134218243;
            ints[1] = 134217697;
            ints[2] = 256;
            this.Test_ContainsPositive<int>(ints, 134218243);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive04() {
            int[] ints = new int[7];
            ints[0] = 1610612222;
            ints[1] = -1879015264;
            ints[2] = -1610613440;
            ints[3] = -1925239588;
            ints[4] = -1073741313;
            ints[5] = 1073741824;
            ints[6] = 1610612222;
            this.Test_ContainsPositive<int>(ints, 1610612222);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive05() {
            int[] ints = new int[7];
            ints[0] = 2080374782;
            ints[1] = -2113929216;
            ints[2] = -1073741824;
            ints[3] = -2135121962;
            ints[4] = -1064304642;
            ints[5] = 1073741824;
            ints[6] = 2080374782;
            this.Test_ContainsPositive<int>(ints, -2113929216);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive06() {
            int[] ints = new int[14];
            ints[0] = 2086666241;
            ints[1] = -1483228254;
            ints[2] = 402173952;
            ints[3] = -1781014836;
            ints[4] = 1611005951;
            ints[5] = 2065235968;
            ints[6] = 270436380;
            ints[7] = 3221536;
            ints[8] = 919551;
            ints[9] = 285157408;
            ints[10] = 1073741824;
            ints[11] = 831782911;
            ints[12] = 402653184;
            ints[13] = 324009983;
            this.Test_ContainsPositive<int>(ints, 2086666241);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive07() {
            int[] ints = new int[6];
            ints[0] = -1068114943;
            ints[1] = -1242529536;
            ints[2] = 1717567489;
            ints[3] = -1242529536;
            ints[4] = -1068114943;
            ints[5] = -1068114943;
            this.Test_ContainsPositive<int>(ints, -1068114943);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive08() {
            int[] ints = new int[4];
            ints[0] = 1073809920;
            ints[1] = 65535;
            ints[2] = 2046;
            ints[3] = 1073741824;
            this.Test_ContainsPositive<int>(ints, 1073809920);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive09() {
            int[] ints = new int[14];
            ints[0] = 1358954497;
            ints[1] = -517931008;
            ints[2] = -241102832;
            ints[3] = -1080557568;
            ints[4] = 1073741841;
            ints[5] = 1342177297;
            ints[6] = 939522049;
            ints[7] = 17;
            ints[8] = 4;
            ints[9] = 10489888;
            ints[10] = 1073741824;
            ints[11] = 1073741840;
            ints[12] = 1073741824;
            ints[13] = 562566144;
            this.Test_ContainsPositive<int>(ints, 1073741840);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive10() {
            int[] ints = new int[14];
            ints[0] = 1892417794;
            ints[1] = -127165334;
            ints[2] = 35914246;
            ints[3] = -188944320;
            ints[4] = 1560282497;
            ints[5] = 1716248766;
            ints[6] = 1045955330;
            ints[7] = 1374210;
            ints[8] = 131070;
            ints[9] = 27690368;
            ints[10] = 1075139076;
            ints[11] = 1343768096;
            ints[12] = 1075139076;
            ints[13] = 1208301570;
            this.Test_ContainsPositive<int>(ints, 1343768096);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive11() {
            int[] ints = new int[14];
            ints[0] = 2146962304;
            ints[1] = 1082917161;
            ints[2] = 2146435190;
            ints[3] = 1044383815;
            ints[4] = 804784000;
            ints[5] = 1073219455;
            ints[6] = 1074036737;
            ints[7] = 536870912;
            ints[8] = 536870912;
            ints[9] = 536870977;
            ints[10] = 536870912;
            ints[11] = 1074003967;
            ints[12] = 1073741824;
            ints[13] = 1073741823;
            this.Test_ContainsPositive<int>(ints, 2146962304);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive12() {
            int[] ints = new int[14];
            ints[0] = 1632983040;
            ints[1] = 559241090;
            ints[2] = 782936188;
            ints[3] = 333582320;
            ints[4] = 1088421888;
            ints[5] = 1610612737;
            ints[6] = 1076396048;
            ints[7] = 542498885;
            ints[8] = 370008120;
            ints[9] = 549453824;
            ints[10] = 805806080;
            ints[11] = 1007484928;
            ints[12] = 990253054;
            ints[13] = 697303040;
            this.Test_ContainsPositive<int>(ints, 549453824);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive13() {
            int[] ints = new int[14];
            ints[0] = 2147483624;
            ints[1] = -2145939455;
            ints[2] = 1513423874;
            ints[3] = -2145942528;
            ints[4] = 69206124;
            ints[5] = 297973776;
            ints[6] = 2147483624;
            ints[7] = 2147483624;
            ints[8] = 2147483624;
            ints[9] = 2147483624;
            ints[10] = 2147483624;
            ints[11] = 2147483624;
            ints[12] = 2147483624;
            ints[13] = 2147483624;
            this.Test_ContainsPositive<int>(ints, -2145942528);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive14() {
            int[] ints = new int[14];
            ints[0] = 1142092161;
            ints[1] = 2121;
            ints[2] = 403698306;
            ints[3] = -7847864;
            ints[4] = 994050144;
            ints[5] = 1074266256;
            ints[6] = 1139810561;
            ints[7] = 704834624;
            ints[8] = 704834624;
            ints[9] = 846205056;
            ints[10] = 595349879;
            ints[11] = 1107624529;
            ints[12] = 1091796184;
            ints[13] = 1084256382;
            this.Test_ContainsPositive<int>(ints, 1074266256);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive15() {
            int[] ints = new int[14];
            ints[0] = 1358954496;
            ints[1] = -2145901577;
            ints[2] = -2142880565;
            ints[3] = -2146447362;
            ints[4] = 285179904;
            ints[5] = 1073741824;
            ints[6] = 268918895;
            ints[7] = 16384;
            ints[8] = -2131161114;
            ints[9] = -134122489;
            ints[10] = -2087780366;
            ints[11] = -547275455;
            ints[12] = -2087780366;
            ints[13] = -1623719925;
            this.Test_ContainsPositive<int>(ints, 1358954496);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive16() {
            int[] ints = new int[7];
            ints[0] = 1543766060;
            ints[1] = 262147;
            ints[2] = 738263070;
            ints[3] = -3948501;
            ints[4] = 134217792;
            ints[5] = 935329854;
            ints[6] = 1673527297;
            this.Test_ContainsPositive<int>(ints, 1543766060);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive17() {
            int[] ints = new int[6];
            ints[0] = 17237088;
            ints[1] = 12603393;
            ints[2] = -1358951843;
            ints[3] = 17237088;
            ints[4] = -16899108;
            ints[5] = -2143289316;
            this.Test_ContainsPositive<int>(ints, 17237088);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive18() {
            int[] ints = new int[7];
            ints[0] = 548408067;
            ints[1] = 31980545;
            ints[2] = -135264515;
            ints[3] = 25165824;
            ints[4] = 508526526;
            ints[5] = -1610620937;
            ints[6] = int.MinValue;
            this.Test_ContainsPositive<int>(ints, 31980545);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive19() {
            int[] ints = new int[6];
            ints[0] = 1140875296;
            ints[1] = -2012218996;
            ints[2] = 1066631175;
            ints[3] = -1340058591;
            ints[4] = 57915283;
            ints[5] = -171024712;
            this.Test_ContainsPositive<int>(ints, 1140875296);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive20() {
            int[] ints = new int[14];
            ints[0] = 939524871;
            ints[1] = -1639972167;
            ints[2] = -1577582304;
            ints[3] = -2013298242;
            ints[4] = 100663816;
            ints[5] = 645267935;
            ints[6] = 914359039;
            ints[7] = 30;
            ints[8] = 30;
            ints[9] = 8;
            ints[10] = 100401182;
            ints[11] = 301993984;
            ints[12] = 278921248;
            ints[13] = 260046860;
            this.Test_ContainsPositive<int>(ints, 645267935);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive21() {
            int[] ints = new int[14];
            ints[0] = 134479873;
            ints[1] = -1274672832;
            ints[2] = -1224212480;
            ints[3] = -1344273151;
            ints[4] = -1073741824;
            ints[5] = 7591936;
            ints[7] = 606078336;
            ints[8] = 606078336;
            ints[9] = 1953497088;
            ints[10] = 606078336;
            ints[11] = 1097859072;
            ints[12] = 673187200;
            ints[13] = 622329856;
            this.Test_ContainsPositive<int>(ints, 606078336);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive22() {
            int[] ints = new int[14];
            ints[0] = 10487800;
            ints[1] = 648895;
            ints[2] = 9312706;
            ints[3] = -1408867642;
            ints[4] = 2621520;
            ints[5] = 2666120;
            ints[6] = 20932607;
            ints[7] = 45156518;
            ints[8] = 45156518;
            ints[9] = 1073830437;
            ints[10] = 45156518;
            ints[11] = 1803281496;
            ints[12] = 1610448896;
            ints[13] = 25204766;
            this.Test_ContainsPositive<int>(ints, 648895);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive23() {
            int[] ints = new int[15];
            ints[0] = -1607075711;
            ints[1] = -1610612698;
            ints[2] = 1344405617;
            ints[3] = -1610612698;
            ints[4] = 1142822784;
            ints[5] = -1643250240;
            ints[6] = 1066481120;
            ints[7] = -1883240480;
            ints[8] = -1607075711;
            ints[9] = -1607075711;
            ints[10] = -1607075711;
            ints[11] = -1607075711;
            ints[12] = -1607075711;
            ints[13] = -2134831122;
            ints[14] = -1674180626;
            this.Test_ContainsPositive<int>(ints, -1607075711);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive24() {
            int[] ints = new int[15];
            ints[0] = -2147146744;
            ints[1] = -2147364864;
            ints[2] = 1108428992;
            ints[3] = -2147364864;
            ints[4] = 669002944;
            ints[5] = -2147273786;
            ints[6] = 470855456;
            ints[7] = -2147271974;
            ints[8] = -2147146744;
            ints[9] = -2147146744;
            ints[10] = -2147146744;
            ints[11] = -2147146744;
            ints[12] = -2147146744;
            ints[13] = -2147303433;
            ints[14] = -2147213792;
            this.Test_ContainsPositive<int>(ints, 1108428992);
        }

        [Fact]
        public void Test_ContainsPositive25() {
            int[] ints = new int[31];
            ints[0] = 555745664;
            ints[1] = -1792900776;
            ints[2] = 1511800329;
            ints[3] = -1792900776;
            ints[4] = 566005415;
            ints[5] = -1006632947;
            ints[6] = -1943044092;
            ints[7] = -1336934214;
            ints[8] = -1336934214;
            ints[9] = -1336934214;
            ints[10] = -1336934214;
            ints[11] = -165536492;
            ints[12] = -165536492;
            ints[13] = -165536492;
            ints[14] = -165536492;
            ints[15] = -165536492;
            ints[16] = -165536492;
            ints[17] = -165536492;
            ints[18] = -165536492;
            ints[19] = -165536492;
            ints[20] = -165536492;
            ints[21] = -165536492;
            ints[22] = -165536492;
            ints[23] = -165536492;
            ints[24] = -165536492;
            ints[25] = -165536492;
            ints[26] = -165536492;
            ints[27] = -165536492;
            ints[28] = -165536492;
            ints[29] = -165536492;
            ints[30] = -165536492;
            this.Test_ContainsPositive<int>(ints, 16);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive26() {
            int[] ints = new int[15];
            ints[0] = -2138670335;
            ints[1] = -2142353408;
            ints[2] = 1082164258;
            ints[3] = -2142353408;
            ints[4] = 545286176;
            ints[5] = -2140508468;
            ints[6] = 165608802;
            ints[7] = -2138805216;
            ints[8] = -2138670335;
            ints[9] = -2138670335;
            ints[10] = -2138670335;
            ints[11] = -2138670335;
            ints[12] = -2138670335;
            ints[13] = -2143946352;
            ints[14] = -2141059466;
            this.Test_ContainsPositive<int>(ints, -2138805216);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_ContainsPositive27() {
            int[] ints = new int[19];
            ints[0] = -2038542340;
            ints[1] = -2042590456;
            ints[2] = 1073758208;
            ints[3] = -2042590456;
            ints[4] = -2080428036;
            ints[5] = -2017984512;
            ints[6] = -2013257792;
            ints[7] = -2013257792;
            ints[8] = -2013257792;
            ints[9] = -1812987852;
            ints[10] = -939589504;
            ints[11] = -980529156;
            ints[12] = -2004983855;
            ints[13] = -1758625792;
            ints[14] = -1758625792;
            ints[15] = -1758625792;
            ints[16] = -1758625792;
            ints[17] = -1758625792;
            ints[18] = -1758625792;
            this.Test_ContainsPositive<int>(ints, -1758625792);
        }

    }
}
