using Google.Api.Gax;
using IntugentClassLbrary.Classes;
using IntugentClassLibrary.Classes;
using IntugentClassLibrary.Pages.Rnd;
using IntugentWebApp.Controllers.RnD;
using IntugentWebApp.Models;
using IntugentWebApp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.SqlServer.Server;
using System.Data;
using System.Data.SqlClient;

namespace IntugentWebApp.Pages.RnD_Users
{
    [BindProperties]
    public class FormulationsModel : PageModel
    {
              public string? Id { get; set; }
              public bool gAbandonedIsChecked {  get; set; }
              public RNDSearchResult DataSet { get; set; }
              public string gStudyName {  get; set; }
              public string gID {  get; set; }
              public DataView? gStudyType {  get; set; }
              public int gStudyTypeSelectedValue { get; set; }
      
              public DataView gChemist { get; set; }
              public int gChemistSelectedValue { get; set; }
      
              public DataView gOperator { get; set; }
              public int gOperatorSelectedValue { get; set; }
              public DataView gProductID { get; set; }
              public string gProductIDSelectedValue { get; set; }
              public DateTime? gDateDSCreated { get; set; }
              public DataView gFormProps {  get; set; }
              public DataTable gPO {  get; set; }
              public DataTable gNco {  get; set; }
              public DataTable gIso {  get; set; }
              public string gFoamatGm {  get; set; }
              public List<string> gPolyolList {  get; set; }
              public List<string> gIsoList { get; set; }
      
              public readonly ObjectsService _objectsService;
              public FormulationsModel(ObjectsService objectsService) {
      
                  _objectsService = objectsService;
              }
      
              public void OnGet()
              {
                  Startup();
                       gStudyType = _objectsService.CLists.dvRunTypeRND2;
                       gStudyTypeSelectedValue = 1;
                       gProductID = _objectsService.CLists.dvComProd;
                       gProductIDSelectedValue = "Experimental";
                       gChemist = _objectsService.CLists.dvEmployeesRND;
                      gChemistSelectedValue = 24;
                      gOperator = _objectsService.CLists.dvEmployeesRND;
                      gOperatorSelectedValue = 28; 

                      //  gR2KM.Text = CPages.PageKineticModel1_1.KineticModel.AdcR2Val.ToString("0.00");
                      //  gR2RM.Text = CPages.PageRheoModel1_1.RheoModel.INR2Val.ToString("0.00");
                      //
                      // _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw1 = 99;
                      //
                      //  GetDataSet();

            if (_objectsService.RNDHome.bDataRead == false) { 
                ReadDataset();
                _objectsService.RNDHome.bDataRead = true; }

            gID = SetIntTextField("ID");
            if (_objectsService.RNDHome.drS["Study Name"] == DBNull.Value) gStudyName = String.Empty; else gStudyName = (string)_objectsService.RNDHome.drS["Study Name"];

            if (_objectsService.RNDHome.drS["Chemist"] == DBNull.Value) gChemist = null; else gChemistSelectedValue = (int)_objectsService.RNDHome.drS["Chemist"];
            if (_objectsService.RNDHome.drS["Operator"] == DBNull.Value) gOperator = null; else gOperatorSelectedValue = (int)_objectsService.RNDHome.drS["Operator"];
            if (_objectsService.RNDHome.drS["Product ID"] == DBNull.Value) gProductID = null; else gProductIDSelectedValue = (string)_objectsService.RNDHome.drS["Product ID"];
            if (_objectsService.RNDHome.drS["Study Type"] == DBNull.Value) gStudyType = null; else gStudyTypeSelectedValue = (int)_objectsService.RNDHome.drS["Study Type"];
            if (_objectsService.RNDHome.drS["FoamatGm"] == DBNull.Value) _objectsService.RNDFormulations.cDefualts.FoamatRunWt = 225.0; else _objectsService.RNDFormulations.cDefualts.FoamatRunWt = (double)_objectsService.RNDHome.drS["FoamatGm"];
            if (_objectsService.RNDHome.drS["DateDSCreated"] == DBNull.Value) gDateDSCreated = null; else gDateDSCreated = (DateTime)_objectsService.RNDHome.drS["DateDSCreated"];
            if (_objectsService.RNDHome.drS["Abandoned"] == DBNull.Value) gAbandonedIsChecked = false; else gAbandonedIsChecked = (bool)_objectsService.RNDHome.drS["Abandoned"];

            gFoamatGm = _objectsService.RNDFormulations.cDefualts.FoamatRunWt.ToString();



            SetView();


        }

        public void Startup()
        {
            int id = 0, id1 = 0;

            // Formulation Array
            for (int i = 0; i < _objectsService.RNDFormulations.Forms.nForm; i++) _objectsService.RNDFormulations.Forms.FormAr[i] = new CForm();


            //Table of Properties          ;

            _objectsService.RNDFormulations.dtFormProp.Columns.Add("Descriptors", typeof(string));
            for (int i = 1; i < _objectsService.RNDFormulations.Forms.nForm + 1; i++)
            {
                _objectsService.RNDFormulations.dtFormProp.Columns.Add("#" + i, typeof(double));
            }
            for (int i = 0; i < 30; i++) _objectsService.RNDFormulations.dtFormProp.Rows.Add();

            gFormProps= _objectsService.RNDFormulations.dtFormProp.DefaultView;

            //Initialize Material lists on the PO and Iso Sides

            //           _objectsService.RNDFormulations.Forms.dtFormIso.Add("Descriptors", typeof(string));
            //           for (int i = 1; i < _objectsService.RNDFormulations.Forms.nForm + 1; i++)


            _objectsService.RNDFormulations.Forms.POMats.Add(new CMaterial());
            _objectsService.RNDFormulations.Forms.POMats.Add(new CMaterial());

            _objectsService.RNDFormulations.Forms.IsoMats.Add(new CMaterial()
            {
                ID = 62,
                MatName = "Lupranat® M 20R",
                MatType = "Iso-PMDI",
                MatFunc = 2.7,
                MatNco = 31.5,
                //                Pbw1 = 50.0, Pbw8 = 10
            });




            _objectsService.RNDFormulations.Forms.NCOIndexMats.Add(new CMaterial()
            {
                MatName = "NCO Index (Equivalents of NCO per 100 Equivalents of Active-H",
                Pbw1 = "270",
                Pbw2 = "270",
                Pbw3 = "270",
                Pbw4 = "270",
                Pbw5 = "270",
                Pbw6 = "270",
                Pbw7 = "270",
                Pbw8 = "270"

            });
            for (int ifo = 0; ifo < _objectsService.RNDFormulations.Forms.nForm; ifo++)
            {
                _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex = 270;
                _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide = 100;
            }

            //gPO  = _objectsService.RNDFormulations.Forms.POMats;
            //gNco = _objectsService.RNDFormulations.Forms.NCOIndexMats;
            //gIso = _objectsService.RNDFormulations.Forms.IsoMats;

            //            _objectsService.RNDFormulations.Forms.dtFormIso.Add

            //            GetMatList();
            _objectsService.RNDFormulations.GetMatListSql();
            gPolyolList = _objectsService.RNDFormulations.sMatNameListPO.ToList();
            gIsoList = _objectsService.RNDFormulations.sMatNameListIso.ToList();
            _objectsService.RNDFormulations.ModifyPOIsoLists(0, ref _objectsService.RNDFormulations.Forms.IsoMats, 0, _objectsService.RNDFormulations.dtIso);  //fill the grid with the 1st material on the list

            for (int i = 0; i < _objectsService.RNDFormulations.dtPO.Rows.Count; i++)
            {
                if (_objectsService.RNDFormulations.dtPO.Rows[i]["ID"].ToString() == "106") id = i;
                if (_objectsService.RNDFormulations.dtPO.Rows[i]["ID"].ToString() == "89") id1 = i;

            }
            _objectsService.RNDFormulations.ModifyPOIsoLists(0, ref _objectsService.RNDFormulations.Forms.POMats, id, _objectsService.RNDFormulations.dtPO);
            _objectsService.RNDFormulations.ModifyPOIsoLists(1, ref _objectsService.RNDFormulations.Forms.POMats, id1, _objectsService.RNDFormulations.dtPO);


        }

