using IntugentWebApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace IntugentWebApp.Pages.RnD_Users
{
    [BindProperties]
    public class RNDRawPropDataModel : PageModel
    {
        public DataView gDensityE {  get; set; }
        public DataView gDensityC {  get; set; }
        public DataView gHotPlatesE {  get; set; }
        public DataView gHotPlatesC {  get; set; }
        public DataView gHotPlatesC1 {  get; set; }
        public DataView gCompStrE {  get; set; }
        public DataView gCompStrC {  get; set; }
        public DataView gPoreScanE {  get; set; }
        public DataView gPoreScanC {  get; set; }
        public DataView gCloseCellE {  get; set; }
        public DataView  gCloseCellC {  get; set; }
        private ObjectsService _objectsService;
        public RNDRawPropDataModel(ObjectsService objectsService)
        {
            _objectsService = objectsService;
        }
        public void OnGet()
        {
            _objectsService.RNDHome.GetDataSet();
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
            int i2p1, i2p2;
            for (int i = 0; i < 8; i++)
            {
                i2p1 = 2 * i + 1; i2p2 = i2p1 + 1;
                if (_objectsService.RNDHome.dtF.Rows[i]["DensT1"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[0][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[0][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensT1"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["DensT2"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[1][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[1][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensT2"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["DensT3"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[2][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[2][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensT3"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["DensT4"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[3][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[3][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensT4"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["DensT5"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[4][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[4][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensT5"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["DensL1"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[5][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[5][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensL1"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["DensL2"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[6][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[6][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensL2"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["DensW1"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[7][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[7][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensW1"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["DensW2"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[8][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[8][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensW2"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["DensMass"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityE.Rows[9][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityE.Rows[9][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["DensMass"].ToString();

                if (_objectsService.RNDHome.dtF.Rows[i]["DensAvgT"] == DBNull.Value)_objectsService.RNDRawProps.dtDensityC.Rows[0][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityC.Rows[0][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["DensAvgT"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["DensAvgL"] == DBNull.Value)_objectsService.RNDRawProps.dtDensityC.Rows[1][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityC.Rows[1][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["DensAvgL"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["DensAvgW"] == DBNull.Value)_objectsService.RNDRawProps.dtDensityC.Rows[2][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityC.Rows[2][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["DensAvgW"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["Density"] == DBNull.Value) _objectsService.RNDRawProps.dtDensityC.Rows[3][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtDensityC.Rows[3][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["Density"]).ToString("0.000");

                if (_objectsService.RNDHome.dtF.Rows[i]["CompStr1"] == DBNull.Value) _objectsService.RNDRawProps.dtCompStrE.Rows[0][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtCompStrE.Rows[0][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CompStr1"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CompStr2"] == DBNull.Value) _objectsService.RNDRawProps.dtCompStrE.Rows[1][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtCompStrE.Rows[1][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CompStr2"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CompStr3"] == DBNull.Value) _objectsService.RNDRawProps.dtCompStrE.Rows[2][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtCompStrE.Rows[2][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CompStr3"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CompStr4"] == DBNull.Value) _objectsService.RNDRawProps.dtCompStrE.Rows[3][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtCompStrE.Rows[3][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CompStr4"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CompStr"] == DBNull.Value) _objectsService.RNDRawProps.dtCompStrC.Rows[0][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtCompStrC.Rows[0][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["CompStr"]).ToString("0.000");

                if (_objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer1"] == DBNull.Value) _objectsService.RNDRawProps.dtClosedCellE.Rows[0][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtClosedCellE.Rows[0][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer1"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer2"] == DBNull.Value) _objectsService.RNDRawProps.dtClosedCellE.Rows[1][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtClosedCellE.Rows[1][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer2"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer3"] == DBNull.Value) _objectsService.RNDRawProps.dtClosedCellE.Rows[2][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtClosedCellE.Rows[2][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer3"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer"] == DBNull.Value) _objectsService.RNDRawProps.dtClosedCellC.Rows[0][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtClosedCellC.Rows[0][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer"]).ToString("0.000");

                if (_objectsService.RNDHome.dtF.Rows[i]["CellDiaTop"] == DBNull.Value) _objectsService.RNDRawProps.dtPoreScanE.Rows[0][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtPoreScanE.Rows[0][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CellDiaTop"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CellStDevTop"] == DBNull.Value) _objectsService.RNDRawProps.dtPoreScanE.Rows[1][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtPoreScanE.Rows[1][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CellStDevTop"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CellCountTop"] == DBNull.Value) _objectsService.RNDRawProps.dtPoreScanE.Rows[2][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtPoreScanE.Rows[2][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CellCountTop"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CellDiaSide"] == DBNull.Value) _objectsService.RNDRawProps.dtPoreScanE.Rows[3][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtPoreScanE.Rows[3][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CellDiaSide"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CellStDevSide"] == DBNull.Value) _objectsService.RNDRawProps.dtPoreScanE.Rows[4][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtPoreScanE.Rows[4][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CellStDevSide"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CellCountSide"] == DBNull.Value) _objectsService.RNDRawProps.dtPoreScanE.Rows[5][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtPoreScanE.Rows[5][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["CellCountSide"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["CellDia"] == DBNull.Value) _objectsService.RNDRawProps.dtPoreScanC.Rows[0][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtPoreScanC.Rows[0][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["CellDia"]).ToString("0");
                if (_objectsService.RNDHome.dtF.Rows[i]["CellCount"] == DBNull.Value) _objectsService.RNDRawProps.dtPoreScanC.Rows[1][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtPoreScanC.Rows[1][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["CellCount"]).ToString("0");
                if (_objectsService.RNDHome.dtF.Rows[i]["CellDiaIsotropy"] == DBNull.Value) _objectsService.RNDRawProps.dtPoreScanC.Rows[2][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtPoreScanC.Rows[2][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["CellDiaIsotropy"]).ToString("0.000");

                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateInitMass"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[0][i2p1] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[0][i2p1] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateInitMass"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH1"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[1][i2p1] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[1][i2p1] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH1"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH2"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[2][i2p1] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[2][i2p1] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH2"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH3"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[3][i2p1] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[3][i2p1] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH3"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH4"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[4][i2p1] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[4][i2p1] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH4"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH5"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[5][i2p1] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[5][i2p1] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH5"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesC1.Rows[0][i2p1] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesC1.Rows[0][i2p1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["HotPlateInitH"]).ToString("0.000");

                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalMass"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[0][i2p2] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[0][i2p2] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalMass"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH1"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[1][i2p2] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[1][i2p2] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH1"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH2"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[2][i2p2] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[2][i2p2] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH2"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH3"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[3][i2p2] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[3][i2p2] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH3"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH4"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[4][i2p2] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[4][i2p2] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH4"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH5"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesE.Rows[5][i2p2] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesE.Rows[5][i2p2] = _objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH5"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesC1.Rows[0][i2p2] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesC1.Rows[0][i2p2] = ((double)_objectsService.RNDHome.dtF.Rows[i]["HotPlateFinalH"]).ToString("0.000");

                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateRetainMass"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesC.Rows[0][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesC.Rows[0][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["HotPlateRetainMass"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateRetainThick"] == DBNull.Value) _objectsService.RNDRawProps.dtHotPlatesC.Rows[1][i + 1] = string.Empty; else _objectsService.RNDRawProps.dtHotPlatesC.Rows[1][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["HotPlateRetainThick"]).ToString("0.000");
            }

            SetView();
        }
        public void SetView()
        {
            gDensityE   = _objectsService.RNDRawProps.dtDensityE.DefaultView;
            gDensityC   = _objectsService.RNDRawProps.dtDensityC.DefaultView;
            gHotPlatesE = _objectsService.RNDRawProps.dtHotPlatesE.DefaultView;
            gHotPlatesC = _objectsService.RNDRawProps.dtHotPlatesC.DefaultView;
            gHotPlatesC1 = _objectsService.RNDRawProps.dtHotPlatesC1.DefaultView;
            gCompStrE = _objectsService.RNDRawProps.dtCompStrE.DefaultView;
            gCompStrC   = _objectsService.RNDRawProps.dtCompStrC.DefaultView;
            gPoreScanE  = _objectsService.RNDRawProps.dtPoreScanE.DefaultView;
            gPoreScanC  = _objectsService.RNDRawProps.dtPoreScanC.DefaultView;
            gCloseCellE = _objectsService.RNDRawProps.dtClosedCellE.DefaultView;
            gCloseCellC = _objectsService.RNDRawProps.dtClosedCellC.DefaultView;

        }


        public IActionResult OnPostGBlurDensityE_Click(string rowId,string colId,string text)
        {
            string sMsg;
            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);
            bool bT = false, bW = false, bL = false, b = false;
            int icol1 = icol - 1;

            string[] sFields = { "DensT1", "DensT2", "DensT3", "DensT4", "DensT5", "DensL1", "DensL2", "DensW1", "DensW2", "DensMass" };

            int iSel;
            double dtemp;

            if (icol == 0) return null;
            if (irow > 9) return null;

            //DataGridRow dgr = e.Row;
            //TextBox tb = gDensityE.Columns[icol].GetCellContent(dgr) as TextBox;
            b = GetDoubleFromGrid(sFields, irow, icol1, text);
            b = true;
            if (irow < 5) bT = b;
            else if (irow < 7) bL = b;
            else if (irow < 9) bW = b;

            double dSum = 0, dtemp1 = 0; int nCount = 0;
            if (bT)
            {
                if (_objectsService.RNDHome.dtF.Rows[icol1]["DensT1"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensT1"]; }
                if (_objectsService.RNDHome.dtF.Rows[icol1]["DensT2"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensT2"]; }
                if (_objectsService.RNDHome.dtF.Rows[icol1]["DensT3"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensT3"]; }
                if (_objectsService.RNDHome.dtF.Rows[icol1]["DensT4"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensT4"]; }
                if (_objectsService.RNDHome.dtF.Rows[icol1]["DensT5"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensT5"]; }
                if (nCount > 0) { dtemp1 = dSum / nCount; _objectsService.RNDHome.dtF.Rows[icol1]["DensAvgT"] = dtemp1; _objectsService.RNDRawProps.dtDensityC.Rows[0][icol] = dtemp1.ToString("0.###"); }
                else { _objectsService.RNDHome.dtF.Rows[icol1]["DensAvgT"] = DBNull.Value; _objectsService.RNDRawProps.dtDensityC.Rows[0][icol] = string.Empty; }
            }
            else if (bL)
            {
                if (_objectsService.RNDHome.dtF.Rows[icol1]["DensL1"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensL1"]; }
                if (_objectsService.RNDHome.dtF.Rows[icol1]["DensL2"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensL2"]; }
                if (nCount > 0) { dtemp1 = dSum / nCount; _objectsService.RNDHome.dtF.Rows[icol1]["DensAvgL"] = dtemp1; _objectsService.RNDRawProps.dtDensityC.Rows[1][icol] = dtemp1.ToString("0.###"); }
                else { _objectsService.RNDHome.dtF.Rows[icol1]["DensAvgL"] = DBNull.Value; _objectsService.RNDRawProps.dtDensityC.Rows[1][icol] = string.Empty; }
            }

            else if (bW)
            {
                if (_objectsService.RNDHome.dtF.Rows[icol1]["DensW1"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensW1"]; }
                if (_objectsService.RNDHome.dtF.Rows[icol1]["DensW2"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensW2"]; }
                if (nCount > 0) { dtemp1 = dSum / nCount; _objectsService.RNDHome.dtF.Rows[icol1]["DensAvgW"] = dtemp1; _objectsService.RNDRawProps.dtDensityC.Rows[2][icol] = dtemp1.ToString("0.###"); }
                else { _objectsService.RNDHome.dtF.Rows[icol1]["DensAvgW"] = DBNull.Value; _objectsService.RNDRawProps.dtDensityC.Rows[2][icol] = string.Empty; }
            }

            if (_objectsService.RNDHome.dtF.Rows[icol1]["DensAvgT"] == DBNull.Value || _objectsService.RNDHome.dtF.Rows[icol1]["DensAvgL"] == DBNull.Value || _objectsService.RNDHome.dtF.Rows[icol1]["DensAvgW"] == DBNull.Value || _objectsService.RNDHome.dtF.Rows[icol1]["DensMass"] == DBNull.Value) { _objectsService.RNDHome.dtF.Rows[icol1]["Density"] = DBNull.Value; _objectsService.RNDRawProps.dtDensityC.Rows[3][icol] = string.Empty; }
            else
            {
                dtemp1 = 0.000578704 * (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensAvgT"] * (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensAvgL"] * (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensAvgW"];
                if (dtemp1 > 0)
                {
                    dtemp1 = 0.00220462 * (double)_objectsService.RNDHome.dtF.Rows[icol1]["DensMass"] / dtemp1;
                    _objectsService.RNDHome.dtF.Rows[icol1]["Density"] = dtemp1; _objectsService.RNDRawProps.dtDensityC.Rows[3][icol] = dtemp1.ToString("0.###");
                }
                else { _objectsService.RNDHome.dtF.Rows[icol1]["Density"] = DBNull.Value; _objectsService.RNDRawProps.dtDensityC.Rows[3][icol] = string.Empty; }
            }
            gDensityC  = _objectsService.RNDRawProps.dtDensityC.DefaultView;
            _objectsService.RNDHome.UpdateFormulatiions();
            return new JsonResult(new { message = rowId, colId, text });
        }

        public bool GetDoubleFromGrid(string[] sFields, int irow, int icol1, string tb)
        {
            string stmp, stmp0;
            double dtmp;
            bool b = false;

            string sField = sFields[irow];
            if (_objectsService.RNDHome.dtF.Rows[icol1][sField] == DBNull.Value) stmp0 = string.Empty;
            else if ((double)_objectsService.RNDHome.dtF.Rows[icol1][sField] > 0) stmp0 = ((double)_objectsService.RNDHome.dtF.Rows[icol1][sField]).ToString("0.####");
            else stmp0 = string.Empty;

            if (tb == string.Empty) _objectsService.RNDHome.dtF.Rows[icol1][sField] = DBNull.Value;
            else if (double.TryParse(tb, out dtmp)) { _objectsService.RNDHome.dtF.Rows[icol1][sField] = dtmp; b = true; }
            else { 
                //MessageBox.Show("Improper Value. New Value is not accepted.");
                  tb = stmp0; }
            return true;
        }

        public IActionResult OnPostGCompStrE(string rowId, string colId, string text)
        {
            string sMsg;
            string[] sFields = { "CompStr1", "CompStr2", "CompStr3", "CompStr4" };
            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);
            bool bd = false;
            int icol1 = icol - 1;

            double dtemp;

            if (icol == 0) return null;
            if (irow > 3) return null;

            //DataGridRow dgr = e.Row;
            //TextBox tb = gCompStrE.Columns[icol].GetCellContent(dgr) as TextBox;
            string tb = text;
            bool b = GetDoubleFromGrid(sFields, irow, icol1, tb);

            /*
                        bd = double.TryParse(tb.Text, out dtemp);
                        if (!bd) tb.Text = String.Empty;
                        //                dtDensityE.Rows[irow][icol] = dtemp;

                        switch (irow)
                        {
                            case 0: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CompStr1"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CompStr1"] = DBNull.Value; break;
                            case 1: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CompStr2"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CompStr2"] = DBNull.Value; break;
                            case 2: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CompStr3"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CompStr3"] = DBNull.Value; break;
                            case 3: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CompStr4"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CompStr4"] = DBNull.Value; break;
                        }
            */
            double dSum = 0, dtemp1 = 0; int nCount = 0;
            if (_objectsService.RNDHome.dtF.Rows[icol1]["CompStr1"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["CompStr1"]; }
            if (_objectsService.RNDHome.dtF.Rows[icol1]["CompStr2"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["CompStr2"]; }
            if (_objectsService.RNDHome.dtF.Rows[icol1]["CompStr3"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["CompStr3"]; }
            if (_objectsService.RNDHome.dtF.Rows[icol1]["CompStr4"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["CompStr4"]; }

            if (nCount > 0) { dtemp1 = dSum / nCount; _objectsService.RNDHome.dtF.Rows[icol1]["CompStr"] = dtemp1; _objectsService.RNDRawProps.dtCompStrC.Rows[0][icol] = dtemp1.ToString("0.###"); }
            else { _objectsService.RNDHome.dtF.Rows[icol1]["CompStr"] = DBNull.Value; _objectsService.RNDRawProps.dtCompStrC.Rows[0][icol] = string.Empty; }

            gCompStrC  = _objectsService.RNDRawProps.dtCompStrC.DefaultView;
            _objectsService.RNDHome.UpdateFormulatiions();
            return new JsonResult(true);

        }

                public IActionResult OnPostCloseCellEBlur(string rowId, string colId, string text)
                {
                    string sMsg;
                    string[] sFields = { "ClosedCellPer1", "ClosedCellPer2", "ClosedCellPer3" };
                    int irow = Int32.Parse(rowId);
                    int icol = Int32.Parse(colId);
                    bool bd = false;
                    int icol1 = icol - 1;

                    double dtemp;


                    if (icol == 0) return null;
                    if (irow > 2) return null;

            //DataGridRow dgr = e.Row;
            //TextBox tb = gCompStrE.Columns[icol].GetCellContent(dgr) as TextBox;
                   string tb = text; 
                    bool b = GetDoubleFromGrid(sFields, irow, icol1, tb);

                    /*
                    bd = double.TryParse(tb.Text, out dtemp);
                    if (!bd) tb.Text = String.Empty;
                    //                dtDensityE.Rows[irow][icol] = dtemp;

                    switch (irow)
                    {
                        case 0: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer1"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer1"] = DBNull.Value; break;
                        case 1: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer2"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer2"] = DBNull.Value; break;
                        case 2: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer3"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer3"] = DBNull.Value; break;

                    }
        */
                    double dSum = 0, dtemp1 = 0; int nCount = 0;
                    if (_objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer1"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer1"]; }
                    if (_objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer2"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer2"]; }
                    if (_objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer3"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer3"]; }

                    if (nCount > 0) { dtemp1 = dSum / nCount; _objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer"] = dtemp1; _objectsService.RNDRawProps.dtClosedCellC.Rows[0][icol] = dtemp1.ToString("0.###"); }
                    else { _objectsService.RNDHome.dtF.Rows[icol1]["ClosedCellPer"] = DBNull.Value; _objectsService.RNDRawProps.dtClosedCellC.Rows[0][icol] = string.Empty; }

                    gCloseCellC  = _objectsService.RNDRawProps.dtClosedCellC.DefaultView;
                    _objectsService.RNDHome.UpdateFormulatiions();
                    return new JsonResult(true);

                }

        public IActionResult OnPostOngPoreScaneE(string rowId, string colId, string text)
        {

            string sMsg;
            string[] sFields = { "CellDiaTop", "CellStDevTop", "CellCountTop", "CellDiaSide", "CellStDevSide", "CellCountSide" };
            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);
            bool bd = false, bDi = false, bS = false, bC = false;
            int icol1 = icol - 1;

            int iSel;
            double dtemp;




            if (icol == 0) return null;
            if (irow > 5) return null;

            //DataGridRow dgr = e.Row;
            //TextBox tb = gCompStrE.Columns[icol].GetCellContent(dgr) as TextBox;
            string tb = text;
            bool b = GetDoubleFromGrid(sFields, irow, icol1, tb);
            if (!b) return null;
            if (irow == 0 || irow == 3) bDi = true;
            if (irow == 1 || irow == 4) bS = true;
            if (irow == 2 || irow == 5) bC = true;
            /*
                                                TextBox tb = gDensityE.Columns[icol].GetCellContent(dgr) as TextBox;
                                                bd = double.TryParse(tb.Text, out dtemp);
                                                if (!bd) tb.Text = String.Empty;
                                                //                dtDensityE.Rows[irow][icol] = dtemp;

                                                switch (irow)
                                                {
                                                    case 0: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CellDiaTop"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CellDiaTop"] = DBNull.Value; bDi = true; break;
                                                    case 1: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CellStDevTop"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CellStDevTop"] = DBNull.Value; bS = true; break;
                                                    case 2: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CellCountTop"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CellCountTop",] = DBNull.Value; bC = true; break;
                                                    case 3: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CellDiaSide"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CellDiaSide"] = DBNull.Value; bDi = true; break;
                                                    case 4: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CellStDevSide"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CellStDevSide"] = DBNull.Value; bS = true; break;
                                                    case 5: if (bd) _objectsService.RNDHome.dtF.Rows[icol1]["CellCountSide"] = dtemp; else _objectsService.RNDHome.dtF.Rows[icol1]["CellCountSide"] = DBNull.Value; bC = true; break;
                                                }
                                    */
            double dSum = 0, dtemp1 = 0, num = 0.0, denom = 0.0; int nCount = 0;
            if (bDi)
            {
                if (_objectsService.RNDHome.dtF.Rows[icol1]["CellDiaTop"] != DBNull.Value) { nCount++; num = (double)_objectsService.RNDHome.dtF.Rows[icol1]["CellDiaTop"]; dSum += num; }
                if (_objectsService.RNDHome.dtF.Rows[icol1]["CellDiaSide"] != DBNull.Value) { nCount++; denom = (double)_objectsService.RNDHome.dtF.Rows[icol1]["CellDiaSide"]; dSum += denom; }
                if (nCount > 0) { dtemp1 = dSum / nCount; _objectsService.RNDHome.dtF.Rows[icol1]["CellDia"] = dtemp1; _objectsService.RNDRawProps.dtPoreScanC.Rows[0][icol] = dtemp1.ToString("0"); }
                else { _objectsService.RNDHome.dtF.Rows[icol1]["CellDia"] = DBNull.Value; _objectsService.RNDRawProps.dtPoreScanC.Rows[0][icol] = string.Empty; }

                if (_objectsService.RNDHome.dtF.Rows[icol1]["CellDiaTop"] == DBNull.Value || _objectsService.RNDHome.dtF.Rows[icol1]["CellDiaSide"] == DBNull.Value)
                { _objectsService.RNDHome.dtF.Rows[icol1]["CellDiaIsotropy"] = DBNull.Value; _objectsService.RNDRawProps.dtPoreScanC.Rows[2][icol] = string.Empty; }
                else if (denom > 0)
                { dtemp1 = num / denom; _objectsService.RNDHome.dtF.Rows[icol1]["CellDiaIsotropy"] = dtemp1; _objectsService.RNDRawProps.dtPoreScanC.Rows[2][icol] = dtemp1.ToString("0.###"); }
                else { _objectsService.RNDHome.dtF.Rows[icol1]["CellDiaIsotropy"] = DBNull.Value; _objectsService.RNDRawProps.dtPoreScanC.Rows[2][icol] = string.Empty; }
            }
            else if (bC)
            {
                if (_objectsService.RNDHome.dtF.Rows[icol1]["CellCountTop"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["CellCountTop"]; }
                if (_objectsService.RNDHome.dtF.Rows[icol1]["CellCountSide"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[icol1]["CellCountSide"]; }
                if (nCount > 0) { dtemp1 = dSum / nCount; _objectsService.RNDHome.dtF.Rows[icol1]["CellCount"] = dtemp1; _objectsService.RNDRawProps.dtPoreScanC.Rows[1][icol] = dtemp1.ToString("0"); }
                else { _objectsService.RNDHome.dtF.Rows[icol1]["CellCount"] = DBNull.Value; _objectsService.RNDRawProps.dtPoreScanC.Rows[1][icol] = string.Empty; }
            }


            gPoreScanC  = _objectsService.RNDRawProps.dtPoreScanC.DefaultView;
            _objectsService.RNDHome.UpdateFormulatiions();
            return null;
        }

        public IActionResult OnPostOngHotPlatesE(string rowId, string colId, string text)
        {

            string sMsg;
            string[] sFieldInit = { "HotPlateInitMass", "HotPlateInitH1", "HotPlateInitH2", "HotPlateInitH3", "HotPlateInitH4", "HotPlateInitH5" };
            string[] sFieldFinal = { "HotPlateFinalMass", "HotPlateFinalH1", "HotPlateFinalH2", "HotPlateFinalH3", "HotPlateFinalH4", "HotPlateFinalH5" };
            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);
            bool bd, bm = false, bH = false, bi = false, bf = false, bC = false;
            int ic, icf, icol1, itest;

            int iSel;
            double dtemp;


            if (icol == 0 || icol == 17) return null;
            if (irow > 17) return null;

            icol1 = icol - 1;
            ic = icol1 / 2;
            itest = icol1 - 2 * ic;
            if (itest == 0) bi = true; else bf = true;

            //DataGridRow dgr = e.Row;
            //TextBox tb = gHotPlatesE.Columns[icol].GetCellContent(dgr) as TextBox;
            string tb = text;
            //            bd = double.TryParse(tb.Text, out dtemp);
            //            if (!bd) tb.Text = String.Empty;
            //                dtDensityE.Rows[irow][icol] = dtemp;

            double dSum = 0, dtemp1 = 0, num = 0.0, denom = 0.0; int nCount = 0;

            if (bi)
            {
                /*              switch (irow)
                              {
                                  case 0: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitMass"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitMass"] = DBNull.Value; bm = true; break;
                                  case 1: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH1"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH1"] = DBNull.Value; bH = true; break;
                                  case 2: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH2"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH2"] = DBNull.Value; bH = true; break;
                                  case 3: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH3"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH3"] = DBNull.Value; bH = true; break;
                                  case 4: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH4"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH4"] = DBNull.Value; bH = true; break;
                                  case 5: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH5"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH5"] = DBNull.Value; bH = true; break;
                              }
                */
                bool b = GetDoubleFromGrid(sFieldInit, irow, ic, tb);
                if (!b) return null;
                if (irow == 0) bm = true; else bH = true;

                if (bH)
                {
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH1"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH1"]; }
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH2"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH2"]; }
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH3"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH3"]; }
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH4"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH4"]; }
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH5"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH5"]; }

                    if (nCount > 0) { dtemp1 = dSum / nCount; _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH"] = dtemp1; _objectsService.RNDRawProps.dtHotPlatesC1.Rows[0][icol] = dtemp1.ToString("0.###"); }
                    else { _objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH"] = DBNull.Value; _objectsService.RNDRawProps.dtHotPlatesC1.Rows[0][icol] = string.Empty; }
                }
            }
            else
            {
                /*             switch (irow)
                             {
                                 case 0: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalMass"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalMass"] = DBNull.Value; bm = true; break;
                                 case 1: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH1"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH1"] = DBNull.Value; bH = true; break;
                                 case 2: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH2"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH2"] = DBNull.Value; bH = true; break;
                                 case 3: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH3"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH3"] = DBNull.Value; bH = true; break;
                                 case 4: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH4"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH4"] = DBNull.Value; bH = true; break;
                                 case 5: if (bd) _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH5"] = dtemp; else _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH5"] = DBNull.Value; bH = true; break;
                             }
                */
                bool b = GetDoubleFromGrid(sFieldFinal, irow, ic, tb);
                if (!b) return null;
                if (irow == 0) bm = true; else bH = true;
                if (bH)
                {
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH1"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH1"]; }
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH2"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH2"]; }
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH3"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH3"]; }
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH4"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH4"]; }
                    if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH5"] != DBNull.Value) { nCount++; dSum += (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH5"]; }

                    if (nCount > 0) { dtemp1 = dSum / nCount; _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH"] = dtemp1; _objectsService.RNDRawProps.dtHotPlatesC1.Rows[0][icol] = dtemp1.ToString("0.###"); }
                    else { _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH"] = DBNull.Value; _objectsService.RNDRawProps.dtHotPlatesC1.Rows[0][icol] = string.Empty; }
                }
            }
            if (bH)
            {
                if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH"] == DBNull.Value || _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH"] == DBNull.Value)
                { _objectsService.RNDHome.dtF.Rows[ic]["HotPlateRetainThick"] = DBNull.Value; _objectsService.RNDRawProps.dtHotPlatesC.Rows[1][ic + 1] = string.Empty; }
                else
                {
                    denom = (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitH"];
                    num = (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalH"];
                }
                if (denom > 0) { _objectsService.RNDHome.dtF.Rows[ic]["HotPlateRetainThick"] = 100.0 * num / denom; _objectsService.RNDRawProps.dtHotPlatesC.Rows[1][ic + 1] = (100.0 * num / denom).ToString("0.###"); }
                else { _objectsService.RNDHome.dtF.Rows[ic]["HotPlateRetainThick"] = DBNull.Value; _objectsService.RNDRawProps.dtHotPlatesC.Rows[1][ic + 1] = string.Empty; }
            }
            else
            {
                if (_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitMass"] == DBNull.Value || _objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalMass"] == DBNull.Value)
                { _objectsService.RNDHome.dtF.Rows[ic]["HotPlateRetainMass"] = DBNull.Value; _objectsService.RNDRawProps.dtHotPlatesC.Rows[0][ic + 1] = string.Empty; }
                else
                {
                    denom = (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateInitMass"];
                    num = (double)_objectsService.RNDHome.dtF.Rows[ic]["HotPlateFinalMass"];
                }
                if (denom > 0) { _objectsService.RNDHome.dtF.Rows[ic]["HotPlateRetainMass"] = 100.0 * num / denom; _objectsService.RNDRawProps.dtHotPlatesC.Rows[0][ic + 1] = (100.0 * num / denom).ToString("0.###"); }
                else { _objectsService.RNDHome.dtF.Rows[ic]["HotPlateRetainMass"] = DBNull.Value; _objectsService.RNDRawProps.dtHotPlatesC.Rows[0][ic + 1] = string.Empty; }
            }
            gHotPlatesC1  = _objectsService.RNDRawProps.dtHotPlatesC1.DefaultView;
            gHotPlatesC  = _objectsService.RNDRawProps.dtHotPlatesC.DefaultView;
            _objectsService.RNDHome.UpdateFormulatiions();
            return new JsonResult(true);
        }
  
    
    
    }

}

