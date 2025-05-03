using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Add_Staffshiftchange : System.Web.UI.Page
    {
        //ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if(!IsPostBack)
        //    {
        //        bindddlbranch();
        //        bindddlshift();
        //    }
        //}

        //private void bindddlbranch()
        //{
        //    DataTable dt1 = new DataTable();
        //    dt1 = objservice.Get_Branch().Tables[0];
        //    ddl_branch.DataSource = dt1;
        //    ddl_branch.DataTextField = "NAME";
        //    ddl_branch.DataValueField = "BRANCH_ID";
        //    ddl_branch.DataBind();
        //    ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        //}

        //private void bindddlemployee()
        //{
        //    DataTable dt1 = new DataTable();
        //    dt1 = objservice.Get_Employees(ddl_dept.SelectedValue,ddl_branch.SelectedValue).Tables[0];
        //    ddl_employee.DataSource = dt1;
        //    ddl_employee.DataTextField = "EMP_NAME";
        //    ddl_employee.DataValueField = "EMPLOYEE_CODE";
        //    ddl_employee.DataBind();
        //    ddl_employee.Items.Insert(0, new ListItem("---Select---", "0"));
        //}

        //private void bindddldept()
        //{
        //    DataTable dt1 = new DataTable();
        //    dt1 = objservice.Get_Empdept().Tables[0];
        //    ddl_dept.DataSource = dt1;
        //    ddl_dept.DataTextField = "DEPARTMENT";
        //    ddl_dept.DataValueField = "DEPARTMENT_ID";
        //    ddl_dept.DataBind();
        //    ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        //}

        //private void bindddlshift()
        //{
        //    DataTable dt1 = new DataTable();
        //    dt1 = objservice.Get_shift().Tables[0];
        //    ddl_shift.DataSource = dt1;
        //    ddl_shift.DataTextField = "SHIFT_NAME";
        //    ddl_shift.DataValueField = "SHIFT_ID";
        //    ddl_shift.DataBind();
        //    ddl_shift.Items.Insert(0, new ListItem("---Select---", "0"));
        //}

        //protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bindddlemployee();
        //}

        //protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    bindddldept();

        //    DataTable dt = new DataTable();
        //    dt = objservice.employee_Shiftreport(ddl_branch.SelectedValue).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();
        //    }
        //}

        //protected void ButtonSubmit_Click(object sender, EventArgs e)
        //{
        //    objservice.Update_employeeshift(ddl_employee.SelectedValue,ddl_shift.SelectedValue,"151639");
            
        //    ddl_dept.ClearSelection();
        //    ddl_employee.Items.Clear();
        //    ddl_employee.DataBind();
        //    ddl_shift.ClearSelection();
        //    DataTable dt = new DataTable();
        //    dt = objservice.employee_Shiftreport(ddl_branch.SelectedValue).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();
        //    }
        //    Response.Write("<script>alert('Shift Updated Successfully')</script>");
        //}
    }
}