using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Add_Norms_Staffsitting : System.Web.UI.Page
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
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_Empdept().Tables[0];
            ddl_dept.DataSource = dt1;
            ddl_dept.DataTextField = "DEPARTMENT";
            ddl_dept.DataValueField = "DEPARTMENT_ID";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_bookingid") as Label;
        //        DropDownList DropDownList1 = (e.Row.FindControl("Ddl_area") as DropDownList);
        //        DataTable dt = new DataTable();
        //        dt = objservice.Get_Area(ddl_branch.SelectedValue).Tables[0];
        //        DropDownList1.DataSource = dt;

        //        DropDownList1.DataTextField = "area_name";
        //        DropDownList1.DataValueField = "area_id";
        //        DropDownList1.DataBind();
        //        DropDownList1.Items.Insert(0, new ListItem("---Select---", "0"));


        //    }

        //}

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("Ddl_area");

                    //return DataTable havinf department data
                    DataTable dt = new DataTable();
                    dt = objservice.Get_Area(ddl_branch.SelectedValue).Tables[0];
                    ddList.DataSource = dt;
                    ddList.DataTextField = "area_name";
                    ddList.DataValueField = "area_id";
                    ddList.DataBind();

                    //DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedValue = dr["department_id"].ToString();
                }
            }
        }

        private void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Norms_Employees(ddl_branch.SelectedValue,ddl_dept.SelectedValue).Tables[0];
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
        protected void Btn_view_Click(object sender, EventArgs e)
        {
            bindgrid();
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            GridView1.EditIndex = e.NewEditIndex;
            //DataTable dt = new DataTable();
            //Label id = GridView1.Rows[e.NewEditIndex].FindControl("lbl_empcode") as Label;
            //dt = objservice.Get_Norms_Employees_update(id.Text).Tables[0];
            //if(dt.Rows.Count>0)
            //{
            //    string area_id = dt.Rows[0]["area_id"].ToString();
            //    DropDownList DropDownList1 = GridView1.Rows[e.NewEditIndex].FindControl("Ddl_area") as DropDownList;
            //    DropDownList1.SelectedValue = area_id;
            //}
            
            bindgrid();
        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update  
            Label empcode = GridView1.Rows[e.RowIndex].FindControl("lbl_empcode") as Label;
            //string areaid = ((GridView)GridView1.Rows[e.RowIndex].FindControl("Ddl_area")).SelectedValue.ToString();
            DropDownList DropDownList1 = GridView1.Rows[e.RowIndex].FindControl("Ddl_area") as DropDownList;
            string a = DropDownList1.SelectedValue;

            DataTable dt = new DataTable();
            dt = objservice.Get_Norms_Employees_update(empcode.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                objservice.Update_norms_staffs_sitting(Convert.ToInt32(DropDownList1.SelectedValue), empcode.Text);
            }
            else
            {
                objservice.Insert_norms_staffs_sitting(empcode.Text, Convert.ToInt32(DropDownList1.SelectedValue));
            }

            
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            bindgrid();
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            bindgrid();
        }
    }
}