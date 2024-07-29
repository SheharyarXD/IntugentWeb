using Google.Api.Gax;
using Google.Apis.Bigquery.v2.Data;
using IntugentClassLbrary.Pages;
using IntugentClassLibrary.Classes;
using IntugentWebApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace IntugentWebApp.Pages.Admin_Group
{
    public class AIHomeModel : PageModel
    {
        public ObjectsService _objectsService;
        public DataView gModels {  get; set; }
        public int gModelsSelectedIndex {  get; set; }
        public AIHomeModel(ObjectsService objectsService)
        {
            _objectsService = objectsService;
            _objectsService.gInputIndex = 0;
        }
        public void OnGet()
        {
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
            PerformInitialSearch();
            _objectsService.CNNData.ReadData(_objectsService.CDBase);
        }
        public bool bInitialSearchDone = false;
        //DispatcherTimer dispTimer;


        public void PerformInitialSearch()
        {
            if (_objectsService.CDBase.SearchDatabase(string.Empty) && _objectsService.CDBase.dt.Rows.Count > 0)
            {
                int itmp;

                _objectsService.CDBase.IndexModel = 0;
                gModelsSelectedIndex = _objectsService.CDBase.IndexModel;
                gModels = _objectsService.CDBase.dt.DefaultView;
                _objectsService.CDBase.dr = _objectsService.CDBase.dt.Rows[_objectsService.CDBase.IndexModel];
                _objectsService.CDBase.IDModel = (int)_objectsService.CDBase.dr["ID"];
                EnablesAIPages(true);
                bInitialSearchDone = true;

            }
            else EnablesAIPages(false);
        }

        //private void OnPageLoaded(object sender, RoutedEventArgs e)
        //{
        //    //           if(gModels.Items.Count > 0)  gModels.SelectedIndex = 0;
        //    //            _objectsService.CDBase.IndexModel = gModels.SelectedIndex;
        //    //           _objectsService.CDBase.dr = _objectsService.CDBase.dt.Rows[_objectsService.CDBase.IndexModel];
        //    //            _objectsService.CDBase.IDModel = (int)_objectsService.CDBase.dr["ID"];
        //    //            CNNData.ReadData();

        //    if (!bInitialSearchDone) dispTimer = new DispatcherTimer(//It will not wait after the application is idle.
        //              TimeSpan.Zero,
        //              //It will wait until the application is idle
        //              DispatcherPriority.ApplicationIdle,
        //              //It will call this when the app is idle
        //              dispatcherTimer_Tick,
        //        //On the UI thread
        //              Application.Current.Dispatcher);
        //}

        //private static void dispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    CPages.PageAIHome_1.PerformInitialSearch(); //Now the UI is really shown, do your computations
        //    CPages.PageAIHome_1.dispTimer.Stop();
        //}





        public void SetView()
        {
            if (_objectsService.CDBase.IndexModel >= 0 && gModels.Count > 0)
            {
              //  gModels.ScrollIntoView(gModels.Items[gModelsSelectedIndex]);
            }
        }

        public IActionResult OnPostGNewAIModel_Click()
        {
            if (_objectsService.CDBase.CreateNewModel()) { gModelsSelectedIndex = _objectsService.CDBase.IndexModel; gModels = _objectsService.CDBase.dt.DefaultView; }
            return new JsonResult(true);
        }

        public IActionResult OnPostGModelsSC(int gModelsSelectedIndex)
        {
            gModels = _objectsService.CDBase.dt.DefaultView;
            if (gModels == null 
                //|| CPages.PageModel_1 == null
                ) return new JsonResult(false);
            if (gModels.Count > 0 && gModelsSelectedIndex > -1)
            {
                _objectsService.CDBase.IndexModel = gModelsSelectedIndex;
                for(int i=0;i< _objectsService.CDBase.dt.Rows.Count;i++)
                {
                    if(gModelsSelectedIndex== Int32.Parse(_objectsService.CDBase.dt.Rows[i]["ID"].ToString()))
                    {
                  _objectsService.CDBase.dr = _objectsService.CDBase.dt.Rows[i];


                    }
                }
                _objectsService.CDBase.IDModel = (int)_objectsService.CDBase.dr["ID"];
                //Mouse.OverrideCursor = Cursors.Wait;

               // CStatusBar.SetText("Reading data file.");
               _objectsService.CNNData.ReadData(_objectsService.CDBase);

                //  CStatusBar.SetText("Finished Reading data file.");
                // Mouse.OverrideCursor = null;

            }
            return new JsonResult(_objectsService.CDBase.IndexModel);

        }
        public static void EnablesAIPages(bool bEn)
        {
            //((MainWindow)Application.Current.MainWindow).gsAIModel.IsEnabled = bEn;
            //((MainWindow)Application.Current.MainWindow).gsAIData.IsEnabled = bEn;

        }
    }
}
