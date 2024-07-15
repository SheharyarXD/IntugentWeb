using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Data;
using IntugentWebApp.Utilities;
using IntugentClassLbrary.Classes;
using Google.Api.Gax;

namespace IntugentWebApp.Pages.RnD_Users
{
    public class RNDPropertiesDatafileModel : PageModel
    {
        public DataView gReacE { get; set; }
        public DataView gReacC{ get; set; }
        public DataView gPhotoE{get;set;}
        public DataView gPhotoC{get;set;}
        public DataView gPropsE{get;set;}
        public DataView gPropsC{get;set;}
        public DataView gDataFiles{get;set;}
        public DataView gProd{get;set;}
        public int gProdSelectedValue{get;set; }
        public DataView gNotes{get;set;}
        public List<string> gProdList{get;set; }
        private ObjectsService _objectsService { get; set; }
        public bool gPropTestingCompIsChecked {  get; set; }
        public RNDPropertiesDatafileModel(ObjectsService objectsService)
        {
            _objectsService = objectsService;
        }
        public void OnGet()
        {
            gProdList = PopulateListFromDataView(_objectsService.CLists.dvComProd);
            for (int i = 0; i < 8; i++)
                {
                    if (_objectsService.RNDHome.dtF.Rows[i]["ReactMixingTime"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[0][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[0][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["ReactMixingTime"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["React15PTime"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[1][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[1][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["React15PTime"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["React50PTime"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[2][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[2][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["React50PTime"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["React80PTime"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[3][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[3][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["React80PTime"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["ReactCupEdgeTime"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[4][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[4][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["ReactCupEdgeTime"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["React98PTime"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[5][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[5][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["React98PTime"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["ReactMaxTempTime"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[6][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[6][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["ReactMaxTempTime"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["ReactMaxTemp"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[7][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[7][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["ReactMaxTemp"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["ReactMaxHeight"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[8][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[8][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["ReactMaxHeight"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["ReactSampleMass"] == DBNull.Value) _objectsService.RNDProperties.dtReacE.Rows[9][i + 1] = string.Empty; else _objectsService.RNDProperties.dtReacE.Rows[9][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["ReactSampleMass"].ToString();

                    if (_objectsService.RNDHome.dtF.Rows[i]["PhotoPirPur"] == DBNull.Value) _objectsService.RNDProperties.dtPhotoE.Rows[0][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPhotoE.Rows[0][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["PhotoPirPur"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["PhotoIso"] == DBNull.Value) _objectsService.RNDProperties.dtPhotoE.Rows[1][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPhotoE.Rows[1][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["PhotoIso"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["PhotoCarbo"] == DBNull.Value) _objectsService.RNDProperties.dtPhotoE.Rows[2][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPhotoE.Rows[2][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["PhotoCarbo"].ToString();
                    if (_objectsService.RNDHome.dtF.Rows[i]["PhotoTrimer"] == DBNull.Value) _objectsService.RNDProperties.dtPhotoE.Rows[3][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPhotoE.Rows[3][i + 1] = _objectsService.RNDHome.dtF.Rows[i]["PhotoTrimer"].ToString();

                    if (_objectsService.RNDHome.dtF.Rows[i]["CompStr"] == DBNull.Value) _objectsService.RNDProperties.dtPropsE.Rows[1][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPropsE.Rows[1][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["CompStr"]).ToString("0.000");
                    if (_objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer"] == DBNull.Value) _objectsService.RNDProperties.dtPropsE.Rows[2][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPropsE.Rows[2][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["ClosedCellPer"]).ToString("0.000");
                    if (_objectsService.RNDHome.dtF.Rows[i]["CellDia"] == DBNull.Value) _objectsService.RNDProperties.dtPropsE.Rows[3][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPropsE.Rows[3][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["CellDia"]).ToString("0");
                    if (_objectsService.RNDHome.dtF.Rows[i]["CellCount"] == DBNull.Value) _objectsService.RNDProperties.dtPropsE.Rows[4][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPropsE.Rows[4][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["CellCount"]).ToString("0");
                    if (_objectsService.RNDHome.dtF.Rows[i]["CellDiaIsotropy"] == DBNull.Value) _objectsService.RNDProperties.dtPropsE.Rows[5][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPropsE.Rows[5][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["CellDiaIsotropy"]).ToString("0.000");
                    if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateRetainMass"] == DBNull.Value) _objectsService.RNDProperties.dtPropsE.Rows[8][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPropsE.Rows[8][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["HotPlateRetainMass"]).ToString("0.000");
                    if (_objectsService.RNDHome.dtF.Rows[i]["HotPlateRetainThick"] == DBNull.Value) _objectsService.RNDProperties.dtPropsE.Rows[9][i + 1] = string.Empty; else _objectsService.RNDProperties.dtPropsE.Rows[9][i + 1] = ((double)_objectsService.RNDHome.dtF.Rows[i]["HotPlateRetainThick"]).ToString("0.000");

                    if (_objectsService.RNDHome.dtF.Rows[i]["sFileFTIR"] == DBNull.Value) _objectsService.RNDProperties.dtDataFiles.Rows[0][i + 1] = string.Empty; else _objectsService.RNDProperties.dtDataFiles.Rows[0][i + 1] = (string)_objectsService.RNDHome.dtF.Rows[i]["sFileFTIR"];
                    if (_objectsService.RNDHome.dtF.Rows[i]["sFileTGA"] == DBNull.Value) _objectsService.RNDProperties.dtDataFiles.Rows[1][i + 1] = string.Empty; else _objectsService.RNDProperties.dtDataFiles.Rows[1][i + 1] = (string)_objectsService.RNDHome.dtF.Rows[i]["sFileTGA"];
                    if (_objectsService.RNDHome.dtF.Rows[i]["sFileFoamat"] == DBNull.Value) _objectsService.RNDProperties.dtDataFiles.Rows[2][i + 1] = string.Empty; else _objectsService.RNDProperties.dtDataFiles.Rows[2][i + 1] = (string)_objectsService.RNDHome.dtF.Rows[i]["sFileFoamat"];

                    if (_objectsService.RNDHome.dtF.Rows[i]["Product Code"] == DBNull.Value) _objectsService.RNDProperties.dtComProd.Rows[i][1] = string.Empty; else _objectsService.RNDProperties.dtComProd.Rows[i][1] = (string)_objectsService.RNDHome.dtF.Rows[i]["Product Code"];
                    if (_objectsService.RNDHome.dtF.Rows[i]["sNote"] == DBNull.Value) _objectsService.RNDProperties.dtNotes.Rows[i][1] = string.Empty; else _objectsService.RNDProperties.dtNotes.Rows[i][1] = (string)_objectsService.RNDHome.dtF.Rows[i]["sNote"];

                }
                if (_objectsService.RNDHome.drS["PropTestingComplete"] == DBNull.Value) gPropTestingCompIsChecked = false; else gPropTestingCompIsChecked = (bool)_objectsService.RNDHome.drS["PropTestingComplete"];

                SetView();
    
        }
        public List<string> PopulateListFromDataView(DataView dvComProd)
        {
            List<string> gProdList = new List<string>();

            foreach (DataRowView rowView in dvComProd)
            {
                // Extract "Product Code" from DataRowView and add to the list
                // Replace "Product Code" with your actual column name
                string productCode = rowView["Product Code"].ToString();

                gProdList.Add(productCode);
            }

            return gProdList;
        }
        public void SetView()
        {
            PropPredictions();
            gReacE     = _objectsService.RNDProperties.dtReacE.DefaultView;
            gReacC     = _objectsService.RNDProperties.dtReacC.DefaultView;
            gPhotoE    = _objectsService.RNDProperties.dtPhotoE.DefaultView;
            gPhotoC    = _objectsService.RNDProperties.dtPhotoC.DefaultView;
            gPropsE    = _objectsService.RNDProperties.dtPropsE.DefaultView;
            gPropsC    = _objectsService.RNDProperties.dtPropsC.DefaultView;
            gDataFiles = _objectsService.RNDProperties.dtDataFiles.DefaultView;
            gProd      = _objectsService.RNDProperties.dtComProd.DefaultView;
            gNotes     = _objectsService.RNDProperties.dtNotes.DefaultView;

        }
        public void GetPropList()
        {

        }

        public void PropPredictions()
        {

        }



        //private void gDataFile_Edit(object sender, DataGridBeginningEditEventArgs e)
        //{

        //    gDataFiles.Row = e.Row.GetIndex();
        //    gDataFiles.Col = e.Column.DisplayIndex;
        //}

        public IActionResult OnPostGReacE(string rowId, string colId, string text)
        {
            string sMsg;
            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);
            bool bd = false;
            int icol1 = icol - 1;
            string[] sFields = { "ReactMixingTime", "React15PTime", "React50PTime", "React80PTime", "ReactCupEdgeTime", "React98PTime", "ReactMaxTempTime", "ReactMaxTemp", "ReactMaxHeight", "ReactSampleMass" };
            string sField, stmp0;

            double dtmp, dtmp0;

            //DataGridRow dgr = e.Row;

            if (icol == 0) return null;
            if (irow > 9) return null;

            sField = sFields[irow];
            if (_objectsService.RNDHome.dtF.Rows[icol1][sField] == DBNull.Value) stmp0 = string.Empty;
            else if ((double)_objectsService.RNDHome.dtF.Rows[icol1][sField] > 0) stmp0 = ((double)_objectsService.RNDHome.dtF.Rows[icol1][sField]).ToString("0.####");
            else stmp0 = string.Empty;

            //TextBox tb = gReacE.Columns[icol].GetCellContent(dgr) as TextBox;
            string tb = text;
            if (tb == string.Empty) _objectsService.RNDHome.dtF.Rows[icol1][sField] = DBNull.Value;
            else if (double.TryParse(tb, out dtmp)) _objectsService.RNDHome.dtF.Rows[icol1][sField] = dtmp;
            else {
                //MessageBox.Show("Improper Value. New Value is not accepted.");
                tb = stmp0; }
            //                dtDensityE.Rows[irow][icol] = dtemp;

            _objectsService.RNDHome.UpdateFormulatiions();
            return new JsonResult(true);
        }

        public IActionResult OnPostOngPhotoE(string rowId, string colId, string text)
        {
            string sMsg;
            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);
            bool bd = false;
            int icol1 = icol - 1;
            string[] sFields = { "PhotoPirPur", "PhotoIso", "PhotoCarbo", "PhotoTrimer" };
            string sField, stmp0;
            double dtmp, dtmp0;

            //DataGridRow dgr = e.Row;

            if (icol == 0) return new JsonResult(true);
            if (irow > 3) return new JsonResult(true);

            sField = sFields[irow];
            if (_objectsService.RNDHome.dtF.Rows[icol1][sField] == DBNull.Value) stmp0 = string.Empty;
            else if ((double)_objectsService.RNDHome.dtF.Rows[icol1][sField] > 0) stmp0 = ((double)_objectsService.RNDHome.dtF.Rows[icol1][sField]).ToString("0.####");
            else stmp0 = string.Empty;

            //TextBox tb = gPhotoE.Columns[icol].GetCellContent(dgr) as TextBox;
            string tb = text;
            if (tb == string.Empty) _objectsService.RNDHome.dtF.Rows[icol1][sField] = DBNull.Value;
            else if (double.TryParse(tb, out dtmp)) _objectsService.RNDHome.dtF.Rows[icol1][sField] = dtmp;
            else { 
              //  MessageBox.Show("Improper Value. New Value is not accepted.");
                tb = stmp0; }

            _objectsService.RNDHome.UpdateFormulatiions();
            return new JsonResult(true);
        }

        //public IActionResult OnPostgDataFile_DblClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{

        //    string sdum, strMsg, sFile;
        //    double dval, dT1, dT2, dTi;



        //    //            MessageBox.Show(irow.ToString() + "    " + icol.ToString());

        //    if (gDataFileCol == 0) return new JsonResult(true);
        //    if (gDataFileRow < 0 || gDataFileRow > 2) return new JsonResult(true);

        //    sFile = _objectsService.RNDProperties.dtDataFiles.Rows[gDataFileRow][gDataFileCol].ToString();

        //    OpenFileDialog openFileDialog1 = new OpenFileDialog
        //    {
        //        Title = "Intugent PolyIso - Specifiy Data File ",
        //        Filter = "All Files (*.*)|*.*|Text Files (*.csv; *.txt) |*.csv;*.txt|Excel FIles (*.xl*)|*.xl*",
        //        FileName = sFile
        //    };

        //    openFileDialog1.InitialDirectory = Path.GetDirectoryName(sFile);

        //    if (openFileDialog1.ShowDialog() == false) return new JsonResult(true);

        //    sFile = openFileDialog1.FileName;


        //    if (!File.Exists(sFile))
        //    {
        //        //  MessageBox.Show("Could not find the data file " + sFile, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Error);
        //        return new JsonResult(true);
        //    }

        //    _objectsService.RNDProperties.dtDataFiles.Rows[gDataFileRow]["sFile" + (gDataFileCol).ToString()] = sFile;
        //    gDataFiles = _objectsService.RNDProperties.dtDataFiles.DefaultView;

        //    switch (gDataFileRow)
        //    {
        //        case 0: _objectsService.RNDHome.dtF.Rows[gDataFileCol - 1]["sFileFTIR"] = sFile; break;
        //        case 1: _objectsService.RNDHome.dtF.Rows[gDataFileCol - 1]["sFileTGA"] = sFile; break;
        //        case 2: _objectsService.RNDHome.dtF.Rows[gDataFileCol - 1]["sFileFoamat"] = sFile; break;
        //    }
        //    _objectsService.RNDHome.UpdateFormulatiions();
        //    return new JsonResult(true);
        //}

        public IActionResult OnPostOngDataFiles(string rowId, string colId, string text)
        {
            string sMsg;
            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);
            bool bd = false;
            int icol1 = icol - 1;

            double dtemp;

            //DataGridRow dgr = e.Row;

            if (icol == 0) return new JsonResult(true);
            if (irow > 9) return new JsonResult(true);

            //TextBox tb = gPhotoE.Columns[icol].GetCellContent(dgr) as TextBox;
            string tb = text;
            //                dtDensityE.Rows[irow][icol] = dtemp;

            switch (irow)
            {
                case 0: if (tb == string.Empty) _objectsService.RNDHome.dtF.Rows[icol1]["sFileFTIR"] = DBNull.Value; else _objectsService.RNDHome.dtF.Rows[icol1]["sFileFTIR"] = tb; break;
                case 1: if (tb == string.Empty) _objectsService.RNDHome.dtF.Rows[icol1]["sFileTGA"] = DBNull.Value; else _objectsService.RNDHome.dtF.Rows[icol1]["sFileTGA"] = tb; break;
                case 2: if (tb == string.Empty) _objectsService.RNDHome.dtF.Rows[icol1]["sFileFoamat"] = DBNull.Value; else _objectsService.RNDHome.dtF.Rows[icol1]["sFileFoamat"] = tb; break;

            }

            _objectsService.RNDHome.UpdateFormulatiions();
            return new JsonResult(true);
        }

        public IActionResult OnPostOngNotes(string rowId, string colId, string text)
        {
            string sMsg;
            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);

            int iSel;
            double dtemp;

            //DataGridRow dgr = e.Row;

            if (irow > 9) return new JsonResult(true);
            if (icol == 0) return new JsonResult(true);
            if (icol == 1)
            {
                //TextBox tb = gPhotoE.Columns[icol].GetCellContent(dgr) as TextBox;
                string tb = text;
                if (tb == null) _objectsService.RNDHome.dtF.Rows[irow]["sNote"] = DBNull.Value;
                else if (tb.Length > 255) _objectsService.RNDHome.dtF.Rows[irow]["sNote"] = tb.Substring(0, 255);
                else _objectsService.RNDHome.dtF.Rows[irow]["sNote"] = tb;
            }
            _objectsService.RNDHome.UpdateFormulatiions();
            return new JsonResult(true);
        }

        public IActionResult OnPostGPropTestingCompLF(bool value)
        {
            //if (gPropTestingCompIsChecked == null) _objectsService.RNDHome.drS["PropTestingComplete"] = DBNull.Value;
             if (value == true) _objectsService.RNDHome.drS["PropTestingComplete"] = true; else _objectsService.RNDHome.drS["PropTestingComplete"] = false;
            _objectsService.RNDHome.UpdateDataSet();
            return new JsonResult(true);
        }

        public IActionResult OnPostGProd(string rowId, string colId, string text)
        {
            string sMsg;
            int irow = Int32.Parse(rowId);
            int icol = Int32.Parse(colId);

            int iSel;
            double dtemp;

            //DataGridRow dgr = e.Row;

            if (icol == 0) return new JsonResult(true);
            if (icol == 1)
            {
                //ComboBox cmb = gProd.Columns[1].GetCellContent(dgr) as ComboBox;
                if (text == null) _objectsService.RNDHome.dtF.Rows[irow]["Product Code"] = DBNull.Value; else _objectsService.RNDHome.dtF.Rows[irow]["Product Code"] = text.ToString();
            }
            _objectsService.RNDHome.UpdateFormulatiions();
            return new JsonResult(true);
        }

    }
}
