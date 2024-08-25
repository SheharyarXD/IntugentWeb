using IntugentWebApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace IntugentWebApp.Pages.Mfg_Group
{
    public class MfgReportsModel : PageModel
    {
        public readonly ObjectsService _objectsService;
        public DateTime gReportDate {  get; set; }
        public DataView gReport {  get; set; }
        public MfgReportsModel(ObjectsService objectsService)
        {
            _objectsService = objectsService;

        }
        public void OnGet()
        {
            (_objectsService.MfgInProcess, _objectsService.MfgFinishedGoods, _objectsService.MfgDimensionsStability, _objectsService.MfgPlantsData, _objectsService.MfgJetMixing) = _objectsService.MfgHome.GetAllMfgData(_objectsService.MfgInProcess, _objectsService.MfgFinishedGoods, _objectsService.MfgDimensionsStability, _objectsService.MfgPlantsData, _objectsService.MfgJetMixing);
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
            gReportDate = DateTime.Now;
            //gReportDate= DateTime.Now;
            _objectsService.MfgReport.MfgReport(gReportDate);
            gReport = _objectsService.MfgReport.dt.DefaultView;
        }

        public  IActionResult OnPostReportDate_Changed(DateTime value)
        {
            if (!_objectsService.MfgReport.binit) _objectsService.MfgReport.MfgReport(value);
            _objectsService.MfgReport.binit = false;
            gReport = _objectsService.MfgReport.dt.DefaultView;
            var dataTable = _objectsService.MfgReport.dt;
            var rows = new List<Dictionary<string, object>>();

            foreach (DataRow row in dataTable.Rows)
            {
                var rowDict = new Dictionary<string, object>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    rowDict[column.ColumnName] = row[column];
                }
                rows.Add(rowDict);
            }

            return new JsonResult(rows);
        }
    }
}
