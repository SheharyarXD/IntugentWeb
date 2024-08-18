using Google.Api.Gax;
using IntugentClassLbrary.Classes;
using IntugentClassLbrary.Pages;
using IntugentClassLibrary.Classes;
using IntugentClassLibrary.Pages.Admins;
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
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ObjectsService _objectsService;
        public List<string> gGroup = new List<string>();

        public IndexModel(ILogger<IndexModel> logger, ObjectsService objectsService)
        {
            _logger = logger;
            _objectsService = objectsService;
        }
        public IActionResult OnPostGBeginSession_Click(string values)
        {
            int value = Int32.Parse(values);
            MainWindow mainWindow = new MainWindow();
            (_objectsService.CDefualts, _objectsService.CLists, _objectsService.Cbfile) = mainWindow.MainWindowConstructor(value);

            if (_objectsService.CDefualts != null && _objectsService.CLists != null && _objectsService.Cbfile != null)
            {
                SetOptionBoxes(_objectsService.CDefualts, _objectsService.CLists);
                
                CProdTargets cProdTargets = new CProdTargets(_objectsService.Cbfile,_objectsService.CDefualts);
                _objectsService.CProdTargets = cProdTargets;

                cMatrix cMatrix = new cMatrix();
                _objectsService.cMatrix = cMatrix;

                CDBase cDBase = new CDBase(_objectsService.Cbfile);
                _objectsService.CDBase = cDBase;


                CNNData cNNData = new CNNData(_objectsService.Cbfile);
                _objectsService.CNNData = cNNData;

                CNNModel cNNModel = new CNNModel(_objectsService.CNNData);
                _objectsService.CNNModel = cNNModel;



                CAnalysisData cAnalysis = new CAnalysisData(_objectsService.Cbfile, _objectsService.CDefualts);
                _objectsService.CAnalysisData1 = cAnalysis;

                MfgHome mfgHome = new MfgHome(_objectsService.CDefualts, _objectsService.CLists, _objectsService.Cbfile);
                _objectsService.MfgHome = mfgHome;

                MfgInProcess mfgInProcess = new MfgInProcess(_objectsService.Cbfile);
                _objectsService.MfgInProcess = mfgInProcess;

                CIPProdTargets cIPProdTargets = new CIPProdTargets(_objectsService.Cbfile, _objectsService.MfgInProcess);
                _objectsService.CIPProdTargets= cIPProdTargets;
                MfgFinishedGoods mfgFinishedGoods = new MfgFinishedGoods(_objectsService.Cbfile);
                _objectsService.MfgFinishedGoods = mfgFinishedGoods;

                MfgDimStability mfgDimensionsStability = new MfgDimStability(_objectsService.Cbfile);
                _objectsService.MfgDimensionsStability = mfgDimensionsStability;

                MfgPlantData mfgPlantsData = new MfgPlantData(_objectsService.Cbfile, _objectsService.CLists, _objectsService.CDefualts);
                _objectsService.MfgPlantsData = mfgPlantsData;

                MfgJetMixing mfgJetMixing = new MfgJetMixing(_objectsService.CLists);
                _objectsService.MfgJetMixing = mfgJetMixing;

                MfgProcessCheck mfgProcessCheck = new MfgProcessCheck(_objectsService.Cbfile, _objectsService.CDefualts);
                _objectsService.MfgProcesscheck = mfgProcessCheck;

                MfgReports mfgReports = new MfgReports(_objectsService.Cbfile, _objectsService.CDefualts);
                _objectsService.MfgReport = mfgReports;

                RNDHome rNDHome = new RNDHome(_objectsService.CDefualts, _objectsService.CLists, _objectsService.Cbfile);
                _objectsService.RNDHome = rNDHome;

                RNDFormulations rNDFormulations = new RNDFormulations(_objectsService.CDefualts, _objectsService.Cbfile);
                _objectsService.RNDFormulations = rNDFormulations;

                RNDRValues rNDRValues = new RNDRValues(_objectsService.CLists);
                _objectsService.RNDRValues = rNDRValues;

                RNDRawProps rNDRawProps = new RNDRawProps();
                _objectsService.RNDRawProps = rNDRawProps;

                RNDProperties rNDProperties = new RNDProperties();
                _objectsService.RNDProperties = rNDProperties;

                RNDTDRV rNDTDRV = new RNDTDRV();
                _objectsService.RNDTDRV = rNDTDRV;

                MfgAdmin mfgAdmin = new MfgAdmin(_objectsService.Cbfile);
                _objectsService.MfgAdmin = mfgAdmin;

                AIModel aIModel = new AIModel();
                _objectsService.AIModel = aIModel;
            }
            _objectsService.UserIndex = value;
            HttpContext.Session.SetInt32("UserId", value);
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
            return new JsonResult(value);
        }
        public void OnGet()
        {
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");

            gGroup.Add("OKTA_GAF_Intugent_RnD_Users");
            gGroup.Add("OKTA_GAF_Intugent_Mfg_Users_Gainesville");
            gGroup.Add("OKTA_GAF_Intugent_Mfg_Users_Statesboro");
            gGroup.Add("OKTA_GAF_Intugent_Mfg_Users_CedarCity");
            gGroup.Add("OKTA_GAF_Intugent_Mfg_Users_NewColumbia");
            gGroup.Add("OKTA_GAF_Intugent_Admins");


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