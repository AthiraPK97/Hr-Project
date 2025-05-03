using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class View_doctors : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                DataTable dt1 = new DataTable();
                dt1 = objservice.Get_Branch().Tables[0];
                ddl_branchname.DataSource = dt1;
                ddl_branchname.DataTextField = "NAME";
                ddl_branchname.DataValueField = "BRANCH_ID";
                ddl_branchname.DataBind();
                ddl_branchname.Items.Insert(0, new ListItem("---Select---", "0"));

            }
        }

        protected void ddl_branchname_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_departmentdetails(ddl_branchname.SelectedValue).Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "DEPT_NAME";
            ddl_dept.DataValueField = "DEPT_ID";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctorsdetails(ddl_branchname.SelectedValue,ddl_dept.SelectedValue).Tables[0];
            ddl_drname.DataSource = dt;
            ddl_drname.DataTextField = "dr_name";
            ddl_drname.DataValueField = "dr_id";
            ddl_drname.DataBind();
            ddl_drname.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_duplicationfordrreg(ddl_drname.SelectedValue, ddl_dept.SelectedValue, ddl_branchname.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}