        //private void OngNcoCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    double dtmp, dtmp0;
        //    int irow = e.Row.GetIndex();
        //    int icol = e.Column.DisplayIndex;
        //    DataRow dgr = e.Row;

        //    if (irow == 0 && icol > 0 && icol < _objectsService.RNDFormulations.Forms.nForm + 1)
        //    {
        //        dtmp0 = _objectsService.RNDFormulations.Forms.FormAr[icol - 1].NcoIndex;
        //        TextBox tb = gIso.Columns[icol].GetCellContent(dgr) as TextBox;
        //        if (double.TryParse(tb.Text, out dtmp)) _objectsService.RNDFormulations.Forms.FormAr[icol - 1].NcoIndex = dtmp;
        //        else {
        //          //  MessageBox.Show("Improper Value. New Value is not accepted."); 
        //            if (dtmp0 > 0) tb.Text = dtmp0.ToString("0.#####"); else tb.Text = string.Empty; }
        //    }

        //    SetView();
        //    _objectsService.RNDHome.dtF.Rows[icol - 1]["NCOIndex"] = _objectsService.RNDFormulations.Forms.FormAr[icol - 1].NcoIndex; _objectsService.RNDHome.UpdateFormulatiions();


        //    //           dr["FormsStr"] = JsonSerializer.Serialize<CForms>(Forms);
        //    // string sMsg = JsonSerializer.Serialize(Forms.FormAr[icol - 1].POMatPbw);
        //    //            string sMsg = (string) JsonConvert.SerializeObject(Forms, Formatting.Indented);

        //    //           MessageBox.Show(sMsg);
        //    //           UpdateDataSet();

        //}

        //private void gPO_Paste(object sender, RoutedEventArgs e)

        //{

        //    int iColStart = 4, iColEnd = 4;
        //    double dtmp; string stmp;

        //    List<string[]> clipboardData = ClipboardHelper.ParseClipboardData();
        //    if (clipboardData == null) return;

        //    for (int ir = 0; ir < clipboardData.Count; ir++)
        //    {
        //        if (ir >= _objectsService.RNDFormulations.Forms.POMats.Count) break;
        //        for (int ic = 0; ic < clipboardData[ir].Length; ic++)
        //        {
        //            if (ic + iColStart >= gPO.Columns.Count) break;
        //            if (ic == 0)
        //            {
        //                stmp = clipboardData[ir][ic];
        //                if (double.TryParse(stmp, out dtmp)) { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = dtmp; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw1 = stmp; } else { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = 0; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw1 = string.Empty; }
        //            }
        //            if (ic == 1)
        //            {
        //                stmp = clipboardData[ir][ic];
        //                if (double.TryParse(stmp, out dtmp)) { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = dtmp; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw2 = stmp; } else { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = 0; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw2 = string.Empty; }
        //            }
        //            if (ic == 2)
        //            {
        //                stmp = clipboardData[ir][ic];
        //                if (double.TryParse(stmp, out dtmp)) { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = dtmp; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw3 = stmp; } else { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = 0; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw3 = string.Empty; }
        //            }
        //            if (ic == 3)
        //            {
        //                stmp = clipboardData[ir][ic];
        //                if (double.TryParse(stmp, out dtmp)) { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = dtmp; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw4 = stmp; } else { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = 0; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw4 = string.Empty; }
        //            }
        //            if (ic == 4)
        //            {
        //                stmp = clipboardData[ir][ic];
        //                if (double.TryParse(stmp, out dtmp)) { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = dtmp; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw5 = stmp; } else { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = 0; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw5 = string.Empty; }
        //            }
        //            if (ic == 5)
        //            {
        //                stmp = clipboardData[ir][ic];
        //                if (double.TryParse(stmp, out dtmp)) { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = dtmp; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw6 = stmp; } else { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = 0; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw6 = string.Empty; }
        //            }
        //            if (ic == 6)
        //            {
        //                stmp = clipboardData[ir][ic];
        //                if (double.TryParse(stmp, out dtmp)) { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = dtmp; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw7 = stmp; } else { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = 0; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw7 = string.Empty; }
        //            }
        //            if (ic == 7)
        //            {
        //                stmp = clipboardData[ir][ic];
        //                if (double.TryParse(stmp, out dtmp)) { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = dtmp; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw8 = stmp; } else { _objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw[ir] = 0; _objectsService.RNDFormulations.Forms.POMats[ir].Pbw8 = string.Empty; }
        //            }
        //        }
        //    }
        //    gPO = _objectsService.RNDFormulations.Forms.POMats;
        //    SetView();
        //    string js1;
        //    for (int ic = 0; ic < 8; ic++)
        //    {
        //        js1 = System.Text.Json.JsonSerializer.Serialize(_objectsService.RNDFormulations.Forms.FormAr[ic].POMatPbw);
        //        _objectsService.RNDHome.dtF.Rows[ic]["POPbws"] = js1;
        //    }
        //    _objectsService.RNDHome.UpdateFormulatiions();



        //}
        //private void OngPOCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    string sMsg;
        //    int irow = e.Row.GetIndex();
        //    int icol = e.Column.DisplayIndex;
        //    double dtmp, dtmp0; string stmp = string.Empty;

        //    int iSel;
        //    //         double dtemp;

        //    DataRow dgr = e.Row;

        //    if (irow > _objectsService.RNDFormulations.Forms.nComps - 2)
        //    {
        //        sMsg = "Number of components (rows) must be less than " + _objectsService.RNDFormulations.Forms.nComps.ToString();
        //     //   MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
        //        return;
        //    }
        //    if (icol == 0)
        //    {


        //        ComboBox cmb = gPO.Columns[0].GetCellContent(dgr) as ComboBox;
        //        iSel = cmb.SelectedIndex;

        //        if (iSel > -1)
        //        {
        //            _objectsService.RNDFormulations.ModifyPOIsoLists(irow, ref _objectsService.RNDFormulations.Forms.POMats, iSel, dtPO);
        //            string sMatIDs = _objectsService.RNDFormulations.Forms.POMats[0].ID.ToString();
        //            for (int j = 1; j < _objectsService.RNDFormulations.Forms.POMats.Count; j++) sMatIDs += "," + _objectsService.RNDFormulations.Forms.POMats[j].ID.ToString();
        //            _objectsService.RNDHome.drS["POMats"] = sMatIDs; _objectsService.RNDHome.UpdateDataSet();

        //            stmp = _objectsService.RNDFormulations.Forms.POMats[0].MatOHNum.ToString();
        //            for (int j = 1; j < _objectsService.RNDFormulations.Forms.POMats.Count; j++) stmp += "," + _objectsService.RNDFormulations.Forms.POMats[j].MatOHNum.ToString();
        //            _objectsService.RNDHome.drS["sPOMatsOH"] = stmp; _objectsService.RNDHome.UpdateDataSet();
        //            //  MessageBox.Show(sMatIDs);
        //            /*                   
        //                               _objectsService.RNDFormulations.Forms.POMats[irow].MatType = sMatTypeListPO[iSel];
        //                               POForm1.POMatOH[irow] = _objectsService.RNDFormulations.Forms.POMats[irow].MatOHNum = dMatOHListPO[iSel];
        //                               POForm1.POMatFunc[irow] = _objectsService.RNDFormulations.Forms.POMats[irow].MatFunc = dMatFuncListPO[iSel];
        //                               int.TryParse(dtPO.Rows[irow]["ID"].ToString(), out POForm1.POMatID[irow]); 
        //            */
        //        }

        //    }
        //    else if (icol == 2)
        //    {

