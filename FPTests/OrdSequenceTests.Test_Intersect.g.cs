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
        public void Test_Intersect01() {
            int[] ints = new int[0];
            this.Test_Intersect<int>(ints, ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect02() {
            int[] ints = new int[1];
            this.Test_Intersect<int>(ints, ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect03() {
            int[] ints = new int[1];
            int[] ints1 = new int[1];
            ints1[0] = 67108864;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect04() {
            int[] ints = new int[1];
            int[] ints1 = new int[1];
            ints[0] = 1407196192;
            ints1[0] = 136028355;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect05() {
            int[] ints = new int[1];
            int[] ints1 = new int[2];
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect06() {
            int[] ints = new int[1];
            int[] ints1 = new int[2];
            ints1[0] = int.MinValue;
            ints1[1] = int.MaxValue;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect07() {
            int[] ints = new int[1];
            int[] ints1 = new int[2];
            ints1[0] = 67108864;
            ints1[1] = 67108830;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect08() {
            int[] ints = new int[1];
            int[] ints1 = new int[3];
            ints1[0] = 67108864;
            ints1[1] = 67108830;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect09() {
            int[] ints = new int[1];
            int[] ints1 = new int[3];
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect10() {
            int[] ints = new int[1];
            int[] ints1 = new int[6];
            ints1[0] = 67108864;
            ints1[1] = 67108830;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect11() {
            int[] ints = new int[2];
            this.Test_Intersect<int>(ints, ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect12() {
            int[] ints = new int[2];
            ints[0] = int.MinValue;
            ints[1] = int.MaxValue;
            this.Test_Intersect<int>(ints, ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect13() {
            int[] ints = new int[1];
            int[] ints1 = new int[7];
            ints1[0] = 570442304;
            ints1[1] = -1845489528;
            ints1[2] = -1946142074;
            ints1[3] = -1845489528;
            ints1[4] = -1845489528;
            ints1[5] = -1845489528;
            ints1[6] = -1845489528;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect17() {
            int[] ints = new int[1];
            int[] ints1 = new int[8];
            ints1[0] = 1016070148;
            ints1[1] = -2147450884;
            ints1[2] = -2147454846;
            ints1[3] = 600047617;
            ints1[4] = 472887293;
            ints1[5] = -2147450712;
            ints1[6] = -511;
            ints1[7] = 1016070148;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect18() {
            int[] ints = new int[1];
            int[] ints1 = new int[14];
            ints[0] = 134291457;
            ints1[0] = 134291457;
            ints1[1] = -1610612736;
            ints1[2] = -1614479490;
            ints1[3] = 107093608;
            ints1[4] = -1073741824;
            ints1[5] = -1546492902;
            ints1[6] = -1111551487;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        public void Test_Intersect26() {
            int[] ints = new int[1];
            int[] ints1 = new int[30];
            ints1[0] = 1091076109;
            ints1[1] = -1341800698;
            ints1[2] = -1651605648;
            ints1[3] = 419516561;
            ints1[4] = 12599305;
            ints1[5] = -295084032;
            ints1[6] = -1255927417;
            ints1[7] = -1738014692;
            ints1[8] = -674723232;
            ints1[9] = -674723232;
            ints1[10] = -1064844801;
            ints1[11] = -32439968;
            ints1[12] = -32439968;
            ints1[13] = -32439968;
            ints1[14] = -32439968;
            ints1[15] = -32439968;
            ints1[16] = -32439968;
            ints1[17] = -32439968;
            ints1[18] = -32439968;
            ints1[19] = -32439968;
            ints1[20] = -32439968;
            ints1[21] = -32439968;
            ints1[22] = -32439968;
            ints1[23] = -32439968;
            ints1[24] = -32439968;
            ints1[25] = -32439968;
            ints1[26] = -32439968;
            ints1[27] = -32439968;
            ints1[28] = -32439968;
            ints1[29] = -32439968;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect31() {
            int[] ints = new int[3];
            ints[0] = 67108864;
            ints[1] = 67108830;
            this.Test_Intersect<int>(ints, ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect32() {
            int[] ints = new int[3];
            ints[0] = 4097;
            ints[1] = -2147479552;
            ints[2] = 4095;
            this.Test_Intersect<int>(ints, ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect47() {
            int[] ints = new int[1];
            int[] ints1 = new int[6];
            ints1[0] = 1879048321;
            ints1[1] = -1879050367;
            ints1[2] = -2147483521;
            ints1[3] = -268435456;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect48() {
            int[] ints = new int[1];
            int[] ints1 = new int[7];
            ints1[0] = 539067416;
            ints1[1] = -1628714720;
            ints1[2] = -2145505196;
            ints1[3] = 66846720;
            ints1[4] = 83952140;
            ints1[5] = 83952140;
            ints1[6] = 83952140;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect49() {
            int[] ints = new int[1];
            int[] ints1 = new int[6];
            ints1[0] = 1207959553;
            ints1[1] = -2013265921;
            ints1[2] = int.MinValue;
            ints1[3] = 1073741824;
            ints1[4] = -134217646;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect50() {
            int[] ints = new int[1];
            int[] ints1 = new int[6];
            ints1[0] = 1090519039;
            ints1[1] = -2147221503;
            ints1[2] = -2147221506;
            ints1[3] = 1073741824;
            ints1[4] = 1073217536;
            ints1[5] = -3932160;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect51() {
            int[] ints = new int[1];
            int[] ints1 = new int[7];
            ints1[0] = 1090519039;
            ints1[1] = -2147221503;
            ints1[2] = -2147221506;
            ints1[3] = 1073741824;
            ints1[4] = 1073217536;
            ints1[5] = -3932160;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect53() {
            int[] ints = new int[1];
            int[] ints1 = new int[7];
            ints1[0] = 1610612737;
            ints1[1] = -1610612737;
            ints1[2] = int.MinValue;
            ints1[3] = 1073741824;
            ints1[4] = 536870911;
            ints1[5] = -1;
            ints1[6] = -1073741824;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect54() {
            int[] ints = new int[1];
            int[] ints1 = new int[14];
            ints1[0] = 1610612737;
            ints1[1] = -1610612737;
            ints1[2] = int.MinValue;
            ints1[3] = 1073741824;
            ints1[4] = 536870911;
            ints1[5] = -1;
            ints1[6] = -1073741824;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect55() {
            int[] ints = new int[1];
            int[] ints1 = new int[8];
            ints[0] = -472125431;
            ints1[0] = 14;
            ints1[1] = -2147481079;
            ints1[2] = -2147483645;
            ints1[3] = 1;
            ints1[4] = -1073741824;
            ints1[5] = -1258626766;
            ints1[6] = -1124069373;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect57() {
            int[] ints = new int[1];
            int[] ints1 = new int[14];
            ints1[0] = 1016070148;
            ints1[1] = -2147450884;
            ints1[2] = -2147454846;
            ints1[3] = 600047617;
            ints1[4] = 472887293;
            ints1[5] = -2147450712;
            ints1[6] = -511;
            ints1[7] = 1073741824;
            ints1[8] = 1016070148;
            ints1[9] = 1016070148;
            ints1[10] = 1016070148;
            ints1[11] = 1016070148;
            ints1[12] = 1016070148;
            ints1[13] = 1016070148;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect58() {
            int[] ints = new int[1];
            int[] ints1 = new int[14];
            ints1[0] = 805306368;
            ints1[1] = -791674848;
            ints1[2] = -1073741794;
            ints1[3] = 671088640;
            ints1[4] = 13631488;
            ints1[5] = -523239361;
            ints1[6] = -268435426;
            ints1[7] = 603979776;
            ints1[8] = 536870928;
            ints1[9] = 1016070148;
            ints1[10] = 1016070148;
            ints1[11] = 1016070148;
            ints1[12] = 1016070148;
            ints1[13] = 1016070148;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect59() {
            int[] ints = new int[1];
            int[] ints1 = new int[6];
            ints1[0] = 1091679747;
            ints1[1] = -1326312452;
            ints1[2] = -2147352577;
            ints1[3] = -1056866302;
            ints1[4] = -1374685697;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect61() {
            int[] ints = new int[3];
            int[] ints1 = new int[3];
            ints[0] = 285241249;
            ints[1] = -1279849984;
            ints[2] = -1946288480;
            ints1[0] = 180490266;
            ints1[1] = -1279849984;
            ints1[2] = -1678030080;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect63() {
            int[] ints = new int[3];
            int[] ints1 = new int[3];
            ints[0] = 2147483472;
            ints[1] = -2147483578;
            ints[2] = -2147483634;
            ints1[0] = 2147483520;
            ints1[1] = 2147483462;
            ints1[2] = 254;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect64() {
            int[] ints = new int[6];
            ints[0] = 67108864;
            ints[1] = 67108830;
            this.Test_Intersect<int>(ints, ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect65() {
            int[] ints = new int[6];
            int[] ints1 = new int[6];
            ints[0] = 1073741824;
            ints[1] = -2147483645;
            ints[2] = int.MinValue;
            ints[3] = int.MinValue;
            ints[4] = -1073741828;
            ints[5] = -1073741828;
            ints1[0] = 1073741828;
            ints1[1] = -2147483645;
            ints1[2] = int.MinValue;
            ints1[3] = int.MinValue;
            ints1[4] = -1073741828;
            ints1[5] = -1073741828;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect66() {
            int[] ints = new int[1];
            int[] ints1 = new int[14];
            ints1[0] = 1610743809;
            ints1[1] = -1492750335;
            ints1[2] = -1610637824;
            ints1[3] = 805912576;
            ints1[4] = 272207680;
            ints1[5] = -117440477;
            ints1[6] = -1090158592;
            ints1[7] = -979078976;
            ints1[8] = -979078976;
            ints1[9] = -979078976;
            ints1[10] = -1244160;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect67() {
            int[] ints = new int[6];
            int[] ints1 = new int[7];
            ints[0] = 1076903972;
            ints[1] = -1266212832;
            ints[2] = -1439834658;
            ints[3] = -1266212832;
            ints[4] = 534743360;
            ints[5] = 537296704;
            ints1[0] = 1073741824;
            ints1[1] = -1540833920;
            ints1[2] = -1646002306;
            ints1[3] = -1540833920;
            ints1[4] = 891308056;
            ints1[5] = 937371387;
            ints1[6] = -1540833920;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect68() {
            int[] ints = new int[7];
            ints[0] = 2147483392;
            ints[1] = -1069318065;
            ints[2] = -1073741842;
            ints[4] = 128;
            ints[5] = 2147483264;
            this.Test_Intersect<int>(ints, ints);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect69() {
            int[] ints = new int[1];
            int[] ints1 = new int[14];
            ints1[0] = 1082128411;
            ints1[1] = -2037915647;
            ints1[2] = -2139097062;
            ints1[3] = 1073741824;
            ints1[4] = 1046559;
            ints1[5] = -1073758207;
            ints1[6] = -1190133760;
            ints1[7] = -1224220673;
            ints1[8] = -1132462089;
            ints1[9] = -1072955265;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect70() {
            int[] ints = new int[1];
            int[] ints1 = new int[14];
            ints1[0] = 2147482019;
            ints1[1] = -2139095041;
            ints1[2] = int.MinValue;
            ints1[3] = 1073741824;
            ints1[4] = -1631;
            ints1[5] = -1073750017;
            ints1[6] = -8168;
            ints1[7] = 1073741824;
            ints1[9] = 1610612736;
            ints1[10] = 1016070148;
            ints1[11] = 1016070148;
            ints1[12] = 1016070148;
            ints1[13] = 1016070148;
            this.Test_Intersect<int>(ints, ints1);
        }

        [Fact]
        [PexGeneratedBy(typeof(OrdSequenceTests))]
        public void Test_Intersect76() {
            int[] ints = new int[14];
            ints[0] = 1610629120;
            ints[1] = -939524095;
            ints[2] = -1090519040;
            ints[3] = 134217728;
            ints[4] = 268435456;
            ints[5] = 1191182336;
            ints[6] = 134217728;
            ints[7] = -134283402;
            ints[8] = 1677871070;
            ints[9] = 1677871070;
            ints[10] = 1677871070;
            ints[11] = 1677871070;
            ints[12] = 1677871070;
            ints[13] = 1677871070;
            this.Test_Intersect<int>(ints, ints);
        }

    }
}
