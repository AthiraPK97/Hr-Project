using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace Web_HR_Master
{
    public partial class Branchwise_Checkup : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_branch();
            }
        }
        protected void Load_branch()
        {
            DataTable dt_branch = objService.Get_branch_lab().Tables[0];
            Ddl_branch.DataSource = dt_branch;
            Ddl_branch.DataValueField = "branch_id";
            Ddl_branch.DataTextField = "branch_name";
            Ddl_branch.DataBind();
        }
        protected void Submit_click(object sender,EventArgs e)
        {
            DataTable dt_data = objService.Get_Checkup_details(Ddl_branch.SelectedValue,txtFromDate.Text,txtToDate.Text).Tables[0];
            if(dt_data.Rows.Count>0)
            {
                GridView2.DataSource = dt_data;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
        }
        protected void Export_click(object sender, EventArgs e)
        {
            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            cell1.Text = "CHECK UP PATIENT DATA";
            tr1.Cells.Add(cell1);

            //GridView grid1 = new GridView();
            //grid1.DataSource = dtSymCash;
            //grid1.DataBind();
            TableRow tr2 = new TableRow();
            TableCell cell2 = new TableCell();
            cell2.Controls.Add(GridView2);
            tr2.Cells.Add(cell2);


            tb.Rows.Add(tr1);
            tb.Rows.Add(tr2);

            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename = Checkup_Report.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
    }
}