        //        TextBox tb = gPO.Columns[icol].GetCellContent(dgr) as TextBox;
        //        double.TryParse(tb.Text, out dtmp);
        //        _objectsService.RNDFormulations.Forms.POMats[irow].MatOHNum = dtmp;
        //        stmp = _objectsService.RNDFormulations.Forms.POMats[0].MatOHNum.ToString();
        //        for (int j = 1; j < _objectsService.RNDFormulations.Forms.POMats.Count; j++) stmp += "," + _objectsService.RNDFormulations.Forms.POMats[j].MatOHNum.ToString();
        //        _objectsService.RNDHome.drS["sPOMatsOH"] = stmp; _objectsService.RNDHome.UpdateDataSet();
        //        //                MessageBox.Show(_objectsService.RNDFormulations.Forms.POMats[irow].MatName.ToString()+"\n\nOH#:  " + dtemp.ToString());
        //        SetView();


        //    }
        //    else if (icol > 3 && icol < 12)
        //    {
        //        dtmp0 = _objectsService.RNDFormulations.Forms.FormAr[icol - 4].POMatPbw[irow];
        //        TextBox tb = gPO.Columns[icol].GetCellContent(dgr) as TextBox;

        //        if (tb.Text == string.Empty) { _objectsService.RNDFormulations.Forms.FormAr[icol - 4].POMatPbw[irow] = 0.0; tb.Text = string.Empty; }
        //        else if (double.TryParse(tb.Text, out dtmp)) _objectsService.RNDFormulations.Forms.FormAr[icol - 4].POMatPbw[irow] = dtmp;
        //        else { 
        //           // MessageBox.Show("Improper Value. New Value is not accepted.");
        //            if (dtmp0 > 0) tb.Text = dtmp0.ToString("0.#####");
        //            else tb.Text = string.Empty; }

        //        string js1 = System.Text.Json.JsonSerializer.Serialize(_objectsService.RNDFormulations.Forms.FormAr[icol - 4].POMatPbw);
        //        _objectsService.RNDHome.dtF.Rows[icol - 4]["POPbws"] = js1; _objectsService.RNDHome.UpdateFormulatiions();
        //        //                MessageBox.Show(js1);
        //    }

        //    if (string.IsNullOrEmpty(_objectsService.RNDFormulations.Forms.POMats[irow].MatName))
        //    {
        //        sMsg = "You must choose the material for the row " + (irow + 1);
        //       // MessageBox.Show(sMsg, Params.sAppName, MessageBoxButton.OK, MessageBoxImage.Hand);
        //    }
        //    else SetView();

        //    string js = System.Text.Json.JsonSerializer.Serialize(_objectsService.RNDFormulations.Forms.POMats);
        //    e.Cancel = true;

        //    //           MessageBox.Show(js);
        //}
        //private void OngIsoCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    string sMsg;
        //    int irow = e.Row.GetIndex();
        //    int icol = e.Column.DisplayIndex;
        //    double dtemp;

        //    int iSel;

        //    DataRow dgr = e.Row;

        //    if (irow > _objectsService.RNDFormulations.Forms.nComps - 2)
        //    {
        //        sMsg = "Number of comIsonents (rows) must be less than " + _objectsService.RNDFormulations.Forms.nComps.ToString();
        //       // MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
        //        return;
        //    }
        //    if (icol == 0)
        //    {
        //        if (irow > _objectsService.RNDFormulations.Forms.IsoMats.Count - 1) _objectsService.RNDFormulations.Forms.IsoMats.Add(new CMaterial());


        //        ComboBox cmb = gIso.Columns[0].GetCellContent(dgr) as ComboBox;
        //        iSel = cmb.SelectedIndex;

        //        if (iSel > -1 && irow == 0)
        //        {
        //            _objectsService.RNDFormulations.ModifyPOIsoLists(irow, ref _objectsService.RNDFormulations.Forms.IsoMats, iSel, _objectsService.RNDFormulations.dtIso);
        //            _objectsService.RNDHome.drS["IsoMats"] = _objectsService.RNDFormulations.Forms.IsoMats[0].ID; _objectsService.RNDHome.UpdateDataSet();
        //            //  MessageBox.Show(sMatIDs);
        //            /*
        //                                Forms.IsoMats[irow].MatType = sMatTypeListIso[iSel];
        //                                IsoForm1.IsoMatOH[irow] = Forms.IsoMats[irow].MatOHNum = dMatOHListIso[iSel];
        //                                IsoForm1.IsoMatFunc[irow] = Forms.IsoMats[irow].MatFunc = dMatFuncListIso[iSel];
        //                                int.TryParse(dtIso.Rows[irow]["ID"].ToString(), out IsoForm1.IsoMatID[irow]);
        //            */
        //        }

        //    }
        //    else if (icol == 2)
        //    {

        //        double dtmp; string stmp = string.Empty;
        //        TextBox tb = gPO.Columns[icol].GetCellContent(dgr) as TextBox;
        //        double.TryParse(tb.Text, out dtemp);
        //        _objectsService.RNDFormulations.Forms.IsoMats[irow].MatNco = dtemp;
        //        _objectsService.RNDHome.drS["sIsoMatsNCO"] = _objectsService.RNDFormulations.Forms.IsoMats[0].MatNco.ToString(); _objectsService.RNDHome.UpdateDataSet();
        //        //                MessageBox.Show(Forms.IsoMats[irow].MatName.ToString() + "\n\nNCO%:  " + dtemp.ToString());
        //        SetView();
        //    }
        //    else if (icol > 3 && icol < 11)
        //    {
        //        TextBox tb = gIso.Columns[icol].GetCellContent(dgr) as TextBox;
        //        double.TryParse(tb.Text, out _objectsService.RNDFormulations.Forms.FormAr[icol - 4].IsoMatPbw[irow]);
        //    }

        //    if (string.IsNullOrEmpty(_objectsService.RNDFormulations.Forms.IsoMats[irow].MatName))
        //    {
        //        sMsg = "You must choose the material for the row " + (irow + 1);
        //       // MessageBox.Show(sMsg, Params.sAppName, MessageBoxButton.OK, MessageBoxImage.Hand);
        //    }
        //    else SetView();

        //}


        /*
                private void GetMatList()
                {
                     string sqlPO, sqlIso, sDBcon;
                    var bValid = true;




                    sqlPO = "SELECT * FROM tblRawMaterials  WHERE MatCat <> 'Iso Side' ORDER BY MatName ASC ";
                    sqlIso = "SELECT * FROM tblRawMaterials  WHERE MatCat <> 'PO Side' ORDER BY MatName ASC ";


                    sDBcon = Cbfile.sDBConn();

                    try
                    {
                        using (OleDbConnection conn = new OleDbConnection(sDBcon))
                        {
                            conn.Open();
                            OleDbCommand command = new OleDbCommand();
                            command.Connection = conn;


                            command.CommandText = sqlPO;
                            OleDbDataReader reader = command.ExecuteReader();
                            dtPO = new DataTable();
                            dtPO.Load(reader);
                            Array.Resize(ref sMatNameListPO, dtPO.Rows.Count);
                            Array.Resize(ref sMatTypeListPO, dtPO.Rows.Count);
                            //                Array.Resize(ref dMatOHListPO, dtPO.Rows.Count);
                            //                Array.Resize(ref dMatFuncListPO, dtPO.Rows.Count);


                            for (int i = 0; i < dtPO.Rows.Count; i++)
                            {
                                sMatNameListPO[i] = (dtPO.Rows[i]["MatName"].ToString());
                                sMatTypeListPO[i] = dtPO.Rows[i]["MatType"].ToString();
                                //                     bValid = double.TryParse(dtPO.Rows[i]["MatOH"].ToString(), out dMatOHListPO[i]);
                                //                     bValid  = double.TryParse(dtPO.Rows[i]["MatFunc"].ToString(), out dMatFuncListPO[i]);

                            }

                            command.CommandText = sqlIso;
                            reader = command.ExecuteReader();
                            dtIso = new DataTable();
                            dtIso.Load(reader);
                            Array.Resize(ref sMatNameListIso, dtIso.Rows.Count);
                            Array.Resize(ref sMatTypeListIso, dtIso.Rows.Count);
                            //               Array.Resize(ref dMatNCOListIso, dtIso.Rows.Count);
                            //                Array.Resize(ref dMatFuncListIso, dtIso.Rows.Count);


                            for (int i = 0; i < dtIso.Rows.Count; i++)
                            {
                                sMatNameListIso[i] = (dtIso.Rows[i]["MatName"].ToString());
                                sMatTypeListIso[i] = dtIso.Rows[i]["MatType"].ToString();
                                //                   bValid = double.TryParse(dtIso.Rows[i]["MatIsoCont"].ToString(), out dMatNCOListIso[i]);
                                //                   bValid = double.TryParse(dtIso.Rows[i]["MatFunc"].ToString(), out dMatFuncListIso[i]);

                            }



                        }
                    }
                    catch(Exception e)
                    {
                        string sMsg = "Error opening databases";
                        MessageBox.Show(e.Message, Cbfile.sAppName);
                    }


                    gPolyolList.ItemsSource = sMatNameListPO;
                    gIsoList.ItemsSource = sMatNameListIso;

                }
        */

