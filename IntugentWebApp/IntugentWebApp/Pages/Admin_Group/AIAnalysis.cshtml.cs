using Google.Api.Gax;
using Google.Apis.Bigquery.v2.Data;
using IntugentClassLbrary.Classes;
using IntugentClassLibrary.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using IntugentWebApp.Utilities;
using System.Data;

namespace IntugentWebApp.Pages.Admin_Group
{
    public class AIAnalysisModel : PageModel
    {
        public double[] x;
        public double[] xx;
        public double[] yy;
        public string gStudyName {  get; set; }
        public string gDataFile {  get; set; }
        public string gSQL {  get; set; }
        public string gGroup {  get; set; }
        public string gProperty {  get; set; }
        public string gSource {  get; set; }
        public string gID {  get; set; }
        public int gInputIndex;
        public DataTable gData {  get; set; }
        public DataTable gStat {  get; set; }
        public List<string> gInputVar = new List<string>();
        public int gInputVarSelectedIndex {  get; set; }
        public string gChartLeftTitle { get; set; }

        public CNNModel nnModel ;

        public ObjectsService _objectsService;
        public AIAnalysisModel(ObjectsService objectsService)
        {
            _objectsService= objectsService;
            //nnModel = _objectsService.CNNModel;
            nnModel = _objectsService.CNNData.GetModelData();
        }
        public void OnGet()
        {

            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
            if (_objectsService.CDBase.dr["sNote"] == DBNull.Value) gStudyName = string.Empty; else gStudyName = (string)_objectsService.CDBase.dr["sNote"];
            if (_objectsService.CDBase.dr["sFilePath"] == DBNull.Value) gDataFile = string.Empty; else gDataFile = (string)_objectsService.CDBase.dr["sFilePath"];
            if (_objectsService.CDBase.dr["sSQL"] == DBNull.Value) gSQL = string.Empty; else gSQL = (string)_objectsService.CDBase.dr["sSQL"];
            if (_objectsService.CDBase.dr["sGroup"] == DBNull.Value) gGroup = string.Empty; else gGroup = (string)_objectsService.CDBase.dr["sGroup"];
            if (_objectsService.CDBase.dr["sProperty"] == DBNull.Value) gProperty = string.Empty; else gProperty = (string)_objectsService.CDBase.dr["sProperty"];
            if (_objectsService.CDBase.dr["sDataSource"] == DBNull.Value) gSource = string.Empty; else gSource = (string)_objectsService.CDBase.dr["sDataSource"];
            if (_objectsService.CDBase.dr["ID"] == DBNull.Value) gID = string.Empty; else gID = _objectsService.CDBase.dr["ID"].ToString();


            /*           if (_objectsService.CNNData.nInputNeurons < 1 || _objectsService.CNNData.nDataPts < 1) return;
                       else
            */
            DisplayData();
        }


        public void SetView()
        {
            try
            {

                _objectsService.CNNData.ReadData(_objectsService.CDBase);
                gData = _objectsService.CNNData.dt; // dt.DefaultView;

                xx = new double[_objectsService.CNNData.nDataPts];
                yy = new double[_objectsService.CNNData.nDataPts];
                double dYmin = nnModel.YMin;

                double dYdelta = nnModel.YMax - nnModel.YMin;
                if (dYdelta == 0) dYdelta = dYmin;

                double dXmin = nnModel.XMin[gInputVarSelectedIndex];
                double dXdelta = nnModel.XMax[gInputVarSelectedIndex] - dXmin;
                if (dXdelta == 0) dXdelta = dXmin;

                for (int i = 0; i < _objectsService.CNNData.nDataPts; i++)
                {
                    if (x != null)
                    {

                        xx[i] = x[i] * dXdelta + dXmin;
                    }
                    yy[i] = _objectsService.CNNData.Output[i] * dYdelta + dYmin;
                }
                //circles.Plot(xx, yy);
            }
            catch (Exception ex) { 
            }

        }

        public IActionResult OnPostGUploadData()
        {
            _objectsService.CNNData.ReadData(_objectsService.CDBase);
            //           _objectsService.CNNData.Correlation();
            DisplayData();
              nnModel.nInputNeurons = _objectsService.CNNData.nInputNeurons;
            //_objectsService.AIModel.SaveModel();
            return new JsonResult(true);
        }


