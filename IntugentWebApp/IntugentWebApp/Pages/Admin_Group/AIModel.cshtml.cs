using Google.Apis.Bigquery.v2.Data;
using IntugentClassLbrary.Classes;
using IntugentClassLibrary.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Text;
using IntugentWebApp.Utilities;
using System.Data;

namespace IntugentWebApp.Pages.Admin_Group
{
    public class AIModelModel : PageModel
    {
        private ObjectsService _objectsService;

        public string gMaxIter {  get; set; }
        public string gConvTol { get; set; }
        public string gLearnRate { get; set; }
        public string gStepSizeMin { get; set; }
        public string gnHiddenLayers { get; set; }
        public string gHLayerType { get; set; }
        public string gRMS {  get; set; }
        public string gInputNeurons { get; set; }
        public string gOutputNeurons { get; set; }
        public DataView gHNeurons { get; set;}
        public DataTable gWeights = new DataTable();
        public int gLayerSelectedIndex {  get; set; }
        public List<string> gLayer = new List<string>();

       public double[] yy { get; set; }
       public double[] yyp { get; set; }
        public double[] yth { get; set; }
        public string gChartBottomTitle {  get; set; }
        public string gChartLeftTitle {  get; set; }
        public CNNModel nnModel;
        public AIModelModel(ObjectsService objectsService) { 
        
            _objectsService = objectsService;
        
        }
        public void OnGet()
        {
            if (_objectsService.CDBase.dr["snnModel"] == DBNull.Value) nnModel = _objectsService.CNNModel;
            else { 
                nnModel = (CNNModel)System.Text.Json.JsonSerializer.Deserialize((string)_objectsService.CDBase.dr["snnModel"], typeof(CNNModel));
            }
            nnModel.nInputNeurons = _objectsService.CNNData.nInputNeurons;
            nnModel.Reset();

            string sField = "0.000";
            gMaxIter = nnModel.nMaxIter.ToString();
            gConvTol = nnModel.ConvTol.ToString("0.000E00");
            gLearnRate = nnModel.LearnRate.ToString(sField);
            gStepSizeMin = nnModel.StepSizeMin.ToString(sField);
            gnHiddenLayers = nnModel.nHLayers.ToString();
            gHLayerType = nnModel.HLayerType.ToString();
            if (nnModel.nHLayers < 1 || nnModel.nNeuronsInLayers == null) return;
            SetNeurons();
            SetgLayer();
            SetWeights(1);
            if (nnModel != null)
            {
                nnModel.CNNDatas = _objectsService.CNNData;
                nnModel.Predict();
            }
            else
            {
                throw new InvalidOperationException("nnModel is not initialized.");
            }
            SetView();
        }

        public void SetView()
        {
            //           if(CNNData.OutputPred !=null || CNNData.Output !=null)

            int n = _objectsService.CNNData.Output.Length;
            yy  = new double[n]; 
            yyp = new double[n];
            yth = new double[2];
            double dmin  = nnModel.YMin;
            double dtmp  = nnModel.YMax - dmin;
            yth[0] = nnModel.YMin; yth[1] = nnModel.YMax;

            if (dtmp == 0) dtmp = dmin;

            for (int i = 0; i < n; i++)
            {
                yy[i] = _objectsService.CNNData.Output[i] * dtmp + dmin;
                yyp[i] = _objectsService.CNNData.OutputPred[i] * dtmp + dmin;
            }
            //gComp.Plot(yy, yyp);
            //g_Line.Plot(yth, yth);
            gChartBottomTitle = _objectsService.CNNData.sOutputName + "_Exp.";
            gChartLeftTitle   = _objectsService.CNNData.sOutputName + "_Pred.";
            if (nnModel.ErrorRMSBase > 0) gRMS  = (100.0 * (1.0 - nnModel.ErrorRMS / nnModel.ErrorRMSBase)).ToString("0.00"); else gRMS  = string.Empty;

        }

