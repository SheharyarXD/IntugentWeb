using IntugentClassLbrary.Classes;
using IntugentClassLbrary.Pages;
using IntugentClassLibrary.Classes;
using IntugentClassLibrary.Pages.Admins;
using IntugentClassLibrary.Pages.Mfg;
using IntugentClassLibrary.Pages.Rnd;
using IntugentWebApp.Pages.Mfg_Group;

namespace IntugentWebApp.Utilities
{
    public class ObjectsService
    {
        public int UserIndex  { get;set;}

        //             Global Variables
        public CDefualts CDefualts { get; set; }
        public CLists CLists { get; set; }
        public Cbfile Cbfile { get; set; }
        public CAppParam? CAppParam { get; set; }
        public CUConv? CUconv { get; set; }
        public CJetMix? CJetMix { get; set; }
        public CAnalysisData CAnalysisData1 { get; set; }
        public CForms Forms {  get; set; }

        //              Mfg Variables
        public MfgHome MfgHome { get; set; }
        public MfgInProcess? MfgInProcess { get; set; }
        public MfgFinishedGoods? MfgFinishedGoods { get; set; }
        public MfgDimStability? MfgDimensionsStability { get; set; }
        public MfgPlantData? MfgPlantsData { get; set; }
        public MfgJetMixing?  MfgJetMixing { get; set; }
        public MfgProcessCheck MfgProcesscheck { get; set; }
        public MfgReports MfgReport { get; set; }

        //              RND Variables
        public RNDHome? RNDHome { get; set; }
        public RNDFormulations? RNDFormulations { get; set; }
        public RNDRValues? RNDRValues { get; set; }
        public RNDRawProps RNDRawProps { get; set; }
        public RNDProperties RNDProperties { get; set; }
        public RNDTDRV RNDTDRV {  get; set; }

        //              Admin Variables
        public MfgAdmin MfgAdmin { get; set; }
        public CNNData CNNData { get; set; }
        public CDBase CDBase { get; set; }
        public CNNModel CNNModel { get; set; }
        public cMatrix cMatrix { get; set; }
        public AIModel AIModel { get; set; }


        //              local variables
        public bool gInProcessDoneIsChecked { get; set; }
        public int gInputIndex {  get; set; }
    }
}
