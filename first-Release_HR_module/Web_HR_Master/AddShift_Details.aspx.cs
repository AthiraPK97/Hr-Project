using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class AddShift_Details : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_Branch();
                string branch = Session["BRANCHID"].ToString();
                DataTable dt_ShiftDt = objService.Get_staffShiftDetails(Session["BRANCHID"].ToString()).Tables[0];
                if (dt_ShiftDt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt_ShiftDt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
          

        }

        public void load_Branch()
        {
            DataTable dt_branch = objService.Get_branches().Tables[0];
            if (dt_branch.Rows.Count > 0)
            {

                ddl_Branch.DataSource = dt_branch;
                ddl_Branch.DataValueField = "BRANCH_ID";
                ddl_Branch.DataTextField = "BRANCH_NAME";
                ddl_Branch.DataBind();
                ddl_Branch.Items.Insert(0, new ListItem("---Select---", "-1"));

            }
        }
        //public void load_postname(object sender, EventArgs e)
        //{
        //    DataTable dt_Post = objService.Get_dept_Details().Tables[0];
        //    if (dt_Post.Rows.Count > 0)
        //    {

        //        ddl_Post.DataSource = dt_Post;
        //        ddl_Post.DataValueField = "dep_ID";
        //        ddl_Post.DataTextField = "DEP_NAME";
        //        ddl_Post.DataBind();
        //        ddl_Post.Items.Insert(0, new ListItem("---Select---", "-1"));

        //    }

        //}

        public void load_Shift(object sender, EventArgs e)
        {
            DataTable dt_Shift = objService.Get_shiftDetails().Tables[0];
            if (dt_Shift.Rows.Count > 0)
            {

                ddl_Shift.DataSource = dt_Shift;
                ddl_Shift.DataValueField = "shift_id";
                ddl_Shift.DataTextField = "shift";
                ddl_Shift.DataBind();
                ddl_Shift.Items.Insert(0, new ListItem("---Select---", "-1"));

            }

        }
        public void load_username(object sender, EventArgs e)
        {
            DataTable dt_userName = objService.Get_user_Details(ddl_Branch.SelectedValue.ToString()).Tables[0];
            if (dt_userName.Rows.Count > 0)
            {

                ddl_username.DataSource = dt_userName;
                ddl_username.DataValueField = "UNIQUE_USERNAME";
                ddl_username.DataTextField = "username";
                ddl_username.DataBind();
                ddl_username.Items.Insert(0, new ListItem("---Select---", "-1"));

            }

        }
        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            if (ddl_Branch.SelectedIndex == -1)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Choose Branch ...');", true);
            else if (ddl_Branch.SelectedIndex == 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Choose designation...');", true);
            else if (ddl_username.SelectedIndex == -1)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Choose Username...');", true);

            int res = objService.InsertStaffShift(ddl_username.SelectedValue.ToString(), ddl_Branch.SelectedValue.ToString(), ddl_Shift.SelectedValue.ToString());

            if (res > 0)
            {
                DataTable dt_ShiftDt = objService.Get_staffShiftDetails(ddl_Branch.SelectedValue.ToString()).Tables[0];
                if (dt_ShiftDt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt_ShiftDt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Registered....');", true);
                ddl_username.ClearSelection();
                ddl_Shift.ClearSelection();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured ........');", true);

            }
        }

     

     


  

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlContnam = (DropDownList)e.Row.FindControl("ddl_shift");
                DataTable dt_Shift = objService.Get_shiftDetails().Tables[0];
                ddlContnam.DataSource = dt_Shift;
                ddlContnam.DataTextField = "shift";
                ddlContnam.DataValueField = "shift_id";
                ddlContnam.DataBind();
                string selectcontainer = DataBinder.Eval(e.Row.DataItem, "shift").ToString();
                string a = ddlContnam.Items.FindByText(selectcontainer).ToString();
                if (ddlContnam.Items.FindByText(selectcontainer) != null)
                {
                    ddlContnam.Items.FindByText(selectcontainer).Selected = true;
                }
            }
        }
    }
}