        public IActionResult OnPostGenInfo_LF(string Name,string Value)
        {
            string sFld = String.Empty, sMsg, sdum; ;
            string sName = Name;
            int itmp; double dtmp;
            itmp=int.Parse(Value);
            dtmp=double.Parse(Value);
            switch (sName)
            {
                case "gMaxIter":
                    if (gMaxIter  == string.Empty) { 
                        //MessageBox.Show("Maximum number of iterations must be greater than zero", Cbfile.sAppName);
                        gMaxIter  = nnModel.nMaxIter.ToString(); }
                    else if (int.TryParse(gMaxIter , out itmp)) nnModel.nMaxIter = itmp; else gMaxIter  = nnModel.nMaxIter.ToString(); break;

                case "gConvTol":
                    if (gConvTol  == string.Empty) { 
                        //MessageBox.Show("The Convergence Tolerance must be greater than zero", Cbfile.sAppName); 
                        gConvTol  = nnModel.ConvTol.ToString(); }
                    else if (double.TryParse(gConvTol , out dtmp)) nnModel.ConvTol = dtmp; else gConvTol  = nnModel.ConvTol.ToString(); break;

                case "gLearnRate":
                    if (gLearnRate  == string.Empty) { 
                        //MessageBox.Show("Learning rate must be greater than zero", Cbfile.sAppName); 
                        gLearnRate  = nnModel.LearnRate.ToString(); }
                    else if (double.TryParse(gLearnRate , out dtmp)) nnModel.LearnRate = dtmp; else gLearnRate  = nnModel.LearnRate.ToString(); break;


                case "gStepSizeMin":
                    if (gStepSizeMin  == string.Empty) {
                        //MessageBox.Show("Learning acceleration must be greater than zero", Cbfile.sAppName);
                        gStepSizeMin  = nnModel.StepSizeMin.ToString(); }
                    else if (double.TryParse(gStepSizeMin , out dtmp)) nnModel.StepSizeMin = dtmp; else gStepSizeMin  = nnModel.LearnRate.ToString(); break;


                case "gnHiddenLayers":
                    if (gnHiddenLayers  == string.Empty) { 
                        //MessageBox.Show("Number of Hidden Layers must be greater than zero", Cbfile.sAppName);
                        gnHiddenLayers  = nnModel.nHLayers.ToString(); }
                    else if (!int.TryParse(gnHiddenLayers , out itmp)) gnHiddenLayers  = nnModel.nHLayers.ToString();
                    else if (itmp != nnModel.nHLayers) { nnModel.nHLayers = itmp; nnModel.ResetNeurons(nnModel.nInputNeurons); SetNeurons(); nnModel.ResetWeights(); SetWeights(1); gLayerSelectedIndex = 0; }
                    break;
            }

            SaveModel();
            return new JsonResult(true);
        }

        public void SetNeurons()
        {
            //            _objectsService.AIModel.dtNeurons.Clear();
            /*            if (nnModel.nNeuronsInLayers == null)
                        {
                            nnModel.nNeuronsInLayers = new int[nnModel.nHLayers + 2];
                            for (int i = 0; i < nnModel.nNeuronsInLayers.Length - 1; i++) { nnModel.nNeuronsInLayers[i] = CNNData.nInputNeurons; }
                            nnModel.nNeuronsInLayers[nnModel.nNeuronsInLayers.Length - 1] = 1;
                        }
            */
            _objectsService.AIModel.dtNeurons.Clear();
            for (int i = 1; i < nnModel.nNeuronsInLayers.Length - 1; i++) _objectsService.AIModel.dtNeurons.Rows.Add(i, "Hidden Layer", nnModel.nNeuronsInLayers[i]);

            //            nnModel.nNeuronsInLayers[0] = CNNData.nNeurons;
            gInputNeurons  = nnModel.nNeuronsInLayers[0].ToString();

            nnModel.nNeuronsInLayers[nnModel.nNeuronsInLayers.Length - 1] = 1;
            gOutputNeurons  = "1";

            gHNeurons= _objectsService.AIModel.dtNeurons.DefaultView;

        }

        public void SetWeights(int iLayer)
        {
            int nCols = 0;
            string stmp;
            string sForm = "0.00";

            for (int i = 0; i < nnModel.nNeuronsInLayers.Length; i++)
                if (nCols < nnModel.nNeuronsInLayers[i]) nCols = nnModel.nNeuronsInLayers[i];

            nCols += 2;

            if (gWeights == null)
            {
                gWeights = new DataTable();
            }
            gWeights.Columns.Add("#", typeof(string));
            gWeights.Columns.Add("Offset", typeof(string));
            for (int i = gWeights.Columns.Count; i < nCols; i++)
            {
                stmp = "#" + (i - 1).ToString();
                gWeights.Columns.Add(stmp, typeof(string));
            }

            if (nnModel.Weights == null)
            {
 
                return;
            }

            gWeights.Clear();

            for (int iN = 1; iN < nnModel.nNeuronsInLayers[iLayer] + 1; iN++)
            {
                DataRow row = gWeights.NewRow();
                row[0] = "#" + iN.ToString();
                for (int iN1 = 0; iN1 < nnModel.nNeuronsInLayers[iLayer - 1] + 1; iN1++)
                {
                    row[iN1 + 1] = nnModel.Weights[iLayer][iN][iN1].ToString(sForm);
                }
                gWeights.Rows.Add(row);
            }
        }
    

        public void SetgLayer()
        {
            if (gLayer != null)
            {
            gLayer.Clear();
            }
            for (int i = 0; i < nnModel.nHLayers; i++) gLayer.Add("#" + (i + 1));
            gLayer.Add("Output"); gLayerSelectedIndex = 0;
        }
      
