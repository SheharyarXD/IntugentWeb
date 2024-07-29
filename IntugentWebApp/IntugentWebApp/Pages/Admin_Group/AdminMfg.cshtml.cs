using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IntugentWebApp.Utilities;

namespace IntugentWebApp.Pages.Admin_Group
{
    [BindProperties]
    public class AdminMfgModel : PageModel
    {
        public DataView gIPT {  get; set; }
        private ObjectsService _objectsService;
        public AdminMfgModel(ObjectsService objectsService)
        {
            _objectsService = objectsService;
        }
        public void OnGet()
        {
            ViewData["Index"] = HttpContext.Session.GetInt32("UserId");
        }
        public IActionResult OnPostGIPTargetUpload_Click(List<string[]> clipboard)
        {
            int itmp, iColStart = 4, iColEnd = 4;
            double dtmp; string stmp;
            int ic, irEx = 1, irF = 2;
            DataRow dr; DataRow[] drs = new DataRow[1];
            bool bNewRow = false;

            List<string[]> clipboardData = clipboard;
            if (clipboardData == null || clipboardData.Count < 4 || clipboardData[0][0] != "Intugent PI - Green Product Targets")
            {
                return new JsonResult(new { success = false, message = "Invalid clipboard data" });
            }

            try
            {
                _objectsService.MfgAdmin.sql = "select * from [dbo].[IP Product Targets]";
                _objectsService.MfgAdmin.dt.Clear();
                _objectsService.MfgAdmin.da = new SqlDataAdapter(_objectsService.MfgAdmin.sql, _objectsService.MfgAdmin.Cbfile.conAZ);
                itmp = _objectsService.MfgAdmin.da.Fill(_objectsService.MfgAdmin.dt);
                _objectsService.MfgAdmin.dtCopy = _objectsService.MfgAdmin.dt.Clone();

                for (int ir = 3; ir < clipboardData.Count; ir++)
                {
                    bNewRow = false;
                    ic = 0;
                    stmp = clipboardData[ir][ic].Trim();
                    if (stmp == string.Empty) break;

                    _objectsService.MfgAdmin.sql = "Select * from [Product Matrix] where [Product Code] = '" + stmp + "'";
                    _objectsService.MfgAdmin.dtPr.Clear();
                    _objectsService.MfgAdmin.daPr = new SqlDataAdapter(_objectsService.MfgAdmin.sql, _objectsService.MfgAdmin.Cbfile.conAZ);
                    itmp = _objectsService.MfgAdmin.daPr.Fill(_objectsService.MfgAdmin.dtPr);
                    if (itmp == 0) continue;

                    drs = _objectsService.MfgAdmin.dt.Select("[Product Code (Local)] = '" + stmp + "'");
                    if (drs.Length > 0)
                    {
                        dr = drs[0];
                        bNewRow = false;
                    }
                    else
                    {
                        dr = _objectsService.MfgAdmin.dt.NewRow();
                        _objectsService.MfgAdmin.dt.Rows.Add(dr);
                        dr["Product Code (Local)"] = stmp;
                    }

                    for (ic = 1; ic < clipboardData[ir].Length; ic++)
                    {
                        if (clipboardData[irEx][ic] == "Extract")
                        {
                            if (double.TryParse(clipboardData[ir][ic], out dtmp))
                                dr[clipboardData[irF][ic]] = dtmp;
                        }
                    }
                    _objectsService.MfgAdmin.dtCopy.ImportRow(dr);
                }
                _objectsService.MfgAdmin.UpdateDataSet();

                // Convert DataTable to JSON
                var jsonData = DataTableToJson(_objectsService.MfgAdmin.dtCopy);

                return new JsonResult( jsonData );
            }
            catch (Exception ex)
            {
                string sMsg = "Error in reading clipboard data and saving it to database";
                System.Diagnostics.Trace.TraceError(sMsg + "\n\n" + ex.Message);
                return new JsonResult(new { success = false, message = sMsg });
            }
        }

        // Helper method to convert DataTable to JSON
        private List<Dictionary<string, object>> DataTableToJson(DataTable table)
        {
            var jsonResult = new List<Dictionary<string, object>>();
            foreach (DataRow row in table.Rows)
            {
                var rowDict = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    rowDict[col.ColumnName] = row[col];
                }
                jsonResult.Add(rowDict);
            }
            return jsonResult;
        }

    }
}
