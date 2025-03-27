using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class TempstaffPersonalReport : System.Web.UI.Page
    {

        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt_StaffDt = objService.Get_TempStaffPersonalReport().Tables[0];
            if (dt_StaffDt.Rows.Count > 0)
            {
                GridView1.DataSource = dt_StaffDt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }

        }

        protected void ButtonExport_Click(object sender, EventArgs e)
        {
            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Gray;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.HeaderStyle.Font.Size = 12;

            GridView1.RowStyle.Font.Name = "Arial";
            GridView1.RowStyle.Font.Size = 10;
            GridView1.RowStyle.ForeColor = System.Drawing.Color.Black;
            cell1.Controls.Add(GridView1);
            tr1.Cells.Add(cell1);


            tb.Rows.Add(tr1);
            //tb.Rows.Add(tr2);

            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename = Staff_Shift_Report.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
    }
}