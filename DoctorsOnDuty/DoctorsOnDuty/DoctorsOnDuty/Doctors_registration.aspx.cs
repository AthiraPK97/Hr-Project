using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Doctors_registration : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            //GridView3.Visible = true;
            if (!IsPostBack)
            {
                div_monthly.Visible = false;
                div_weekly.Visible = false;
                SetInitialRow();
                SetInitialRow1();
                //SetInitialRow2();

                DataTable dt1 = new DataTable();
                dt1 = objservice.Get_Branch().Tables[0];
                ddl_branchname.DataSource = dt1;
                ddl_branchname.DataTextField = "NAME";
                ddl_branchname.DataValueField = "BRANCH_ID";
                ddl_branchname.DataBind();
                ddl_branchname.Items.Insert(0, new ListItem("---Select---", "0"));

                //Text_perpatient_amt.Visible = false;
                //Text_pervisit_amt.Visible = false;
                //Text_abovemaximum_amt.Visible = false;
                //Text_abovemaximum_percent.Visible = false;
                //Text_lab_amt.Visible = false;
                //Text_lab_percent.Visible = false;
                //Text_procedurecharges_amt.Visible = false;
                //Text_procedurecharges_percent.Visible = false;
                //Text_echo_amt.Visible = false;
                //Text_echo_percent.Visible = false;
                //Text_tmt_amt.Visible = false;
                //Text_tmt_percent.Visible = false;
                //Text_scan_amt.Visible = false;
                //Text_scan_percent.Visible = false;
                //Text_pft_amt.Visible = false;
                //Text_pft_percent.Visible = false;
                //Text_taall.Visible = false;
                //Text_tasunday.Visible = false;

                //Text_pervisit_amt.Text = "";
                //Text_perpatient_amt.Text = "";
                //Text_abovemaximum_amt.Text = "";
                //Text_abovemaximum_percent.Text = "";
                //Text_lab_amt.Text = "";
                //Text_lab_percent.Text = "";
                //Text_procedurecharges_amt.Text = "";
                //Text_procedurecharges_percent.Text = "";
                //Text_echo_amt.Text = "";
                //Text_echo_percent.Text = "";
                //Text_tmt_amt.Text = "";
                //Text_tmt_percent.Text = "";
                //Text_scan_amt.Text = "";
                //Text_scan_percent.Text = "";
                //Text_pft_amt.Text = "";
                //Text_pft_percent.Text = "";
                //Text_taall.Text = "";
                //Text_tasunday.Text = "";
            }
            Label1.Visible = false;            
        }


        //-------------------------------------------------------------gridview1---------------------------------------------------------------------
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

        }

        //private void SetInitialRow2()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr = null;
        //    dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        //    dr = dt.NewRow();
        //    dr["RowNumber"] = 1;
        //    dr["Column1"] = string.Empty;
        //    dr["Column2"] = string.Empty;
        //    dr["Column3"] = string.Empty;
        //    dt.Rows.Add(dr);
        //    //dr = dt.NewRow();
        //    //Store the DataTable in ViewState
        //    ViewState["CurrentTable"] = dt;
        //    Gridview3.DataSource = dt;
        //    Gridview3.DataBind();

        //}
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("DropDownList1");
                        DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("DropDownList2");
                        TextBox txt1 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_frmtime");
                        TextBox txt2 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_totime");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = ddl1.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Column2"] = ddl2.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Column3"] = txt1.Text;
                        dtCurrentTable.Rows[i - 1]["Column4"] = txt2.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {  
                        DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("DropDownList1");
                        DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("DropDownList2");
                        TextBox txt1 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_frmtime");
                        TextBox txt2 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_totime");
                        ddl1.Text = dt.Rows[i]["Column1"].ToString();
                        ddl2.Text = dt.Rows[i]["Column2"].ToString();
                        txt1.Text = dt.Rows[i]["Column3"].ToString();
                        txt2.Text = dt.Rows[i]["Column4"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        //--------------------------------------------------------------------gridview2---------------------------------------------------------------------

        private void SetInitialRow1()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //Store the DataTable in ViewState
            ViewState["CurrentTable1"] = dt;
            Gridview2.DataSource = dt;
            Gridview2.DataBind();

        }
        private void AddNewRowToGrid1()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        DropDownList ddl1 = (DropDownList)Gridview2.Rows[rowIndex].Cells[1].FindControl("DropDownList3");
                        TextBox txt1 = (TextBox)Gridview2.Rows[rowIndex].Cells[2].FindControl("txt_frmtime");
                        TextBox txt2 = (TextBox)Gridview2.Rows[rowIndex].Cells[3].FindControl("txt_totime");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = ddl1.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Column2"] = txt1.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = txt2.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable1"] = dtCurrentTable;
                    Gridview2.DataSource = dtCurrentTable;
                    Gridview2.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData1();
        }
        private void SetPreviousData1()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList ddl1 = (DropDownList)Gridview2.Rows[rowIndex].Cells[1].FindControl("DropDownList3");
                        TextBox txt1 = (TextBox)Gridview2.Rows[rowIndex].Cells[2].FindControl("txt_frmtime");
                        TextBox txt2 = (TextBox)Gridview2.Rows[rowIndex].Cells[3].FindControl("txt_totime");
                        ddl1.Text = dt.Rows[i]["Column1"].ToString();
                        txt1.Text = dt.Rows[i]["Column2"].ToString();
                        txt2.Text = dt.Rows[i]["Column3"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        protected void ButtonAdd_Click1(object sender, EventArgs e)
        {
            AddNewRowToGrid1();
        }





        protected void ddl_visitingperiod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_visitingperiod.SelectedItem.Text== "Monthly")
            {
                div_weekly.Visible = false;
                div_monthly.Visible = true;
            }
            else if (ddl_visitingperiod.SelectedItem.Text == "Weekly")
            {
                div_monthly.Visible = false;
                div_weekly.Visible = true;
            }
        }
        protected void ddl_branchname_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_department().Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "DEPT_NAME";
            ddl_dept.DataValueField = "DEPT_ID"; 
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctors(ddl_dept.SelectedValue,ddl_branchname.SelectedValue).Tables[0];
            ddl_drname.DataSource = dt;
            ddl_drname.DataTextField = "NAME";
            ddl_drname.DataValueField = "STAFF_ID";
            ddl_drname.DataBind();
            ddl_drname.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void Buttons(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //string pervisit, patientvisit, abovemaximum, lab, procedurecharges, echo, tmt, opticalreference;
            //if(Check_pervisit_amt.Checked==true)
            //{
            //    if(Check_pervisit_amt.Checked==true && Check_pervisit_percent.Checked==true)
            //    {
            //        Label1.Text = "* Please Select Either Amount or Percentage";
            //    }
            //    else
            //    {
            //        //pervisit = Text_pervisit.Text;
            //    }
            //}

            if (ddl_drname.SelectedValue=="0")
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Doctor Name";
            }
            else if(ddl_dept.SelectedValue=="0")
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Department Name";
            }
            else if(ddl_branchname.SelectedValue=="0")
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Branch Name";
            }
            else if(ddl_drarea.SelectedIndex<=0)
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Doctor Sitting Area";
            }
            else if(ddl_visitingperiod.SelectedIndex<=0)
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Visiting Period";
            }
            else
            {
                
                if (ddl_visitingperiod.SelectedItem.Text == "Weekly")
                {
                    foreach (GridViewRow gr in Gridview2.Rows)
                    {
                        string weeknum="0";
                        if(((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text== "Sunday")
                        {
                            weeknum = "1";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text == "Monday")
                        {
                            weeknum = "2";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text == "Tuesday")
                        {
                            weeknum = "3";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text == "Wednesday")
                        {
                            weeknum = "4";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text == "Thursday")
                        {
                            weeknum = "5";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text == "Friday")
                        {
                            weeknum = "6";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text == "Saturday")
                        {
                            weeknum = "7";
                        }
                        objservice.Doctor_registration(ddl_drname.SelectedValue, ddl_visitingperiod.SelectedItem.Text, weeknum, "0", ddl_branchname.SelectedValue, ddl_dept.SelectedValue, ddl_drarea.SelectedItem.Text,  ddl_drname.SelectedItem.Text, ddl_dept.SelectedItem.Text, ddl_branchname.SelectedItem.Text, Session["USERID"].ToString(), ((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text,"All", ((TextBox)gr.Cells[0].FindControl("txt_frmtime")).Text, ((TextBox)gr.Cells[0].FindControl("txt_totime")).Text);
                    }
                }
                else if (ddl_visitingperiod.SelectedItem.Text == "Monthly")
                {
                    foreach (GridViewRow gr in Gridview1.Rows)
                    {
                        string weeknum = "0";
                        string week = "0";
                        if (((DropDownList)gr.Cells[0].FindControl("DropDownList1")).SelectedItem.Text == "Sunday")
                        {
                            weeknum = "1";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList1")).SelectedItem.Text == "Monday")
                        {
                            weeknum = "2";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList1")).SelectedItem.Text == "Tuesday")
                        {
                            weeknum = "3";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList1")).SelectedItem.Text == "Wednesday")
                        {
                            weeknum = "4";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList1")).SelectedItem.Text == "Thursday")
                        {
                            weeknum = "5";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList1")).SelectedItem.Text == "Friday")
                        {
                            weeknum = "6";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList1")).SelectedItem.Text == "Saturday")
                        {
                            weeknum = "7";
                        }

                        if (((DropDownList)gr.Cells[0].FindControl("DropDownList2")).SelectedItem.Text == "First Week")
                        {
                            week = "1";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList2")).SelectedItem.Text == "Second Week")
                        {
                            week = "2";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList2")).SelectedItem.Text == "Third Week")
                        {
                            week = "3";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList2")).SelectedItem.Text == "Fourth Week")
                        {
                            week = "4";
                        }
                        else if (((DropDownList)gr.Cells[0].FindControl("DropDownList2")).SelectedItem.Text == "Fifth Week")
                        {
                            week = "5";
                        }
                            
                        objservice.Doctor_registration(ddl_drname.SelectedValue, ddl_visitingperiod.SelectedItem.Text, weeknum,week, ddl_branchname.SelectedValue, ddl_dept.SelectedValue, ddl_drarea.SelectedItem.Text, ddl_drname.SelectedItem.Text, ddl_dept.SelectedItem.Text, ddl_branchname.SelectedItem.Text, Session["USERID"].ToString(), ((DropDownList)gr.Cells[0].FindControl("DropDownList1")).SelectedItem.Text, ((DropDownList)gr.Cells[0].FindControl("DropDownList2")).SelectedItem.Text, ((TextBox)gr.Cells[0].FindControl("txt_frmtime")).Text, ((TextBox)gr.Cells[0].FindControl("txt_totime")).Text);
                             
                    }
                }
                //objservice.insert_paymentterms(ddl_drname.SelectedValue, Text_pervisit_amt.Text, Text_patientlimit.Text, Text_perpatient_amt.Text, Text_abovemaximum_amt.Text, Text_abovemaximum_percent.Text, Text_lab_amt.Text, Text_lab_percent.Text, Text_procedurecharges_amt.Text, Text_procedurecharges_percent.Text, Text_echo_amt.Text, Text_echo_percent.Text, Text_tmt_amt.Text, Text_tmt_percent.Text, Text_scan_amt.Text, Text_scan_percent.Text,Text_pft_amt.Text,Text_pft_percent.Text,Text_taall.Text,Text_tasunday.Text);
                objservice.delete_select();
                Response.Write("<script>alert('Doctor Registered Successfully')</script>");
                ddl_branchname.ClearSelection();
                ddl_dept.Items.Clear();
                ddl_drarea.ClearSelection();
                ddl_drname.Items.Clear();
                ddl_visitingperiod.ClearSelection();
                div_monthly.Visible = false;
                div_weekly.Visible = false;
                //txt_paymentterms.Text = string.Empty;

            }           
        }

        protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            dt.Rows[e.RowIndex].Delete();
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                

            }
        }
    
        protected void Gridview1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Gridview1.DataBind();
        }

        protected void Gridview2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            dt.Rows[e.RowIndex].Delete();
            Gridview2.DataSource = dt;
            Gridview2.DataBind();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {


            }
        }

        protected void Gridview2_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Gridview2.DataBind();
        }
    }
}