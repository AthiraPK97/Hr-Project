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
    public partial class SalaryCalculation : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        public decimal totalSalary = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;
            Button2.Visible = true;

            DataTable dt = new DataTable();
            dt = objService.Get_daysCountOfEmployees(txt_fromdate.Text, txt_todate.Text).Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
            Response.AddHeader("Content-Disposition", "attachment;filename = TemporySalaryReport.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Required for GridView export
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Calculate total sum
                totalSalary += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NetSalary"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[7].Text = "Total:";
                e.Row.Cells[8].Text = totalSalary.ToString("N2"); // Format as decimal
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;
            }
        }

    }
}