        public void DisplayData()
        {
            string sMsg;
            string sForm = "0.000";

            //           ReadData();

            //            _objectsService.CNNData.Correlation();

            /*            if (dtXCorr != null) dtXCorr.Columns.Clear(); 
                        if (dt != null) dt.Columns.Clear();


                        dt.Columns.Add("#", typeof(string)); dt.Columns.Add(_objectsService.CNNData.sOutputName, typeof(string));
                        for (int i = 0; i < _objectsService.CNNData.nInputNeurons; i++) dt.Columns.Add(_objectsService.CNNData.sInputNames[i], typeof(string));

                        //            dt.Columns.Add("X", typeof(string));
            */
            //gData.Columns.Clear();
            //gData.Columns.Add(new DataGridTextColumn()); DataGridTextColumn dc = (DataGridTextColumn)gData.Columns[0]; dc.Width = 50; dc.Binding = new Binding("#"); dc.Header = "#";

            //for (int i = 0; i < _objectsService.CNNData.nInputNeurons; i++)
            //{
            //    gData.Columns.Add(new DataGridTextColumn()); dc = (DataGridTextColumn)gData.Columns[i + 1]; dc.Width = 85; dc.Binding = new Binding(_objectsService.CNNData.sInputNames[i]); dc.Header = _objectsService.CNNData.sInputNames[i]; dc.Binding.StringFormat = sForm;

            //}
            //gData.Columns.Add(new DataGridTextColumn()); dc = (DataGridTextColumn)gData.Columns[_objectsService.CNNData.nInputNeurons + 1]; dc.Width = 75; dc.Binding = new Binding(_objectsService.CNNData.sOutputName); dc.Header = _objectsService.CNNData.sOutputName; dc.Binding.StringFormat = sForm;

            /*
                        double dYMin = _objectsService.AIModel.nnModel.YMin;
                        double dYdel = _objectsService.AIModel.nnModel.YMax - dYMin;
                        if (dYdel == 0) dYdel = dYMin;
                        for (int i = 0; i < _objectsService.CNNData.nDataPts; i++)
                        {
                            dt.Rows.Add();
                            dt.Rows[i][0] = i.ToString();
                            dt.Rows[i][1] = (_objectsService.CNNData.Output[i]*dYdel+dYMin).ToString(sForm);
                            for (int j = 0; j < _objectsService.CNNData.nInputNeurons; j++) dt.Rows[i][j + 2] = _objectsService.CNNData.data[i, j].ToString(sForm);
                        }
            */
            gData = _objectsService.CNNData.dt; // dt.DefaultView;

            /*           dtXCorr.Columns.Add("Variable", typeof(string)); dtXCorr.Columns.Add("Average", typeof(string));
                       dtXCorr.Columns.Add("StdDev", typeof(string)); dtXCorr.Columns.Add("Correlation", typeof(string));

                       dtXCorr.Rows.Add(); dtXCorr.Rows[0]["Variable"] = _objectsService.CNNData.sOutputName; dtXCorr.Rows[0]["Average"] = _objectsService.CNNData.OutputAvg.ToString(sForm);
                       dtXCorr.Rows[0]["StdDev"] = _objectsService.CNNData.OutputSD.ToString(sForm); dtXCorr.Rows[0]["Correlation"] = "1.000";

                       for (int i = 0; i < _objectsService.CNNData.nInputNeurons; i++)
                       {
                           dtXCorr.Rows.Add(); dtXCorr.Rows[i + 1]["Variable"] = _objectsService.CNNData.sInputNames[i]; dtXCorr.Rows[i + 1]["Average"] = _objectsService.CNNData.InputAvg[i].ToString(sForm);
                           dtXCorr.Rows[i + 1]["StdDev"] = _objectsService.CNNData.InputSD[i].ToString(sForm); dtXCorr.Rows[i + 1]["Correlation"] = _objectsService.CNNData.InOutCorr[i].ToString(sForm);
                       }
            */
            if (_objectsService.CNNData.dtXCorr != null)
            {

            gStat = _objectsService.CNNData.dtXCorr;
            }


            gInputVar.Clear();
            if (_objectsService.CNNData.data != null)
            {

            x = _objectsService.cMatrix.GetColumn2D(_objectsService.CNNData.data, _objectsService.gInputIndex);
            gInputVar = _objectsService.CNNData.sInputNames.ToList(); gInputVarSelectedIndex = _objectsService.gInputIndex;
            }

            gChartLeftTitle = _objectsService.CNNData.sOutputName;
            SetView();
        }


