using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Shift_change : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Visible = false;
                bindddlbranch();
            }
        }

        private void bindddlbranch()
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_Branch().Tables[0];
            ddl_branch.DataSource = dt1;
            ddl_branch.DataTextField = "NAME";
            ddl_branch.DataValueField = "BRANCH_ID";
            ddl_branch.DataBind();
            ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddldept()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_departmentforshiftchange(txt_olddate.Text, ddl_branch.SelectedValue).Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "DEPT_NAME";
            ddl_dept.DataValueField = "DEPT_ID";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddldr()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctorsforshiftchange(Convert.ToInt32( ddl_branch.SelectedValue),Convert.ToInt32( ddl_dept.SelectedValue),txt_olddate.Text).Tables[0];
            ddl_drname.DataSource = dt;
            ddl_drname.DataTextField = "DR_NAME";
            ddl_drname.DataValueField = "DR_ID";
            ddl_drname.DataBind();
            ddl_drname.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void txt_date_OnChanged(object sender, EventArgs e)
        {
            bindddldept();
            bindddldr();

            ddl_drname.Items.Clear();
            txt_frmtime.Text = string.Empty;
            txt_totime.Text = string.Empty;
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddldept();
            bindddldr();
        }
        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddldr();

            txt_frmtime.Text = string.Empty;
            txt_totime.Text = string.Empty;
        }



        protected void ddl_drname_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_monthlyorweekly(ddl_drname.SelectedValue).Tables[0];
            string visiting_period = dt.Rows[0]["Weekly_monthly"].ToString();
            if (visiting_period == "Monthly")
            {
                //DataTable dt1 = new DataTable();
                //dt1=objservice.Get_allforshiftchangemonthly(ddl_dept.SelectedValue,txt_olddate.Text,ddl_drname.SelectedValue).Tables[0];
                //Label1.Text= dt1.Rows[0]["duty_id"].ToString();

                DataTable dt1 = new DataTable();
                dt1 = objservice.Get_allforshiftchangemonthly(ddl_dept.SelectedValue, txt_olddate.Text, ddl_drname.SelectedValue, ddl_branch.SelectedValue).Tables[0];
                ddl_oldtime.DataSource = dt1;
                ddl_oldtime.DataTextField = "time_";
                ddl_oldtime.DataValueField = "duty_id";
                ddl_oldtime.DataBind();
                //ddl_oldtime.Items.Insert(0, new ListItem("---Select---", "0"));

                //txt_time.Text= dt1.Rows[0]["duty_time"].ToString();

            }
            else
            {
                DataTable dt2 = new DataTable();
                dt2=objservice.Get_allforshiftchangeweekly(ddl_dept.SelectedValue, txt_olddate.Text, ddl_drname.SelectedValue, ddl_branch.SelectedValue).Tables[0];
                ddl_oldtime.DataSource = dt2;
                ddl_oldtime.DataTextField = "time_";
                ddl_oldtime.DataValueField = "duty_id";
                ddl_oldtime.DataBind();
                //Label1.Text = dt2.Rows[0]["duty_id"].ToString();
                //txt_time.Text= dt2.Rows[0]["duty_time"].ToString();
            }
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt=objservice.Get_duplicateforupdateshift(Label1.Text, txt_olddate.Text).Tables[0];
            if(dt.Rows.Count>0)
            {
                objservice.Update_shiftchange(txt_newdate.Text, txt_frmtime.Text,txt_totime.Text, txt_olddate.Text, ddl_oldtime.SelectedValue);
                Response.Write("<script>alert('Doctor Shift Changed Successfully')</script>");
                txt_newdate.Text = string.Empty;
                txt_olddate.Text = string.Empty;
                txt_frmtime.Text = string.Empty;
                txt_totime.Text = string.Empty;
                ddl_dept.ClearSelection();
                ddl_drname.ClearSelection();
                ddl_oldtime.ClearSelection();
            }
            else
            {
                objservice.Shift_change(ddl_oldtime.SelectedValue, txt_olddate.Text, txt_newdate.Text, txt_frmtime.Text,txt_totime.Text);
                Response.Write("<script>alert('Doctor Shift Changed Successfully')</script>");
                txt_newdate.Text = string.Empty;
                txt_olddate.Text = string.Empty;
                txt_frmtime.Text = string.Empty;
                txt_totime.Text = string.Empty;
                ddl_dept.Items.Clear();
                ddl_drname.Items.Clear();
                ddl_oldtime.Items.Clear();
            }           
        }
    }
}