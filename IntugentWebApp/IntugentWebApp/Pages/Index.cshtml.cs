using IntugentClassLbrary.Classes;
using IntugentClassLbrary.Pages;
using IntugentClassLibrary.Classes;
using IntugentClassLibrary.Pages.Mfg;
using IntugentClassLibrary.Pages.Rnd;
using IntugentClassLibrary.Utilities;
using IntugentWebApp.Utilities;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;

namespace IntugentWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ObjectsService _objectsService;

        public IndexModel(ILogger<IndexModel> logger, ObjectsService objectsService)
        {
            _logger = logger;
            _objectsService = objectsService;
        }

        public void OnGet()
        {
            MainWindow mainWindow = new MainWindow();
            (_objectsService.CDefualts, _objectsService.CLists, _objectsService.Cbfile) = mainWindow.MainWindowConstructor();

            if (_objectsService.CDefualts != null && _objectsService.CLists != null && _objectsService.Cbfile != null)
            {
                SetOptionBoxes(_objectsService.CDefualts, _objectsService.CLists);

                CAnalysisData cAnalysis = new CAnalysisData(_objectsService.Cbfile, _objectsService.CDefualts);
                _objectsService.CAnalysisData1 = cAnalysis;
                
                MfgHome mfgHome = new MfgHome(_objectsService.CDefualts, _objectsService.CLists, _objectsService.Cbfile);
                _objectsService.MfgHome = mfgHome;

                MfgInProcess mfgInProcess = new MfgInProcess(_objectsService.Cbfile);
                _objectsService.MfgInProcess = mfgInProcess;

                MfgFinishedGoods mfgFinishedGoods =new MfgFinishedGoods(_objectsService.Cbfile);
                _objectsService.MfgFinishedGoods = mfgFinishedGoods;

                MfgDimStability mfgDimensionsStability = new MfgDimStability(_objectsService.Cbfile);
                _objectsService.MfgDimensionsStability = mfgDimensionsStability;

                MfgPlantData mfgPlantsData = new MfgPlantData(_objectsService.Cbfile, _objectsService.CLists,_objectsService.CDefualts);
                _objectsService.MfgPlantsData = mfgPlantsData;

                MfgJetMixing mfgJetMixing = new MfgJetMixing(_objectsService.CLists);
                _objectsService.MfgJetMixing = mfgJetMixing;

                MfgProcessCheck mfgProcessCheck =new MfgProcessCheck(_objectsService.Cbfile,_objectsService.CDefualts);
                _objectsService.MfgProcesscheck = mfgProcessCheck;

                MfgReports mfgReports = new MfgReports(_objectsService.Cbfile, _objectsService.CDefualts);
                _objectsService.MfgReport = mfgReports;

                RNDHome rNDHome = new RNDHome(_objectsService.CDefualts, _objectsService.CLists, _objectsService.Cbfile);
                _objectsService.RNDHome = rNDHome;
            }


        }

        public void SetOptionBoxes(CDefualts defualts, CLists lists)
        {
            DataRow dr;
            var bValid = true;
            int indx;


            lists.dvComProd = (lists.dtComProd.DefaultView).ToTable().DefaultView; //Make a copy
            dr = lists.dtComProd.NewRow();
            dr["Product Code"] = defualts.sProdMfgAll;
            dr["Product"] = defualts.sProdMfgAll;
            lists.dtComProd.Rows.InsertAt(dr, 0);
            lists.dvComProdAll = lists.dtComProd.DefaultView;
        }
        

    }
}