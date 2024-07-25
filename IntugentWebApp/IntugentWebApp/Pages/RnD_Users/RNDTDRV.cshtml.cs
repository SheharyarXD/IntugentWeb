using IntugentWebApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace IntugentWebApp.Pages.RnD_Users
{
    [BindProperties]
    public class RNDTDRVModel : PageModel
    {
       public DataView gExpPropsE {get;set;}
       public DataView gExpPropsC {get;set;}
       public DataView gExpPropsP {get;set;}

        public bool? gAgedTestingCompIsChecked {  get; set; }
        private ObjectsService _objectsService { get; set; }
        public RNDTDRVModel(ObjectsService objectsService) {
        
                _objectsService = objectsService;
        }
        public void OnGet()
        {
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
            int ir;
            for (int i = 0; i < 8; i++)
            {
                ir = 1;
                if (_objectsService.RNDHome.dtF.Rows[i]["K10D25FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 1][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 1][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K10D25FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K10D40FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 2][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 2][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K10D40FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K10D75FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 3][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 3][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K10D75FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K10D110FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 4][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 4][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K10D110FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K10D25FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 6][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 6][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K10D25FFinal"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K10D40FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 7][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 7][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K10D40FFinal"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K10D75FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 8][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 8][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K10D75FFinal"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K10D110FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 9][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 9][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K10D110FFinal"].ToString();

                if (_objectsService.RNDHome.dtF.Rows[i]["R10D25FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 1][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 1][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R10D25FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R10D40FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 2][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 2][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R10D40FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R10D75FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 3][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 3][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R10D75FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R10D110FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 4][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 4][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R10D110FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R10D25FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 6][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 6][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R10D25FFinal"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R10D40FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 7][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 7][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R10D40FFinal"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R10D75FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 8][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 8][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R10D75FFinal"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R10D110FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 9][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 9][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R10D110FFinal"]).ToString("0.000");

                ir = 13;
                if (_objectsService.RNDHome.dtF.Rows[i]["K90D25FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 1][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 1][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K90D25FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K90D40FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 2][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 2][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K90D40FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K90D75FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 3][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 3][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K90D75FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K90D110FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 4][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 4][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K90D110FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K90D25FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 6][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 6][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K90D25FFinal"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K90D40FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 7][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 7][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K90D40FFinal"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K90D75FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 8][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 8][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K90D75FFinal"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K90D110FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 9][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 9][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K90D110FFinal"].ToString();

                if (_objectsService.RNDHome.dtF.Rows[i]["R90D25FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 1][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 1][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R90D25FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R90D40FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 2][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 2][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R90D40FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R90D75FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 3][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 3][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R90D75FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R90D110FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 4][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 4][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R90D110FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R90D25FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 6][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 6][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R90D25FFinal"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R90D40FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 7][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 7][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R90D40FFinal"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R90D75FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 8][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 8][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R90D75FFinal"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R90D110FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 9][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 9][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R90D110FFinal"]).ToString("0.000");

                ir = 25;
                if (_objectsService.RNDHome.dtF.Rows[i]["K180D25FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 1][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 1][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K180D25FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K180D40FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 2][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 2][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K180D40FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K180D75FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 3][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 3][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K180D75FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K180D110FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 4][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 4][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K180D110FInit"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K180D25FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 6][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 6][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K180D25FFinal"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K180D40FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 7][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 7][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K180D40FFinal"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K180D75FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 8][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 8][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K180D75FFinal"].ToString();
                if (_objectsService.RNDHome.dtF.Rows[i]["K180D110FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 9][i + 1] = string.Empty; else _objectsService.RNDTDRV.dtTdrvE.Rows[ir + 9][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["K180D110FFinal"].ToString();

                if (_objectsService.RNDHome.dtF.Rows[i]["R180D25FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 1][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 1][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R180D25FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R180D40FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 2][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 2][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R180D40FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R180D75FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 3][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 3][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R180D75FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R180D110FInit"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 4][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 4][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R180D110FInit"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R180D25FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 6][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 6][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R180D25FFinal"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R180D40FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 7][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 7][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R180D40FFinal"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R180D75FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 8][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 8][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R180D75FFinal"]).ToString("0.000");
                if (_objectsService.RNDHome.dtF.Rows[i]["R180D110FFinal"] == DBNull.Value) _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 9][i] = string.Empty; else _objectsService.RNDTDRV.dtTdrvC.Rows[ir + 9][i] = ((double)_objectsService.RNDHome.dtF.Rows[i]["R180D110FFinal"]).ToString("0.000");

            }
            if (_objectsService.RNDHome.drS["AgedTestingComplete"] == DBNull.Value) gAgedTestingCompIsChecked = false; else gAgedTestingCompIsChecked = (bool)_objectsService.RNDHome.drS["AgedTestingComplete"];




            SetView();
        }
        public void SetView()
        {
            gExpPropsE = _objectsService.RNDTDRV.dtTdrvE.DefaultView;
            gExpPropsC = _objectsService.RNDTDRV.dtTdrvC.DefaultView;
            gExpPropsP = _objectsService.RNDTDRV.dtTdrvP.DefaultView;
        }
        public IActionResult OnPostGAgedTestingCompLF(bool value)
        {
            //if (gAgedTestingCompIsChecked == null) _objectsService.RNDHome.drS["AgedTestingComplete"] = DBNull.Value;
            if (value == true) _objectsService.RNDHome.drS["AgedTestingComplete"] = true; else _objectsService.RNDHome.drS["AgedTestingComplete"] = false;
            _objectsService.RNDHome.UpdateDataSet();
            return new JsonResult(value);
        }

        public IActionResult OnPostOngExpPropsE(string rowId, string colId, string text)
        {
            string sMsg;
            string[] sFieldsK = { "", "", "K10D25FInit", "K10D40FInit", "K10D75FInit", "K10D110FInit", "", "K10D25FFinal", "K10D40FFinal", "K10D75FFinal", "K10D110FFinal", "", "", "", "K90D25FInit", "K90D40FInit", "K90D75FInit", "K90D110FInit", "", "K90D25FFinal", "K90D40FFinal", "K90D75FFinal", "K90D110FFinal", "", "", "", "K180D25FInit", "K180D40FInit", "K180D75FInit", "K180D110FInit", "", "K180D25FFinal", "K180D40FFinal", "K180D75FFinal", "K180D110FFinal" };
            string[] sFieldsR = { "", "", "R10D25FInit", "R10D40FInit", "R10D75FInit", "R10D110FInit", "", "R10D25FFinal", "R10D40FFinal", "R10D75FFinal", "R10D110FFinal", "", "", "", "R90D25FInit", "R90D40FInit", "R90D75FInit", "R90D110FInit", "", "R90D25FFinal", "R90D40FFinal", "R90D75FFinal", "R90D110FFinal", "", "", "", "R180D25FInit", "R180D40FInit", "R180D75FInit", "R180D110FInit", "", "R180D25FFinal", "R180D40FFinal", "R180D75FFinal", "R180D110FFinal" };

            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);
            bool bd = false;
            int icol1 = icol - 1;

            double dtemp;


            if (icol == 0) return new JsonResult(true);
            if (irow > 34) return new JsonResult(true);

            //DataGridRow dgr = e.Row;
            string tb = text;

                       // bd = double.TryParse(tb.Text, out dtemp);
                       // if (!bd) tb.Text = String.Empty;
                       //     _objectsService.RNDRawProps.dtDensityE.Rows[irow][icol] = dtemp;

                       //switch (irow)
                       //{
                       //    case 0: tb.Text = String.Empty; break;
                       //    case 1: tb.Text = String.Empty; break;

                       //    case 2:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D25FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R10D25FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D25FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D25FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K10D25FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D25FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 3:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D40FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R10D40FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D40FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D40FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K10D40FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D40FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 4:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D75FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R10D75FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D75FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D75FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K10D75FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D75FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 5:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D110FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R10D110FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D110FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D110FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K10D110FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D110FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 6: tb.Text = String.Empty; break;

                       //    case 7:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D25FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R10D25FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D25FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D25FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K10D25FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D25FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 8:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D40FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R10D40FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D40FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D40FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K10D40FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D40FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 9:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D75FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R10D75FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D75FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D75FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K10D75FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D75FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 10:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D110FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R10D110FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K10D110FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D110FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K10D110FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R10D110FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 11: tb.Text = String.Empty; break;
                       //    case 12: tb.Text = String.Empty; break;
                       //    case 13: tb.Text = String.Empty; break;

                       //    case 14:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D25FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R90D25FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D25FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D25FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K90D25FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D25FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 15:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D40FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R90D40FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D40FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D40FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K90D40FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D40FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 16:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D75FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R90D75FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D75FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D75FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K90D75FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D75FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 17:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D110FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R90D110FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D110FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D110FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K90D110FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D110FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 18: tb.Text = String.Empty; break;

                       //    case 19:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D25FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R90D25FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D25FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D25FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K90D25FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D25FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 20:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D40FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R90D40FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D40FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D40FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K90D40FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D40FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 21:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D75FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R90D75FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D75FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D75FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K90D75FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D75FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 22:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D110FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R90D110FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K90D110FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D110FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K90D110FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R90D110FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 23: tb.Text = String.Empty; break;
                       //    case 24: tb.Text = String.Empty; break;
                       //    case 25: tb.Text = String.Empty; break;

                       //    case 26:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D25FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R180D25FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D25FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D25FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K180D25FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D25FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 27:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D40FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R180D40FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D40FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D40FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K180D40FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D40FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 28:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D75FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R180D75FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D75FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D75FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K180D75FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D75FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 29:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D110FInit"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R180D110FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D110FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D110FInit"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K180D110FInit"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D110FInit"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 30: tb.Text = String.Empty; break;

                       //    case 31:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D25FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R180D25FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D25FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D25FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K180D25FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D25FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 32:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D40FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R180D40FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D40FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D40FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K180D40FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D40FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 33:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D75FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R180D75FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D75FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D75FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K180D75FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D75FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 34:
                       //        if (!bd) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D110FFinal"] = DBNull.Value; _objectsService.RNDHome.dtF.Rows[icol1]["R180D110FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = String.Empty; }
                       //        else if (dtemp > 0) { _objectsService.RNDHome.dtF.Rows[icol1]["K180D110FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D110FFinal"] = 1 / dtemp; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtemp).ToString("0.###"); }
                       //        else { _objectsService.RNDHome.dtF.Rows[icol1]["K180D110FFinal"] = dtemp; _objectsService.RNDHome.dtF.Rows[icol1]["R180D110FFinal"] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; }
                       //        break;

                       //    case 35: tb.Text = String.Empty; break;

                       //}
            
            bool bGet = false;
            if (irow > 1 && irow < 6) bGet = true;
            else if (irow > 6 && irow < 11) bGet = true;
            else if (irow > 13 && irow < 18) bGet = true;
            else if (irow > 18 && irow < 23) bGet = true;
            else if (irow > 25 && irow < 30) bGet = true;
            else if (irow > 30 && irow < 35) bGet = true;
            else { tb = string.Empty; return new JsonResult(true); }

            GetTDRVValues(sFieldsK, irow, icol1, tb, sFieldsR);
            _objectsService.RNDHome.UpdateFormulatiions();
            return new JsonResult(true);
        }

        public bool GetTDRVValues(string[] sFields, int irow, int icol1, string tb, string[] sFieldsR)
        {
            string stmp, stmp0;
            double dtmp;
            bool b = false;

            string sField = sFields[irow];
            string sFieldR = sFieldsR[irow];

            if (_objectsService.RNDHome.dtF.Rows[icol1][sField] == DBNull.Value) stmp0 = string.Empty;
            else if ((double)_objectsService.RNDHome.dtF.Rows[icol1][sField] > 0) stmp0 = ((double)_objectsService.RNDHome.dtF.Rows[icol1][sField]).ToString("0.####");
            else stmp0 = string.Empty;

            if (tb == string.Empty) { _objectsService.RNDHome.dtF.Rows[icol1][sFieldR] = _objectsService.RNDHome.dtF.Rows[icol1][sField] = DBNull.Value; _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = string.Empty; b = true; }
            else if (double.TryParse(tb, out dtmp))
            {
                if (dtmp > 0)
                {
                    _objectsService.RNDHome.dtF.Rows[icol1][sField] = dtmp; b = true;
                    _objectsService.RNDHome.dtF.Rows[icol1][sFieldR] = 1.0 / dtmp;
                    _objectsService.RNDTDRV.dtTdrvC.Rows[irow][icol1] = (1 / dtmp).ToString("0.###");

                }
                else b = false;
            }
            else b = false;

            if (!b) { 
               // MessageBox.Show("Improper Value. New Value is not accepted."); 
                tb = stmp0; }

            //           MessageBox.Show(sField + "\n" + sFieldR);
            return true;
        }


    }
}
