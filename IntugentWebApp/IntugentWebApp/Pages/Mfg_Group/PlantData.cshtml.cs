using IntugentClassLbrary.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Google.Cloud.BigQuery.V2;
using Google.Apis.Auth.OAuth2;
using System.Data;
using System.Runtime.Serialization;
using System;
using IntugentWebApp.Utilities;
using IntugentClassLibrary.Pages.Mfg;
using System.Xml.Linq;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace IntugentWebApp.Pages.Mfg_Group
{
    public class Plant_DataModel : PageModel
    {
        public string gID { get; set; }
        public string gProductionDate { get; set; }
        public string gProductionTime { get; set; }
        public string gQCCheckTime { get; set; }
        public string gFBTime { get; set; }
        public string gDelTimeButton { get; set; }
        public string gProductCode { get; set; }
        public bool gDataSetNextIsEnabled {  get; set; }
        public bool gDataSetPrevIsEnabled {  get; set; }
        public bool gGetPlantDataIsEnabled {  get; set; }
        public DataTable gChemDel { get; private set; }
        public DataTable gChemDel1 { get; private set; }
        public DataTable gPTable { get; private set; }
        public DataTable gDBelt { get; private set; }
        public DataTable gOthers { get; private set; }
        public DataTable gNewInsData { get; private set; }

        private readonly ObjectsService _objectsService;
        public Plant_DataModel(ObjectsService objectsService)
        {
            _objectsService = objectsService;
        }
        public void OnGet()
        {

            string s, sn; double dtemp;
            _objectsService.MfgPlantsData.GetDataSet();


            //           if (!GetDataSet()) return;

            SetView();


            /*
                        string jsonPath = @"G:\My Drive\Intugent Software\InsulationFoams\Data Files\myprojectasjad-924ee97d126f.json";
                        var credentials = GoogleCredential.FromFile(jsonPath);

                        BigQueryClient client = BigQueryClient.Create("MyProjectAsjad", credentials);
                        string query = @"
                        SELECT name FROM `bigquery-public-data.usa_names.usa_1910_2013`
                        WHERE state = 'TX'
                        LIMIT 100";
                        BigQueryJob job = client.CreateQueryJob(
                            sql: query,
                            parameters: null,

                            options: new QueryOptions { UseQueryCache = false });
                        // Wait for the job to complete.
                        job = job.PollUntilCompleted().ThrowOnAnyError();
                        // Display the results
                        foreach (BigQueryRow row in client.GetQueryResults(job.Reference))
                        {
                            MessageBox.Show($"{row["name"]}");
                        }
            */
        }
        public void SetView()
        {
            bool bTimeStampsWithin5Min = true;
            _objectsService.MfgPlantsData.drIP = _objectsService.MfgInProcess.dr;
            _objectsService.MfgPlantsData.drFG = _objectsService.MfgFinishedGoods.dr;

            gID = _objectsService.MfgPlantsData.dr["ID4ALL"].ToString();
            if (_objectsService.Cbfile.iIDMfgIndex == 0) gDataSetNextIsEnabled = false; else gDataSetNextIsEnabled = true;
            if (_objectsService.Cbfile.iIDMfgIndex == _objectsService.MfgHome.dt.Rows.Count - 1) gDataSetPrevIsEnabled = false; else gDataSetPrevIsEnabled = true;

            if (_objectsService.MfgPlantsData.drIP["Test Date"] == DBNull.Value) gProductionDate = String.Empty; else gProductionDate  = ((DateTime)_objectsService.MfgPlantsData.drIP["Test Date"]).ToString("yyyy-MM-ddTHH:mm");
            if (_objectsService.MfgPlantsData.drIP["Product ID"] == DBNull.Value) gProductCode= String.Empty; else gProductCode  = _objectsService.MfgPlantsData.drIP["Product ID"].ToString();
            gDelTimeButton = "* The two Board Time Stamps must be within " + _objectsService.CDefualts.dDelTimeButton.ToString() + " minute(s) (site specific) of each other to extract process data." +
                " The data will be averaged over a " + _objectsService.CDefualts.dDelTimeCalc.ToString() + " minute (site specific) window around the FG Board Time Stamp.";


            _objectsService.MfgPlantsData.dtFGTime = DateTime.Now; _objectsService.MfgPlantsData.dtIPTime = _objectsService.MfgPlantsData.dtFGTime.AddDays(10); _objectsService.MfgPlantsData.dtQCCheckTime = _objectsService.MfgPlantsData.dtFGTime.AddDays(-10);
            if (_objectsService.MfgPlantsData.drIP["Test Date"] == DBNull.Value) { bTimeStampsWithin5Min = false; gProductionTime  = String.Empty; } else { _objectsService.MfgPlantsData.dtIPTime = (DateTime)_objectsService.MfgPlantsData.drIP["Test Date"]; gProductionTime  = _objectsService.MfgPlantsData.dtIPTime.ToString("yyyy-MM-ddTHH:mm"); }
            if (_objectsService.MfgPlantsData.drIP["Time of Pour Table QC Check"] == DBNull.Value) { gQCCheckTime  = String.Empty; } else { _objectsService.MfgPlantsData.dtQCCheckTime = (DateTime)_objectsService.MfgPlantsData.drIP["Time of Pour Table QC Check"]; gQCCheckTime  = _objectsService.MfgPlantsData.dtQCCheckTime.ToString("HH:mm:ss"); }
            if (_objectsService.MfgPlantsData.drFG["Finished Board Time Stamp FG"] == DBNull.Value) { bTimeStampsWithin5Min = false; gFBTime  = String.Empty; } else { _objectsService.MfgPlantsData.dtFGTime = (DateTime)_objectsService.MfgPlantsData.drFG["Finished Board Time Stamp FG"]; gFBTime  = _objectsService.MfgPlantsData.dtFGTime.ToString("yyyy-MM-ddTHH:mm"); }

            if (bTimeStampsWithin5Min)
            {
                //               if (Math.Abs((dtIPTime.TimeOfDay - dtFGTime.TimeOfDay).TotalMinutes) > CDefualts.dDelTimeButton) bTimeStampsWithin5Min = false;
                if (Math.Abs((_objectsService.MfgPlantsData.dtIPTime - _objectsService.MfgPlantsData.dtFGTime).TotalMinutes) > _objectsService.CDefualts.dDelTimeButton) bTimeStampsWithin5Min = false;
            }
            if (bTimeStampsWithin5Min) gGetPlantDataIsEnabled = true; else gGetPlantDataIsEnabled = false;

            //          if (_objectsService.MfgPlantsData.drIP["Test Date"] != DBNull.Value) dtFGTime = ((DateTime)_objectsService.MfgPlantsData.drIP["Test Date"]).Date + dtFGTime.TimeOfDay;  //Assuming same date for the inprocess board and finished good board
          

            gChemDel = _objectsService.MfgPlantsData.dtPPChemDel;
            gChemDel1 =  _objectsService.MfgPlantsData.dtPPChemDel1;
            gPTable =    _objectsService.MfgPlantsData.dtPPPTable;
            gDBelt =     _objectsService.MfgPlantsData.dtPPDBelt;
            gOthers =    _objectsService.MfgPlantsData.dtPPOthers;
            gNewInsData =_objectsService.MfgPlantsData.dtNewInsData;

        }
        public IActionResult OnPostGetPlantData_Click()
        {
          //  Mouse.OverrideCursor = Cursors.Wait;
            _objectsService.MfgPlantsData.GetPlantData(_objectsService.MfgPlantsData.dtFGTime);
           // Mouse.OverrideCursor = null;
           // CStatusBar.SetText("Data Saved at " + DateTime.Now.ToString("hh:mm:ss tt"));
            return new JsonResult(true);
        }
        public async void GetPlantDataBackground(DateTime dateTime)
        {
            _objectsService.Cbfile.bCanSwitchRecord = false;
           // CStatusBar.SetText("Pulling process data for dataset " + _objectsService.Cbfile.iIDMfg.ToString());
            string sRet = await Task.Run(() => _objectsService.MfgPlantsData.GetPlantData(dateTime));
            _objectsService.Cbfile.bCanSwitchRecord = true;
           // CStatusBar.SetText("Finished pulling process data for dataset " + _objectsService.Cbfile.iIDMfg.ToString());
            return;
        }
        public IActionResult OnPostNavigateDataSet(string direction)
        {
            if (!_objectsService.Cbfile.bCanSwitchRecord)
            {
                //   MessageBox.Show(Cbfile.sNoRecSwitchMsg, Cbfile.sAppName);
                return new JsonResult(new { success = false, message = "Cannot switch record" });

            }

            switch (direction)
            {
                case "prev":
                    _objectsService.Cbfile.iIDMfgIndex += 1;
                    break;
                case "next":
                    _objectsService.Cbfile.iIDMfgIndex -= 1;
                    break;
                default:
                    return new JsonResult(new { success = false, message = "Invalid direction" });
            }

            if (_objectsService.Cbfile.iIDMfgIndex < 0)
            {
                _objectsService.Cbfile.iIDMfgIndex = 0;
            }

            if (_objectsService.Cbfile.iIDMfgIndex > _objectsService.MfgHome.dt.Rows.Count - 1)
            {
                _objectsService.Cbfile.iIDMfgIndex = _objectsService.MfgHome.dt.Rows.Count - 1;
            }

            UpdateDataSetView();
            return new JsonResult(new
            {
                success = true,
                newIndex = _objectsService.Cbfile.iIDMfgIndex
            });
        }
        private void UpdateDataSetView()
        {
            _objectsService.Cbfile.iIDMfg = (int)_objectsService.MfgHome.dt.Rows[_objectsService.Cbfile.iIDMfgIndex]["ID4All"];
            _objectsService.CLists.drEmployee["MfgIDSelected"] = _objectsService.Cbfile.iIDMfg;
            _objectsService.CLists.UpdateEmployee();

            (_objectsService.MfgInProcess, _objectsService.MfgFinishedGoods, _objectsService.MfgDimensionsStability, _objectsService.MfgPlantsData, _objectsService.MfgJetMixing) = _objectsService.MfgHome.GetAllMfgData(_objectsService.MfgInProcess, _objectsService.MfgFinishedGoods, _objectsService.MfgDimensionsStability, _objectsService.MfgPlantsData, _objectsService.MfgJetMixing);
            SetView();

            // Enable/disable buttons based on the index
            gDataSetNextIsEnabled = _objectsService.Cbfile.iIDMfgIndex < (_objectsService.MfgHome.dt.Rows.Count - 1);
            gDataSetPrevIsEnabled = _objectsService.Cbfile.iIDMfgIndex > 0;
        }
        /*
                public async void LongTaskButton_Click(object sender, RoutedEventArgs e)
                {
                    LongTaskButton.IsEnabled = false;
                    LongTaskTextBlock.Text = "Starting long task";

                    string result = "";
                    try
                    {
                        result = await Task.Run(() =>
                        {
                            Thread.Sleep(2000);
                            throw new Exception("Something crashed!");
                            return "Completed long task";
                        });
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                    }

                    LongTaskButton.IsEnabled = true;
                    LongTaskTextBlock.Text = result;
                }
        */
    }
}
