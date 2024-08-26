using IntugentClassLibrary.Classes;
using IntugentWebApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Drawing;
using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace IntugentWebApp.Pages.Analysis
{
    [BindProperties]
    public class Analysis2Model : PageModel
    {
       public string scnX1 = "Green-Board Time Stamp", scnX2 = "FG-Board Time Stamp", scnY1 = "Green-Compressive Str Avg6", scnY2 = "FG-Compressive Str Avg6";
       public double[] gX1Y1_X, gX1Y1_Y, gX2Y1_X, gX2Y1_Y, gX1Y2_X, gX1Y2_Y, gX2Y2_X, gX2Y2_Y;
        DataTable dt;
        private readonly ObjectsService _objectsService;
        public Analysis2Model(ObjectsService objectsService)
        {
            _objectsService= objectsService;
        }
        public DataView gProd1;
        public int gProd1SelectedIndex;
        public string gProd1SelectedValue;
        public DataView gMfgSite;
        public int gMfgSiteSelectedIndex;
        public string gMfgSiteSelectedValue;
        public DataView gProp1;
        public DataView gCorr;
        public string gProp1SelectedValue;
        public string test;
        public DateTime? gMfgDate1;
        public DateTime? gMfgDate2; 
        public string gX1SelectedValue {get; set;}
       public string gX2SelectedValue {get; set;}
       public string gY1SelectedValue {get; set;}
       public string gY2SelectedValue {get; set;}
        public DataView gX1 { get; set; }
        public DataView gX2{get;set;}
        public DataView gY1{get;set;}
        public DataView gY2{get;set;}

        public void OnGet()
        {
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
            _objectsService.CAnalysisData1.GetLists();      
            if (gProp1SelectedValue == null) gProp1SelectedValue = "FG-Compressive Str Avg6";
            if (gProd1SelectedValue == null) gProd1SelectedIndex = 0;
            if (gMfgSiteSelectedValue == null) gMfgSiteSelectedIndex = 0;
            _objectsService.CAnalysisData1.GetData(GetSearchCriteria());
            gY2 = gY1 = gX2 = gX1 = _objectsService.CAnalysisData1.dtProps.DefaultView;
            gX1SelectedValue = scnX1;
            gX2SelectedValue = scnX2;
            gY1SelectedValue = scnY1;
            gY2SelectedValue = scnY2;


            dt = _objectsService.CAnalysisData1.dtPropValues;
            DrawCharts();
        }
        public IActionResult OnPostUpdateCharts(string gX1SelectedValue, string gX2SelectedValue, string gY1SelectedValue, string gY2SelectedValue)
        {
            this.gX1SelectedValue = gX1SelectedValue;
            this.gX2SelectedValue = gX2SelectedValue;
            this.gY1SelectedValue = gY1SelectedValue;
            this.gY2SelectedValue = gY2SelectedValue;

            // Ensure the data is fetched and processed

            dt = _objectsService.CAnalysisData1.dtPropValues;

            // Redraw charts with the new data
            DrawCharts();

            var chartData = new
            {
                gX1Y1_X = this.gX1Y1_X,
                gX1Y1_Y = this.gX1Y1_Y,
                gX2Y1_X = this.gX2Y1_X,
                gX2Y1_Y = this.gX2Y1_Y,
                gX1Y2_X = this.gX1Y2_X,
                gX1Y2_Y = this.gX1Y2_Y,
                gX2Y2_X = this.gX2Y2_X,
                gX2Y2_Y = this.gX2Y2_Y
            };

            return new JsonResult(chartData);
        }

        public void DrawCharts()
        {
            int ncount = 0;
            if (dt == null) return;

            if (gX1SelectedValue != null) scnX1 = (string)gX1SelectedValue;
            if (gX2SelectedValue != null) scnX2 = (string)gX2SelectedValue;
            if (gY1SelectedValue != null) scnY1 = (string)gY1SelectedValue;
            if (gY2SelectedValue != null) scnY2 = (string)gY2SelectedValue;

            gX1Y1_X = new double[dt.Rows.Count];
            gX1Y1_Y = new double[dt.Rows.Count];
            gX2Y1_X = new double[dt.Rows.Count];
            gX2Y1_Y = new double[dt.Rows.Count];
            gX1Y2_X = new double[dt.Rows.Count];
            gX1Y2_Y = new double[dt.Rows.Count];
            gX2Y2_X = new double[dt.Rows.Count];
            gX2Y2_Y = new double[dt.Rows.Count];

            ncount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][scnX1] == DBNull.Value || dt.Rows[i][scnY1] == DBNull.Value) continue;
                if (double.IsNaN((double)dt.Rows[i][scnX1]) || double.IsNaN((double)dt.Rows[i][scnY1])) continue;
                gX1Y1_X[ncount] = (double)dt.Rows[i][scnX1];
                gX1Y1_Y[ncount] = (double)dt.Rows[i][scnY1];
                ncount++;
            }
            Array.Resize(ref gX1Y1_X, ncount);
            Array.Resize(ref gX1Y1_Y, ncount);

            ncount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][scnX1] == DBNull.Value || dt.Rows[i][scnY2] == DBNull.Value) continue;
                if (double.IsNaN((double)dt.Rows[i][scnX1]) || double.IsNaN((double)dt.Rows[i][scnY2])) continue;
                gX1Y2_X[ncount] = (double)dt.Rows[i][scnX1];
                gX1Y2_Y[ncount] = (double)dt.Rows[i][scnY2];
                ncount++;
            }
            Array.Resize(ref gX1Y2_X, ncount);
            Array.Resize(ref gX1Y2_Y, ncount);

            ncount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][scnX2] == DBNull.Value || dt.Rows[i][scnY2] == DBNull.Value) continue;
                if (double.IsNaN((double)dt.Rows[i][scnX2]) || double.IsNaN((double)dt.Rows[i][scnY2])) continue;
                gX2Y2_X[ncount] = (double)dt.Rows[i][scnX2];
                gX2Y2_Y[ncount] = (double)dt.Rows[i][scnY2];
                ncount++;
            }
            Array.Resize(ref gX2Y2_X, ncount);
            Array.Resize(ref gX2Y2_Y, ncount);

            ncount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][scnX2] == DBNull.Value || dt.Rows[i][scnY1] == DBNull.Value) continue;
                if (double.IsNaN((double)dt.Rows[i][scnX2]) || double.IsNaN((double)dt.Rows[i][scnY1])) continue;
                gX2Y1_X[ncount] = (double)dt.Rows[i][scnX2];
                gX2Y1_Y[ncount] = (double)dt.Rows[i][scnY1];
                ncount++;
            }
            Array.Resize(ref gX2Y1_X, ncount);
            Array.Resize(ref gX2Y1_Y, ncount);


            //gCircles21.PlotXY(gX2Y1_X, gX2Y1_Y);
            //gCircles12.PlotXY(gX1Y2_X, gX1Y2_Y);
            //gCircles22.PlotXY(gX2Y2_X, gX2Y2_Y);
            //gCircles11.PlotXY(gX1Y1_X, gX1Y1_Y);


            ////           gCircles11.PlotXY(X1, Y1);
            ////            gCircles22.PlotXY(X2, Y2);

            //gx1y1.LeftTitle = "Y1:- " + scnY1; gx1y1.BottomTitle = "X1:- " + scnX1;
            //gx1y2.LeftTitle = "Y2:- " + scnY2; gx1y2.BottomTitle = "X1:- " + scnX1;
            //gx2y2.LeftTitle = "Y2:- " + scnY2; gx2y2.BottomTitle = "X2:- " + scnX2;
            //gx2y1.LeftTitle = "Y1:- " + scnY1; gx2y1.BottomTitle = "X2:- " + scnX2;

            //gCircles12.IsAutoFitEnabled = true;
            //gCircles21.IsAutoFitEnabled = true;
            //gCircles11.IsAutoFitEnabled = true;
            //gCircles22.IsAutoFitEnabled = true;



        }


        public string GetSearchCriteria()
        {
            gProd1 = _objectsService.CAnalysisData1.dtGlobalProducts.DefaultView;
            gMfgSite = _objectsService.CAnalysisData1.dtLocations.DefaultView;
            gProp1 = _objectsService.CAnalysisData1.dtProps.DefaultView;
            gProp1SelectedValue = "FG-Compressive Str Avg6";
            gMfgDate2 = DateTime.Now;
            gMfgDate1 = DateTime.Now.AddYears(-1);
            string sql = string.Empty, sql1 = string.Empty;
            DateTime dateTime1;
            //Location

            sql = sql1 = string.Empty;
            if (gMfgSiteSelectedValue != null) sql = "sLocation = '" + gMfgSiteSelectedValue.ToString() + "'";


            sql1 = string.Empty;
            if (gProd1SelectedValue != null)
            {
                sql1 = "[Product Code Global] = '" + gProd1SelectedValue.ToString() + "'";
                if (sql == string.Empty) sql = sql1; else sql = sql + " And " + sql1;
            }

            //Dates
            if (gMfgDate2 != null)
            {
                dateTime1 = ((DateTime)gMfgDate2).AddDays(1);
                sql1 = "[Test Date] < '" + dateTime1.ToString() + "'";
                if (sql == string.Empty) sql = sql1; else sql = sql + " And " + sql1;
            }

            if (gMfgDate1 != null)
            {
                dateTime1 = ((DateTime)gMfgDate1);
                sql1 = "[Test Date] >= '" + dateTime1.ToString() + "'";
                if (sql == string.Empty) sql = sql1; else sql = sql + " And " + sql1;
            }
            test = sql;
            return sql;
        }

    }
}
