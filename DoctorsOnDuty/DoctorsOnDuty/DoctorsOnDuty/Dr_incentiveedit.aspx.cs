using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Dr_incentiveedit : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlbinddept();
            }
        }

        private void ddlbinddept()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_departmentforincetiveedit().Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "DEPT_NAME";
            ddl_dept.DataValueField = "DEPT_ID";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_drforincetiveedit(ddl_dept.SelectedValue).Tables[0];
            ddl_drname.DataSource = dt;
            ddl_drname.DataTextField = "doctor_name";
            ddl_drname.DataValueField = "dr_id";
            ddl_drname.DataBind();
            ddl_drname.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_drname_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_percentageforincetiveedit(ddl_dept.SelectedValue,ddl_drname.SelectedValue).Tables[0];
            txt_lab.Text = dt.Rows[0]["lab_incentive"].ToString();
            txt_mammoscan.Text = dt.Rows[0]["mammo_scan_incentive"].ToString();
            txt_ct.Text = dt.Rows[0]["ct_incentive"].ToString();
        }

        protected void Edit_click(object sender, EventArgs e)
        {
            if(ddl_dept.SelectedItem.Text=="---Select---")
            {
                Response.Write("<script>alert('Please Select Department')</script>");
            }
            else if(ddl_drname.SelectedItem.Text=="---Select---")
            {
                Response.Write("<script>alert('Please Select Doctor Name')</script>");
            }
            else
            {
                objservice.Update_incentivepercent(ddl_dept.SelectedValue, ddl_drname.SelectedValue, Convert.ToDecimal(txt_lab.Text), Convert.ToInt32(txt_mammoscan.Text), Convert.ToDecimal(txt_ct.Text));
                txt_lab.Text = string.Empty;
                txt_mammoscan.Text = string.Empty;
                txt_ct.Text = string.Empty;
                ddl_drname.Items.Clear();
                ddl_dept.ClearSelection();
                Response.Write("<script>alert('Doctor Incentive Percentage Edited Successfully')</script>");
            }           
        }
    }
}