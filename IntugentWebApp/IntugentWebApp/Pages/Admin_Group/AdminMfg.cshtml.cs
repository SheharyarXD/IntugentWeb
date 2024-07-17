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
        }
        public IActionResult OnPostGIPTargetUpload_Click(List<string[]> clipboard)
        {
            int itmp, iColStart = 4, iColEnd = 4;
            double dtmp; string stmp;
            int ic, irEx = 1, irF = 2;
            DataRow dr; DataRow[] drs = new DataRow[1];
            bool bNewRow = false;

            List<string[]> clipboardData = clipboard;
            if (clipboardData == null) { 
               // MessageBox.Show("You must first copy all the used range (starting from cell A1) of \"Intugent PI - Green Product Targets\".", Cbfile.sAppName);
                return new JsonResult(false); }
            if (clipboardData.Count < 4) { 
              //  MessageBox.Show("You must first copy all the used range (starting from cell A1) of \"Intugent PI - Green Product Targets\".", Cbfile.sAppName);
                return new JsonResult(false); }
            if (clipboardData[0][0] != "Intugent PI - Green Product Targets") {
                //MessageBox.Show("You must first copy all the used range (starting from cell A1) of \"Intugent PI - Green Product Targets\".", Cbfile.sAppName); 
                return new JsonResult(false); }

            //            sql = "select * from [dbo].[IP Product Targets] where 1=2";
            //            dtCopy.Clear(); da = new SqlDataAdapter(sql, Cbfile.conAZ); itmp = da.Fill(dtCopy);

            //Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                _objectsService.MfgAdmin.sql = "select * from [dbo].[IP Product Targets]";
                _objectsService.MfgAdmin.dt.Clear(); _objectsService.MfgAdmin.da = new SqlDataAdapter(_objectsService.MfgAdmin.sql, _objectsService.MfgAdmin.Cbfile.conAZ); itmp = _objectsService.MfgAdmin.da.Fill(_objectsService.MfgAdmin.dt);
                _objectsService.MfgAdmin.dtCopy = _objectsService.MfgAdmin.dt.Clone();

                for (int ir = 3; ir < clipboardData.Count; ir++)
                {
                    bNewRow = false;
                    ic = 0;
                    stmp = clipboardData[ir][ic].Trim();
                    if (stmp == string.Empty) break;

                    _objectsService.MfgAdmin.sql = "Select * from [Product Matrix] where [Product Code] = '" + stmp + "'";
                    _objectsService.MfgAdmin.dtPr.Clear(); _objectsService.MfgAdmin.daPr = new SqlDataAdapter(_objectsService.MfgAdmin.sql, _objectsService.MfgAdmin.Cbfile.conAZ); itmp = _objectsService.MfgAdmin.daPr.Fill(_objectsService.MfgAdmin.dtPr);
                    if (itmp == 0) {
                       // MessageBox.Show(clipboardData[ir][ic] + " was not found in the Product Matrix.  Targets will not be updated", Cbfile.sAppName);
                        continue; }

                    drs = _objectsService.MfgAdmin.dt.Select("[Product Code (Local)] = '" + stmp + "'");
                    if (drs.Length > 0) { dr = drs[0]; bNewRow = false; } else { dr = _objectsService.MfgAdmin.dt.NewRow(); _objectsService.MfgAdmin.dt.Rows.Add(dr); dr["Product Code (Local)"] = stmp; }

                    for (ic = 1; ic < clipboardData[ir].Length; ic++)
                    {
                        if (clipboardData[irEx][ic] == "Extract")
                        { if (double.TryParse(clipboardData[ir][ic], out dtmp)) dr[clipboardData[irF][ic]] = dtmp; }// else dr[clipboardData[irF][ic]] = DBNull.Value; }
                    }
                    //               if (bNewRow) dtCopy.Rows.Add(dr); else dtCopy.ImportRow(dr);
                    _objectsService.MfgAdmin.dtCopy.ImportRow(dr);

                }
                _objectsService.MfgAdmin.UpdateDataSet();

            }
            catch (Exception ex)
            {
                string sMsg = "Error in reading clipboard data and saving it to database";
              //  MessageBox.Show(sMsg, Cbfile.sAppName, MessageBoxButton.OK, MessageBoxImage.Stop);
                System.Diagnostics.Trace.TraceError(sMsg + "\n\n" + ex.Message);
               // CTelClient.TelException(ex, sMsg);
                return new JsonResult(false);
            }
            finally
            {
                //Mouse.OverrideCursor = null;
            }

            //gIPT.Visibility = Visibility.Visible;
            gIPT = _objectsService.MfgAdmin.dtCopy.DefaultView;
            return new JsonResult(true);
        }
    }
}