        //private void OnNodeNoEditing(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    string sMsg;
        //    int irow = e.Row.GetIndex();
        //    int icol = e.Column.DisplayIndex;

        //    int iSel;
        //    double dtemp;

        //    DataGridRow dgr = e.Row;

        //    if (irow > nnModel.nHLayers - 1)
        //    {
        //        sMsg = "Too many hidden layers";
        //      //  MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
        //        return;
        //    }
        //    if (icol == 2)
        //    {
        //        int itmp; string stmp = string.Empty;
        //        TextBox tb = gHNeurons.Columns[icol].GetCellContent(dgr) as TextBox;

        //        if (tb  == string.Empty) {
        //            //MessageBox.Show("Number of neurons must be greater than zero", Cbfile.sAppName);
        //            tb  = nnModel.nNeuronsInLayers[irow + 1].ToString(); }
        //        else if (!int.TryParse(tb , out itmp)) tb  = nnModel.nNeuronsInLayers[irow + 1].ToString();
        //        else
        //        if (itmp != nnModel.nNeuronsInLayers[irow + 1]) { nnModel.nNeuronsInLayers[irow + 1] = itmp; nnModel.ResetWeights(); SetWeights(gLayer.SelectedIndex + 1); }

        //        //               if (int.TryParse(tb , out itmp) && itmp > 0) nnModel.nNeuronsInLayers[irow + 1] = itmp;
        //        //                else { MessageBox.Show("The number of Neurons must be > 0"); tb  = nnModel.nNeuronsInLayers[irow + 1].ToString(); }
        //        nnModel.Predict();
        //        SetView();


        //        string sModel = System.Text.Json.JsonSerializer.Serialize(nnModel);
        //        //                MessageBox.Show(sModel);
        //        _objectsService.CDBase.dr["snnModel"] = sModel;
        //        _objectsService.CDBase.dr["sUser"] = _objectsService.CDefualts.sEmployee;
        //        _objectsService.CDBase.dr["DateLastChanged"] = DateTime.Now;
        //        _objectsService.CDBase.UpdateModel();
        //    }
        //}

        public void SaveModel()
        {
            string sModel = System.Text.Json.JsonSerializer.Serialize(nnModel);
            //           MessageBox.Show(sModel);
            _objectsService.CDBase.dr["snnModel"] = sModel;
            _objectsService.CDBase.UpdateModel();
        }

        #region Preview Function

        //private void PreviewPositiveRealNumber(object sender, TextCompositionEventArgs e)
        //{
        //    var regex = new Regex("[^0-9 .]");
        //    e.Handled = regex.IsMatch(e );
        //}

        //private void PreviewRealNumber(object sender, TextCompositionEventArgs e)
        //{
        //    var regex = new Regex("[^0-9 . -+ --]");
        //    e.Handled = regex.IsMatch(e );
        //}

        //private void PreviewInteger(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9]");
        //    e.Handled = regex.IsMatch(e );
        //}

        //private void PreviewPositiveInteger(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9 -+]");
        //    e.Handled = regex.IsMatch(e );
        //}

        #endregion

        public IActionResult OnPostGLayer_Changed(string Index)
        {
            gLayerSelectedIndex = Int32.Parse(Index);
            if (gLayerSelectedIndex >= 0) SetWeights(gLayerSelectedIndex + 1);
            nnModel.Predict();
            SetView();
            return new JsonResult(true);
        }

        public IActionResult OnPostTrainTheModel()
        {
            //Mouse.OverrideCursor = Cursors.Wait;
            nnModel.TrainModel();
            nnModel.Predict();
            SetView();
            SaveModel();
            SetWeights(gLayerSelectedIndex + 1);
            //Mouse.OverrideCursor = null;
            return new JsonResult(true);
        }

        //private void OnDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //   // MessageBox.Show("aa");
        //    e.Handled = true;
        //}

        //private void PrevDClick(object sender, MouseButtonEventArgs e)
        //{
        //    //          g_Line.Padding = new System.Windows.Thickness(0, 30, 0, 0);

        //    //           gChart.Padding = new System.Windows.Thickness(0, 30, 0, 0);
        //    gChart.PlotOriginY = gChart.PlotOriginX = nnModel.YMin - 0.05 * (nnModel.YMax - nnModel.YMin);
        //    gChart.PlotHeight = gChart.PlotWidth = 1.1 * (nnModel.YMax - nnModel.YMin);
        //    e.Handled = true;

        //}

        public IActionResult OnPostGHLayerType_Changed(string gHLayerTypeSelectedItem)
        {
            nnModel.HLayerType = gHLayerTypeSelectedItem;
            SaveModel();
            //           MessageBox.Show(nnModel.HLayerType);
            nnModel.Predict();

            SetView();
            return new JsonResult(true);
        }
    }
}
