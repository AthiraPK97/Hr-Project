using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Edit_doctors_registration : System.Web.UI.Page
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

                DataTable dt1 = new DataTable();
                dt1 = objservice.Get_Branch().Tables[0];
                ddl_branchname.DataSource = dt1;
                ddl_branchname.DataTextField = "NAME";
                ddl_branchname.DataValueField = "BRANCH_ID";
                ddl_branchname.DataBind();
                ddl_branchname.Items.Insert(0, new ListItem("---Select---", "0"));
                
            }
            Label1.Visible = false;
        }


        protected void ddl_visitingperiod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_visitingperiod.SelectedItem.Text == "Monthly")
            {
                div_weekly.Visible = false;
                div_monthly.Visible = true;
                DataTable dt = new DataTable();
                dt = objservice.Get_Doctorsdtlforedit(ddl_drname.SelectedValue, ddl_dept.SelectedValue, ddl_branchname.SelectedValue).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string weekormonth = dt.Rows[0]["weekly_monthly"].ToString();
                    if(weekormonth== "Monthly")
                    {
                        ViewState["CurrentTable"] = dt;
                        Gridview1.DataSource = dt;
                        Gridview1.DataBind();
                    }
                }
            }
            else if (ddl_visitingperiod.SelectedItem.Text == "Weekly")
            {
                div_monthly.Visible = false;
                div_weekly.Visible = true;
                DataTable dt = new DataTable();
                dt = objservice.Get_Doctorsdtlforedit(ddl_drname.SelectedValue, ddl_dept.SelectedValue, ddl_branchname.SelectedValue).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string weekormonth = dt.Rows[0]["weekly_monthly"].ToString();
                    if (weekormonth == "Weekly")
                    {
                        ViewState["CurrentTable"] = dt;
                        Gridview2.DataSource = dt;
                        Gridview2.DataBind();
                    }
                }
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
            ddl_drarea.ClearSelection();
            ddl_visitingperiod.ClearSelection();
            div_monthly.Visible = false;
            div_weekly.Visible = false;
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctorsforedit(ddl_dept.SelectedValue, ddl_branchname.SelectedValue).Tables[0];
            ddl_drname.DataSource = dt;
            ddl_drname.DataTextField = "DR_NAME";
            ddl_drname.DataValueField = "DR_ID";
            ddl_drname.DataBind();
            ddl_drname.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_dr_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gridview1.DataSource = null;
            Gridview1.DataBind();
            SetInitialRow();
            Gridview2.DataSource = null;
            Gridview2.DataBind();
            SetInitialRow1();
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctorsdtlforedit(ddl_drname.SelectedValue,ddl_dept.SelectedValue,ddl_branchname.SelectedValue).Tables[0];
            if(dt.Rows.Count>0)
            {
                ddl_drarea.SelectedValue = dt.Rows[0]["dr_sittingarea"].ToString();
                ddl_visitingperiod.SelectedValue= dt.Rows[0]["weekly_monthly"].ToString();
                if (ddl_visitingperiod.SelectedValue == "Weekly")
                {
                    div_monthly.Visible = false;
                    div_weekly.Visible = true;
                    ViewState["CurrentTable1"] = dt;
                    Gridview2.DataSource = dt;
                    Gridview2.DataBind();
                }
                else
                {
                    div_weekly.Visible = false;
                    div_monthly.Visible = true;
                    ViewState["CurrentTable"] = dt;
                    Gridview1.DataSource = dt;
                    Gridview1.DataBind();
                }
            }
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

            if (ddl_drname.SelectedValue == "0")
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Doctor Name";
            }
            else if (ddl_dept.SelectedValue == "0")
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Department Name";
            }
            else if (ddl_branchname.SelectedValue == "0")
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Branch Name";
            }
            else if (ddl_drarea.SelectedIndex <= 0)
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Doctor Sitting Area";
            }
            else if (ddl_visitingperiod.SelectedIndex <= 0)
            {
                Label1.Visible = true;
                Label1.Text = "* Please Select Visiting Period";
            }
            else
            {
                objservice.delete_duplicationfordrreg(ddl_drname.SelectedValue, ddl_dept.SelectedValue, ddl_branchname.SelectedValue);
                if (ddl_visitingperiod.SelectedItem.Text == "Weekly")
                {
                    foreach (GridViewRow gr in Gridview2.Rows)
                    {
                        string weeknum = "0";
                        if (((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text == "Sunday")
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
                        
                        objservice.Doctor_registration(ddl_drname.SelectedValue, ddl_visitingperiod.SelectedItem.Text, weeknum, "0", ddl_branchname.SelectedValue, ddl_dept.SelectedValue, ddl_drarea.SelectedItem.Text, ddl_drname.SelectedItem.Text, ddl_dept.SelectedItem.Text, ddl_branchname.SelectedItem.Text, Session["USERID"].ToString(), ((DropDownList)gr.Cells[0].FindControl("DropDownList3")).SelectedItem.Text, "All", ((TextBox)gr.Cells[0].FindControl("txt_frmtime")).Text, ((TextBox)gr.Cells[0].FindControl("txt_totime")).Text);
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
                        //objservice.delete_duplicationfordrreg(ddl_drname.SelectedValue, ddl_dept.SelectedValue, ddl_branchname.SelectedValue);
                        objservice.Doctor_registration(ddl_drname.SelectedValue, ddl_visitingperiod.SelectedItem.Text, weeknum, week, ddl_branchname.SelectedValue, ddl_dept.SelectedValue, ddl_drarea.SelectedItem.Text, ddl_drname.SelectedItem.Text, ddl_dept.SelectedItem.Text, ddl_branchname.SelectedItem.Text, Session["USERID"].ToString(), ((DropDownList)gr.Cells[0].FindControl("DropDownList1")).SelectedItem.Text, ((DropDownList)gr.Cells[0].FindControl("DropDownList2")).SelectedItem.Text, ((TextBox)gr.Cells[0].FindControl("txt_frmtime")).Text, ((TextBox)gr.Cells[0].FindControl("txt_totime")).Text);

                    }
                }
                //objservice.insert_paymentterms(ddl_drname.SelectedValue, Text_pervisit_amt.Text, Text_patientlimit.Text, Text_perpatient_amt.Text, Text_abovemaximum_amt.Text, Text_abovemaximum_percent.Text, Text_lab_amt.Text, Text_lab_percent.Text, Text_procedurecharges_amt.Text, Text_procedurecharges_percent.Text, Text_echo_amt.Text, Text_echo_percent.Text, Text_tmt_amt.Text, Text_tmt_percent.Text, Text_scan_amt.Text, Text_scan_percent.Text,Text_pft_amt.Text,Text_pft_percent.Text,Text_taall.Text,Text_tasunday.Text);
                objservice.delete_select();
                Response.Write("<script>alert('Doctor Details Updated Successfully')</script>");
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
            int count1 = 0, count2 = 0;
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            count1 = dt.Rows.Count;
            dt.Rows[e.RowIndex].Delete();
            count2 = dt.Rows.Count;
            if (count1 == count2)
            {
                int i = Convert.ToInt32(e.RowIndex);
                dt.Rows.RemoveAt(i);
            }              
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
            int count1 = 0,count2=0;
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            count1 = dt.Rows.Count;
            dt.Rows[e.RowIndex].Delete();
            count2 = dt.Rows.Count;
            if(count1==count2)
            {
                int i = Convert.ToInt32(e.RowIndex);
                dt.Rows.RemoveAt(i);
            }           
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






        //-------------------------------------------------------------gridview1---------------------------------------------------------------------


        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("week_name", typeof(string)));
            dt.Columns.Add(new DataColumn("weekno_name", typeof(string)));
            dt.Columns.Add(new DataColumn("to_time", typeof(string)));
            dt.Columns.Add(new DataColumn("from_time", typeof(string)));
            dr = dt.NewRow();
            dr["week_name"] = string.Empty;
            dr["weekno_name"] = string.Empty;
            dr["to_time"] = string.Empty;
            dr["from_time"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

        }

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
                        dtCurrentTable.Rows[i - 1]["week_name"] = ddl1.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["weekno_name"] = ddl2.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["to_time"] = txt1.Text;
                        dtCurrentTable.Rows[i - 1]["from_time"] = txt2.Text;
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
                        ddl1.Text = dt.Rows[i]["week_name"].ToString();
                        ddl2.Text = dt.Rows[i]["weekno_name"].ToString();
                        txt1.Text = dt.Rows[i]["to_time"].ToString();
                        txt2.Text = dt.Rows[i]["from_time"].ToString();
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
            dt.Columns.Add(new DataColumn("week_name", typeof(string)));
            dt.Columns.Add(new DataColumn("to_time", typeof(string)));
            dt.Columns.Add(new DataColumn("from_time", typeof(string)));
            dr = dt.NewRow();
            dr["week_name"] = string.Empty;
            dr["to_time"] = string.Empty;
            dr["from_time"] = string.Empty;
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
                        //drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["week_name"] = ddl1.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["to_time"] = txt1.Text;
                        dtCurrentTable.Rows[i - 1]["from_time"] = txt2.Text;
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
                        ddl1.Text = dt.Rows[i]["week_name"].ToString();
                        txt1.Text = dt.Rows[i]["to_time"].ToString();
                        txt2.Text = dt.Rows[i]["from_time"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        protected void ButtonAdd_Click1(object sender, EventArgs e)
        {
            AddNewRowToGrid1();
        }




    }
}