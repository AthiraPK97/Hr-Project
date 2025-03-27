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
    public partial class PunchingReportWithoutPhoto : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (!IsPostBack)
            {
                load_UserDetails();
            }
        }
        protected void Btn_ViewsClick(object sender, EventArgs e)
        {
            panel1.Visible = true;
            DataTable ds = new DataTable();
            Button1.Visible = true;
            string inputDate = Text_frmdate.Text;
            DateTime parsedDate = DateTime.ParseExact(inputDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            string formattedDateFromDate = parsedDate.ToString("yyyy-MM-dd");
            
            string inputDate2 = Text_todate.Text;
            DateTime parsedDate2 = DateTime.ParseExact(inputDate2, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            string formattedDateToDate = parsedDate2.ToString("yyyy-MM-dd");
            if(parsedDate2>DateTime.Now)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Can't');", true);
            }
            if (Session["USERTYPE"].ToString() == "hr" || Session["USERTYPE"].ToString() == "hrhead" || Session["USERTYPE"].ToString() == "developer" || Session["USERTYPE"].ToString() == "techlead" || Session["USERTYPE"].ToString() == "unithead")
            {
                ds = objService.get_Attendance(formattedDateFromDate, formattedDateToDate, ddl_name.SelectedValue.ToString()).Tables[0];
            }
            else
            {
                ds = objService.get_Attendance(formattedDateFromDate, formattedDateToDate, Session["USERID"].ToString()).Tables[0];

            }
            if (ds.Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No data Found');", true);
            }


        }
        protected void ButtonExport_Click(object sender, EventArgs e)
        {
            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            GridView2.HeaderStyle.ForeColor = System.Drawing.Color.White;
            GridView2.HeaderStyle.BackColor = System.Drawing.Color.Gray;
            GridView2.HeaderStyle.Font.Bold = true;
            GridView2.HeaderStyle.Font.Size = 12;

            GridView2.RowStyle.Font.Name = "Arial";
            GridView2.RowStyle.Font.Size = 10;
            GridView2.RowStyle.ForeColor = System.Drawing.Color.Black;
            cell1.Controls.Add(GridView2);
            tr1.Cells.Add(cell1);


            tb.Rows.Add(tr1);
            //tb.Rows.Add(tr2);

            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename = Temporary_punchingReport.xls");
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
    
        public void load_UserDetails()
        {
            DataTable dt_userdetails = objService.Get_TEmpName().Tables[0];
            if (dt_userdetails.Rows.Count > 0)
            {
                dt_userdetails.Columns.Add("DisplayText", typeof(string));

                // Populate the new column with concatenated values
                foreach (DataRow row in dt_userdetails.Rows)
                {
                    row["DisplayText"] = row[1].ToString() + "-" + row[8].ToString();
                }
                ddl_name.Items.Clear();
                ddl_name.DataSource = dt_userdetails;
                ddl_name.DataValueField = "username";
                ddl_name.DataTextField = "DisplayText";
                ddl_name.DataBind();


                ddl_name.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", ""));

            }
        }
        protected void ddl_name_changed(object sender, EventArgs e)
        {
            string selectedValue = ddl_name.SelectedValue;
        }
    }
}