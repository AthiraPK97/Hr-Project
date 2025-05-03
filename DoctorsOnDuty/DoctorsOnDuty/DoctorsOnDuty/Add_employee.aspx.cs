using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Add_employee : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddlbranch();
                bindddldept();
            }
        }
        private void bindddldept()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_Empdept().Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "DEPARTMENT";
            ddl_dept.DataValueField = "DEPARTMENT_ID";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddlbranch()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_Branchforaddemployee().Tables[0];
            ddl_branch.DataSource = dt2;
            ddl_branch.DataTextField = "NAME";
            ddl_branch.DataValueField = "BRANCH_ID";
            ddl_branch.DataBind();
            ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddlemployee()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_Employees(ddl_branch.SelectedValue).Tables[0];
            //dt2 = objservice.Get_Employees1().Tables[0];
            ddl_employee.DataSource = dt2;
            ddl_employee.DataTextField = "emp_name";
            ddl_employee.DataValueField = "emp_code";
            ddl_employee.DataBind();
            ddl_employee.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_RegisteredEmployees(ddl_branch.SelectedValue,ddl_dept.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddlemployee();
            bindgrid();
        }
        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            objservice.insert_employeedtl(ddl_dept.SelectedValue, ddl_employee.SelectedValue, ddl_branch.SelectedValue, Session["USERID"].ToString());
            //ddl_dept.ClearSelection();
            //ddl_employee.Items.Clear();
            bindddlemployee();
            bindgrid();
            Response.Write("<script>alert('Employee Added Successfully')</script>");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {

            }
        }
        protected void GridView1_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label emp_code = GridView1.Rows[e.RowIndex].FindControl("lbl_empcode") as Label;

            objservice.delete_employee(emp_code.Text);
            bindgrid();

            Response.Write("<script>alert('Employee Deleted Successfully...!!')</script>");
        }
    }
}