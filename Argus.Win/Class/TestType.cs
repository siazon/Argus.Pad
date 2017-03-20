using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Win
{
    public enum TestType
    {
        //  [EnumDescription("质控---标准光源测试")]
        QC_PMTSTD = 0,
        //  [EnumDescription("NT-proBNP")]
        NT_proBNP = 1,
        //  [EnumDescription("cTni")]
        cTni = 2,
        //  [EnumDescription("cTnT")]
        cTnT = 3,
        // [EnumDescription("PCT")]
        PCT = 4,
        // [EnumDescription("CK-MB")]
        CK_MB = 5,
        // [EnumDescription("Myo")]
        Myo = 6,
        // [EnumDescription("BNP")]
        BNP = 7,
        // [EnumDescription("D-Dimer")]
        D_Dimer = 8,
        // [EnumDescription("MPO")]
        MPO = 9,
        //  [EnumDescription("Lp-PLA2")]
        Lp_PLA2 = 10,
    }
}
