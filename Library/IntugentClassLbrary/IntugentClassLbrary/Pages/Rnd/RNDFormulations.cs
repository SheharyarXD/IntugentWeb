using IntugentClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntugentClassLbrary.Classes;
using System.Collections.ObjectModel;

namespace IntugentClassLibrary.Pages.Rnd
{
    public class RNDFormulations
    {
        public CForms Forms = new CForms();
        public CMaterial AirMaterial = new CMaterial();
        public string[] sMatNameListPO = { "Polyol A" }, sMatTypeListPO = { "Polyol" };
        public string[] sMatNameListIso = { "Polyol A" }, sMatTypeListIso = { "Polyol" };
        //        public CPOForm POForm1 = new CPOForm();
        public DataTable dtPO, dtIso;                       //  Data table for Iso and PO Materials from database
        public DataTable dtFormProp = new DataTable();
        public DataTable dtRecipe = new DataTable();

        string sSqlQuery;
        //       public SqlDataAdapter da;
        public SqlDataAdapter daMat;
        DataTable dt = new DataTable();
        //       public DataRow dr;
        public bool bDataSetChanged = false;
        public const string sDef = "0.0000", sOr = "0.00";
        public CDefualts cDefualts;
        public Cbfile cbfile;
        public RNDFormulations(CDefualts cDefualts,Cbfile cbfile) { 
                this.cDefualts = cDefualts;
            this.cbfile = cbfile;
        }
        public void GetMatListSql()
        {
            string sql;
            int itmp;
            string sMsg = "Error opening databases";



            try
            {
                sql = "select * from[dbo].[tblRawMaterials] where MatCat<> 'Iso Side' AND GAFMat = 'True' order by MatName";
                daMat = new SqlDataAdapter(sql, cbfile.conAZ);
                dtPO = new DataTable(); itmp = daMat.Fill(dtPO);

                Array.Resize(ref sMatNameListPO, dtPO.Rows.Count); Array.Resize(ref sMatTypeListPO, dtPO.Rows.Count);
                for (int i = 0; i < dtPO.Rows.Count; i++) { sMatNameListPO[i] = (dtPO.Rows[i]["MatName"].ToString()); sMatTypeListPO[i] = dtPO.Rows[i]["MatType"].ToString(); }

                sql = "select * from[dbo].[tblRawMaterials] where MatCat<> 'PO Side' AND GAFMat = 'True' order by MatName";
                daMat = new SqlDataAdapter(sql, cbfile.conAZ);
                dtIso = new DataTable(); itmp = daMat.Fill(dtIso);

                Array.Resize(ref sMatNameListIso, dtIso.Rows.Count); Array.Resize(ref sMatTypeListIso, dtIso.Rows.Count);
                for (int i = 0; i < dtIso.Rows.Count; i++) { sMatNameListIso[i] = (dtIso.Rows[i]["MatName"].ToString()); sMatTypeListIso[i] = dtIso.Rows[i]["MatType"].ToString(); }

            }
            catch (Exception ex)
            {
                sMsg = "Errors in obtaining the material lists for R&D Formulations";
                // MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                System.Diagnostics.Trace.TraceError(sMsg + "\n\n" + ex.Message);
                //  CTelClient.TelException(ex, sMsg);
            }
        }
        public void ModifyPOIsoLists(int irow, ref ObservableCollection<CMaterial> Mats, int iSel, DataTable dt)
        {
            /*
            Make sure that the first material in the PO and Iso list declarled in intializing the page have all the following variables
            */

            double dtemp; int itemp;

            if (iSel < 0 || iSel > dt.Rows.Count - 1) return;

            int.TryParse(dt.Rows[iSel]["ID"].ToString(), out itemp); Mats[irow].ID = itemp;
            Mats[irow].MatName = dt.Rows[iSel]["MatName"].ToString();
            Mats[irow].MatType = dt.Rows[iSel]["MatType"].ToString();
            double.TryParse(dt.Rows[iSel]["MatFunc"].ToString(), out dtemp); Mats[irow].MatFunc = dtemp;
            double.TryParse(dt.Rows[iSel]["MatOH"].ToString(), out dtemp); Mats[irow].MatOHNum = dtemp;
            double.TryParse(dt.Rows[iSel]["MatIsoCont"].ToString(), out dtemp); Mats[irow].MatNco = dtemp;
            double.TryParse(dt.Rows[iSel]["MolWt"].ToString(), out dtemp); Mats[irow].MolWt = dtemp;

            Mats[irow].GasName = dt.Rows[iSel]["GasName"].ToString();
            double.TryParse(dt.Rows[iSel]["GassToLiqWtRatio"].ToString(), out dtemp); Mats[irow].GassToLiqWtRatio = dtemp;
            double.TryParse(dt.Rows[iSel]["GassMolWt"].ToString(), out dtemp); Mats[irow].GassMolWt = dtemp;
            double.TryParse(dt.Rows[iSel]["GasBoilingTemp"].ToString(), out dtemp); Mats[irow].GasBoilingTemp = dtemp;
            double.TryParse(dt.Rows[iSel]["GasCond_A"].ToString(), out dtemp); Mats[irow].GasCond_A = dtemp;
            double.TryParse(dt.Rows[iSel]["GasCond_B"].ToString(), out dtemp); Mats[irow].GasCond_B = dtemp;
            double.TryParse(dt.Rows[iSel]["GasVis_A"].ToString(), out dtemp); Mats[irow].GasVis_A = dtemp;
            double.TryParse(dt.Rows[iSel]["GasVis_B"].ToString(), out dtemp); Mats[irow].GasVis_B = dtemp;
            double.TryParse(dt.Rows[iSel]["GasVapPAtm_A"].ToString(), out dtemp); Mats[irow].GasVapPAtm_A = dtemp;
            double.TryParse(dt.Rows[iSel]["GasVapPAtm_B"].ToString(), out dtemp); Mats[irow].GasVapPAtm_B = dtemp;
            double.TryParse(dt.Rows[iSel]["GasVapPAtm_C"].ToString(), out dtemp); Mats[irow].GasVapPAtm_C = dtemp;

        }

    }
}
