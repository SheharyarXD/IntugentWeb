using IntugentClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntugentClassLibrary.Pages.Rnd
{
    public class RNDRValues
    {
        public int nComps = Params.nComps;
        public int nForms = Params.nFormMax;
        public CRCalc RCalc = new CRCalc();
        public CRData RData = new CRData();

        public DataTable dtGasComp = new DataTable();
        int nForm = 5;

    }
}
