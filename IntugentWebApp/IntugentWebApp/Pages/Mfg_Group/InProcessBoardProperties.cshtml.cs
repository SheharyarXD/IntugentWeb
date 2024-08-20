using Google.Api.Gax;
using IntugentClassLbrary.Classes;
using IntugentClassLibrary.Classes;
using IntugentClassLibrary.Pages.Mfg;
using IntugentClassLibrary.Utilities;
using IntugentWebApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace IntugentWebApp.Pages.Mfg_Group
{
    [BindProperties]

    public class InProcessBoardPropertiesModel : PageModel
    {
        #region properties
        public string gsLoc1A { get; set; }
        public string gsLoc2A { get; set; }
        public string gsLoc3A { get; set; }
        public string gsLoc1E { get; set; }
        public string gsLoc3E { get; set; }
        public string gsLoc3F { get; set; }
        public string gsLoc1B { get; set; }
        public string gsLoc2B { get; set; }
        public string gsLoc3B { get; set; }
        public string gsLoc1C { get; set; }
        public string gsLoc2C { get; set; }
        public string gsLoc3C { get; set; }
        public string gsLoc1D { get; set; }
        public string gsLoc2D { get; set; }
        public string gsLoc3D { get; set; }
        public bool gDataSetNextIsEnabled { get; set; }
        public bool gDataSetPrevIsEnabled { get; set; }
        public DateTime? gTestDateTime { get; set; }
        public DataView gProdID { get; set; }
        public string gProdIDSelectedValue { get; set; }
        public DataView gRunType { get; set; }
        public int gRunTypeSelectedValue { get; set; }
        public DataView gSurfactant { get; set; }
        public int gSurfactantSelectedIndex { get; set; }
        public DataView gLayout { get; set; }
        public int gLayoutSelectedIndex { get; set; }
        public DataView gPaperManufacturer { get; set; }
        public int gPaperManufacturerSelectedIndex { get; set; }
        public DataView gShift { get; set; }
        public int gShiftSelectedValue { get; set; }
        public DataView gOperator { get; set; }
        public int gOperatorSelectedItem { get; set; }
        public string gID { get; set; }
        public bool gTimeStampNotLegibleIsChecked { get; set; }
        public int gPaperManufacturerSelectedValue { get; set; }
        public string gRunningWetDesnsity { get; set; }
        public string gWarehouseTemp { get; set; }
        public string gWarehouseHumidity { get; set; }
        public bool gInProcessDoneIsChecked { get; set; }
        public bool gAbandonedIsChecked { get; set; }
        public string gCoreDensityIPText { get; set; }
        public string gThicknessIPText { get; set; }
        public string gCompressiveIPText { get; set; }
        public string gCompressiveIP5Text { get; set; }
        public string gThicknessValleyText { get; set; }
        public string gThicknessPeakText { get; set; }
        public string gFlatnessText { get; set; }
        public string gLengthText { get; set; }
        public string gWidthText { get; set; }
        public string gBundleHeightIPText { get; set; }
        public string gDiagoanl1Text { get; set; }
        public string gDiagoanl2Text { get; set; }
        public string gDiagoanlDiffText { get; set; }
        public string gThicknessIP_1Text { get; set; }
        public string gThicknessIP_2Text { get; set; }
        public string gThicknessIP_3Text { get; set; }
        public string gThicknessIP_4Text { get; set; }
        public string gThicknessIP_5Text { get; set; }
        public string gThicknessIP_6Text { get; set; }
        public string gThicknessIP_7Text { get; set; }
        public string gThicknessIP_8Text { get; set; }
        public string gThicknessIP_9Text { get; set; }
        public string gThicknessIP_10Text { get; set; }
        public string gThicknessIP_11Text { get; set; }
        public string gThicknessIP_12Text { get; set; }
        public object gThicknessIP_13Text { get; set; }
        public string gThicknessIP_14Text { get; set; }
        public string gThicknessIP_15Text { get; set; }
        public string gThicknessIP_16Text { get; set; }
        public string gThicknessIP_17Text { get; set; }
        public bool gTopBoardPerforatedIsChecked { get; set; }
        public bool gBottomBoardPerforatedIsChecked { get; set; }
        public bool gTopBoardPrintOKIsChecked { get; set; }
        public bool gBottomBoardPrintOKIsChecked { get; set; }
        public string gCompressiveIP_1Text { get; set; }
        public string gCompressiveIP_2Text { get; set; }
        public string gCompressiveIP_3Text { get; set; }
        public string gCompressiveIP_4Text { get; set; }
        public string gCompressiveIP_5Text { get; set; }
        public string gCompressiveIP_6Text { get; set; }
        public bool gCompStrKnitPresent_1IsChecked { get; set; }
        public bool gCompStrKnitPresent_2IsChecked { get; set; }
        public bool gCompStrKnitPresent_3IsChecked { get; set; }
        public bool gCompStrKnitPresent_4IsChecked { get; set; }
        public bool gCompStrKnitPresent_5IsChecked { get; set; }
        public bool gCompStrKnitPresent_6IsChecked { get; set; }
        public bool gCoreKnitPresent_1IsChecked { get; set; }
        public string gMass_1Text { get; set; }
        public string gL1_1Text { get; set; }
        public string gW1_1Text { get; set; }
        public string gT1_1Text { get; set; }
        public string gT2_1Text { get; set; }
        public string gT3_1Text { get; set; }
        public string gT4_1Text { get; set; }
        public string gT5_1Text { get; set; }
        public string gCoreDensityIP_1Text { get; set; }
        public string gMass_2Text { get; set; }
        public string gL1_2Text { get; set; }
        public string gW1_2Text { get; set; }
        public string gT1_2Text { get; set; }
        public string gT2_2Text { get; set; }
        public string gT3_2Text { get; set; }
        public string gT4_2Text { get; set; }
        public string gT5_2Text { get; set; }
        public string gCoreDensityIP_2Text { get; set; }
        public string gMass_3Text { get; set; }
        public string gL1_3Text { get; set; }
        public string gW1_3Text { get; set; }
        public string gT1_3Text { get; set; }
        public string gT2_3Text { get; set; }
        public string gT3_3Text { get; set; }
        public string gT4_3Text { get; set; }
        public string gT5_3Text { get; set; }
        public bool gCoreKnitPresent_2IsChecked { get; set; }
        public string gCoreDensityIP_3Text { get; set; }
        public bool gCoreKnitPresent_3IsChecked { get; set; }
        public string gPourHeadPosition_1Text { get; set; }
        public string gPourHeadPosition_2Text { get; set; }
        public string gPourHeadPosition_3Text { get; set; }
        public string gIRFacerTempLowerText { get; set; }
        public string gIRFacerTempUpperText { get; set; }
        public string gIRStreamTempPourHead_1Text { get; set; }
        public string gIRStreamTempPourHead_2Text { get; set; }
        public string gIRStreamTempPourHead_3Text { get; set; }
        public string gIRNipRoll_1Text { get; set; }
        public string gIRNipRoll_2Text { get; set; }
        public string gIRNipRoll_3Text { get; set; }
        public string gKnitLineLoc_1Text { get; set; }
        public string gKnitLineLoc_2Text { get; set; }
        public string gKnitLineLoc_3Text { get; set; }
        public string gKnitLineLoc_4Text { get; set; }
        public string gKnitLineLoc_5Text { get; set; }
        public string gKnitLineLoc_6Text { get; set; }
        public string gKnitLineLoc_7Text { get; set; }
        public string gThicknessAvg1Text { get; set; }
        public string gThicknessAvg2Text { get; set; }
        public string gThicknessSlopeText { get; set; }
        public string gTimePourTableQCCheckCustomFormat { get; set; }
        public DateTime gTimePourTableQCCheckValue { get; set; }
        public string gSplitterAgeText { get; set; }
        public string gHeadPlateAgeText { get; set; }
        public int gSurfactantSelectedValue { get; set; }
        public int gLayoutSelectedValue { get; set; }
        //            color properties
        public bool backColorCal { get; set; } = true;
        public bool backColorRed { get; set; } = false;
        public bool gThicknessIPBackground {  get; set; }
        public bool gThicknessAvg1Background {  get; set; }
        public bool gThicknessAvg2Background {  get; set; }
        public bool gThicknessSlopeBackground {  get; set; }
        public bool gFlatnessBackground {  get; set; }
        public bool gBundleHeightIPBackground {  get; set; }
        public bool gLengthBackground {  get; set; }
        public bool gWidthBackground {  get; set; }
        public bool gDiagoanlDiffBackground {  get; set; }

        public bool gCoreDensityIPBackground { get; set; }
        public bool gCoreDensityIP_1Background { get; set; }
        public bool gCoreDensityIP_2Background { get; set; }
        public bool gCoreDensityIP_3Background { get; set; }
        public bool gCompressiveIPBackground {  get; set; }
        public bool gCompressiveIP5Background {  get; set; }
        public bool gBoardTimeStampBackground {  get; set; }
        #endregion

        private readonly ObjectsService _objectsService;

        public InProcessBoardPropertiesModel(ObjectsService objectsService)
        {
            _objectsService = objectsService;
        }
        public void OnGet()
        {
            (_objectsService.MfgInProcess, _objectsService.MfgFinishedGoods, _objectsService.MfgDimensionsStability, _objectsService.MfgPlantsData, _objectsService.MfgJetMixing) = _objectsService.MfgHome.GetAllMfgData(_objectsService.MfgInProcess, _objectsService.MfgFinishedGoods, _objectsService.MfgDimensionsStability, _objectsService.MfgPlantsData, _objectsService.MfgJetMixing);
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
            SetData();

            MfgInProcess? mfgInProcess = new MfgInProcess(_objectsService.Cbfile);
            _objectsService.MfgInProcess = mfgInProcess;

            gsLoc1A = gsLoc1E = _objectsService.CDefualts.sLocMfg1.ToUpper();
            gsLoc2A = _objectsService.CDefualts.sLocMfg2.ToUpper();
            gsLoc3A = gsLoc3E = gsLoc3F = _objectsService.CDefualts.sLocMfg3.ToUpper();

            gsLoc1B = gsLoc1C = gsLoc1D = _objectsService.CDefualts.sLocMfg1;
            gsLoc2B = gsLoc2C = gsLoc2D = _objectsService.CDefualts.sLocMfg2;
            gsLoc3B = gsLoc3C = gsLoc3D = _objectsService.CDefualts.sLocMfg3;

            SetView();

            // print values here.. not properly binding with frontend...!!!!!!!!!!
        }
        private void SetData()
        {
            #region Mfg specific lists
            if (_objectsService.CDefualts.IDLocation != 3)
            {
                gProdID = _objectsService.CLists.dvComProd;
                gProdIDSelectedValue = _objectsService.CDefualts.sProdMfg;

                gRunType = _objectsService.CLists.dvRunType2;
                gRunTypeSelectedValue = _objectsService.CDefualts.iRunType;

                gSurfactant = _objectsService.CLists.dvSurfactants;
                gSurfactantSelectedIndex = 0;

                gLayout = _objectsService.CLists.dvLayout;
                gLayoutSelectedIndex = 0;

                gPaperManufacturer = _objectsService.CLists.dvPaper;
                gPaperManufacturerSelectedIndex = 0;

                gShift = _objectsService.CLists.dvShift;
                gShiftSelectedValue = 1;

                gOperator = _objectsService.CLists.dvEmployeesMfg;
                gOperatorSelectedItem = _objectsService.CDefualts.IDEmployee;
            }
            #endregion
        }
        private void CheckLimits(string sF)
        {
            //Must be included in setview and   change products
            string sRet = string.Empty;
            //            if (sF == "All") CProdTargets.GetProductTargets();


            if (sF == "gThicknessIP" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Thickness - IP"] == DBNull.Value) gThicknessIPBackground = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.ThicknessWithinLimits((double)_objectsService.MfgInProcess.dr["Thickness - IP"]);
                    if (sRet == "Red") gThicknessIPBackground = backColorRed;
                    //else if (sRet == "Esc") gThicknessIP.Background = backColorEsc;
                    else gThicknessIPBackground = backColorCal;
                }

            }

            if (sF == "gThicknessAvg1" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Thickness IP Avg1"] == DBNull.Value) gThicknessAvg1Background = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.ThicknessAvg1WithinLimits((double)_objectsService.MfgInProcess.dr["Thickness IP Avg1"]);
                    if (sRet == "Red") gThicknessAvg1Background = backColorRed;
                    //else if (sRet == "Esc") gThicknessAvg1.Background = backColorEsc;
                    else gThicknessAvg1Background = backColorCal;
                }

            }
            if (sF == "gThicknessAvg2" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Thickness IP Avg2"] == DBNull.Value) gThicknessAvg2Background = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.ThicknessAvg2WithinLimits((double)_objectsService.MfgInProcess.dr["Thickness IP Avg2"]);
                    if (sRet == "Red") gThicknessAvg2Background = backColorRed;
                    //else if (sRet == "Esc") gThicknessAvg2.Background = backColorEsc;
                    else gThicknessAvg2Background = backColorCal;
                }

            }
            if (sF == "gThicknessSlope" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["IP Thickness Slope"] == DBNull.Value) gThicknessSlopeBackground = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.ThicknessSlopeWithinLimits((double)_objectsService.MfgInProcess.dr["IP Thickness Slope"]);
                    if (sRet == "Red") gThicknessSlopeBackground = backColorRed;
                    //else if (sRet == "Esc") gThicknessSlope.Background = backColorEsc;
                    else gThicknessSlopeBackground = backColorCal;
                }

            }

            if (sF == "gFlatness" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Flatness IP"] == DBNull.Value) gFlatnessBackground = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.ThicknessProfileWithinLimits((double)_objectsService.MfgInProcess.dr["Flatness IP"]);
                    if (sRet == "Red") gFlatnessBackground = backColorRed;
                    //else if (sRet == "Esc") gFlatness.Background = backColorEsc;
                    else gFlatnessBackground = backColorCal;
                }

            }
            if (sF == "gBundleHeightIP" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Bundle Height IP"] == DBNull.Value) gBundleHeightIPBackground = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.BundleHeightWithinLimits((double)_objectsService.MfgInProcess.dr["Bundle Height IP"]);
                    if (sRet == "Red") gBundleHeightIPBackground = backColorRed;
                    //else if (sRet == "Esc") gBundleHeightIP.Background = backColorEsc;
                    else gBundleHeightIPBackground = backColorCal;
                }

            }

            if (sF == "gLength" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Length"] == DBNull.Value) gLengthBackground = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.BoardLengthWithinLimits((double)_objectsService.MfgInProcess.dr["Length"]);
                    if (sRet == "Red") gLengthBackground = backColorRed;
                    //else if (sRet == "Esc") gLength.Background = backColorEsc;
                    else gLengthBackground = backColorCal;
                }

            }
            if (sF == "gWidth" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Width"] == DBNull.Value) gWidthBackground = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.BoardWidthWithinLimits((double)_objectsService.MfgInProcess.dr["Width"]);
                    if (sRet == "Red") gWidthBackground = backColorRed;
                    //else if (sRet == "Esc") gWidth.Background = backColorEsc;
                    else gWidthBackground = backColorCal;
                }

            }
            if (sF == "gDiagoanlDiff" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["IP Diagonal Diff"] == DBNull.Value) gDiagoanlDiffBackground = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.BoardSquarenessWithinLimits((double)_objectsService.MfgInProcess.dr["IP Diagonal Diff"]);
                    if (sRet == "Red") gDiagoanlDiffBackground = backColorRed;
                    //else if (sRet == "Esc") gDiagoanlDiff.Background = backColorEsc;
                    else gDiagoanlDiffBackground = backColorCal;
                }
            }
            /*         if (sF == "gCoreDensityIP" || sF == "All")
                     {
                         if (_objectsService.MfgInProcess.dr["Width"] == DBNull.Value) gCoreDensityIP.Background = backColor;
                         else
                         {
                             sRet = _objectsService.CIPProdTargets.BoardWidthWithinLimits((double)_objectsService.MfgInProcess.dr["Width"]);
                             if (sRet == "Red") gCoreDensityIP.Background = backColorRed;
                             else if (sRet == "Esc") gCoreDensityIP.Background = backColorEsc;
                             else gCoreDensityIP.Background = backColor;
                         }

                     }*/
            if (sF == "gCoreDensityIP" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Core Density - IP"] == DBNull.Value) gCoreDensityIPBackground = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.CoreDensityWithinLimits((double)_objectsService.MfgInProcess.dr["Core Density - IP"]);
                    if (sRet == "Red") gCoreDensityIPBackground = backColorRed;
                    //else if (sRet == "Esc") gCoreDensityIP.Background = backColorEsc;
                    else gCoreDensityIPBackground = backColorCal;
                }
            }
            if (sF == "gCoreDensityIP_1" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Core Density - IP 1"] == DBNull.Value) gCoreDensityIP_1Background = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.CoreDensityWithinLimits((double)_objectsService.MfgInProcess.dr["Core Density - IP 1"]);
                    if (sRet == "Red") gCoreDensityIP_1Background = backColorRed;
                    //else if (sRet == "Esc") gCoreDensityIP_1.Background = backColorEsc;
                    else gCoreDensityIP_1Background = backColorCal;
                }
            }
            if (sF == "gCoreDensityIP_2" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Core Density - IP 2"] == DBNull.Value) gCoreDensityIP_2Background = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.CoreDensityWithinLimits((double)_objectsService.MfgInProcess.dr["Core Density - IP 2"]);
                    if (sRet == "Red") gCoreDensityIP_2Background = backColorRed;
                    //else if (sRet == "Esc") gCoreDensityIP_2.Background = backColorEsc;
                    else gCoreDensityIP_2Background = backColorCal;
                }
            }
            if (sF == "gCoreDensityIP_3" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Core Density - IP 3"] == DBNull.Value) gCoreDensityIP_3Background = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.CoreDensityWithinLimits((double)_objectsService.MfgInProcess.dr["Core Density - IP 3"]);
                    if (sRet == "Red") gCoreDensityIP_3Background = backColorRed;
                    //else if (sRet == "Esc") gCoreDensityIP_3.Background = backColorEsc;
                    else gCoreDensityIP_3Background = backColorCal;
                }
            }
            if (sF == "gCompressiveIP" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Compressive Strength - IP"] == DBNull.Value) gCompressiveIPBackground = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.CompressionStrWithinLimits((double)_objectsService.MfgInProcess.dr["Compressive Strength - IP"]);
                    if (sRet == "Red") gCompressiveIPBackground = backColorRed;
                    //else if (sRet == "Esc") gCompressiveIP.Background = backColorEsc;
                    else gCompressiveIPBackground = backColorCal;
                }
            }
            if (sF == "gCompressiveIP5" || sF == "All")
            {
                if (_objectsService.MfgInProcess.dr["Compressive Strength 5 - IP"] == DBNull.Value) gCompressiveIP5Background = backColorCal;
                else
                {
                    sRet = _objectsService.CIPProdTargets.CompressionStrWithinLimits((double)_objectsService.MfgInProcess.dr["Compressive Strength 5 - IP"]);
                    if (sRet == "Red") gCompressiveIP5Background = backColorRed;
                    //else if (sRet == "Esc") gCompressiveIP5.Background = backColorEsc;
                    else gCompressiveIP5Background = backColorCal;
                }
            }


            /*
                        if (sF == "gCompressiveIP" || sF == "All")
                        {
                            if (_objectsService.MfgInProcess.dr["Compressive Strength - IP"] == DBNull.Value) gCompressiveIP.Background = backColorCal;
                            else if (CProdTargets.CompressionWithinLimits((double)_objectsService.MfgInProcess.dr["Compressive Strength - IP"]) == "N") gCompressiveIP.Background = backColorWarn; else gCompressiveIP.Background = backColorCal;
                        }

                        if (sF == "gCompressiveIP5" || sF == "All")
                        {
                            if (_objectsService.MfgInProcess.dr["Compressive Strength 5 - IP"] == DBNull.Value) gCompressiveIP5.Background = backColorCal;
                            else if (CProdTargets.CompressionWithinLimits((double)_objectsService.MfgInProcess.dr["Compressive Strength 5 - IP"]) == "N") gCompressiveIP5.Background = backColorWarn; else gCompressiveIP5.Background = backColorCal;
                        }

                        if (sF == "gCoreDensityIP" || sF == "All")
                        {
                            if (_objectsService.MfgInProcess.dr["Core Density - IP"] == DBNull.Value) gCoreDensityIP.Background = backColorCal;
                            else if (CProdTargets.CoreDensWithinLimits((double)_objectsService.MfgInProcess.dr["Core Density - IP"]) == "N") gCoreDensityIP.Background = backColorWarn; else gCoreDensityIP.Background = backColorCal;
                        }

                        if (sF == "gCoreDensityIP_1" || sF == "All")
                        {
                            if (_objectsService.MfgInProcess.dr["Core Density - IP 1"] == DBNull.Value) gCoreDensityIP_1.Background = backColorCal;
                            else if (CProdTargets.CoreDensWithinLimits((double)_objectsService.MfgInProcess.dr["Core Density - IP 1"]) == "N") gCoreDensityIP_1.Background = backColorWarn; else gCoreDensityIP_1.Background = backColorCal;
                        }

                        if (sF == "gCoreDensityIP_2" || sF == "All")
                        {
                            if (_objectsService.MfgInProcess.dr["Core Density - IP 2"] == DBNull.Value) gCoreDensityIP_2.Background = backColorCal;
                            else if (CProdTargets.CoreDensWithinLimits((double)_objectsService.MfgInProcess.dr["Core Density - IP 2"]) == "N") gCoreDensityIP_2.Background = backColorWarn; else gCoreDensityIP_2.Background = backColorCal;
                        }

                        if (sF == "gCoreDensityIP_3" || sF == "All")
                        {
                            if (_objectsService.MfgInProcess.dr["Core Density - IP 3"] == DBNull.Value) gCoreDensityIP_3.Background = backColorCal;
                            else if (CProdTargets.CoreDensWithinLimits((double)_objectsService.MfgInProcess.dr["Core Density - IP 3"]) == "N") gCoreDensityIP_3.Background = backColorWarn; else gCoreDensityIP_3.Background = backColorCal;
                        }

                        if (sF == "gLength" || sF == "All")
                        {
                            if (_objectsService.MfgInProcess.dr["Length"] == DBNull.Value) gLength.Background = backColor;
                            else if (CProdTargets.LengthWithinLimits((double)_objectsService.MfgInProcess.dr["Length"]) == "N") gLength.Background = backColorWarn; else gLength.Background = backColor;
                        }

                        if (sF == "gCoreDensityIP" || sF == "All")
                        {
                            if (_objectsService.MfgInProcess.dr["Width"] == DBNull.Value) gCoreDensityIP.Background = backColor;
                            else if (CProdTargets.WidthWithinLimits((double)_objectsService.MfgInProcess.dr["Width"]) == "N") gCoreDensityIP.Background = backColorWarn; else gCoreDensityIP.Background = backColor;
                        }

                        if (sF == "gDiagoanlDiff" || sF == "All")
                        {
                            if (_objectsService.MfgInProcess.dr["IP Diagonal Diff"] == DBNull.Value) gDiagoanlDiff.Background = backColorCal;
                            else if (CProdTargets.SquarenessWithinLimits((double)_objectsService.MfgInProcess.dr["IP Diagonal Diff"]) == "N") gDiagoanlDiff.Background = backColorWarn; else gDiagoanlDiff.Background = backColorCal;
                        }
               */

            DateTime IPdate, FGdate;
            string sMsg = "Green Board and FG Board time stamps must be greater than 01-01-2000 and must be within " + _objectsService.CDefualts.dDelTimeButton.ToString() + " minutes of each other.";

            //if (sF == "BoardTimeStamp" || sF == "All")
            //{
            //    if (_objectsService.MfgInProcess.drFG["Finished Board Time Stamp FG"] == DBNull.Value || _objectsService.MfgInProcess.dr["Test Date"] == DBNull.Value)
            //    { gBoardTimeStampBackground = backColorRed;
            //            //if (sF == "BoardTimeStamp")
            //            //MessageBox.Show(sMsg, _objectsService.Cbfile.sAppName);
            //    }
            //    else
            //    {
            //        FGdate = (DateTime)_objectsService.MfgInProcess.drFG["Finished Board Time Stamp FG"];
            //        IPdate = (DateTime)_objectsService.MfgInProcess.dr["Test Date"];
            //        if (IPdate < new DateTime(2000, 01, 01) || Math.Abs((FGdate - IPdate).TotalMinutes) > _objectsService.CDefualts.dDelTimeButton)
            //        { gBoardTimeStampBackground = backColorRed; }
            //        else gBoardTimeStampBackground = backColorCal;
            //        if (sF == "BoardTimeStamp")
            //        {
            //            if (gBoardTimeStampBackground == backColorCal)
            //            {
            //                //CStatusBar.SetText("Pulling process data for dataset " + Cbfile.iIDMfg.ToString());
            //                _objectsService.MfgPlantsData.GetPlantDataBackground(FGdate);
            //                //                           CStatusBar.SetText("Finished pulling process data for dataset " + Cbfile.iIDMfg.ToString());
            //            }
            //            //else MessageBox.Show(sMsg, _objectsService.Cbfile.sAppName);

            //        }
            //    }
            //}

        }
        public void SetView()
        {
            if (_objectsService.Cbfile.iIDMfgIndex == 0) gDataSetNextIsEnabled = false; else gDataSetNextIsEnabled = true;
            if (_objectsService.Cbfile.iIDMfgIndex == _objectsService.MfgHome.dt.Rows.Count - 1) gDataSetPrevIsEnabled = false; else gDataSetPrevIsEnabled = true;

            #region date, time, and datetime controls.

            if (_objectsService.MfgInProcess.dr?["Test Date"] == DBNull.Value) gTestDateTime = _objectsService.Cbfile.dateDefault;
            else { gTestDateTime = (DateTime)_objectsService.MfgInProcess.dr["Test Date"]; }


            #region Gen. Info, Av. Values, Board Dimensions

            gID = _objectsService.MfgInProcess.dr?["ID4ALL"].ToString();
            if ((_objectsService.MfgInProcess.dr?["Operator"] == DBNull.Value)) gOperatorSelectedItem = -1; else gOperatorSelectedItem = (int)_objectsService.MfgInProcess.dr["Operator"];

            if (!(_objectsService.MfgInProcess.dr?["Click box if time stamp is NOT legible"] == DBNull.Value)) gTimeStampNotLegibleIsChecked = (bool)_objectsService.MfgInProcess.dr?["Click box if time stamp is NOT legible"]; else gTimeStampNotLegibleIsChecked = false;
            if (_objectsService.MfgInProcess.dr?["Shift"] == DBNull.Value) gShiftSelectedValue = -1; else gShiftSelectedValue = (int)_objectsService.MfgInProcess.dr?["Shift"];
            if ((_objectsService.MfgInProcess.dr?["Product ID"] == DBNull.Value)) gProdIDSelectedValue = String.Empty; else gProdIDSelectedValue = _objectsService.MfgInProcess.dr?["Product ID"].ToString();
            if ((_objectsService.MfgInProcess.dr?["Paper Manufacturer"] == DBNull.Value)) gPaperManufacturerSelectedValue = -1; else gPaperManufacturerSelectedValue = (int)_objectsService.MfgInProcess.dr?["Paper Manufacturer"];
            gRunningWetDesnsity = _objectsService.MfgInProcess.SetDoubleTextField("Running Wet Density");
            gWarehouseTemp = _objectsService.MfgInProcess.SetDoubleTextField("Warehouse Temp");
            gWarehouseHumidity = _objectsService.MfgInProcess.SetDoubleTextField("Warehouse Humidity");

            if ((_objectsService.MfgInProcess.dr?["IP Testing Complete"] == DBNull.Value)) { gInProcessDoneIsChecked = false; _objectsService.gInProcessDoneIsChecked = false; } else { _objectsService.gInProcessDoneIsChecked=gInProcessDoneIsChecked = (bool)_objectsService.MfgInProcess.dr?["IP Testing Complete"]; }
            if (_objectsService.MfgInProcess.dr?["Run Type"] == DBNull.Value) gRunTypeSelectedValue = -1; else gRunTypeSelectedValue = (int)_objectsService.MfgInProcess.dr?["Run Type"];
            if ((_objectsService.MfgInProcess.dr?["Abandoned"] == DBNull.Value)) gAbandonedIsChecked = false; else gAbandonedIsChecked = (bool)_objectsService.MfgInProcess.dr?["Abandoned"];

            gCoreDensityIPText = _objectsService.MfgInProcess.SetDoubleTextField("Core Density - IP", MfgInProcess.sOr);
            gThicknessIPText = _objectsService.MfgInProcess.SetDoubleTextField("Thickness - IP", MfgInProcess.sOr);
            gCompressiveIPText = _objectsService.MfgInProcess.SetDoubleTextField("Compressive Strength - IP", MfgInProcess.sOr);
            gCompressiveIP5Text = _objectsService.MfgInProcess.SetDoubleTextField("Compressive Strength 5 - IP", MfgInProcess.sOr);
            gThicknessValleyText = _objectsService.MfgInProcess.SetDoubleTextField("thickness IP- valleys", MfgInProcess.sOr);
            gThicknessPeakText = _objectsService.MfgInProcess.SetDoubleTextField("thickness peaks IP", MfgInProcess.sOr);
            gFlatnessText = _objectsService.MfgInProcess.SetDoubleTextField("Flatness IP", MfgInProcess.sOr);

            gLengthText = _objectsService.MfgInProcess.SetDoubleTextField("Length");
            gWidthText = _objectsService.MfgInProcess.SetDoubleTextField("Width");
            gBundleHeightIPText = _objectsService.MfgInProcess.SetDoubleTextField("Bundle Height IP");
            gDiagoanl1Text = _objectsService.MfgInProcess.SetDoubleTextField("IP Diagonal 1");
            gDiagoanl2Text = _objectsService.MfgInProcess.SetDoubleTextField("IP Diagonal 2");
            gDiagoanlDiffText = _objectsService.MfgInProcess.SetDoubleTextField("IP Diagonal Diff", MfgInProcess.sOr);
            #endregion

            #region thickness

            gThicknessIP_1Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 1");
            gThicknessIP_2Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 2");
            gThicknessIP_3Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 3");
            gThicknessIP_4Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 4");
            gThicknessIP_5Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 5");
            gThicknessIP_6Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 6");
            gThicknessIP_7Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 7");
            gThicknessIP_8Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 8");
            gThicknessIP_9Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 9");
            gThicknessIP_10Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 10");
            gThicknessIP_11Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 11");
            gThicknessIP_12Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 12");
            gThicknessIP_13Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 13");
            gThicknessIP_14Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 14");
            gThicknessIP_15Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 15");
            gThicknessIP_16Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 16");
            gThicknessIP_17Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP - 17");

            #endregion

            if (!(_objectsService.MfgInProcess.dr?["Top Board Perforated"] == DBNull.Value)) gTopBoardPerforatedIsChecked = (bool)_objectsService.MfgInProcess.dr?["Top Board Perforated"]; else gTopBoardPerforatedIsChecked = false;
            if (!(_objectsService.MfgInProcess.dr?["Bottom Board Perforated"] == DBNull.Value)) gBottomBoardPerforatedIsChecked = (bool)_objectsService.MfgInProcess.dr?["Bottom Board Perforated"]; else gBottomBoardPerforatedIsChecked = false;
            if (!(_objectsService.MfgInProcess.dr?["Top Board Print OK"] == DBNull.Value)) gTopBoardPrintOKIsChecked = (bool)_objectsService.MfgInProcess.dr?["Top Board Print OK"]; else gTopBoardPrintOKIsChecked = false;
            if (!(_objectsService.MfgInProcess.dr?["Bottom Board Print OK"] == DBNull.Value)) gBottomBoardPrintOKIsChecked = (bool)_objectsService.MfgInProcess.dr?["Bottom Board Print OK"]; else gBottomBoardPrintOKIsChecked = false;

            gCompressiveIP_1Text = _objectsService.MfgInProcess.SetDoubleTextField("Compressive IP - 1");
            gCompressiveIP_2Text = _objectsService.MfgInProcess.SetDoubleTextField("Compressive IP - 2");
            gCompressiveIP_3Text = _objectsService.MfgInProcess.SetDoubleTextField("Compressive IP - 3");
            gCompressiveIP_4Text = _objectsService.MfgInProcess.SetDoubleTextField("Compressive IP - 4");
            gCompressiveIP_5Text = _objectsService.MfgInProcess.SetDoubleTextField("Compressive IP - 5");
            gCompressiveIP_6Text = _objectsService.MfgInProcess.SetDoubleTextField("Compressive IP - 6");

            if (_objectsService.MfgInProcess.dr?["Comp Str Knit Present 1"] == DBNull.Value) gCompStrKnitPresent_1IsChecked = false; else gCompStrKnitPresent_1IsChecked = (bool)_objectsService.MfgInProcess.dr?["Comp Str Knit Present 1"];
            if (_objectsService.MfgInProcess.dr?["Comp Str Knit Present 2"] == DBNull.Value) gCompStrKnitPresent_2IsChecked = false; else gCompStrKnitPresent_2IsChecked = (bool)_objectsService.MfgInProcess.dr?["Comp Str Knit Present 2"];
            if (_objectsService.MfgInProcess.dr?["Comp Str Knit Present 3"] == DBNull.Value) gCompStrKnitPresent_3IsChecked = false; else gCompStrKnitPresent_3IsChecked = (bool)_objectsService.MfgInProcess.dr?["Comp Str Knit Present 3"];
            if (_objectsService.MfgInProcess.dr?["Comp Str Knit Present 4"] == DBNull.Value) gCompStrKnitPresent_4IsChecked = false; else gCompStrKnitPresent_4IsChecked = (bool)_objectsService.MfgInProcess.dr?["Comp Str Knit Present 4"];
            if (_objectsService.MfgInProcess.dr?["Comp Str Knit Present 5"] == DBNull.Value) gCompStrKnitPresent_5IsChecked = false; else gCompStrKnitPresent_5IsChecked = (bool)_objectsService.MfgInProcess.dr?["Comp Str Knit Present 5"];
            if (_objectsService.MfgInProcess.dr?["Comp Str Knit Present 6"] == DBNull.Value) gCompStrKnitPresent_6IsChecked = false; else gCompStrKnitPresent_6IsChecked = (bool)_objectsService.MfgInProcess.dr?["Comp Str Knit Present 6"];

            gMass_1Text = _objectsService.MfgInProcess.SetDoubleTextField("Mass 1");
            gL1_1Text = _objectsService.MfgInProcess.SetDoubleTextField("L1 1");
            gW1_1Text = _objectsService.MfgInProcess.SetDoubleTextField("W1 1");
            gT1_1Text = _objectsService.MfgInProcess.SetDoubleTextField("T1 1");
            gT2_1Text = _objectsService.MfgInProcess.SetDoubleTextField("T2 1");
            gT3_1Text = _objectsService.MfgInProcess.SetDoubleTextField("T3 1");
            gT4_1Text = _objectsService.MfgInProcess.SetDoubleTextField("T4 1");
            gT5_1Text = _objectsService.MfgInProcess.SetDoubleTextField("T5 1");
            if (_objectsService.MfgInProcess.dr?["Core Knit Present 1"] == DBNull.Value) gCoreKnitPresent_1IsChecked = false; else gCoreKnitPresent_1IsChecked = (bool)_objectsService.MfgInProcess.dr?["Core Knit Present 1"];
            gCoreDensityIP_1Text = _objectsService.MfgInProcess.SetDoubleTextField("Core Density - IP 1", MfgInProcess.sOr);

            gMass_2Text = _objectsService.MfgInProcess.SetDoubleTextField("Mass 2");
            gL1_2Text = _objectsService.MfgInProcess.SetDoubleTextField("L1 2");
            gW1_2Text = _objectsService.MfgInProcess.SetDoubleTextField("W1 2");
            gT1_2Text = _objectsService.MfgInProcess.SetDoubleTextField("T1 2");
            gT2_2Text = _objectsService.MfgInProcess.SetDoubleTextField("T2 2");
            gT3_2Text = _objectsService.MfgInProcess.SetDoubleTextField("T3 2");
            gT4_2Text = _objectsService.MfgInProcess.SetDoubleTextField("T4 2");
            gT5_2Text = _objectsService.MfgInProcess.SetDoubleTextField("T5 2");
            if (_objectsService.MfgInProcess.dr?["Core Knit Present 2"] == DBNull.Value) gCoreKnitPresent_2IsChecked = false; else gCoreKnitPresent_2IsChecked = (bool)_objectsService.MfgInProcess.dr?["Core Knit Present 2"];
            gCoreDensityIP_2Text = _objectsService.MfgInProcess.SetDoubleTextField("Core Density - IP 2", MfgInProcess.sOr);

            gMass_3Text = _objectsService.MfgInProcess.SetDoubleTextField("Mass 3");
            gL1_3Text = _objectsService.MfgInProcess.SetDoubleTextField("L1 3");
            gW1_3Text = _objectsService.MfgInProcess.SetDoubleTextField("W1 3");
            gT1_3Text = _objectsService.MfgInProcess.SetDoubleTextField("T1 3");
            gT2_3Text = _objectsService.MfgInProcess.SetDoubleTextField("T2 3");
            gT3_3Text = _objectsService.MfgInProcess.SetDoubleTextField("T3 3");
            gT4_3Text = _objectsService.MfgInProcess.SetDoubleTextField("T4 3");
            gT5_3Text = _objectsService.MfgInProcess.SetDoubleTextField("T5 3");
            if (_objectsService.MfgInProcess.dr?["Core Knit Present 3"] == DBNull.Value) gCoreKnitPresent_3IsChecked = false; else gCoreKnitPresent_3IsChecked = (bool)_objectsService.MfgInProcess.dr?["Core Knit Present 3"];
            gCoreDensityIP_3Text = _objectsService.MfgInProcess.SetDoubleTextField("Core Density - IP 3", MfgInProcess.sOr);

            if (_objectsService.MfgInProcess.dr?["Time of Pour Table QC Check"] == DBNull.Value) gTimePourTableQCCheckCustomFormat = _objectsService.MfgInProcess.sNull;
            else { gTimePourTableQCCheckCustomFormat = _objectsService.MfgInProcess.sTimeFormat; gTimePourTableQCCheckValue = (DateTime)_objectsService.MfgInProcess.dr?["Time of Pour Table QC Check"]; }
            if ((_objectsService.MfgInProcess.dr?["Surfactant Type"] == DBNull.Value)) gSurfactantSelectedValue = -1; else gSurfactantSelectedValue = (int)_objectsService.MfgInProcess.dr?["Surfactant Type"];
            if ((_objectsService.MfgInProcess.dr?["Pour Table Layout"] == DBNull.Value)) gLayoutSelectedValue = -1; else gLayoutSelectedValue = (int)_objectsService.MfgInProcess.dr?["Pour Table Layout"];

            gSplitterAgeText = _objectsService.MfgInProcess.SetIntTextField("Splitter Age (minutes)");
            gHeadPlateAgeText = _objectsService.MfgInProcess.SetIntTextField("Headplate Age / Pour Run Time (minutes)");

            #region Pour Table

            gPourHeadPosition_1Text = _objectsService.MfgInProcess.SetDoubleTextField("Pour Head Position - 1");
            gPourHeadPosition_2Text = _objectsService.MfgInProcess.SetDoubleTextField("Pour Head Position - 2");
            gPourHeadPosition_3Text = _objectsService.MfgInProcess.SetDoubleTextField("Pour Head Position - 3");

            gIRFacerTempLowerText = _objectsService.MfgInProcess.SetDoubleTextField("IR Facer Temp - Lower");
            gIRFacerTempUpperText = _objectsService.MfgInProcess.SetDoubleTextField("IR Facer Temp - Upper");

            gIRStreamTempPourHead_1Text = _objectsService.MfgInProcess.SetDoubleTextField("IR Stream Temp - Pour Head 1");
            gIRStreamTempPourHead_2Text = _objectsService.MfgInProcess.SetDoubleTextField("IR Stream Temp - Pour Head 2");
            gIRStreamTempPourHead_3Text = _objectsService.MfgInProcess.SetDoubleTextField("IR Stream Temp - Pour Head 3");

            gIRNipRoll_1Text = _objectsService.MfgInProcess.SetDoubleTextField("IR Stream Temp - Nipp Roll 1");
            gIRNipRoll_2Text = _objectsService.MfgInProcess.SetDoubleTextField("IR Stream Temp - Nipp Roll 2");
            gIRNipRoll_3Text = _objectsService.MfgInProcess.SetDoubleTextField("IR Stream Temp - Nipp Roll 3");

            #endregion

            #region Knit Line Location
            gKnitLineLoc_1Text = _objectsService.MfgInProcess.SetDoubleTextField("Knit Line Loc 1");
            gKnitLineLoc_2Text = _objectsService.MfgInProcess.SetDoubleTextField("Knit Line Loc 2");
            gKnitLineLoc_3Text = _objectsService.MfgInProcess.SetDoubleTextField("Knit Line Loc 3");
            gKnitLineLoc_4Text = _objectsService.MfgInProcess.SetDoubleTextField("Knit Line Loc 4");
            gKnitLineLoc_5Text = _objectsService.MfgInProcess.SetDoubleTextField("Knit Line Loc 5");
            gKnitLineLoc_6Text = _objectsService.MfgInProcess.SetDoubleTextField("Knit Line Loc 6");
            gKnitLineLoc_7Text = _objectsService.MfgInProcess.SetDoubleTextField("Knit Line Loc 7");

            #endregion

            #region Thickness Avgs for each side
            gThicknessAvg1Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP Avg1", MfgInProcess.sOr);
            gThicknessAvg2Text = _objectsService.MfgInProcess.SetDoubleTextField("Thickness IP Avg2", MfgInProcess.sOr);
            gThicknessSlopeText = _objectsService.MfgInProcess.SetDoubleTextField("IP Thickness Slope", MfgInProcess.sOr);
            #endregion

            CheckLimits("All");


            #endregion
        }

        public IActionResult OnPostNewDataset(string caller)
        {
            string sName = caller;

            if (!_objectsService.Cbfile.bCanSwitchRecord) { 
               // MessageBox.Show(Cbfile.sNoRecSwitchMsg, Cbfile.sAppName); 
                return Page(); 
            }
            switch (sName)
            {
                case "gDataSetPrev": _objectsService.Cbfile.iIDMfgIndex += 1; break;
                case "gDataSetNext": _objectsService.Cbfile.iIDMfgIndex -= 1; break;
            }

            if (_objectsService.Cbfile.iIDMfgIndex < 0) _objectsService.Cbfile.iIDMfgIndex = 0;
            if (_objectsService.Cbfile.iIDMfgIndex > _objectsService.MfgHome.dt.Rows.Count - 1) _objectsService.Cbfile.iIDMfgIndex = _objectsService.MfgHome.dt.Rows.Count - 1;

            _objectsService.Cbfile.iIDMfg = (int)_objectsService.MfgHome.dt.Rows[_objectsService.Cbfile.iIDMfgIndex]["ID4ALL"];
            _objectsService.CLists.drEmployee["MfgIDSelected"] = _objectsService.Cbfile.iIDMfg; CLists_UpdateEmployee.UpdateEmployee(_objectsService.CLists);

           (_objectsService.MfgInProcess,_objectsService.MfgFinishedGoods,_objectsService.MfgDimensionsStability, _objectsService.MfgPlantsData, _objectsService.MfgJetMixing) = _objectsService.MfgHome.GetAllMfgData(_objectsService.MfgInProcess,_objectsService.MfgFinishedGoods, _objectsService.MfgDimensionsStability, _objectsService.MfgPlantsData, _objectsService.MfgJetMixing);

            //SetView();
            return new JsonResult(new { message = "Dataset selected: " + caller });
        }

        public IActionResult OnPostGBoardPerfs_LF(string caller, string state)
        {
            string sName = caller;

            _objectsService.MfgInProcess.bDataSetChanged = true;

            switch (sName)
            {
                case "gTopBoardPerforated": _objectsService.MfgInProcess.dr["Top Board Perforated"] = state; break;
                case "gBottomBoardPerforated":  _objectsService.MfgInProcess.dr["Bottom Board Perforated"] = state; break;
                case "gTopBoardPrintOK": _objectsService.MfgInProcess.dr["Top Board Print OK"] = state; break;
                case "gBottomBoardPrintOK": _objectsService.MfgInProcess.dr["Bottom Board Print OK"] = state; break;

            }
            _objectsService.MfgInProcess.UpdateDataSet();

            return new JsonResult(new { message = "Dataset selected: " + state});
        }

        public IActionResult OnPostGThickness_LF(string caller, double value)
        {
            string sName = caller;

            _objectsService.MfgInProcess.bDataSetChanged = true;

            switch (sName)
            {
                case "gThicknessIP_1": _objectsService.MfgInProcess.dr["Thickness IP - 1"] = value; break;
                case "gThicknessIP_2": _objectsService.MfgInProcess.dr["Thickness IP - 2"] = value; break;
                case "gThicknessIP_3": _objectsService.MfgInProcess.dr["Thickness IP - 3"] = value; break;
                case "gThicknessIP_4": _objectsService.MfgInProcess.dr["Thickness IP - 4"] = value; break;
                case "gThicknessIP_5": _objectsService.MfgInProcess.dr["Thickness IP - 5"] = value; break;
                case "gThicknessIP_6": _objectsService.MfgInProcess.dr["Thickness IP - 6"] = value; break;
                case "gThicknessIP_7": _objectsService.MfgInProcess.dr["Thickness IP - 7"] = value; break;
                case "gThicknessIP_8": _objectsService.MfgInProcess.dr["Thickness IP - 8"] = value; break;
                case "gThicknessIP_9": _objectsService.MfgInProcess.dr["Thickness IP - 9"] = value; break;
                case "gThicknessIP_10": _objectsService.MfgInProcess.dr["Thickness IP - 10"] = value; break;
                case "gThicknessIP_11": _objectsService.MfgInProcess.dr["Thickness IP - 11"] = value; break;
                case "gThicknessIP_12": _objectsService.MfgInProcess.dr["Thickness IP - 12"] = value; break;
                case "gThicknessIP_13": _objectsService.MfgInProcess.dr["Thickness IP - 13"] = value; break;
                case "gThicknessIP_14": _objectsService.MfgInProcess.dr["Thickness IP - 14"] = value; break;
                case "gThicknessIP_15": _objectsService.MfgInProcess.dr["Thickness IP - 15"] = value; break;
                case "gThicknessIP_16": _objectsService.MfgInProcess.dr["Thickness IP - 16"] = value; break;
                case "gThicknessIP_17": _objectsService.MfgInProcess.dr["Thickness IP - 17"] = value; break;

            }

            int nCount = 0; double dSum = 0, dtmp;
            string sField = "Thickness IP - ";
            double dmin = double.MaxValue, dmax = double.MinValue;

            for (int i = 1; i < 18; i++)
            {
                sField = "Thickness IP - " + i.ToString();
                if (!(_objectsService.MfgInProcess.dr[sField] == DBNull.Value))
                {
                    dtmp = (double)_objectsService.MfgInProcess.dr[sField]; dSum += dtmp; nCount += 1;
                    if (dtmp < dmin) dmin = dtmp; if (dtmp > dmax) dmax = dtmp;
                }
            }


            dtmp = dSum / (double)nCount;
            if (nCount < 17 || Double.IsNaN(dtmp))
            {
                gThicknessIPText = gThicknessValleyText = gThicknessPeakText = gFlatnessText = string.Empty;
                _objectsService.MfgInProcess.dr["Thickness - IP"] = _objectsService.MfgInProcess.dr["thickness IP- valleys"] = _objectsService.MfgInProcess.dr["thickness peaks IP"] = _objectsService.MfgInProcess.dr["Flatness IP"] = DBNull.Value;
            }
            else
            {
                gThicknessIPText = dtmp.ToString(MfgInProcess.sOr); _objectsService.MfgInProcess.dr["Thickness - IP"] = dtmp;
                gThicknessValleyText = dmin.ToString(MfgInProcess.sOr); _objectsService.MfgInProcess.dr["thickness IP- valleys"] = dmin;
                gThicknessPeakText = dmax.ToString(MfgInProcess.sOr); _objectsService.MfgInProcess.dr["thickness peaks IP"] = dmax;
                gFlatnessText = (dmin - dmax).ToString(MfgInProcess.sOr); _objectsService.MfgInProcess.dr["Flatness IP"] = dmin - dmax;
            }

            nCount = 0;
            dSum = 0.0;
            for (int i = 1; i < 9; i++)
            {
                sField = "Thickness IP - " + i.ToString();
                if (!(_objectsService.MfgInProcess.dr[sField] == DBNull.Value)) { dtmp = (double)_objectsService.MfgInProcess.dr[sField]; dSum += dtmp; nCount += 1; }
            }
            dtmp = dSum / (double)nCount;
            if (nCount < 8 || Double.IsNaN(dtmp)) { gThicknessAvg1Text = string.Empty; _objectsService.MfgInProcess.dr["Thickness IP Avg1"] = DBNull.Value; }
            else { gThicknessAvg1Text = dtmp.ToString(MfgInProcess.sOr); _objectsService.MfgInProcess.dr["Thickness IP Avg1"] = dtmp; }

            nCount = 0;
            dSum = 0.0;
            for (int i = 10; i < 18; i++)
            {
                sField = "Thickness IP - " + i.ToString();
                if (!(_objectsService.MfgInProcess.dr[sField] == DBNull.Value)) { dtmp = (double)_objectsService.MfgInProcess.dr[sField]; dSum += dtmp; nCount += 1; }
            }
            dtmp = dSum / (double)nCount;
            if (nCount < 8 || Double.IsNaN(dtmp)) { gThicknessAvg2Text = string.Empty; _objectsService.MfgInProcess.dr["Thickness IP Avg2"] = DBNull.Value; }
            else { gThicknessAvg2Text = dtmp.ToString(MfgInProcess.sOr); _objectsService.MfgInProcess.dr["Thickness IP Avg2"] = dtmp; }

            if (_objectsService.MfgInProcess.dr["Thickness IP Avg1"] != DBNull.Value && _objectsService.MfgInProcess.dr["Thickness IP Avg2"] != DBNull.Value)
            {
                dtmp = Math.Abs((double)_objectsService.MfgInProcess.dr["Thickness IP Avg1"] - (double)_objectsService.MfgInProcess.dr["Thickness IP Avg2"]); gThicknessSlopeText = dtmp.ToString(MfgInProcess.sOr); _objectsService.MfgInProcess.dr["IP Thickness Slope"] = dtmp;
            }
            else gThicknessSlopeText = string.Empty;


            _objectsService.MfgInProcess.UpdateDataSet();

            return new JsonResult(new { message = "Dataset selected: " + caller + " -- " + value });
        }

        public IActionResult OnPostGKintLineLocs_LF(string caller, double value)
        {
            _objectsService.MfgInProcess.bDataSetChanged = true;

            switch (caller)
            {
                case "gKnitLineLoc_1": _objectsService.MfgInProcess.dr["Knit Line Loc 1"] = value; break;
                case "gKnitLineLoc_2": _objectsService.MfgInProcess.dr["Knit Line Loc 2"] = value; break;
                case "gKnitLineLoc_3": _objectsService.MfgInProcess.dr["Knit Line Loc 3"] = value; break;
                case "gKnitLineLoc_4": _objectsService.MfgInProcess.dr["Knit Line Loc 4"] = value; break;
                case "gKnitLineLoc_5": _objectsService.MfgInProcess.dr["Knit Line Loc 5"] = value; break;
                case "gKnitLineLoc_6": _objectsService.MfgInProcess.dr["Knit Line Loc 6"] = value; break;
                case "gKnitLineLoc_7": _objectsService.MfgInProcess.dr["Knit Line Loc 7"] = value; break;
            }
            _objectsService.MfgInProcess.UpdateDataSet();

            return new JsonResult(new { message = "Dataset selected: " + caller });
        }
        
        public IActionResult OnPostGBoardDimensions_LF(string caller, double value)
        {
            bool bDia = false;
            double dtmp;

            _objectsService.MfgInProcess.bDataSetChanged = true;

            switch (caller)
            {
                case "gLength": _objectsService.MfgInProcess.dr["Length"] = value; break;
                case "gWidth": _objectsService.MfgInProcess.dr["Width"] = value; break;
                case "gBundleHeightIP": _objectsService.MfgInProcess.dr["Bundle Height IP"] = value; break;
                case "gDiagoanl1": _objectsService.MfgInProcess.dr["IP Diagonal 1"] = value; bDia = true; break;
                case "gDiagoanl2": _objectsService.MfgInProcess.dr["IP Diagonal 2"] = value; bDia = true; break;

            }

            if (bDia && !(_objectsService.MfgInProcess.dr["IP Diagonal 1"] == DBNull.Value) && !(_objectsService.MfgInProcess.dr["IP Diagonal 2"] == DBNull.Value))
            { dtmp = Math.Abs((double)_objectsService.MfgInProcess.dr["IP Diagonal 1"] - (double)_objectsService.MfgInProcess.dr["IP Diagonal 2"]); _objectsService.MfgInProcess.dr["IP Diagonal Diff"] = dtmp; gDiagoanlDiffText = dtmp.ToString(MfgInProcess.sOr); }

            _objectsService.MfgInProcess.UpdateDataSet();

            return new JsonResult(new { message = "Dataset selected: " + caller });
        }

        public IActionResult OnPostCompressiveStr_LF(string caller, double value)
        {
            _objectsService.MfgInProcess.bDataSetChanged = true;

            switch (caller)
            {
                case "gCompressiveIP_1": _objectsService.MfgInProcess.dr["Compressive IP - 1"] = value; break;
                case "gCompressiveIP_2": _objectsService.MfgInProcess.dr["Compressive IP - 2"] = value; break;
                case "gCompressiveIP_3": _objectsService.MfgInProcess.dr["Compressive IP - 3"] = value; break;
                case "gCompressiveIP_4": _objectsService.MfgInProcess.dr["Compressive IP - 4"] = value; break;
                case "gCompressiveIP_5": _objectsService.MfgInProcess.dr["Compressive IP - 5"] = value; break;
                case "gCompressiveIP_6": _objectsService.MfgInProcess.dr["Compressive IP - 6"] = value; break;
            }


            int nCount = 0;
            double dSum = 0.0, dtmp, dMin = double.MaxValue;

            if (!(_objectsService.MfgInProcess.dr["Compressive IP - 1"] == DBNull.Value)) { nCount += 1; dtmp = (double) _objectsService.MfgInProcess.dr["Compressive IP - 1"]; dSum += dtmp; if (dMin > dtmp) dMin = dtmp; }
            if (!(_objectsService.MfgInProcess.dr["Compressive IP - 2"] == DBNull.Value)) { nCount += 1; dtmp = (double) _objectsService.MfgInProcess.dr["Compressive IP - 2"]; dSum += dtmp; if (dMin > dtmp) dMin = dtmp; }
            if (!(_objectsService.MfgInProcess.dr["Compressive IP - 3"] == DBNull.Value)) { nCount += 1; dtmp = (double) _objectsService.MfgInProcess.dr["Compressive IP - 3"]; dSum += dtmp; if (dMin > dtmp) dMin = dtmp; }
            if (!(_objectsService.MfgInProcess.dr["Compressive IP - 4"] == DBNull.Value)) { nCount += 1; dtmp = (double) _objectsService.MfgInProcess.dr["Compressive IP - 4"]; dSum += dtmp; if (dMin > dtmp) dMin = dtmp; }
            if (!(_objectsService.MfgInProcess.dr["Compressive IP - 5"] == DBNull.Value)) { nCount += 1; dtmp = (double) _objectsService.MfgInProcess.dr["Compressive IP - 5"]; dSum += dtmp; if (dMin > dtmp) dMin = dtmp; }
            if (!(_objectsService.MfgInProcess.dr["Compressive IP - 6"] == DBNull.Value)) { nCount += 1; dtmp = (double) _objectsService.MfgInProcess.dr["Compressive IP - 6"]; dSum += dtmp; if (dMin > dtmp) dMin = dtmp; }

            if (nCount == 6)
            {
                 _objectsService.MfgInProcess.dr["Compressive Strength - IP"] = dSum / 6.0; gCompressiveIPText = (dSum / 6.0).ToString(MfgInProcess.sOr);
                 _objectsService.MfgInProcess.dr["Compressive Strength 5 - IP"] = (dSum - dMin) / 5.0; gCompressiveIP5Text = ((dSum - dMin) / 5.0).ToString(MfgInProcess.sOr);
            }
            else if (nCount == 5)
            {
                 _objectsService.MfgInProcess.dr["Compressive Strength - IP"] = DBNull.Value; gCompressiveIPText = String.Empty;
                 _objectsService.MfgInProcess.dr["Compressive Strength 5 - IP"] = dSum / 5.0; gCompressiveIP5Text = (dSum / 5.0).ToString(MfgInProcess.sOr);
            }

            else
            {
                 _objectsService.MfgInProcess.dr["Compressive Strength - IP"] = DBNull.Value; gCompressiveIPText = String.Empty;
                 _objectsService.MfgInProcess.dr["Compressive Strength 5 - IP"] = DBNull.Value; gCompressiveIP5Text = String.Empty;
            }


            _objectsService.MfgInProcess.UpdateDataSet();

            return new JsonResult(new { message = "Dataset selected: " + caller });
        }
    }
}
