﻿using IntugentClassLbrary.Classes;
using IntugentClassLibrary.Classes;
using IntugentClassLibrary.Pages.Mfg;
using IntugentClassLibrary.Pages.Rnd;
using IntugentWebApp.Pages.Mfg_Group;

namespace IntugentWebApp.Utilities
{
    public class ObjectsService
    {
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


        //              local variables
        public bool gInProcessDoneIsChecked { get; set; }
    }
}