        public IActionResult OnPostGenInfo_LF(string Name,string Value)
        {
            string sFld = String.Empty, sMsg, sdum; ;
            //           TextBox tbx = sender as TextBox;
            //           string sText = tbx ;
            string sName = Name;

            switch (sName)
            {
                case "gStudyName": if (gStudyName  == string.Empty) _objectsService.CDBase.dr["sNote"] = DBNull.Value; else _objectsService.CDBase.dr["sNote"] = Value; break;
                case "gDataFile": if (gDataFile  == string.Empty) _objectsService.CDBase.dr["sFilePath"] = DBNull.Value; else _objectsService.CDBase.dr["sFilePath"] = Value; break;
                case "gSQL": if (gSQL  == string.Empty) _objectsService.CDBase.dr["sSQL"] = DBNull.Value; else _objectsService.CDBase.dr["sSQL"] = Value; break;
                case "gGroup": if (gGroup  == string.Empty) _objectsService.CDBase.dr["sGroup"] = DBNull.Value; else _objectsService.CDBase.dr["sGroup"] = Value; break;
                case "gProperty": if (gProperty  == string.Empty) _objectsService.CDBase.dr["sProperty"] = DBNull.Value; else _objectsService.CDBase.dr["sProperty"] = Value; break;
                case "gSource": if (gSource  == string.Empty) _objectsService.CDBase.dr["sDataSource"] = DBNull.Value; else _objectsService.CDBase.dr["sDataSource"] = Value; break;
            }
            _objectsService.CDBase.UpdateModel();
            return new JsonResult(true);
        }

        public IActionResult OnPostBrowseFile(string filePath)
        {
            string sFile; string sForm = "0.000";
            //OpenFileDialog openFileDialog1 = new OpenFileDialog
            //{
            //    Title = "Open Data File .csv file ",
            //    Filter = "Tab delimited Files (*.txt)|*.txt|Comma delimited Files (*.csv)|*.csv"
            //};

            //if (openFileDialog1.ShowDialog() == false) return new JsonResult(false);

            //sFile = openFileDialog1.FileName;
            sFile = filePath;

            //if (!File.Exists(sFile))
            //{
            //    // MessageBox.Show("Could not find the data file " + sFile, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Error);
            //    return new JsonResult(false);
            //}
            gDataFile  = sFile;
            _objectsService.CDBase.dr["sFilePath"] = sFile;
            _objectsService.CDBase.UpdateModel();
            return new JsonResult(true);
        }

        public IActionResult OnPostGInputVar_Change(string Value)
        {
            gInputVarSelectedIndex = Int32.Parse(Value);
            if (gInputVarSelectedIndex < 0) return new JsonResult(false);
            x = _objectsService.cMatrix.GetColumn2D(_objectsService.CNNData.data, gInputVarSelectedIndex);

            SetView();
            _objectsService.gInputIndex = gInputVarSelectedIndex;
            return new JsonResult(_objectsService.gInputIndex) ;
            //SetgChartAxes();

        } 
        //private void PrevDClick(object sender, MouseButtonEventArgs e)
        //{
        //    SetgChartAxes();
        //    //           e.Handled = true;

        //}
        //public void SetgChartAxes()
        //{
        //    gChart.PlotOriginY = CPages.PageModel_1.nnModel.YMin - 0.05 * (CPages.PageModel_1.nnModel.YMax - CPages.PageModel_1.nnModel.YMin);
        //    gChart.PlotHeight = 1.1 * (CPages.PageModel_1.nnModel.YMax - CPages.PageModel_1.nnModel.YMin);

        //    int ind = gInputVarSelectedIndex;
        //    if (ind < 0) return;
        //    double dmin = CPages.PageModel_1.nnModel.XMin[ind];
        //    double dmax = CPages.PageModel_1.nnModel.XMax[ind];
        //    gChart.PlotOriginX = dmin - 0.05 * (dmax - dmin);
        //    gChart.PlotWidth = 1.1 * (dmax - dmin);
        //}
    }
}
