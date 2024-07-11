﻿using Google.Api.Gax;
using IntugentClassLbrary.Classes;
using IntugentClassLbrary.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntugentClassLibrary.Pages.Rnd
{
    public class RNDHome
    {
        public string sMsg, sSqlQuery, sParamValue1;
        public string sDef = "0.000";
        public SqlDataAdapter da;
        public DataTable dt = new DataTable();
        public DataTable dtSearch = new DataTable();
        public DataRow dr, drSearch;
        public string sqlSearchDS =
            "Select TOP(20) RN.ID,DateDSCreated, RN.[Study Name], RN.[Product ID], [Product Matrix].[Product Description], R1.Employees as 'Operator', R2.Employees as 'Chemist' from[RNDDatasets] as RN " +
            "Left JOIN Roster AS R1 ON RN.Operator = R1.ID " +
            "Left JOIN Roster AS R2 ON RN.Chemist = R2.ID " +
            "Left Join[Product Matrix] on RN.[Product ID] = [Product Code]";
        public bool bInit = true;
        public SqlDataAdapter daF, daS;
        public DataTable dtF = new DataTable();
        public DataTable dtS = new DataTable();
        public DataRow drS, drF;
        public int IdSet = -1;
        public int indSet = 23;  // set by the program after the new dataset transfer is complete
        public bool bDataRead;
        public Cbfile CBfiles;
        public CDefualts CDefualts;
        public CLists CList;
        public RNDHome(CDefualts CDefualts, CLists CList, Cbfile CBfile)
        {
            bInit = false;
            CDefualts = CDefualts;
            this.CList = CList;
            CBfile = CBfile;
        }

        public bool GetNewDataset()
        {
            string sMsg = "Could not creat a new R&D dataset.";
            string sPOMats = "105,106";
            int iPORows = 12;
            int iIsoMat = 118;
            int iDummy = 0;
            string sql = "Select Next Value for [dbo].[IDRNDSeq]";
            //           using (Cbfile.conAZ)
            {
                SqlCommand cmd = new SqlCommand(sql, CBfiles.conAZ);
                try
                {
                    CBfiles.conAZ.Open();
                    iDummy = (int)cmd.ExecuteScalar();
                    CBfiles.conAZ.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                    sMsg = "Could not create a new sequence number for RND Dataset";
                    System.Diagnostics.Trace.TraceError(sMsg + "\n\n" + ex.Message);
                    //CTelClient.TelException(ex, sMsg);
                    return false;
                }
            } //Get seq. #

            string sSqlQuery = "Select * from [RNDDatasets] where ID =" + iDummy.ToString(); //1943";  //3137
            daS = new SqlDataAdapter(sSqlQuery, CBfiles.conAZ);
            dtS.Clear();
            int itmp = daS.Fill(dtS);  //check if this already id exisits
            if (itmp > 0)
            {
              //  MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                sMsg = "An R&D Dataset with ID " + iDummy.ToString() + " already exists";
                System.Diagnostics.Trace.TraceError(sMsg);
                return false;
            }

            try
            {
                drS = dtS.NewRow();                   //Create a new record
                drS["ID"] = iDummy;
                drS["Location"] = CDefualts.IDLocation;
                drS["DateDSCreated"] = DateTime.Now;
                drS["PORows"] = iPORows;
                drS["POMats"] = sPOMats;
                drS["IsoMats"] = iIsoMat;
                drS["PropTestingComplete"] = false;
                drS["AgedTestingComplete"] = false;

                dtS.Rows.Add(drS);
                new SqlCommandBuilder(daS);
                daS.Update(dtS);
                drS = dtS.Rows[0];
                IdSet = iDummy;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                sMsg = "Could not create a new R&D Dataset with ID " + iDummy.ToString();
                System.Diagnostics.Trace.TraceError(sMsg + "\n\n" + ex.Message);
               // CTelClient.TelException(ex, sMsg);

                return false;
            }

            int iForm = (IdSet - 1) * 8;

            sSqlQuery = "Select * from [RNDFormulations] where ID =" + iForm.ToString(); //1943";  //3137

            try
            {
                daF = new SqlDataAdapter(sSqlQuery, CBfiles.conAZ);
                dtF.Clear();
                itmp = daF.Fill(dtF);  //check if this already id exisits
                if (itmp > 0)
                {
                  //  MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                    sMsg = "An R&D Formulation with ID " + iForm.ToString() + " already exists";
                    System.Diagnostics.Trace.TraceError(sMsg + "\n\n");
                    return false;
                }

                for (int i = 0; i < 8; i++)
                {
                    drF = dtF.NewRow();
                    drF["ID"] = 8 * (IdSet - 1) + i;
                    drF["IDDataset"] = IdSet;
                    drF["FormNo"] = i;
                    drF["NCOIndex"] = 270;
                    drF["Product Code"] = "Experimental";

                    dtF.Rows.Add(drF);
                }
                new SqlCommandBuilder(daF);
                daF.Update(dtF);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                sMsg = "Could not create a new R&D Formulations with ID " + iForm.ToString();
                System.Diagnostics.Trace.TraceError(sMsg + "\n\n" + ex.Message);
               //CTelClient.TelException(ex, sMsg);
                return false;
            }

            return true;
        }

        public bool GetDataSet()
        {
            int id, itmp;
            string sMsg = "Could not get the selected R&D dataset from the server.";
            try
            {
                string sSqlQuery = "Select * from [RNDDatasets] where ID =" + IdSet.ToString(); //1943";  //3137
                daS = new SqlDataAdapter(sSqlQuery, CBfiles.conAZ);

                dtS.Clear();
                itmp = daS.Fill(dtS);
                if (itmp < 1)
                {
                   // MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                    System.Diagnostics.Trace.TraceError(sMsg + "\n\n");
                    EnableRNDPages(false);
                    return false;
                }
                //Get Formulations
                sSqlQuery = "Select * from [RNDFormulations] where IDDataset =" + IdSet.ToString(); //1943";  //3137
                daF = new SqlDataAdapter(sSqlQuery, CBfiles.conAZ);

                dtF.Clear();
                itmp = daF.Fill(dtF);
                if (itmp != 8)
                {
                   // MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                    sMsg = "Could not get the formulations for the selected R&D dataset";
                    System.Diagnostics.Trace.TraceError(sMsg + "\n\n");
                    EnableRNDPages(false);
                    return false;
                }
            }
            catch (SqlException ex)
            {
               // MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                sMsg = "Could not get the data for the RND Dataset " + IdSet.ToString();
                System.Diagnostics.Trace.TraceError(sMsg + "\n\n" + ex.Message);
                EnableRNDPages(false);
               // CTelClient.TelException(ex, sMsg);
                return false;
            }
            drS = dtS.Rows[0];

          //  if (CPages.PageRecipe_1 != null) { CPages.PageRecipe_1.ReadDataset(); RNDHome.bDataRead = true; } else RNDHome.bDataRead = false;  //if page is not initialized, must read the data on loading Recipe page
            EnableRNDPages(true);

            return true;
        }


        public void UpdateDataSet()
        {
            string sMsg = "Coult not save to the server";

            try
            {
                SqlCommandBuilder sb = new SqlCommandBuilder(daS);
                sb.ConflictOption = ConflictOption.OverwriteChanges;
                daS.Update(dtS);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                sMsg = "Could not save the R&D dataset " + IdSet.ToString();
                System.Diagnostics.Trace.TraceError(sMsg + "\n\n" + ex.Message);
               // CTelClient.TelException(ex, sMsg);

                return;
            }

           // CStatusBar.SetText("Data Saved at " + DateTime.Now.ToString("hh:mm:ss:tt"));
        }

        public void UpdateFormulatiions()
        {
            string sMsg = "Coult not save to the server";

            try
            {
                SqlCommandBuilder sb = new SqlCommandBuilder(daF);
                sb.ConflictOption = ConflictOption.OverwriteChanges;
                daF.Update(dtF);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                sMsg = "Could not save the formulations for the R&D dataset " + IdSet;
                System.Diagnostics.Trace.TraceError(sMsg + "\n\n" + ex.Message);
               // CTelClient.TelException(ex, sMsg);
                return;
            }

            //CStatusBar.SetText("Data Saved at " + DateTime.Now.ToString("hh:mm:ss:tt"));
        }

        public void EnableRNDPages(bool bEn)
        {
            //gFRE.IsEnabled = bEn;
            //gFRV.IsEnabled = bEn;
            //gRPR.IsEnabled = bEn;
            //gFPR.IsEnabled = bEn;
            //gTDR.IsEnabled = bEn;
        }
        public void GetAllRNDData()
        {
            //if (CPages.PageInProcess_1 == null || CPages.PageFinishedGoods_1 == null || CPages.PageDimStability_1 == null || CPages.PagePlantData_1 == null) return;

            // CPages.PagePlantData_1.GetDataSet();

            //mfgFinishedGoods.drIP = mfgDimensionStability.drIP = CPages.PagePlantData_1.drIP = mfgInProcess.dr;
            //  mfgInProcess.drFG = mfgDimensionStability.drFG = CPages.PagePlantData_1.drFG = mfgFinishedGoods.dr;



        }
    }

}
