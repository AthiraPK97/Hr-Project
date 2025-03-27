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
    public partial class Report : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_data(Ddl_status.SelectedValue);
                Button1.Visible = false;
            }
        }
        public void Load_data(string status)
        {
            DataTable dtgrid = new DataTable();
            if (Ddl_status.SelectedValue.ToString() == "Live")
            {
                //DataTable dt1 = objService.Get_HRMaster_Dashboard_Live().Tables[0];
                //DataTable dt2 = objService.Get_HRMaster_Dashboard_One().Tables[0];
                //var dt = dt1.AsEnumerable().Union(dt2.AsEnumerable()).OrderBy(d => d.Field<string>("branch_name"));
                //dtgrid = dt.CopyToDataTable();




                DataTable dt1 = objService.Get_HRMaster().Tables[0];
                DataTable dt2 = objService.Get_Qualifn().Tables[0];
                //var results = from table1 in dt1.AsEnumerable()
                //              join table2 in dt2.AsEnumerable() on (string)table1["emp_code"] equals (string)table2["emp_code"]
                //var results = from table1 in dt1.AsEnumerable()
                //              join table2 in dt2.AsEnumerable() on (string)table1["emp_code"] equals (string)table2["emp_code"]
                //              select new
                //              {
                //                  col1 = (string)table1["firm_id"],
                //                  Col2 = (string)table1["emp_code"],
                //                  Col3 = (string)table1["emp_name"],
                //                  Col4 = (string)table1["caste"],
                //                  col5 = (string)table1["religion"],
                //                  Col6 = (string)table1["identity_name"],
                //                  Col7 = (string)table1["idproof_number"],
                //                  Col8 = (string)table1["blood_group"],
                //                  col9 = (string)table1["spouse_name"],
                //                  Col10 = (string)table1["father_name"],
                //                  Col11 = (string)table1["emp_email"],
                //                  Col12 = (string)table1["gender"],
                //                  col13 = (string)table1["birth_date"],
                //                  Col14 = (decimal)table1["age"],
                //                  Col15 = (string)table1["permanent_addr"],
                //                  Col16 = (string)table1["present_addr"],
                //                  Col17 = (string)table1["cont_phone"],
                //                  Col18 = (string)table1["res_phone"],
                //                  col19 = (string)table1["state"],
                //                  Col20 = (string)table1["shift"],
                //                  Col21 = (string)table1["in_time"],
                //                  Col22 = (string)table1["out_time"],
                //                  Col23 = (string)table1["join_dt"],
                //                  Col24 = (decimal)table1["exp"],
                //                  col25 = (string)table1["designation"],
                //                  Col26 = (string)table1["dep_name"],
                //                  Col27 = (decimal)table1["basic_pay"],
                //                  Col28 = (string)table1["post_name"],
                //                  Col29 = (decimal)table1["year_pass"],
                //                  Col30 = (string)table2["qualification"],
                //                  Col31 = (string)table1["branch_name"] };

                DataTable dtResult = new DataTable();
                //dtResult.Columns.Add("firm_id", typeof(decimal));
                dtResult.Columns.Add("Emp_code", typeof(decimal));
                dtResult.Columns.Add("Name", typeof(string)); 
                //dtResult.Columns.Add("caste", typeof(string));
                //dtResult.Columns.Add("religion", typeof(string)); dtResult.Columns.Add("identity_name", typeof(string));
                //dtResult.Columns.Add("idproof_number", typeof(string)); dtResult.Columns.Add("blood_group", typeof(string));
                //dtResult.Columns.Add("spouse_name", typeof(string)); dtResult.Columns.Add("father_name", typeof(string));
                //dtResult.Columns.Add("emp_email", typeof(string)); 
                dtResult.Columns.Add("Gender", typeof(string));
                dtResult.Columns.Add("birth_date", typeof(string)); 
                //dtResult.Columns.Add("age", typeof(decimal));
                //dtResult.Columns.Add("permanent_addr", typeof(string)); dtResult.Columns.Add("present_addr", typeof(string));
                dtResult.Columns.Add("Cont_phone", typeof(string)); dtResult.Columns.Add("Res_phone", typeof(string));
                dtResult.Columns.Add("State", typeof(string)); 
                //dtResult.Columns.Add("shift", typeof(string));
                //dtResult.Columns.Add("in_time", typeof(string)); dtResult.Columns.Add("out_time", typeof(string));
                dtResult.Columns.Add("Join_Date", typeof(string));
                //dtResult.Columns.Add("exp", typeof(string));
                dtResult.Columns.Add("Designation", typeof(string)); dtResult.Columns.Add("Department", typeof(string));
                //dtResult.Columns.Add("basic_pay", typeof(decimal)); 
                dtResult.Columns.Add("Post_Name", typeof(string));
                //dtResult.Columns.Add("year_pass", typeof(string)); 
                dtResult.Columns.Add("Qualification", typeof(string));
                dtResult.Columns.Add("Branch_name", typeof(string));

                var result = from dataRows1 in dt1.AsEnumerable()
                             join dataRows2 in dt2.AsEnumerable()
                             on dataRows1.Field<decimal>("emp_code") equals dataRows2.Field<decimal>("emp_code")

                             select dtResult.LoadDataRow(new object[]
                             {

                //dataRows1.Field<decimal>("firm_id"),
                dataRows1.Field<decimal>("emp_code"),
                dataRows1.Field<string>("emp_name"),
                //dataRows1.Field<string>("caste"),
                //dataRows1.Field<string>("religion"),
                //dataRows1.Field<string>("identity_name"),
                //dataRows1.Field<string>("idproof_number"),
                //dataRows1.Field<string>("blood_group"),
                //dataRows1.Field<string>("spouse_name"),
                //dataRows1.Field<string>("father_name"),
                //dataRows1.Field<string>("emp_email"),
                dataRows1.Field<string>("gender"),
                dataRows1.Field<string>("date_of_birth"),
                //dataRows1.Field<decimal>("age"),
                //dataRows1.Field<string>("permanent_addr"),
                //dataRows1.Field<string>("present_addr"),
                dataRows1.Field<string>("cont_phone"),
                dataRows1.Field<string>("res_phone"),
                dataRows1.Field<string>("state"),
                //dataRows1.Field<string>("shift"),
                //dataRows1.Field<string>("in_time"),
                //dataRows1.Field<string>("out_time"),
                dataRows1.Field<string>("join_dt"),
                //dataRows1.Field<string>("exp"),
                dataRows1.Field<string>("designation"),
                dataRows1.Field<string>("dep_name"),
                //dataRows1.Field<decimal>("basic_pay"),
                dataRows1.Field<string>("post_name"),
                //dataRows1.Field<string>("year_pass"),
                dataRows2.Field<string>("qualification"),
                dataRows1.Field<string>("branch_name")
                              }, false);
                result.CopyToDataTable();
            


                //DataTable dtAo = objService.Get_HRMaster_AO().Tables[0];
                //dtAo.Columns.Remove("firm_id"); dtAo.Columns.Remove("caste");  dtAo.Columns.Remove("religion"); dtAo.Columns.Remove("identity_name"); //dtAo.Columns.Remove("child_number"); dtAo.Columns.Remove("marital_status");
                //dtAo.Columns.Remove("idproof_number"); dtAo.Columns.Remove("blood_group"); dtAo.Columns.Remove("spouse_name"); dtAo.Columns.Remove("father_name"); dtAo.Columns.Remove("emp_email");
                //dtAo.Columns.Remove("birth_date"); dtAo.Columns.Remove("age"); dtAo.Columns.Remove("permanent_addr"); dtAo.Columns.Remove("present_addr"); dtAo.Columns.Remove("shift");
                //dtAo.Columns.Remove("in_time"); dtAo.Columns.Remove("out_time"); dtAo.Columns.Remove("exp"); dtAo.Columns.Remove("basic_pay"); dtAo.Columns.Remove("year_pass");
                //DataTable dtGrid = objService.Get_HRMaster_Dashboard().Tables[0];
                //dtGrid.Columns.Remove("firm_id"); dtGrid.Columns.Remove("caste"); dtGrid.Columns.Remove("religion"); dtGrid.Columns.Remove("identity_name"); //dtGrid.Columns.Remove("child_number"); dtGrid.Columns.Remove("marital_status");
                //dtGrid.Columns.Remove("idproof_number"); dtGrid.Columns.Remove("blood_group"); dtGrid.Columns.Remove("spouse_name"); dtGrid.Columns.Remove("father_name"); dtGrid.Columns.Remove("emp_email");
                //dtGrid.Columns.Remove("birth_date"); dtGrid.Columns.Remove("age"); dtGrid.Columns.Remove("permanent_addr"); dtGrid.Columns.Remove("present_addr"); dtGrid.Columns.Remove("shift");
                //dtGrid.Columns.Remove("in_time"); dtGrid.Columns.Remove("out_time"); dtGrid.Columns.Remove("exp"); dtGrid.Columns.Remove("basic_pay"); dtGrid.Columns.Remove("year_pass");
                //var dt = dtAo.AsEnumerable().Union(dtGrid.AsEnumerable()).OrderBy(d => d.Field<string>("branch_name"));
                //DataTable dtnew = dt.CopyToDataTable();
                if (dtResult.Rows.Count > 0)
                {
                    GridView2.DataSource = dtResult;
                    GridView2.DataBind();
                    Button1.Visible = true;
                }
            }
            else if(Ddl_status.SelectedValue.ToString() == "Resigned")
            {
                dtgrid = objService.Get_HRMaster_Dashboard_Not().Tables[0];
                dtgrid.Columns.Remove("firm_id"); dtgrid.Columns.Remove("branch_id"); dtgrid.Columns.Remove("status_id");
                if (dtgrid.Rows.Count > 0)
                {
                    GridView2.DataSource = dtgrid;
                    GridView2.DataBind();
                    Button1.Visible = true;
                }
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                Button1.Visible = false;
            }
            //DataTable dtbranch = objService.Get_branches().Tables[0];
            //DataTable dtnew = dtgrid.Select().CopyToDataTable();

            //            DataTable dtMerged =
            //                 (from a in dtgrid.AsEnumerable()
            //                  join b in dtbranch.AsEnumerable()
            //                   on
            //a["branch_id"].ToString() equals b["branch_id"].ToString()
            //                 into g
            //                  where g.Count() > 0
            //                  select a).CopyToDataTable();

            //            if (Ddl_status.SelectedValue.ToString() == "Live")
            //            {
            //                var custs = from a in dtMerged.AsEnumerable()
            //                            where a.Field<string>("status_id").Contains("1")
            //                            select a;
            //            }
            //            else
            //            {
            //                var custs = from a in dtMerged.AsEnumerable()
            //                            where a.Field<string>("status_id").Contains("3")
            //                            select a;
            //            }
            //dtMerged.Columns.Remove("firm_id"); dtMerged.Columns.Remove("branch_id");

            
            //var dt = dtMerged.AsEnumerable().OrderBy(d => d.Field<string>("branch_name"));

            
        }
    
        protected void Export_click(object sender, EventArgs e)
        {

            GridView2.AllowPaging = false;
            DataTable dtgrid = new DataTable();
            if (Ddl_status.SelectedValue.ToString() == "Resigned")
            {
                dtgrid = objService.Get_HRMaster_Dashboard_Not().Tables[0];
                dtgrid.Columns.Remove("firm_id"); dtgrid.Columns.Remove("branch_id"); dtgrid.Columns.Remove("status_id");
                if (dtgrid.Rows.Count > 0)
                {
                    GridView2.DataSource = dtgrid;
                    GridView2.DataBind();
                }
            }

            else if (Ddl_status.SelectedValue.ToString() == "Live")
            {
                
                DataTable dt1 = objService.Get_HRMaster().Tables[0];
                DataTable dt2 = objService.Get_Qualifn().Tables[0];
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("Emp_code", typeof(decimal));
                dtResult.Columns.Add("Name", typeof(string));
                dtResult.Columns.Add("Gender", typeof(string));
                dtResult.Columns.Add("date_of_birth", typeof(string));
               dtResult.Columns.Add("Cont_phone", typeof(string)); dtResult.Columns.Add("Res_phone", typeof(string));
                dtResult.Columns.Add("State", typeof(string));
                dtResult.Columns.Add("Join_Date", typeof(string));
                dtResult.Columns.Add("Designation", typeof(string)); dtResult.Columns.Add("Department", typeof(string));
               dtResult.Columns.Add("Post_Name", typeof(string));
                dtResult.Columns.Add("Qualification", typeof(string));
                dtResult.Columns.Add("Branch_name", typeof(string));

                var result = from dataRows1 in dt1.AsEnumerable()
                             join dataRows2 in dt2.AsEnumerable()
                             on dataRows1.Field<decimal>("emp_code") equals dataRows2.Field<decimal>("emp_code")

                             select dtResult.LoadDataRow(new object[]
                             {

                dataRows1.Field<decimal>("emp_code"),
                dataRows1.Field<string>("emp_name"),
                dataRows1.Field<string>("gender"),
                dataRows1.Field<string>("date_of_birth"),

                dataRows1.Field<string>("cont_phone"),
                dataRows1.Field<string>("res_phone"),
                dataRows1.Field<string>("state"),
                dataRows1.Field<string>("join_dt"),
                dataRows1.Field<string>("designation"),
                dataRows1.Field<string>("dep_name"),
                dataRows1.Field<string>("post_name"),
                dataRows2.Field<string>("qualification"),
                dataRows1.Field<string>("branch_name")
                              }, false);
                result.CopyToDataTable();


                if (dtResult.Rows.Count > 0)
                {
                    GridView2.DataSource = dtResult;
                    GridView2.DataBind();
                    Button1.Visible = true;
                }
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                Button1.Visible = false;
            } 
            GridView2.DataBind();

            GridView2.HeaderStyle.ForeColor = System.Drawing.Color.White;
            GridView2.HeaderStyle.BackColor = System.Drawing.Color.Gray;
            GridView2.HeaderStyle.Font.Bold = true;
            GridView2.HeaderStyle.Font.Size = 12;

            GridView2.RowStyle.Font.Name = "Arial";
            GridView2.RowStyle.Font.Size = 10;
            GridView2.RowStyle.ForeColor = System.Drawing.Color.Black;

            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            //cell1.Text = "EMPLOYEES MASTER DATA";
            //tr1.Cells.Add(cell1);

            //GridView grid1 = new GridView();
            //grid1.DataSource = dtSymCash;
            //grid1.DataBind();
            //TableRow tr2 = new TableRow();
            //TableCell cell2 = new TableCell();
            cell1.Controls.Add(GridView2);
            tr1.Cells.Add(cell1);


            tb.Rows.Add(tr1);
            
            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename = Emp_dtls.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }

        protected void Ddl_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_data(Ddl_status.SelectedValue);
        }

        protected void GridView1_Pageindexchanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            Load_data(Ddl_status.SelectedValue);


        }
    }
}