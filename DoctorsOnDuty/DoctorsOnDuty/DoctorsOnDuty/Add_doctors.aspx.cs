using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Add_doctors : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddldept();
            }
        }
        private void bindddldept()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_department().Tables[0];
            ddl_dept.DataSource = dt;
            ddl_dept.DataTextField = "dept_name";
            ddl_dept.DataValueField = "dept_id";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddldoctor()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_doctor(ddl_dept.SelectedValue).Tables[0];
            ddl_doctor.DataSource = dt;
            ddl_doctor.DataTextField = "name";
            ddl_doctor.DataValueField = "staff_id";
            ddl_doctor.DataBind();
            ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddldoctor();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_duplicatedr(ddl_doctor.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('Doctor Already Registered')</script>");
            }
            else
            {
                objservice.insert_doctors(ddl_doctor.SelectedValue, ddl_doctor.SelectedItem.Text, ddl_dept.SelectedValue);
                Response.Write("<script>alert('Doctor Registered Successfully')</script>");
                ddl_dept.ClearSelection();
                ddl_doctor.Items.Clear();
            }
        }
    }
}