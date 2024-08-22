using Google.Api.Gax;
using IntugentClassLbrary.Classes;
using IntugentClassLibrary.Classes;
using IntugentClassLibrary.Pages.Rnd;
using IntugentWebApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Text.Json;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntugentWebApp.Pages.RnD_Users
{
    [BindProperties]
    public class RNDRValuesModel : PageModel
    {
        public string gMeasureTemp {  get; set; }
        public string gCellSize {  get; set; }
        public string gCellPress {  get; set; }
        public string gPolDen {  get; set; }
        public string gPolCond {  get; set; }
        public string gFracStruts {  get; set; }
        public DataView gXAxis {  get; set; }
        public DataView gYAxis {  get; set; }
        public DataView gGasComp {  get; set; }
        public string gXAxisSelectedItem {  get; set; }
        public string gXAxisSelectedValue {  get; set; }
        public string gYAxisSelectedItem { get; set; }
        public string gYAxisSelectedValue { get; set; }
        public double[] dAr0;
        public double[] dAr1;
        public double[] dAr2;
        public double[] dAr3;
        public double[] dAr4;
        public double[] dArX;
        public readonly ObjectsService _objectsService; 

                
            public RNDRValuesModel(ObjectsService objectsService)
            {
            _objectsService = objectsService;
               
            }

            public void OnGet()
            {
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
            // CPages.PageRecipe_1.ReadDataset();
            _objectsService.RNDFormulations.ReadDataset();
            _objectsService.RNDFormulations.FormDescriptors();



            for (int ifo = 0; ifo < Params.nFormMax; ifo++)
            {
                _objectsService.RNDRValues.RCalc.FoamDensityBase[ifo] = _objectsService.RNDFormulations.Forms.FormAr[ifo].FoamDensity;
                _objectsService.RNDRValues.RCalc.FoamDensityTT[ifo] = _objectsService.RNDFormulations.Forms.FormAr[ifo].FoamDensity;
            }
            _objectsService.RNDRValues.RCalc.dTempKTT = _objectsService.RNDRValues.RData.dTestTempC + 273.0;  // Calculation are done using _objectsService.RNDRValues.RCalc.dTempKTT
            CollectBlowGases();
            _objectsService.RNDRValues.RCalc.CalBlowGasesProps(_objectsService.RNDRValues.RData.dTestTempC);
            gGasComp = _objectsService.RNDRValues.dtGasComp.DefaultView;

            SetFields();
            SetView();
            }


        public void CollectBlowGases()
        {
            double temp1, dTerm1, dTerm2, dTerm3;
            int ico, iba, jba, ifo, idpt;



            #region  //Collect all the blowing agent materials in the formulations and their moles.  Add Air as first blowing agent.  

            _objectsService.RNDRValues.RCalc.GasMats.Clear();

            iba = -1;
            for (ico = 0; ico < _objectsService.RNDFormulations.Forms.POMats.Count; ico++)
            {
                if (_objectsService.RNDFormulations.Forms.POMats[ico].GassToLiqWtRatio > 0)
                {
                    iba += 1;
                    _objectsService.RNDRValues.RCalc.GasMats.Add(new CMaterial());
                    _objectsService.RNDRValues.RCalc.GasMats[iba] = _objectsService.RNDFormulations.Forms.POMats[ico];
                    for (ifo = 0; ifo < Params.nFormMax; ifo++)
                    {
                        _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba] = _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] * _objectsService.RNDRValues.RCalc.GasMats[iba].GassToLiqWtRatio / _objectsService.RNDRValues.RCalc.GasMats[iba].GassMolWt;
                    }
                }
            }

            _objectsService.RNDRValues.RCalc.IAirBAIndex = -1;                            //Add Air if it is already not included
            for (ico = 0; ico < _objectsService.RNDRValues.RCalc.GasMats.Count; ico++)
            {
                if (_objectsService.RNDRValues.RCalc.GasMats[ico].ID == Params.iAirDBId)
                { _objectsService.RNDRValues.RCalc.IAirBAIndex = ico; break; }
            }

            if (_objectsService.RNDRValues.RCalc.IAirBAIndex == -1)
            {
                for (ico = 0; ico < _objectsService.RNDFormulations.dtPO.Rows.Count; ico++)
                {
                    if (_objectsService.RNDFormulations.dtPO.Rows[ico]["ID"].ToString() == Params.iAirDBId.ToString())
                    {
                        iba += 1;
                        if (iba + 1 > _objectsService.RNDRValues.RCalc.GasMats.Count) _objectsService.RNDRValues.RCalc.GasMats.Add(new CMaterial());
                        _objectsService.RNDFormulations.ModifyPOIsoLists(iba, ref _objectsService.RNDRValues.RCalc.GasMats, ico, _objectsService.RNDFormulations.dtPO);
                        _objectsService.RNDRValues.RCalc.IAirBAIndex = iba;


                        break;

                    }
                }


            }

            _objectsService.RNDRValues.RCalc.nBlowAg = iba + 1;

            #endregion

            #region // Calculate the mole fraction each gas in the cell (gaesous phase) and output values in the data grid

            for (ifo = 0; ifo < Params.nFormMax; ifo++)
            {
                temp1 = 0.0;
                for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++) temp1 += _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba];
                if (temp1 > 0.0)
                    for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++)
                    {
                        _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba] = _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba] / temp1;
                        _objectsService.RNDRValues.RCalc.MoleFracsTT[ifo, iba] = _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba];
                    }
            }


            #endregion

        }
        public void RPreData(CRCalc RCalc)
            {
                double temp1, dTerm1, dTerm2, dTerm3;
                int ico, iba, jba, ifo, idpt;



                #region  //Calculate the temperature range.  Collect all the blowing agent materials in the formulations and their moles.  Add Air as first blowing agent.  The datbase must have Air as raw material with record number Params.AirDBId.


                for (idpt = 0; idpt < Params.nDataPts; idpt++)
                { _objectsService.RNDRValues.RCalc.TempC[idpt] = _objectsService.RNDRValues.RData.dTestTempC - 50.0 + idpt * 2.0; _objectsService.RNDRValues.RCalc.TempK[idpt] = _objectsService.RNDRValues.RCalc.TempC[idpt] + 273.0; }

                _objectsService.RNDRValues.RCalc.GasMats.Clear();
                iba = -1;


                for (ico = 0; ico < _objectsService.RNDFormulations.Forms.POMats.Count; ico++)
                {

                    if (_objectsService.RNDFormulations.Forms.POMats[ico].GassToLiqWtRatio > 0)
                    {
                        iba += 1;
                        _objectsService.RNDRValues.RCalc.GasMats.Add(new CMaterial());
                        _objectsService.RNDRValues.RCalc.GasMats[iba] = _objectsService.RNDFormulations.Forms.POMats[ico];
                        for (ifo = 0; ifo < _objectsService.RNDRValues.nForm; ifo++)
                        {
                            _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba] = _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] * _objectsService.RNDRValues.RCalc.GasMats[iba].GassToLiqWtRatio / _objectsService.RNDRValues.RCalc.GasMats[iba].GassMolWt;
                        }
                    }
                }

                _objectsService.RNDRValues.RCalc.IAirBAIndex = -1;                            //Add Air if it is already not included
                for (ico = 0; ico < _objectsService.RNDRValues.RCalc.GasMats.Count; ico++)
                {
                    if (_objectsService.RNDRValues.RCalc.GasMats[ico].ID == Params.iAirDBId)
                    { _objectsService.RNDRValues.RCalc.IAirBAIndex = ico; break; }
                }

                if (_objectsService.RNDRValues.RCalc.IAirBAIndex == -1)
                {
                    for (ico = 0; ico < _objectsService.RNDFormulations.dtPO.Rows.Count; ico++)
                    {
                        if (_objectsService.RNDFormulations.dtPO.Rows[ico]["ID"].ToString() == Params.iAirDBId.ToString())
                        {
                            iba += 1;
                            if (iba + 1 > _objectsService.RNDRValues.RCalc.GasMats.Count) _objectsService.RNDRValues.RCalc.GasMats.Add(new CMaterial());

                            _objectsService.RNDFormulations.ModifyPOIsoLists(iba, ref _objectsService.RNDRValues.RCalc.GasMats, ico, _objectsService.RNDFormulations.dtPO);
                            _objectsService.RNDRValues.RCalc.IAirBAIndex = iba;


                            break;

                        }
                    }


                }

                _objectsService.RNDRValues.RCalc.nBlowAg = iba + 1;

                #endregion

                #region // Calculate the gaseous phase properties of all the blowing agents at all the temperatues

                for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++)
                {
                    for (idpt = 0; idpt < Params.nDataPts; idpt++)
                    {
                        _objectsService.RNDRValues.RCalc.Lambda[iba, idpt] = _objectsService.RNDRValues.RCalc.GasMats[iba].GasCond_A * Math.Pow(_objectsService.RNDRValues.RCalc.TempK[idpt] / 273, _objectsService.RNDRValues.RCalc.GasMats[iba].GasCond_B);
                        _objectsService.RNDRValues.RCalc.VapPres[iba, idpt] = Math.Exp(_objectsService.RNDRValues.RCalc.GasMats[iba].GasVapPAtm_A - _objectsService.RNDRValues.RCalc.GasMats[iba].GasVapPAtm_B / _objectsService.RNDRValues.RCalc.TempK[idpt]);
                    }

                }


                idpt = Params.nDataPts / 2;  // //Calculate the Aij at mid temperature

                _objectsService.RNDRValues.RCalc.dTempKTT = _objectsService.RNDRValues.RData.dTestTempC + 273;
                for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++)
                {
                    _objectsService.RNDRValues.RCalc.ViscosityTT[iba] = _objectsService.RNDRValues.RCalc.GasMats[iba].GasVis_A * Math.Pow(_objectsService.RNDRValues.RCalc.dTempKTT / 273, _objectsService.RNDRValues.RCalc.GasMats[iba].GasVis_B);
                    _objectsService.RNDRValues.RCalc.LambdaTT[iba] = _objectsService.RNDRValues.RCalc.Lambda[iba, idpt];
                }

                for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++)
                    for (jba = 0; jba < _objectsService.RNDRValues.RCalc.nBlowAg; jba++)
                    {
                        dTerm1 = _objectsService.RNDRValues.RCalc.ViscosityTT[iba] / _objectsService.RNDRValues.RCalc.ViscosityTT[jba] * Math.Sqrt(_objectsService.RNDRValues.RCalc.GasMats[jba].MolWt / _objectsService.RNDRValues.RCalc.GasMats[iba].MolWt);
                        dTerm2 = 8.0 * (1.0 + _objectsService.RNDRValues.RCalc.GasMats[iba].MolWt / _objectsService.RNDRValues.RCalc.GasMats[jba].MolWt);
                        dTerm3 = (1.0 + Math.Sqrt(dTerm1));
                        _objectsService.RNDRValues.RCalc.AijTT[iba, jba] = dTerm3 * dTerm3 / Math.Sqrt(dTerm2);
                    }



                #endregion

                #region // Calculate the mole fraction each gas in the cell (gaesous phase) and output values in the data grid

                for (ifo = 0; ifo < _objectsService.RNDRValues.nForms; ifo++)
                {
                    temp1 = 0.0;
                    for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++) temp1 += _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba];
                    if (temp1 > 0.0)
                        for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++)
                        {
                            _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba] = _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba] / temp1 * 100;
                            _objectsService.RNDRValues.RCalc.MoleFracsTT[ifo, iba] = _objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba];
                        }
                }


                #endregion

            }
        
        //public void KValuesFn(CRCalc RCalc)
        //            {
        //                double dSum1, dSum2;
        //                int iba, ifo, jba;

        //                for (ifo = 0; ifo <_objectsService.RNDRValues.nForms; ifo++)
        //                {
        //                    dSum1 = 0.0;
        //                    for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++)
        //                    {
        //                        dSum2 = 0.0;
        //                        for (jba = 0; jba < _objectsService.RNDRValues.RCalc.nBlowAg; jba++)
        //                            dSum2 += _objectsService.RNDRValues.RCalc.AijTT[iba, jba] * _objectsService.RNDRValues.RCalc.MoleFracsTT[ifo, jba];
        //                        dSum1 += _objectsService.RNDRValues.RCalc.LambdaTT[iba] * _objectsService.RNDRValues.RCalc.MoleFracsTT[ifo, iba] / dSum2;
        //                    }
        //                    _objectsService.RNDRValues.RCalc.KOutTT[ifo] = dSum1;
        //                }
        //            }
                
        //public void RKValuesBase(CRCalc RCalc)
        //            {
        //                int ifo;


        //                KValuesFn(_objectsService.RNDRValues.RCalc);

        //                for (ifo = 0; ifo <_objectsService.RNDRValues.nForms; ifo++) 
        //                {
        //                    _objectsService.RNDRValues.RCalc.KValuesBase[ifo] = _objectsService.RNDRValues.RCalc.KOutTT[ifo];
        //                    _objectsService.RNDRValues.RCalc.RValuesBase[ifo] = Params.RKConFactor/ _objectsService.RNDRValues.RCalc.KOutTT[ifo];
        //                }
        //            }
            
        public IActionResult OnPostExportData()
            {
                SetDefaultValues();
                SetFields();
                SetView();
                UpdateDataset();
                return new JsonResult(true);
            }

        private void SetView()
            {
                #region // Declaration and initialization
                int idpt, ncount, iba, ifo;
                double AvFoamDen, dsum1, dtemp;

            dAr0 = new double[Params.nDataPts];
            dAr1 = new double[Params.nDataPts];
            dAr2 = new double[Params.nDataPts];
            dAr3 = new double[Params.nDataPts];
            dAr4 = new double[Params.nDataPts];
            dArX = new double[Params.nDataPts];
            _objectsService.RNDRValues.RCalc.dTempKTT = _objectsService.RNDRValues.RData.dTestTempC + 273.0;//Reset Lambdas and vap press to base values
                _objectsService.RNDRValues.RCalc.dCellPressTT = _objectsService.RNDRValues.RData.dInitCellPress;
                _objectsService.RNDRValues.RCalc.dCellSizeTT = _objectsService.RNDRValues.RData.dCellSize;
                _objectsService.RNDRValues.RCalc.dPolyDenTT = _objectsService.RNDRValues.RData.dPolDensity;
                _objectsService.RNDRValues.RCalc.dPolyCondTT = _objectsService.RNDRValues.RData.dPolCond;
                _objectsService.RNDRValues.RCalc.dFracStrut = _objectsService.RNDRValues.RData.dFracStrut;
                for (ifo = 0; ifo < Params.nFormMax; ifo++) _objectsService.RNDRValues.RCalc.FoamDensityTT[ifo] = _objectsService.RNDRValues.RCalc.FoamDensityBase[ifo];

                #endregion
                #region  // Calculate the k values at the standard condiction. Fill the Data table with conductivities and mole fractions


                for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++)
                {
                    _objectsService.RNDRValues.RCalc.VapPresTT[iba] = _objectsService.RNDRValues.RCalc.VapPresBase[iba];
                    _objectsService.RNDRValues.RCalc.LambdaTT[iba] = _objectsService.RNDRValues.RCalc.LambdaBase[iba];

                }
                _objectsService.RNDRValues.RCalc.AdjMoleFracs();    // Adjust molefracs for vapor pressue

                _objectsService.RNDRValues.RCalc.KValuesFn();  //Calculate k values

                for (ifo = 0; ifo < _objectsService.RNDRValues.nForms; ifo++)
                {
                    _objectsService.RNDRValues.RCalc.KValuesBase[ifo] = _objectsService.RNDRValues.RCalc.KOutTT[ifo];
                    _objectsService.RNDRValues.RCalc.RValuesBase[ifo] = Params.RKConFactor / _objectsService.RNDRValues.RCalc.KOutTT[ifo];
                }

                _objectsService.RNDRValues.dtGasComp.Clear();   //Clear datatable and fill it.
                for (int i = 0; i < Params.nComps; i++) _objectsService.RNDRValues.dtGasComp.Rows.Add();

                int ir = 0;
                _objectsService.RNDRValues.dtGasComp.Rows[ir][0] = "Thermal Properties";
                _objectsService.RNDRValues.dtGasComp.Rows[ir + 1][0] = "   Thermal Conductivity (mW/m-K)";
                _objectsService.RNDRValues.dtGasComp.Rows[ir + 2][0] = "   RValue (°F-ft2-hr/Btu)";
                for (ifo = 0; ifo < Params.nFormMax; ifo++)
                {
                    _objectsService.RNDRValues.dtGasComp.Rows[ir + 1][ifo + 1] = (_objectsService.RNDRValues.RCalc.KValuesBase[ifo] * 1000.0).ToString("0.0");
                    _objectsService.RNDRValues.dtGasComp.Rows[ir + 2][ifo + 1] = (_objectsService.RNDRValues.RCalc.RValuesBase[ifo]).ToString("0.0");
                }


                ir += 4;

                _objectsService.RNDRValues.dtGasComp.Rows[ir][0] = "Gas Composition (Mole Freaction)";

                for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++)
                {
                    _objectsService.RNDRValues.dtGasComp.Rows[ir + 1 + iba]["GasName"] = "   " + _objectsService.RNDRValues.RCalc.GasMats[iba].GasName;
                    for (ifo = 0; ifo < Params.nFormMax; ifo++)
                        _objectsService.RNDRValues.dtGasComp.Rows[ir + 1 + iba][ifo + 1] = (_objectsService.RNDRValues.RCalc.MoleFracs[ifo, iba] * 100.0).ToString("0.000");
                }

                gGasComp = _objectsService.RNDRValues.dtGasComp.DefaultView;

                #endregion


                switch (_objectsService.RNDRValues.RData.sXaxisTag)
                {
                    case "CS":
                        #region //Plot  R/K Values with Cell Size

                        //                    _objectsService.RNDRValues.RCalc.dCellPressTT = _objectsService.RNDRValues.RData.dInitCellPress;  //Set the input values fro KValuesFn
                        for (idpt = 0; idpt < Params.nDataPts; idpt++)
                        {
                            _objectsService.RNDRValues.RCalc.dCellSizeTT = 0.5 * (1.0 + 2.0 * idpt / (double)Params.nDataPts) * _objectsService.RNDRValues.RData.dCellSize;
                            dArX[idpt] = 1.0E6 * _objectsService.RNDRValues.RCalc.dCellSizeTT;

                            _objectsService.RNDRValues.RCalc.AdjMoleFracs();    // Adjust molefracs for vapor pressue

                            _objectsService.RNDRValues.RCalc.KValuesFn();  //Calculate k values

                            for (ifo = 0; ifo < _objectsService.RNDRValues.nForms; ifo++)
                                _objectsService.RNDRValues.RCalc.KValues[ifo, idpt] = _objectsService.RNDRValues.RCalc.KOutTT[ifo];
                        }

                        #endregion
                        break;

                    case "DE":
                        #region //Plot  R/K Values with Density

                        ncount = 0;
                        dsum1 = 0.0;
                        for (ifo = 0; ifo < _objectsService.RNDRValues.nForms; ifo++)
                            if (_objectsService.RNDRValues.RCalc.FoamDensityBase[ifo] > 0 && _objectsService.RNDRValues.RCalc.FoamDensityBase[ifo] < 0.9 * Params.PolymerDensity)
                            { ncount += 1; dsum1 += _objectsService.RNDRValues.RCalc.FoamDensityBase[ifo]; }
                        AvFoamDen = dsum1 / ncount;

                        for (idpt = 0; idpt < Params.nDataPts; idpt++)
                        {

                            dArX[idpt] = 0.5 * (1.0 + 2.0 * idpt / (double)Params.nDataPts) * AvFoamDen;
                            for (ifo = 0; ifo < _objectsService.RNDRValues.nForms; ifo++) _objectsService.RNDRValues.RCalc.FoamDensityTT[ifo] = dArX[idpt];

                            _objectsService.RNDRValues.RCalc.AdjMoleFracs();    // Adjust molefracs for vapor pressue

                            _objectsService.RNDRValues.RCalc.KValuesFn();  //Calculate k values

                            for (ifo = 0; ifo < _objectsService.RNDRValues.nForms; ifo++)
                                _objectsService.RNDRValues.RCalc.KValues[ifo, idpt] = _objectsService.RNDRValues.RCalc.KOutTT[ifo];
                        }

                        #endregion
                        break;

                    default:
                        #region //Plot  R/K Values with Temperature

                        _objectsService.RNDRValues.RCalc.dCellPressTT = _objectsService.RNDRValues.RData.dInitCellPress;  //Set the input values fro KValuesFn
                        _objectsService.RNDRValues.RCalc.dCellSizeTT = _objectsService.RNDRValues.RData.dCellSize;
                        for (idpt = 0; idpt < Params.nDataPts; idpt++)
                        {
                            _objectsService.RNDRValues.RCalc.dTempKTT = _objectsService.RNDRValues.RCalc.TempK[idpt];
                            dArX[idpt] = _objectsService.RNDRValues.RCalc.TempC[idpt] * 1.8 + 32;
                            for (iba = 0; iba < _objectsService.RNDRValues.RCalc.nBlowAg; iba++)
                            {
                                _objectsService.RNDRValues.RCalc.LambdaTT[iba] = _objectsService.RNDRValues.RCalc.Lambda[iba, idpt];
                                _objectsService.RNDRValues.RCalc.VapPresTT[iba] = _objectsService.RNDRValues.RCalc.VapPres[iba, idpt];
                            }

                            _objectsService.RNDRValues.RCalc.AdjMoleFracs();    // Adjust molefracs for vapor pressue

                            _objectsService.RNDRValues.RCalc.KValuesFn();  //Calculate k values

                            for (ifo = 0; ifo < _objectsService.RNDRValues.nForms; ifo++)
                                _objectsService.RNDRValues.RCalc.KValues[ifo, idpt] = _objectsService.RNDRValues.RCalc.KOutTT[ifo];
                        }

                        #endregion
                        break;
                }

                #region //Draw Plots

                if (_objectsService.RNDRValues.RData.sYaxisTag == "KV")
                {

                    for (idpt = 0; idpt < Params.nDataPts; idpt++)
                    {
                        dAr0[idpt] = _objectsService.RNDRValues.RCalc.KValues[0, idpt] * 1000.0;
                        dAr1[idpt] = _objectsService.RNDRValues.RCalc.KValues[1, idpt] * 1000.0;
                        dAr2[idpt] = _objectsService.RNDRValues.RCalc.KValues[2, idpt] * 1000.0;
                        dAr3[idpt] = _objectsService.RNDRValues.RCalc.KValues[3, idpt] * 1000.0;
                        dAr4[idpt] = _objectsService.RNDRValues.RCalc.KValues[4, idpt] * 1000.0;
                    }
                }

                else
                    for (idpt = 0; idpt < Params.nDataPts; idpt++)
                    {
                        dAr0[idpt] = Params.RKConFactor / _objectsService.RNDRValues.RCalc.KValues[0, idpt];
                        dAr1[idpt] = Params.RKConFactor / _objectsService.RNDRValues.RCalc.KValues[1, idpt];
                        dAr2[idpt] = Params.RKConFactor / _objectsService.RNDRValues.RCalc.KValues[2, idpt];
                        dAr3[idpt] = Params.RKConFactor / _objectsService.RNDRValues.RCalc.KValues[3, idpt];
                        dAr4[idpt] = Params.RKConFactor / _objectsService.RNDRValues.RCalc.KValues[4, idpt];
                    }

                //gdegcure1_1.Plot(dArX, dAr0);
                //gdegcure2_1.Plot(dArX, dAr1);
                //gdegcure3_1.Plot(dArX, dAr2);
                //gdegcure4_1.Plot(dArX, dAr3);
                //gdegcure5_1.Plot(dArX, dAr4);

                //gCureChart1.BottomTitle = _objectsService.RNDRValues.RCalc.sXAxisTitle;
                //gCureChart1.LeftTitle = _objectsService.RNDRValues.RCalc.sYAxisTitle;

                //gCureChart1.IsAutoFitEnabled = true;

                #endregion
            }

            #region //Control Actions
            /*






                    private void gYAxis_SelectionChanged(object sender, SelectionChangedEventArgs e)
                    {
                        ComboBoxItem cmi = (ComboBoxItem)(gYAxis.SelectedItem);
                        _objectsService.RNDRValues.RData.sYaxisTag = cmi.Tag.ToString();
                        _objectsService.RNDRValues.RCalc.sYAxisTitle = cmi.Content.ToString();
                        SetView();
                    }

                    private void gXAxis_SelectionChanged(object sender, SelectionChangedEventArgs e)
                    {
                        ComboBoxItem cmi = (ComboBoxItem)(gXAxis.SelectedItem);
                        _objectsService.RNDRValues.RData.sXaxisTag = cmi.Tag.ToString();
                        _objectsService.RNDRValues.RCalc.sXAxisTitle = cmi.Content.ToString();
                        SetView();
                    }
            */

            public IActionResult OnPostGAxis_SelectionChanged(string Name,string value,string item)
            {
                string sFld = null, sMsg;
                //ComboBoxItem cmi;
                string sName = Name;

               switch (sName)
               {
                   case "gXAxis":
                    // cmi = (ComboBoxItem)(gXAxis.SelectedItem);
                    gXAxisSelectedItem = item;
                    gXAxisSelectedValue = value;


                       _objectsService.RNDRValues.RData.sXaxisTag = gXAxisSelectedValue.ToString();
                       _objectsService.RNDRValues.RCalc.sXAxisTitle = gXAxisSelectedItem.ToString(); break;

                   case "gYAxis":
                    // cmi = (ComboBoxItem)(gYAxis.SelectedItem);
                    gYAxisSelectedItem = item;
                    gYAxisSelectedValue = value;

                    _objectsService.RNDRValues.RData.sYaxisTag = gYAxisSelectedValue.ToString();
                       _objectsService.RNDRValues.RCalc.sYAxisTitle = gYAxisSelectedItem.ToString();
                    break;
            }

                SetView();

                UpdateDataset();
            return new JsonResult(true);
            }


            public IActionResult OnPostLostFocus_Fields(string Name,string value)
            {
                string sFld = null, sMsg;
                string sName = Name;
                double dtemp;
                switch (sName)
                {
                    case "gMeasureTemp":
                        if (Double.TryParse(value , out dtemp)) { _objectsService.RNDRValues.RData.dTestTempC = (dtemp - 32.0) / 1.8; _objectsService.RNDRValues.RCalc.CalBlowGasesProps(_objectsService.RNDRValues.RData.dTestTempC); }
                        else {
                        //MessageBox.Show("Improper Value. New Value is not accepted.");
                        if (_objectsService.RNDRValues.RData.dTestTempC > -459) gMeasureTemp  = (_objectsService.RNDRValues.RData.dTestTempC * 1.8 + 32.0).ToString("0.000"); else gMeasureTemp  = string.Empty; }
                        break;

                    case "gCellSize":
                        if (Double.TryParse(value, out dtemp)) _objectsService.RNDRValues.RData.dCellSize = 1.0E-6 * dtemp;
                        else {
                      //  MessageBox.Show("Improper Value. New Value is not accepted.");
                        if (_objectsService.RNDRValues.RData.dCellSize > 0) gCellSize  = (_objectsService.RNDRValues.RData.dCellSize * 1.0E+6).ToString("0.000"); else gCellSize  = string.Empty; }
                        break;

                    case "gCellPress":
                        if (Double.TryParse(value, out dtemp)) _objectsService.RNDRValues.RData.dInitCellPress = dtemp;
                        else {
                       // MessageBox.Show("Improper Value. New Value is not accepted.");
                        if (_objectsService.RNDRValues.RData.dInitCellPress > 0) gCellPress  = (_objectsService.RNDRValues.RData.dInitCellPress).ToString("0.000"); else gCellPress  = string.Empty; }
                        break;

                    case "gPolDen":
                        if (Double.TryParse(value, out dtemp)) _objectsService.RNDRValues.RData.dPolDensity = dtemp * _objectsService.RNDRValues.CUConv.ToSi_Dens;
                        else {
                            //MessageBox.Show("Improper Value. New Value is not accepted.");
                            if (_objectsService.RNDRValues.RData.dPolDensity > 0) gPolDen  = (_objectsService.RNDRValues.RData.dPolDensity / _objectsService.RNDRValues.CUConv.ToSi_Dens).ToString("0.000"); else gPolDen  = string.Empty; }
                        break;

                    case "gPolCond":
                        if (Double.TryParse(value, out dtemp)) _objectsService.RNDRValues.RData.dPolCond = 0.001 * dtemp;
                        else { 
                        //MessageBox.Show("Improper Value. New Value is not accepted.");
                        if (_objectsService.RNDRValues.RData.dPolCond > 0) gPolCond  = (_objectsService.RNDRValues.RData.dPolCond * 1000.0).ToString("0.000"); else gPolCond  = string.Empty; }
                        break;

                    case "gFracStruts":
                        if (Double.TryParse(value, out dtemp)) _objectsService.RNDRValues.RData.dFracStrut = 0.01 * dtemp;
                        else {
                       // MessageBox.Show("Improper Value. New Value is not accepted."); 
                        if (_objectsService.RNDRValues.RData.dFracStrut > 0) gFracStruts  = (_objectsService.RNDRValues.RData.dFracStrut * 100.0).ToString("0.000"); else gFracStruts  = string.Empty; }
                        break;
                }

                SetView();
                UpdateDataset();
            return new JsonResult(true);
            }



            #endregion

            void UpdateDataset()
            {
                string js1 = System.Text.Json.JsonSerializer.Serialize(_objectsService.RNDRValues.RData);
                _objectsService.RNDRValues.CLists.drEmployee["sRValueParams"] = js1;
                _objectsService.RNDRValues.CLists.UpdateEmployee();
            }

       

            public void SetDefaultValues()
            {
                _objectsService.RNDRValues.RData.dTestTempC = 25;  // microns
                _objectsService.RNDRValues.RData.dCellSize = 250E-6;  // microns
                _objectsService.RNDRValues.RData.dInitCellPress = 0.8; //atm
                _objectsService.RNDRValues.RData.dPolDensity = 1200.0;  //kg/m3
                _objectsService.RNDRValues.RData.dAgeTempC = 50;
                _objectsService.RNDRValues.RData.dPolCond = 0.225;
                _objectsService.RNDRValues.RData.dFracStrut = 0.7;
                _objectsService.RNDRValues.RData.sYaxisTag = "RV";
                _objectsService.RNDRValues.RData.sXaxisTag = "TE";
            }

            public void SetFields()
            {
                gMeasureTemp  = (_objectsService.RNDRValues.RData.dTestTempC * 1.8 + 32.0).ToString("0.0");
                gCellSize  = (1.0E6 * _objectsService.RNDRValues.RData.dCellSize).ToString("0.0");
                gCellPress  = _objectsService.RNDRValues.RData.dInitCellPress.ToString("0.00");
                gPolDen  = (_objectsService.RNDRValues.RData.dPolDensity / _objectsService.RNDRValues.CUConv.ToSi_Dens).ToString("0.00");
                gPolCond  = (1000.0 * _objectsService.RNDRValues.RData.dPolCond).ToString("0.00");
                gFracStruts  = (100.0 * _objectsService.RNDRValues.RData.dFracStrut).ToString("0.00");
            gXAxisSelectedValue = _objectsService.RNDRValues.RData.sXaxisTag;
            //gXAxisSelectedItem = _objectsService.RNDRValues.RCalc.sXAxisTitle;
            gYAxisSelectedValue = _objectsService.RNDRValues.RData.sYaxisTag;
                 //gYAxisSelectedValue = _objectsService.RNDRValues.RCalc.sYAxisTitle;
            //for (int i=0;i<2;i++)
            //    if (gYAxisSelectedItem.ToString() == _objectsService.RNDRValues.RData.sYaxisTag)
            //    {  _objectsService.RNDRValues.RCalc.sYAxisTitle = gYAxisSelectedValue.ToString(); }
            //for(int i = 0; i < 3; i++)
            //    if (gXAxisSelectedItem.ToString() == _objectsService.RNDRValues.RData.sXaxisTag)
            //    {  _objectsService.RNDRValues.RCalc.sXAxisTitle = gXAxisSelectedValue.ToString(); }
        }
    }

}