       public IActionResult OnPostOngFoamatGmLostFocus()
        {
            Double.TryParse(gFoamatGm, out _objectsService.RNDFormulations.cDefualts.FoamatRunWt);
            SetView();
            _objectsService.RNDHome.drS["FoamatGm"] = _objectsService.RNDFormulations.cDefualts.FoamatRunWt; _objectsService.RNDHome.UpdateDataSet();
            return new JsonResult(true);
        }

        public void SetView()
        {
            int ifo; string sMsg;

            try
            {
                //                GetDataSet();


                FormDescriptors();

                int ir = 1;
                double dSum;
                /*
                                _objectsService.RNDFormulations.dtFormProp.Rows[ir]["Descriptors"] = "Component Ratios";
                                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1]["Descriptors"] = "   PBW of Polyol Side per 100 pbw of Iso Side";
                                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2]["Descriptors"] = "   PBW of Iso Side per 100 pbw of Polyol Side";
                                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 3]["Descriptors"] = "   NCO Index (%)";
               for (ifo = 0; ifo < _objectsService.RNDFormulations.Forms.nForm; ifo++)
                {
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].PolyolIsoRatio.ToString("0.0");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].IsoPolyolRatio.ToString("0.0");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 3][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex.ToString("0.0");
                }
                 */
                _objectsService.RNDFormulations.dtFormProp.Rows[ir]["Descriptors"] = "Weights and Ratios";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1]["Descriptors"] = "   B Side - PBW of Polyol Side Materials";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2]["Descriptors"] = "   A+B Side - PBW Total of all Materials";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 3]["Descriptors"] = "   %A - Percent Isocyanate";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 4]["Descriptors"] = "   %B - Percent Polyol Side Materials";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 5]["Descriptors"] = "   Foam - Cup Isocyante (A) Side (gm)";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 6]["Descriptors"] = "   Foam - Cup Polyol (B) Side (gm)";


                for (ifo = 0; ifo < _objectsService.RNDFormulations.Forms.nForm; ifo++)
                {
                    dSum = _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide + _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide;
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide.ToString("0.0");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2][ifo + 1] = dSum.ToString("0.0");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 3][ifo + 1] = (100.0 * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide / dSum).ToString("0.0");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 4][ifo + 1] = (100.0 * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide / dSum).ToString("0.0");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 5][ifo + 1] = (_objectsService.RNDFormulations.cDefualts.FoamatRunWt * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide / dSum).ToString("0.0");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 6][ifo + 1] = (_objectsService.RNDFormulations.cDefualts.FoamatRunWt * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide / dSum).ToString("0.0");
                }

                ir = ir + 8;
                _objectsService.RNDFormulations.dtFormProp.Rows[ir]["Descriptors"] = "Polyol Info.";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1]["Descriptors"] = "   OH # for Polyol Mix";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2]["Descriptors"] = "   OH # for all Active H";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 3]["Descriptors"] = "   Av. Polyol Func.";

                for (ifo = 0; ifo < _objectsService.RNDFormulations.Forms.nForm; ifo++)
                {
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPolyol.ToString("0.0");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPOSide.ToString("0.0");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 3][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide.ToString("0.00");
                }



                ir = ir + 6;
                _objectsService.RNDFormulations.dtFormProp.Rows[ir]["Descriptors"] = "Iso Info.";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1]["Descriptors"] = "   Av. NCO content for Isocyantates ";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2]["Descriptors"] = "   Av. functionality of Isocyantates ";
                for (ifo = 0; ifo < _objectsService.RNDFormulations.Forms.nForm; ifo++)
                {
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide.ToString("0.00");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide.ToString("0.00");
                }

                ir = ir + 4;
                _objectsService.RNDFormulations.dtFormProp.Rows[ir]["Descriptors"] = "Formulation Analysis";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1]["Descriptors"] = "   Water level (% Formulation)";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2]["Descriptors"] = "   Other Blowing Agent Wt. (% of polymer)";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 3]["Descriptors"] = "   Catalyst level (% Formulation)";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 4]["Descriptors"] = "   Surfactant level (% Formulation)";

                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 6]["Descriptors"] = "   Foam: Theoratical Min. Density (lb/ft&#x00B3) at STP";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 7]["Descriptors"] = "   Wt. Percent of Isocyanurate in the polymer";
                _objectsService.RNDFormulations.dtFormProp.Rows[ir + 8]["Descriptors"] = "   Moles of crosslinks per kg of material";
                for (ifo = 0; ifo < _objectsService.RNDFormulations.Forms.nForm; ifo++)
                {
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 1][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].WaterWtFr.ToString("0.00");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 2][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].BlowingAgentWtFr1.ToString("0.00");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 3][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].CatalystWtFr.ToString("0.00");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 4][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].SurfactWtFr.ToString("0.00");

                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 6][ifo + 1] = (_objectsService.RNDFormulations.Forms.FormAr[ifo].FoamDensity / 16.018463).ToString("0.00");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 7][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].IsocyanuratePbw.ToString("0.00");
                    _objectsService.RNDFormulations.dtFormProp.Rows[ir + 8][ifo + 1] = _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity.ToString("0.000");
                }

                _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw1 = (_objectsService.RNDFormulations.Forms.FormAr[0].TotalPbwIsoSide).ToString("0.0");
                _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw2 = (_objectsService.RNDFormulations.Forms.FormAr[1].TotalPbwIsoSide).ToString("0.0");
                _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw3 = (_objectsService.RNDFormulations.Forms.FormAr[2].TotalPbwIsoSide).ToString("0.0");
                _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw4 = (_objectsService.RNDFormulations.Forms.FormAr[3].TotalPbwIsoSide).ToString("0.0");
                _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw5 = (_objectsService.RNDFormulations.Forms.FormAr[4].TotalPbwIsoSide).ToString("0.0");
                _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw6 = (_objectsService.RNDFormulations.Forms.FormAr[5].TotalPbwIsoSide).ToString("0.0");
                _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw7 = (_objectsService.RNDFormulations.Forms.FormAr[6].TotalPbwIsoSide).ToString("0.0");
                _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw8 = (_objectsService.RNDFormulations.Forms.FormAr[7].TotalPbwIsoSide).ToString("0.0");
                //                   _objectsService.RNDFormulations.Forms.IsoMats[0].Pbw4 = 30;
                //              gIso.ItemsSource = _objectsService.RNDFormulations.Forms.IsoMats;

            }
            catch (Exception ex)
            {
                sMsg = "Error in calculating writting formulation descriptors";
                //MessageBox.Show(sMsg, Cbfile.sAppName); CTelClient.TelException(ex, sMsg);
            }

            //            Forms.IsoMats[0].Pbw1 = Forms.FormAr[0].TotalPbwIsoSide;


            gFormProps= _objectsService.RNDFormulations.dtFormProp.DefaultView;
        }
        public void FormDescriptors()
        {
            int i, ico, ifo;
            double dsumPbw, dsumPbwPO, dsumOH, dsumOHPO, dsumFunc, dsumFunc1, dsumNco, dsumBlowingAg, dsumBlowingAg1, dsumWater, dsumSurfac, dsumCatalyst;
            double temp1, temp2, temp3;
            string sMsg;

            //Calculates Equivs of polyols.   

            try
            {
                for (ifo = 0; ifo < _objectsService.RNDFormulations.Forms.nForm; ifo++)
                {

                    dsumPbw = dsumPbwPO = dsumOH = dsumOHPO = dsumFunc = dsumFunc1 = dsumBlowingAg = dsumBlowingAg1 = dsumWater = dsumSurfac = dsumCatalyst = 0.0;
                    for (ico = 0; ico < _objectsService.RNDFormulations.Forms.POMats.Count; ico++)
                    {
                        if (string.IsNullOrEmpty(_objectsService.RNDFormulations.Forms.POMats[ico].MatName))
                            if (_objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] > 0)
                            {
                                sMsg = "You must choose the material for the row " + (ico + 1).ToString() + " of the Polyol Side Materials table";
                               // MessageBox.Show(sMsg, Params.sAppName, MessageBoxButton.OK, MessageBoxImage.Hand);
                                /*
                                                                if (ico > _objectsService.RNDFormulations.Forms.POMats.Count - 1) _objectsService.RNDFormulations.Forms.POMats.Add(new CMaterial());
                                                                    ModifyPOIsoLists(ico, ref _objectsService.RNDFormulations.Forms.POMats, 0, dtPO);
                                */
                                return;
                            }
                            else continue;

                        else
                        {
                            dsumPbw = dsumPbw + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico];
                            dsumOH = dsumOH + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] * _objectsService.RNDFormulations.Forms.POMats[ico].MatOHNum;
                            if (_objectsService.RNDFormulations.Forms.POMats[ico].MatType.Contains("Polyol"))
                            {
                                dsumPbwPO = dsumPbwPO + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico];
                                dsumOHPO = dsumOHPO + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] * _objectsService.RNDFormulations.Forms.POMats[ico].MatOHNum;
                            }
                            if (_objectsService.RNDFormulations.Forms.POMats[ico].MatFunc > 0)
                            {
                                dsumFunc = dsumFunc + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] * _objectsService.RNDFormulations.Forms.POMats[ico].MatOHNum * _objectsService.RNDFormulations.Forms.POMats[ico].MatFunc;
                                dsumFunc1 = dsumFunc1 + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] * _objectsService.RNDFormulations.Forms.POMats[ico].MatOHNum;
                            }
                            if (_objectsService.RNDFormulations.Forms.POMats[ico].GassToLiqWtRatio > 0.0)
                            {
                                dsumBlowingAg = dsumBlowingAg + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] * _objectsService.RNDFormulations.Forms.POMats[ico].GassToLiqWtRatio;
                                dsumBlowingAg1 = dsumBlowingAg1 + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico];
                            }
                            if (_objectsService.RNDFormulations.Forms.POMats[ico].MatType.Contains("Catalyst")) dsumCatalyst = dsumCatalyst + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico];
                            if (_objectsService.RNDFormulations.Forms.POMats[ico].MatType.Contains("Surfactant")) dsumSurfac = dsumSurfac + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico];
                            if (_objectsService.RNDFormulations.Forms.POMats[ico].ID == 74) dsumWater = dsumWater + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico];
                        }

                    }

                    if (dsumPbw > 0) _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPOSide = dsumOH / dsumPbw; else _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPOSide = 0;
                    if (dsumPbwPO > 0) _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPolyol = dsumOHPO / dsumPbwPO; else _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPolyol = 0;
                    if (dsumFunc1 > 0) _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide = dsumFunc / dsumFunc1; else _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide = 0;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide = dsumPbw;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPolyol = dsumPbwPO;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwFuncPOSide = dsumFunc1;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].BlowingAgentWtFr = dsumBlowingAg;  //Total wt of blowing agent in PO side.  Will be normalized later
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].SurfactWtFr = dsumSurfac;    //Total wt. will be normalized later
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].CatalystWtFr = dsumCatalyst;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].WaterWtFr = dsumWater;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].BlowingAgentWtFr1 = dsumBlowingAg1 - dsumWater;

                    /*
                    dsumPbw = dsumNco = dsumFunc = dsumFunc1 = dsumBlowingAg = 0.0;
                    for (ico = 0; ico < Forms.IsoMats.Count; ico++)
                    {

                        if (Forms.FormAr[ifo].IsoMatPbw[ico] > 0 && string.IsNullOrEmpty(_objectsService.RNDFormulations.Forms.IsoMats[ico].MatName))
                        {
                            sMsg = "You must choose the material for the row " + (ico + 1).ToString() + " of the Iso Side Material table";
                            MessageBox.Show(sMsg, Params.sAppName, MessageBoxButton.OK, MessageBoxImage.Hand);
                            return;
                        }
                        else
                        {
                            dsumPbw = dsumPbw + _objectsService.RNDFormulations.Forms.FormAr[ifo].IsoMatPbw[ico];
                            dsumNco = dsumNco + _objectsService.RNDFormulations.Forms.FormAr[ifo].IsoMatPbw[ico] * _objectsService.RNDFormulations.Forms.IsoMats[ico].MatNco;

                            if (_objectsService.RNDFormulations.Forms.IsoMats[ico].MatFunc > 0)
                            {
                                dsumFunc = dsumFunc + _objectsService.RNDFormulations.Forms.FormAr[ifo].IsoMatPbw[ico] * _objectsService.RNDFormulations.Forms.IsoMats[ico].MatNco * _objectsService.RNDFormulations.Forms.IsoMats[ico].MatFunc;
                                dsumFunc1 = dsumFunc1 + _objectsService.RNDFormulations.Forms.FormAr[ifo].IsoMatPbw[ico] * _objectsService.RNDFormulations.Forms.IsoMats[ico].MatNco;

                            }

                        }
                    }

                    if (dsumPbw > 0) _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide = dsumNco / dsumPbw; else _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide = 0;
                    if (dsumFunc1 > 0) _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide = dsumFunc / dsumFunc1; else _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide = 0;

                    _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide = dsumPbw;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwFuncIsoSide = dsumFunc1;
                     */
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide = _objectsService.RNDFormulations.Forms.IsoMats[0].MatNco;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide = _objectsService.RNDFormulations.Forms.IsoMats[0].MatFunc;

                }

                // PO and Iso side weights calculations, Isocyanurate trimer and crosslink density calculations

                for (ifo = 0; ifo < _objectsService.RNDFormulations.Forms.nForm; ifo++)
                {
                    /*
                     * _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide = 100.0;
                                       if (_objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide > 0)
                                           _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide = _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex / 100.0 * _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPOSide / 56100.0 * 4200.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide;
                                       if (_objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide > 0.0)
                                           _objectsService.RNDFormulations.Forms.FormAr[ifo].PolyolIsoRatio = _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide / _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide * 100.0;
                                       else _objectsService.RNDFormulations.Forms.FormAr[ifo].PolyolIsoRatio = 0.0;
                                       if (_objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide > 0.0)
                                           _objectsService.RNDFormulations.Forms.FormAr[ifo].IsoPolyolRatio = _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide / _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide * 100.0;
                                       else _objectsService.RNDFormulations.Forms.FormAr[ifo].IsoPolyolRatio = 0.0;
                    */

                    _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide = _objectsService.RNDFormulations.Forms.IsoMats[0].MatNco;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide = _objectsService.RNDFormulations.Forms.IsoMats[0].MatFunc;

                    _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide = _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPOSide / 56100 * 4200.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex * 0.01;
                    _objectsService.RNDFormulations.Forms.FormAr[ifo].IsoMatPbw[0] = _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide;


                    _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = 0;
                    if (_objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex <= 100.0)
                    {
                        _objectsService.RNDFormulations.Forms.FormAr[ifo].IsocyanuratePbw = 0;

                        temp1 = 0.01 * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex * (_objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide - 2.0);
                        if (temp1 > 0.0)
                            _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = 0.5 * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPOSide / 56100.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide * temp1;
                        temp2 = _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide - 2.0;
                        if (temp2 > 0)
                            _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity += 0.5 * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide / 4200.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide * temp2;

                        temp1 = _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide + _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide;
                        _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity / temp1 * 1000.0;
                    }

                    else
                    {
                        _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = 0;
                        dsumPbw = (_objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide + _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide);
                        if (dsumPbw > 0) _objectsService.RNDFormulations.Forms.FormAr[ifo].IsocyanuratePbw = 100.0 * (1.0 - 100.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex) * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide / dsumPbw;
                        else _objectsService.RNDFormulations.Forms.FormAr[ifo].IsocyanuratePbw = 0;

                        temp1 = _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide - 2.0;
                        if (temp1 > 0.0)
                            _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity += 0.5 * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPOSide / 56100.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide * temp1;
                        temp2 = (_objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide - 2.0) * 100 / _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex;
                        if (temp2 > 0)
                            _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity += 0.5 * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide / 4200.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide * temp2;
                        temp3 = 3 * (_objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide - 1.0) * (1 - 100 / _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex) * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide;
                        if (temp3 > 0.0)
                            _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity += 0.5 * temp3 * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide / 4200.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide / 3.0;

                        _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity / dsumPbw * 1000.0;

                    }

                    /*

                                        if (_objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex <= 100.0)
                                        {
                                            _objectsService.RNDFormulations.Forms.FormAr[ifo].IsocyanuratePbw100 = 0;

                                            temp1 = 0.01 * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex * _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide - 2.0;
                                            if (temp1 > 0.0)
                                                _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = 0.5 * _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPOSide / 56100.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide * temp1;
                                            temp2 = _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide - 2.0;
                                            if (temp2 > 0)
                                                _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = 0.5 * _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide / 4200.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide * temp2;

                                            temp1 = _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide + _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide;
                                            _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity / temp1 * 1000.0;
                                        }

                                        else
                                        {
                                            dsumPbw = (_objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide + _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide);
                                            if (dsumPbw > 0) _objectsService.RNDFormulations.Forms.FormAr[ifo].IsocyanuratePbw100 = 100.0 * (1.0 - 100.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex) * _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide / dsumPbw;
                                            else _objectsService.RNDFormulations.Forms.FormAr[ifo].IsocyanuratePbw100 = 0;

                                            temp1 = _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide - 2.0;
                                            if (temp1 > 0.0)
                                                _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = 0.5 * _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].OHNumPOSide / 56100.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvPOSide * temp1;
                                            temp2 = (_objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide - 2.0) * 100 / _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex;
                                            if (temp2 > 0)
                                                _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = 0.5 * _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide / 4200.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide * temp2;
                                            temp3 = 3 * (_objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide - 1.0) * (1 - 100 / _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIndex) * _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide;
                                            if (temp3 > 0.0)
                                                _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = 0.5 * temp3 * _objectsService.RNDFormulations.Forms.FormAr[ifo].NcoIsoSide / 4200.0 / _objectsService.RNDFormulations.Forms.FormAr[ifo].FuncAvIsoSide / 3.0;

                                            temp1 = _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwPOSide + _objectsService.RNDFormulations.Forms.FormAr[ifo].BasisPbwIsoSide;
                                            _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity = _objectsService.RNDFormulations.Forms.FormAr[ifo].CrosslinkDensity / temp1 * 1000.0;

                                        }
                    */


                }

                //Calculate the density

                for (ifo = 0; ifo < _objectsService.RNDFormulations.Forms.nForm; ifo++)
                {
                    temp1 = temp2 = temp3 = 0;
                    for (ico = 0; ico < _objectsService.RNDFormulations.Forms.POMats.Count; ico++)
                    {
                        if (_objectsService.RNDFormulations.Forms.POMats[ico].GassToLiqWtRatio > 0)
                        {
                            temp2 = temp2 + _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] * _objectsService.RNDFormulations.Forms.POMats[ico].GassToLiqWtRatio; // gas weight
                            temp3 = temp3 + 413.0 / 273.0 * 22.41 * _objectsService.RNDFormulations.Forms.FormAr[ifo].POMatPbw[ico] * _objectsService.RNDFormulations.Forms.POMats[ico].GassToLiqWtRatio / _objectsService.RNDFormulations.Forms.POMats[ico].GassMolWt; //STP Gas vol = 22.41 m3/kg-mole
                        }

                    }


                    _objectsService.RNDFormulations.Forms.FormAr[ifo].FoamDensity = Params.PolymerDensity;
                    temp1 = _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide + _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwIsoSide;    //Total wt
                    temp3 = temp3 + (temp1 - temp2) / Params.PolymerDensity;   //gas volume + polymer volume
                    if (temp3 > 0.0) _objectsService.RNDFormulations.Forms.FormAr[ifo].FoamDensity = temp1 / temp3;

                    if (temp1 * _objectsService.RNDFormulations.Forms.FormAr[ifo].TotalPbwPOSide > 0.0)
                    {
                        _objectsService.RNDFormulations.Forms.FormAr[ifo].BlowingAgentWtFr = _objectsService.RNDFormulations.Forms.FormAr[ifo].BlowingAgentWtFr / temp1 * 100.0;  //Convert Blowing Agent wt to fraction
                        _objectsService.RNDFormulations.Forms.FormAr[ifo].CatalystWtFr = _objectsService.RNDFormulations.Forms.FormAr[ifo].CatalystWtFr / temp1 * 100.0;  //Convert Blowing Agent wt to fraction
                        _objectsService.RNDFormulations.Forms.FormAr[ifo].SurfactWtFr = _objectsService.RNDFormulations.Forms.FormAr[ifo].SurfactWtFr / temp1 * 100.0;  //Convert Blowing Agent wt to fraction
                        _objectsService.RNDFormulations.Forms.FormAr[ifo].WaterWtFr = _objectsService.RNDFormulations.Forms.FormAr[ifo].WaterWtFr / temp1 * 100.0;  //Convert Blowing Agent wt to fraction
                        _objectsService.RNDFormulations.Forms.FormAr[ifo].BlowingAgentWtFr1 = _objectsService.RNDFormulations.Forms.FormAr[ifo].BlowingAgentWtFr1 / temp1 * 100.0;  //Convert Blowing Agent wt to fraction

                    }

                }


            }
            catch (Exception ex) { sMsg = "Error in calculating formulation descriptors";
                //MessageBox.Show(sMsg, Cbfile.sAppName); CTelClient.TelException(ex, sMsg); 
            }
        }

        #region Set Fields

        public void SetDoubleField(string sText, string sField)
        {
            double dtmp;

            if (String.IsNullOrEmpty(sText)) _objectsService.RNDHome.drS[sField] = DBNull.Value;
            else
            {
                if (double.TryParse(sText, out dtmp)) _objectsService.RNDHome.drS[sField] = dtmp;
                else _objectsService.RNDHome.drS[sField] = DBNull.Value;
            }

        }

        public void SetIntField(string sText, string sField)
        {
            int itmp;

            if (String.IsNullOrEmpty(sText)) _objectsService.RNDHome.drS[sField] = DBNull.Value;
            else
            {
                if (int.TryParse(sText, out itmp)) _objectsService.RNDHome.drS[sField] = itmp;
                else _objectsService.RNDHome.drS[sField] = DBNull.Value;
            }

        }

        public string SetIntTextField(string sField)
        {
            string s = String.Empty;
            if (!(_objectsService.RNDHome.drS[sField] == DBNull.Value)) s = ((int)_objectsService.RNDHome.drS[sField]).ToString();
            return s;
        }
        public string SetDoubleTextField(string sField, string sForm = RNDFormulations.sDef)
        {
            string s = String.Empty;
            if (!(_objectsService.RNDHome.drS[sField] == DBNull.Value)) s = ((double)_objectsService.RNDHome.drS[sField]).ToString(sForm);
            return s;
        }

       //public IActionResult OnPostGPO_LoadingRow()
       // {
       //     IEditableCollectionView itemsView = this.gPO;
       //     if (this.gPO.Count == 29 + 1 && itemsView.IsAddingNew == true)
       //     {
       //         // Commit the current one added by the user
       //         itemsView.CommitNew();

       //         // Once the adding transaction is commit the user cannot add an other one
       //         //this.gPO.CanUserAddRows = false;
       //     }
       //    return new JsonResult(true);
       // }



        public DateTime SetDateTimeField(string sField)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            if (!(_objectsService.RNDHome.drS[sField] == DBNull.Value)) dt = (DateTime)_objectsService.RNDHome.drS[sField];
            return dt;
        }

       //public IActionResult OnPostGPO_AddARow()
       // {
       //     if (this.gPO.Items.Count > 28)
       //     {
       //       //  MessageBox.Show("Cannot add another row", Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Warning); return;
       //     }

       //     _objectsService.RNDFormulations.Forms.POMats.Add(new CMaterial());
       //     _objectsService.RNDHome.drS["PORows"] = this.gPO.Items.Count;
       //     _objectsService.RNDHome.UpdateDataSet();
       //     return new JsonResult(true);
       // }

        public string SetTimeField(string sField)
        {
            string s = String.Empty;
            if (!(_objectsService.RNDHome.drS[sField] == DBNull.Value)) s = ((DateTime)_objectsService.RNDHome.drS[sField]).ToString("HH:mm:ss");
            return s;
        }

        #endregion

        #region Lost Focus and Other Actions

       //public IActionResult OnPostGenInfo_LF(string Name,string Value)
       // {
       //     string sFld = String.Empty;
       //     string sName = Name;

       //     _objectsService.RNDFormulations.bDataSetChanged = true;

       //     switch (sName)
       //     {
       //         case "gStudyName":
       //             if (gStudyName == null) { _objectsService.RNDHome.drS["Study Name"] = DBNull.Value; _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["Study Name"] = string.Empty; }
       //             else { _objectsService.RNDHome.drS["Study Name"] = _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["Study Name"] = gStudyName; }
       //             _objectsService.gRNDSearch.ItemsSource = _objectsService.RNDHome.dt.DefaultView;
       //             break;

       //         case "gChemist":
       //             if (gChemistSelectedValue == null) { _objectsService.RNDHome.drS["Chemist"] = DBNull.Value; _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["Chemist"] = string.Empty; }
       //             else { _objectsService.RNDHome.drS["Chemist"] = (int)gChemistSelectedValue; _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["Chemist"] = gChemist; }
       //             CPages.PageRndHome_1.gRNDSearch.ItemsSource = _objectsService.RNDHome.dt.DefaultView;
       //             break;

       //         case "gOperator":
       //             if (gOperatorSelectedValue == null) { _objectsService.RNDHome.drS["Operator"] = DBNull.Value; _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["Operator"] = string.Empty; }
       //             else { _objectsService.RNDHome.drS["Operator"] = (int)gOperatorSelectedValue; _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["Operator"] = gOperator; }
       //             break;

       //         case "gProductID":
       //             if (gProductIDSelectedValue == null) { _objectsService.RNDHome.drS["Product ID"] = DBNull.Value; _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["Product ID"] = string.Empty; }
       //             else { _objectsService.RNDHome.drS["Product ID"] = gProductIDSelectedValue; _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["Product ID"] = gProductIDSelectedValue; }
       //             break;

       //         case "gStudyType":
       //             if (gStudyTypeSelectedValue == null) { _objectsService.RNDHome.drS["Study Type"] = DBNull.Value; }
       //             else { _objectsService.RNDHome.drS["Study Type"] = (int)gStudyTypeSelectedValue; }; break;

       //         case "gDateDSCreated":
       //             if (gDateDSCreated == null) { _objectsService.RNDHome.drS["DateDSCreated"] = DBNull.Value; _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["DateDSCreated"] = DBNull.Value; }
       //             else { _objectsService.RNDHome.drS["DateDSCreated"] = gDateDSCreated; _objectsService.RNDHome.dt.Rows[_objectsService.RNDHome.indSet]["DateDSCreated"] = gDateDSCreated; }
       //             break;

       //         case "gAbandoned": if (gAbandonedIsChecked == true) _objectsService.RNDHome.drS["Abandoned"] = true; else _objectsService.RNDHome.drS["Abandoned"] = false; break;
       //     }
       //     _objectsService.RNDHome.UpdateDataSet();
       //     return new JsonResult(true);
       // }

       public  IActionResult OnPostVisibility_LF()
        {
            return new JsonResult(true);
        }

        public IActionResult OnPostGPO_SelectionChanged()
        {
            //          DataGridRow row = (DataGridRow) gPO.SelectedItem;
            //          MessageBox.Show(row.GetIndex().ToString());
            return new JsonResult(true);
        }



        #endregion

        #region read formulation data for new dataset
        public void ReadDataset()
        {
            int id, iSel, j, nRows, itmp;
            double dtmp;

            char[] delimiterChars = new char[] { ' ', ',', ':', '\t' };

            if (_objectsService.RNDHome.drS["PORows"] != DBNull.Value) 
                nRows = (int)_objectsService.RNDHome.drS["PORows"];
            else nRows = 3;
            _objectsService.RNDFormulations.Forms.POMats.Clear();
            for (int i = 0; i < nRows; i++) _objectsService.RNDFormulations.Forms.POMats.Add(new CMaterial());

            //Read PO dataset and PO side formulation
            if (_objectsService.RNDHome.drS["POMats"] != DBNull.Value)
            {
                string[] strParts = _objectsService.RNDHome.drS["POMats"].ToString().Split(delimiterChars);
                if (nRows > strParts.Length) nRows = strParts.Length;
                for (int i = 0; i < nRows; i++) //Grid by default adds an extra row sometime
                {
                    id = int.Parse(strParts[i]);
                    iSel = FindIndex(id, _objectsService.RNDFormulations.dtPO);
                    _objectsService.RNDFormulations.ModifyPOIsoLists(i, ref _objectsService.RNDFormulations.Forms.POMats, iSel, _objectsService.RNDFormulations.dtPO);
                }
                /*
                                id = int.Parse(strParts[nRows-1]);
                                iSel = FindIndex(id, dtPO);
                                if(iSel > 0)
                                {
                                    _objectsService.RNDFormulations.Forms.POMats.Add(new CMaterial());
                                    ModifyPOIsoLists(_objectsService.RNDFormulations.Forms.POMats.Count-1, ref _objectsService.RNDFormulations.Forms.POMats, iSel, dtPO);
                                }
                */
            }

            //Ajust for the user assigned OH numbers

            if (_objectsService.RNDHome.drS["sPOMatsOH"] != DBNull.Value)
            {
                string[] strParts = _objectsService.RNDHome.drS["sPOMatsOH"].ToString().Split(delimiterChars);
                if (nRows > strParts.Length) nRows = strParts.Length;
                for (int i = 0; i < nRows - 1; i++) //Grid by default adds an extra row sometime
                {
                    if (double.TryParse(strParts[i], out dtmp)) _objectsService.RNDFormulations.Forms.POMats[i].MatOHNum = dtmp;
                }
            }

            //Set pbws


            string sPOf = "0.0", stmp;
            for (int i = 0; i < _objectsService.RNDHome.dtF.Rows.Count; i++)
            {
                for (j = 0; j < _objectsService.RNDFormulations.Forms.FormAr[i].POMatPbw.Length; j++) _objectsService.RNDFormulations.Forms.FormAr[i].POMatPbw[j] = 0.0;
                if (_objectsService.RNDHome.dtF.Rows[i]["POPbws"] != DBNull.Value)
                {
                    _objectsService.RNDFormulations.Forms.FormAr[i].POMatPbw = System.Text.Json.JsonSerializer.Deserialize<double[]>((string)_objectsService.RNDHome.dtF.Rows[i]["POPbws"]);
                    switch (i)
                    {

                        case (0):
                            for (j = 0; j < nRows; j++)
                            { if (_objectsService.RNDFormulations.Forms.FormAr[0].POMatPbw[j] > 0) stmp = (_objectsService.RNDFormulations.Forms.FormAr[0].POMatPbw[j]).ToString(sPOf); else stmp = string.Empty; _objectsService.RNDFormulations.Forms.POMats[j].Pbw1 = stmp; }
                            break;

                        case (1):
                            for (j = 0; j < nRows; j++)
                            { if (_objectsService.RNDFormulations.Forms.FormAr[1].POMatPbw[j] > 0) stmp = (_objectsService.RNDFormulations.Forms.FormAr[1].POMatPbw[j]).ToString(sPOf); else stmp = string.Empty; _objectsService.RNDFormulations.Forms.POMats[j].Pbw2 = stmp; }
                            break;
                        case (2):
                            for (j = 0; j < nRows; j++)
                            { if (_objectsService.RNDFormulations.Forms.FormAr[2].POMatPbw[j] > 0) stmp = (_objectsService.RNDFormulations.Forms.FormAr[2].POMatPbw[j]).ToString(sPOf); else stmp = string.Empty; _objectsService.RNDFormulations.Forms.POMats[j].Pbw3 = stmp; }
                            break;
                        case (3):
                            for (j = 0; j < nRows; j++)
                            { if (_objectsService.RNDFormulations.Forms.FormAr[3].POMatPbw[j] > 0) stmp = (_objectsService.RNDFormulations.Forms.FormAr[3].POMatPbw[j]).ToString(sPOf); else stmp = string.Empty; _objectsService.RNDFormulations.Forms.POMats[j].Pbw4 = stmp; }
                            break;
                        case (4):
                            for (j = 0; j < nRows; j++)
                            { if (_objectsService.RNDFormulations.Forms.FormAr[4].POMatPbw[j] > 0) stmp = (_objectsService.RNDFormulations.Forms.FormAr[4].POMatPbw[j]).ToString(sPOf); else stmp = string.Empty; _objectsService.RNDFormulations.Forms.POMats[j].Pbw5 = stmp; }
                            break;
                        case (5):
                            for (j = 0; j < nRows; j++)
                            { if (_objectsService.RNDFormulations.Forms.FormAr[5].POMatPbw[j] > 0) stmp = (_objectsService.RNDFormulations.Forms.FormAr[5].POMatPbw[j]).ToString(sPOf); else stmp = string.Empty; _objectsService.RNDFormulations.Forms.POMats[j].Pbw6 = stmp; }
                            break;
                        case (6):
                            for (j = 0; j < nRows; j++)
                            { if (_objectsService.RNDFormulations.Forms.FormAr[6].POMatPbw[j] > 0) stmp = (_objectsService.RNDFormulations.Forms.FormAr[6].POMatPbw[j]).ToString(sPOf); else stmp = string.Empty; _objectsService.RNDFormulations.Forms.POMats[j].Pbw7 = stmp; }
                            break;
                        case (7):
                            for (j = 0; j < nRows; j++)
                            { if (_objectsService.RNDFormulations.Forms.FormAr[7].POMatPbw[j] > 0) stmp = (_objectsService.RNDFormulations.Forms.FormAr[7].POMatPbw[j]).ToString(sPOf); else stmp = string.Empty; _objectsService.RNDFormulations.Forms.POMats[j].Pbw8 = stmp; }
                            break;

                            /*
                                                    case (0): for (j = 0; j < nRows; j++) _objectsService.RNDFormulations.Forms.POMats[j].Pbw1 = _objectsService.RNDFormulations.Forms.FormAr[0].POMatPbw[j]; break;
                                                    case (1): for (j = 0; j < nRows; j++) _objectsService.RNDFormulations.Forms.POMats[j].Pbw2 = _objectsService.RNDFormulations.Forms.FormAr[1].POMatPbw[j]; break;
                                                    case (2): for (j = 0; j < nRows; j++) _objectsService.RNDFormulations.Forms.POMats[j].Pbw3 = _objectsService.RNDFormulations.Forms.FormAr[2].POMatPbw[j]; break;
                                                    case (3): for (j = 0; j < nRows; j++) _objectsService.RNDFormulations.Forms.POMats[j].Pbw4 = _objectsService.RNDFormulations.Forms.FormAr[3].POMatPbw[j]; break;
                                                    case (4): for (j = 0; j < nRows; j++) _objectsService.RNDFormulations.Forms.POMats[j].Pbw5 = _objectsService.RNDFormulations.Forms.FormAr[4].POMatPbw[j]; break;
                                                    case (5): for (j = 0; j < nRows; j++) _objectsService.RNDFormulations.Forms.POMats[j].Pbw6 = _objectsService.RNDFormulations.Forms.FormAr[5].POMatPbw[j]; break;
                                                    case (6): for (j = 0; j < nRows; j++) _objectsService.RNDFormulations.Forms.POMats[j].Pbw7 = _objectsService.RNDFormulations.Forms.FormAr[6].POMatPbw[j]; break;
                                                    case (7): for (j = 0; j < nRows; j++) _objectsService.RNDFormulations.Forms.POMats[j].Pbw8 = _objectsService.RNDFormulations.Forms.FormAr[7].POMatPbw[j]; break;
                            */
                    }
                }
            }

            //Read Iso Section

            nRows = 1;
            _objectsService.RNDFormulations.Forms.IsoMats.Clear();
            for (int i = 0; i < nRows; i++) _objectsService.RNDFormulations.Forms.IsoMats.Add(new CMaterial());

            if (_objectsService.RNDHome.drS["IsoMats"] != DBNull.Value)
            {
                id = (int)_objectsService.RNDHome.drS["IsoMats"];
                iSel = FindIndex(id, _objectsService.RNDFormulations.dtIso);
                _objectsService.RNDFormulations.ModifyPOIsoLists(0, ref _objectsService.RNDFormulations.Forms.IsoMats, iSel, _objectsService.RNDFormulations.dtIso);
            }
            if (_objectsService.RNDHome.drS["sIsoMatsNCO"] != DBNull.Value)  //Adjust NCO for user entered #
                if (double.TryParse(_objectsService.RNDHome.drS["sIsoMatsNCO"].ToString(), out dtmp)) _objectsService.RNDFormulations.Forms.IsoMats[0].MatNco = dtmp;

            for (int i = 0; i < _objectsService.RNDHome.dtF.Rows.Count; i++)
            {
                if (_objectsService.RNDHome.dtF.Rows[i]["NCOIndex"] != DBNull.Value) _objectsService.RNDFormulations.Forms.FormAr[i].NcoIndex = (double)_objectsService.RNDHome.dtF.Rows[i]["NCOIndex"];
                else _objectsService.RNDFormulations.Forms.FormAr[i].NcoIndex = 270;
            }
            _objectsService.RNDFormulations.Forms.NCOIndexMats[0].Pbw1 = (_objectsService.RNDFormulations.Forms.FormAr[0].NcoIndex).ToString(sPOf);
            _objectsService.RNDFormulations.Forms.NCOIndexMats[0].Pbw2 = (_objectsService.RNDFormulations.Forms.FormAr[1].NcoIndex).ToString(sPOf);
            _objectsService.RNDFormulations.Forms.NCOIndexMats[0].Pbw3 = (_objectsService.RNDFormulations.Forms.FormAr[2].NcoIndex).ToString(sPOf);
            _objectsService.RNDFormulations.Forms.NCOIndexMats[0].Pbw4 = (_objectsService.RNDFormulations.Forms.FormAr[3].NcoIndex).ToString(sPOf);
            _objectsService.RNDFormulations.Forms.NCOIndexMats[0].Pbw5 = (_objectsService.RNDFormulations.Forms.FormAr[4].NcoIndex).ToString(sPOf);
            _objectsService.RNDFormulations.Forms.NCOIndexMats[0].Pbw6 = (_objectsService.RNDFormulations.Forms.FormAr[5].NcoIndex).ToString(sPOf);
            _objectsService.RNDFormulations.Forms.NCOIndexMats[0].Pbw7 = (_objectsService.RNDFormulations.Forms.FormAr[6].NcoIndex).ToString(sPOf);
            _objectsService.RNDFormulations.Forms.NCOIndexMats[0].Pbw8 = (_objectsService.RNDFormulations.Forms.FormAr[7].NcoIndex).ToString(sPOf);

            SetView();
        }

        public static int FindIndex(int id, DataTable dt)
        {
            int index = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
                if ((int)dt.Rows[i]["ID"] == id) return i;
            return index;
        }
        #endregion
    }
}
