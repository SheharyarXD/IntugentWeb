using Google.Api.Gax;
using IntugentClassLbrary.Classes;
using IntugentClassLibrary.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntugentWebApp.Pages.RnD_Users
{
    public class RNDRValuesModel : PageModel
    {

        //    public RNDRValuesModel()
        //    {
        //        Startup();
        //    }

        //    public void OnGet()
        //    {
        //    CPages.PageRecipe_1.ReadDataset();
        //    CPages.PageRecipe_1.FormDescriptors();



        //    for (int ifo = 0; ifo < Params.nFormMax; ifo++)
        //    {
        //        RCalc.FoamDensityBase[ifo] = CPages.PageRecipe_1.Forms.FormAr[ifo].FoamDensity;
        //        RCalc.FoamDensityTT[ifo] = CPages.PageRecipe_1.Forms.FormAr[ifo].FoamDensity;
        //    }
        //    RCalc.dTempKTT = RData.dTestTempC + 273.0;  // Calculation are done using RCalc.dTempKTT
        //    RCalc.CollectBlowGases();
        //    RCalc.CalBlowGasesProps(RData.dTestTempC);

        //    SetFields();
        //    SetView();
        //    }



        //    public void RPreData(CRCalc RCalc)
        //    {
        //        double temp1, dTerm1, dTerm2, dTerm3;
        //        int ico, iba, jba, ifo, idpt;



        //        #region  //Calculate the temperature range.  Collect all the blowing agent materials in the formulations and their moles.  Add Air as first blowing agent.  The datbase must have Air as raw material with record number Params.AirDBId.


        //        for (idpt = 0; idpt < Params.nDataPts; idpt++)
        //        { RCalc.TempC[idpt] = RData.dTestTempC - 50.0 + idpt * 2.0; RCalc.TempK[idpt] = RCalc.TempC[idpt] + 273.0; }

        //        RCalc.GasMats.Clear();
        //        iba = -1;


        //        for (ico = 0; ico < CPages.PageRecipe_1.Forms.POMats.Count; ico++)
        //        {

        //            if (CPages.PageRecipe_1.Forms.POMats[ico].GassToLiqWtRatio > 0)
        //            {
        //                iba += 1;
        //                RCalc.GasMats.Add(new CMaterial());
        //                RCalc.GasMats[iba] = CPages.PageRecipe_1.Forms.POMats[ico];
        //                for (ifo = 0; ifo < nForm; ifo++)
        //                {
        //                    RCalc.MoleFracs[ifo, iba] = CPages.PageRecipe_1.Forms.FormAr[ifo].POMatPbw[ico] * RCalc.GasMats[iba].GassToLiqWtRatio / RCalc.GasMats[iba].GassMolWt;
        //                }
        //            }
        //        }

        //        RCalc.IAirBAIndex = -1;                            //Add Air if it is already not included
        //        for (ico = 0; ico < RCalc.GasMats.Count; ico++)
        //        {
        //            if (RCalc.GasMats[ico].ID == Params.iAirDBId)
        //            { RCalc.IAirBAIndex = ico; break; }
        //        }

        //        if (RCalc.IAirBAIndex == -1)
        //        {
        //            for (ico = 0; ico < CPages.PageRecipe_1.dtPO.Rows.Count; ico++)
        //            {
        //                if (CPages.PageRecipe_1.dtPO.Rows[ico]["ID"].ToString() == Params.iAirDBId.ToString())
        //                {
        //                    iba += 1;
        //                    if (iba + 1 > RCalc.GasMats.Count) RCalc.GasMats.Add(new CMaterial());

        //                    CPages.PageRecipe_1.ModifyPOIsoLists(iba, ref RCalc.GasMats, ico, CPages.PageRecipe_1.dtPO);
        //                    RCalc.IAirBAIndex = iba;


        //                    break;

        //                }
        //            }


        //        }

        //        RCalc.nBlowAg = iba + 1;

        //        #endregion

        //        #region // Calculate the gaseous phase properties of all the blowing agents at all the temperatues

        //        for (iba = 0; iba < RCalc.nBlowAg; iba++)
        //        {
        //            for (idpt = 0; idpt < Params.nDataPts; idpt++)
        //            {
        //                RCalc.Lambda[iba, idpt] = RCalc.GasMats[iba].GasCond_A * Math.Pow(RCalc.TempK[idpt] / 273, RCalc.GasMats[iba].GasCond_B);
        //                RCalc.VapPres[iba, idpt] = Math.Exp(RCalc.GasMats[iba].GasVapPAtm_A - RCalc.GasMats[iba].GasVapPAtm_B / RCalc.TempK[idpt]);
        //            }

        //        }


        //        idpt = Params.nDataPts / 2;  // //Calculate the Aij at mid temperature

        //        RCalc.dTempKTT = RData.dTestTempC + 273;
        //        for (iba = 0; iba < RCalc.nBlowAg; iba++)
        //        {
        //            RCalc.ViscosityTT[iba] = RCalc.GasMats[iba].GasVis_A * Math.Pow(RCalc.dTempKTT / 273, RCalc.GasMats[iba].GasVis_B);
        //            RCalc.LambdaTT[iba] = RCalc.Lambda[iba, idpt];
        //        }

        //        for (iba = 0; iba < RCalc.nBlowAg; iba++)
        //            for (jba = 0; jba < RCalc.nBlowAg; jba++)
        //            {
        //                dTerm1 = RCalc.ViscosityTT[iba] / RCalc.ViscosityTT[jba] * Math.Sqrt(RCalc.GasMats[jba].MolWt / RCalc.GasMats[iba].MolWt);
        //                dTerm2 = 8.0 * (1.0 + RCalc.GasMats[iba].MolWt / RCalc.GasMats[jba].MolWt);
        //                dTerm3 = (1.0 + Math.Sqrt(dTerm1));
        //                RCalc.AijTT[iba, jba] = dTerm3 * dTerm3 / Math.Sqrt(dTerm2);
        //            }



        //        #endregion

        //        #region // Calculate the mole fraction each gas in the cell (gaesous phase) and output values in the data grid

        //        for (ifo = 0; ifo < nForms; ifo++)
        //        {
        //            temp1 = 0.0;
        //            for (iba = 0; iba < RCalc.nBlowAg; iba++) temp1 += RCalc.MoleFracs[ifo, iba];
        //            if (temp1 > 0.0)
        //                for (iba = 0; iba < RCalc.nBlowAg; iba++)
        //                {
        //                    RCalc.MoleFracs[ifo, iba] = RCalc.MoleFracs[ifo, iba] / temp1 * 100;
        //                    RCalc.MoleFracsTT[ifo, iba] = RCalc.MoleFracs[ifo, iba];
        //                }
        //        }


        //        #endregion

        //    }
        //    /*
        //            public void KValuesFn(CRCalc RCalc)
        //            {
        //                double dSum1, dSum2;
        //                int iba, ifo, jba;

        //                for (ifo = 0; ifo < nForms; ifo++)
        //                {
        //                    dSum1 = 0.0;
        //                    for (iba = 0; iba < RCalc.nBlowAg; iba++)
        //                    {
        //                        dSum2 = 0.0;
        //                        for (jba = 0; jba < RCalc.nBlowAg; jba++)
        //                            dSum2 += RCalc.AijTT[iba, jba] * RCalc.MoleFracsTT[ifo, jba];
        //                        dSum1 += RCalc.LambdaTT[iba] * RCalc.MoleFracsTT[ifo, iba] / dSum2;
        //                    }
        //                    RCalc.KOutTT[ifo] = dSum1;
        //                }
        //            }
        //    */

        //    /*
        //            public void RKValuesBase(CRCalc RCalc)
        //            {
        //                int ifo;


        //                KValuesFn(RCalc);

        //                for (ifo = 0; ifo < nForms; ifo++) 
        //                {
        //                    RCalc.KValuesBase[ifo] = RCalc.KOutTT[ifo];
        //                    RCalc.RValuesBase[ifo] = Params.RKConFactor/ RCalc.KOutTT[ifo];
        //                }
        //            }
        //    */
        //    private void Click_ExportData(object sender, RoutedEventArgs e)
        //    {
        //        SetDefaultValues();
        //        SetFields();
        //        SetView();
        //        UpdateDataset();
        //    }

        //    private void SetView()
        //    {
        //        #region // Declaration and initialization
        //        int idpt, ncount, iba, ifo;
        //        double AvFoamDen, dsum1, dtemp;
        //        double[] dAr0 = new double[Params.nDataPts];
        //        double[] dAr1 = new double[Params.nDataPts];
        //        double[] dAr2 = new double[Params.nDataPts];
        //        double[] dAr3 = new double[Params.nDataPts];
        //        double[] dAr4 = new double[Params.nDataPts];
        //        double[] dArX = new double[Params.nDataPts];

        //        RCalc.dTempKTT = RData.dTestTempC + 273.0;//Reset Lambdas and vap press to base values
        //        RCalc.dCellPressTT = RData.dInitCellPress;
        //        RCalc.dCellSizeTT = RData.dCellSize;
        //        RCalc.dPolyDenTT = RData.dPolDensity;
        //        RCalc.dPolyCondTT = RData.dPolCond;
        //        RCalc.dFracStrut = RData.dFracStrut;
        //        for (ifo = 0; ifo < Params.nFormMax; ifo++) RCalc.FoamDensityTT[ifo] = RCalc.FoamDensityBase[ifo];

        //        #endregion
        //        #region  // Calculate the k values at the standard condiction. Fill the Data table with conductivities and mole fractions


        //        for (iba = 0; iba < RCalc.nBlowAg; iba++)
        //        {
        //            RCalc.VapPresTT[iba] = RCalc.VapPresBase[iba];
        //            RCalc.LambdaTT[iba] = RCalc.LambdaBase[iba];

        //        }
        //        RCalc.AdjMoleFracs();    // Adjust molefracs for vapor pressue

        //        RCalc.KValuesFn();  //Calculate k values

        //        for (ifo = 0; ifo < nForms; ifo++)
        //        {
        //            RCalc.KValuesBase[ifo] = RCalc.KOutTT[ifo];
        //            RCalc.RValuesBase[ifo] = Params.RKConFactor / RCalc.KOutTT[ifo];
        //        }

        //        dtGasComp.Clear();   //Clear datatable and fill it.
        //        for (int i = 0; i < Params.nComps; i++) dtGasComp.Rows.Add();

        //        int ir = 0;
        //        dtGasComp.Rows[ir][0] = "Thermal Properties";
        //        dtGasComp.Rows[ir + 1][0] = "   Thermal Conductivity (mW/m-K)";
        //        dtGasComp.Rows[ir + 2][0] = "   RValue (°F-ft2-hr/Btu)";
        //        for (ifo = 0; ifo < Params.nFormMax; ifo++)
        //        {
        //            dtGasComp.Rows[ir + 1][ifo + 1] = (RCalc.KValuesBase[ifo] * 1000.0).ToString("0.0");
        //            dtGasComp.Rows[ir + 2][ifo + 1] = (RCalc.RValuesBase[ifo]).ToString("0.0");
        //        }


        //        ir += 4;

        //        dtGasComp.Rows[ir][0] = "Gas Composition (Mole Freaction)";

        //        for (iba = 0; iba < RCalc.nBlowAg; iba++)
        //        {
        //            dtGasComp.Rows[ir + 1 + iba]["GasName"] = "   " + RCalc.GasMats[iba].GasName;
        //            for (ifo = 0; ifo < Params.nFormMax; ifo++)
        //                dtGasComp.Rows[ir + 1 + iba][ifo + 1] = (RCalc.MoleFracs[ifo, iba] * 100.0).ToString("0.000");
        //        }

        //        gGasComp.ItemsSource = dtGasComp.DefaultView;

        //        #endregion


        //        switch (RData.sXaxisTag)
        //        {
        //            case "CS":
        //                #region //Plot  R/K Values with Cell Size

        //                //                    RCalc.dCellPressTT = RData.dInitCellPress;  //Set the input values fro KValuesFn
        //                for (idpt = 0; idpt < Params.nDataPts; idpt++)
        //                {
        //                    RCalc.dCellSizeTT = 0.5 * (1.0 + 2.0 * idpt / (double)Params.nDataPts) * RData.dCellSize;
        //                    dArX[idpt] = 1.0E6 * RCalc.dCellSizeTT;

        //                    RCalc.AdjMoleFracs();    // Adjust molefracs for vapor pressue

        //                    RCalc.KValuesFn();  //Calculate k values

        //                    for (ifo = 0; ifo < nForms; ifo++)
        //                        RCalc.KValues[ifo, idpt] = RCalc.KOutTT[ifo];
        //                }

        //                #endregion
        //                break;

        //            case "DE":
        //                #region //Plot  R/K Values with Density

        //                ncount = 0;
        //                dsum1 = 0.0;
        //                for (ifo = 0; ifo < nForms; ifo++)
        //                    if (RCalc.FoamDensityBase[ifo] > 0 && RCalc.FoamDensityBase[ifo] < 0.9 * Params.PolymerDensity)
        //                    { ncount += 1; dsum1 += RCalc.FoamDensityBase[ifo]; }
        //                AvFoamDen = dsum1 / ncount;

        //                for (idpt = 0; idpt < Params.nDataPts; idpt++)
        //                {

        //                    dArX[idpt] = 0.5 * (1.0 + 2.0 * idpt / (double)Params.nDataPts) * AvFoamDen;
        //                    for (ifo = 0; ifo < nForms; ifo++) RCalc.FoamDensityTT[ifo] = dArX[idpt];

        //                    RCalc.AdjMoleFracs();    // Adjust molefracs for vapor pressue

        //                    RCalc.KValuesFn();  //Calculate k values

        //                    for (ifo = 0; ifo < nForms; ifo++)
        //                        RCalc.KValues[ifo, idpt] = RCalc.KOutTT[ifo];
        //                }

        //                #endregion
        //                break;

        //            default:
        //                #region //Plot  R/K Values with Temperature

        //                RCalc.dCellPressTT = RData.dInitCellPress;  //Set the input values fro KValuesFn
        //                RCalc.dCellSizeTT = RData.dCellSize;
        //                for (idpt = 0; idpt < Params.nDataPts; idpt++)
        //                {
        //                    RCalc.dTempKTT = RCalc.TempK[idpt];
        //                    dArX[idpt] = RCalc.TempC[idpt] * 1.8 + 32;
        //                    for (iba = 0; iba < RCalc.nBlowAg; iba++)
        //                    {
        //                        RCalc.LambdaTT[iba] = RCalc.Lambda[iba, idpt];
        //                        RCalc.VapPresTT[iba] = RCalc.VapPres[iba, idpt];
        //                    }

        //                    RCalc.AdjMoleFracs();    // Adjust molefracs for vapor pressue

        //                    RCalc.KValuesFn();  //Calculate k values

        //                    for (ifo = 0; ifo < nForms; ifo++)
        //                        RCalc.KValues[ifo, idpt] = RCalc.KOutTT[ifo];
        //                }

        //                #endregion
        //                break;
        //        }

        //        #region //Draw Plots

        //        if (RData.sYaxisTag == "KV")
        //        {

        //            for (idpt = 0; idpt < Params.nDataPts; idpt++)
        //            {
        //                dAr0[idpt] = RCalc.KValues[0, idpt] * 1000.0;
        //                dAr1[idpt] = RCalc.KValues[1, idpt] * 1000.0;
        //                dAr2[idpt] = RCalc.KValues[2, idpt] * 1000.0;
        //                dAr3[idpt] = RCalc.KValues[3, idpt] * 1000.0;
        //                dAr4[idpt] = RCalc.KValues[4, idpt] * 1000.0;
        //            }
        //        }

        //        else
        //            for (idpt = 0; idpt < Params.nDataPts; idpt++)
        //            {
        //                dAr0[idpt] = Params.RKConFactor / RCalc.KValues[0, idpt];
        //                dAr1[idpt] = Params.RKConFactor / RCalc.KValues[1, idpt];
        //                dAr2[idpt] = Params.RKConFactor / RCalc.KValues[2, idpt];
        //                dAr3[idpt] = Params.RKConFactor / RCalc.KValues[3, idpt];
        //                dAr4[idpt] = Params.RKConFactor / RCalc.KValues[4, idpt];
        //            }

        //        gdegcure1_1.Plot(dArX, dAr0);
        //        gdegcure2_1.Plot(dArX, dAr1);
        //        gdegcure3_1.Plot(dArX, dAr2);
        //        gdegcure4_1.Plot(dArX, dAr3);
        //        gdegcure5_1.Plot(dArX, dAr4);

        //        gCureChart1.BottomTitle = RCalc.sXAxisTitle;
        //        gCureChart1.LeftTitle = RCalc.sYAxisTitle;

        //        gCureChart1.IsAutoFitEnabled = true;

        //        #endregion
        //    }

        //    #region //Control Actions
        //    /*






        //            private void gYAxis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //            {
        //                ComboBoxItem cmi = (ComboBoxItem)(gYAxis.SelectedItem);
        //                RData.sYaxisTag = cmi.Tag.ToString();
        //                RCalc.sYAxisTitle = cmi.Content.ToString();
        //                SetView();
        //            }

        //            private void gXAxis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //            {
        //                ComboBoxItem cmi = (ComboBoxItem)(gXAxis.SelectedItem);
        //                RData.sXaxisTag = cmi.Tag.ToString();
        //                RCalc.sXAxisTitle = cmi.Content.ToString();
        //                SetView();
        //            }
        //    */
        //    private void gAxis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {
        //        string sFld = String.Empty, sMsg;
        //        Control ctrl = sender as Control;
        //        ComboBoxItem cmi;
        //        string sName = ctrl.Name;

        //        switch (sName)
        //        {
        //            case "gXAxis":
        //                cmi = (ComboBoxItem)(gXAxis.SelectedItem);
        //                RData.sXaxisTag = cmi.Tag.ToString();
        //                RCalc.sXAxisTitle = cmi.Content.ToString(); break;

        //            case "gYAxis":
        //                cmi = (ComboBoxItem)(gYAxis.SelectedItem);
        //                RData.sYaxisTag = cmi.Tag.ToString();
        //                RCalc.sYAxisTitle = cmi.Content.ToString(); break;
        //        }

        //        SetView();

        //        UpdateDataset();
        //    }


        //    private void LostFocus_Fields(object sender, RoutedEventArgs e)
        //    {
        //        string sFld = String.Empty, sMsg;
        //        Control ctrl = sender as Control;
        //        string sName = ctrl.Name;
        //        double dtemp;
        //        switch (sName)
        //        {
        //            case "gMeasureTemp":
        //                if (Double.TryParse(gMeasureTemp.Text, out dtemp)) { RData.dTestTempC = (dtemp - 32.0) / 1.8; RCalc.CalBlowGasesProps(RData.dTestTempC); }
        //                else { MessageBox.Show("Improper Value. New Value is not accepted."); if (RData.dTestTempC > -459) gMeasureTemp.Text = (RData.dTestTempC * 1.8 + 32.0).ToString("0.000"); else gMeasureTemp.Text = string.Empty; }
        //                break;

        //            case "gCellSize":
        //                if (Double.TryParse(gCellSize.Text, out dtemp)) RData.dCellSize = 1.0E-6 * dtemp;
        //                else { MessageBox.Show("Improper Value. New Value is not accepted."); if (RData.dCellSize > 0) gCellSize.Text = (RData.dCellSize * 1.0E+6).ToString("0.000"); else gCellSize.Text = string.Empty; }
        //                break;

        //            case "gCellPress":
        //                if (Double.TryParse(gCellPress.Text, out dtemp)) RData.dInitCellPress = dtemp;
        //                else { MessageBox.Show("Improper Value. New Value is not accepted."); if (RData.dInitCellPress > 0) gCellPress.Text = (RData.dInitCellPress).ToString("0.000"); else gCellPress.Text = string.Empty; }
        //                break;

        //            case "gPolDen":
        //                if (Double.TryParse(gPolDen.Text, out dtemp)) RData.dPolDensity = dtemp * CUConv.ToSi_Dens;
        //                else { MessageBox.Show("Improper Value. New Value is not accepted."); if (RData.dPolDensity > 0) gPolDen.Text = (RData.dPolDensity / CUConv.ToSi_Dens).ToString("0.000"); else gPolDen.Text = string.Empty; }
        //                break;

        //            case "gPolCond":
        //                if (Double.TryParse(gPolCond.Text, out dtemp)) RData.dPolCond = 0.001 * dtemp;
        //                else { MessageBox.Show("Improper Value. New Value is not accepted."); if (RData.dPolCond > 0) gPolCond.Text = (RData.dPolCond * 1000.0).ToString("0.000"); else gPolCond.Text = string.Empty; }
        //                break;

        //            case "gFracStruts":
        //                if (Double.TryParse(gFracStruts.Text, out dtemp)) RData.dFracStrut = 0.01 * dtemp;
        //                else { MessageBox.Show("Improper Value. New Value is not accepted."); if (RData.dFracStrut > 0) gFracStruts.Text = (RData.dFracStrut * 100.0).ToString("0.000"); else gFracStruts.Text = string.Empty; }
        //                break;
        //        }

        //        SetView();
        //        UpdateDataset();
        //    }



        //    #endregion

        //    void UpdateDataset()
        //    {
        //        string js1 = System.Text.Json.JsonSerializer.Serialize(RData);
        //        CLists.drEmployee["sRValueParams"] = js1;
        //        CLists.UpdateEmployee();
        //    }

        //    public void Startup()
        //    {
        //        int idpt;

        //        SetDefaultValues();
        //        nForm = Params.nFormMax;

        //        dtGasComp.Columns.Add("GasName", typeof(string));
        //        for (int i = 1; i < nForm + 1; i++)
        //        {
        //            dtGasComp.Columns.Add("#" + i, typeof(double));
        //        }
        //        for (int i = 0; i < Params.nComps; i++) dtGasComp.Rows.Add();
        //        gGasComp.ItemsSource = dtGasComp.DefaultView;
        //        try
        //        {
        //            if (CLists.drEmployee["sRValueParams"] == DBNull.Value) SetDefaultValues();
        //            else
        //            {
        //                string js1 = (string)CLists.drEmployee["sRValueParams"];
        //                RData = (CRData)System.Text.Json.JsonSerializer.Deserialize(js1, typeof(CRData));
        //            }
        //        }
        //        catch { SetDefaultValues(); }

        //    }

        //    public void SetDefaultValues()
        //    {
        //        RData.dTestTempC = 25;  // microns
        //        RData.dCellSize = 250E-6;  // microns
        //        RData.dInitCellPress = 0.8; //atm
        //        RData.dPolDensity = 1200.0;  //kg/m3
        //        RData.dAgeTempC = 50;
        //        RData.dPolCond = 0.225;
        //        RData.dFracStrut = 0.7;
        //        RData.sYaxisTag = "RV";
        //        RData.sXaxisTag = "TE";
        //    }

        //    public void SetFields()
        //    {
        //        gMeasureTemp.Text = (RData.dTestTempC * 1.8 + 32.0).ToString("0.0");
        //        gCellSize.Text = (1.0E6 * RData.dCellSize).ToString("0.0");
        //        gCellPress.Text = RData.dInitCellPress.ToString("0.00");
        //        gPolDen.Text = (RData.dPolDensity / CUConv.ToSi_Dens).ToString("0.00");
        //        gPolCond.Text = (1000.0 * RData.dPolCond).ToString("0.00");
        //        gFracStruts.Text = (100.0 * RData.dFracStrut).ToString("0.00");

        //        foreach (ComboBoxItem cmi in gYAxis.Items)
        //            if (cmi.Tag.ToString() == RData.sYaxisTag)
        //            { cmi.IsSelected = true; RCalc.sYAxisTitle = cmi.Content.ToString(); }
        //        foreach (ComboBoxItem cmi in gXAxis.Items)
        //            if (cmi.Tag.ToString() == RData.sXaxisTag)
        //            { cmi.IsSelected = true; RCalc.sXAxisTitle = cmi.Content.ToString(); }
        //    }
    }

}
