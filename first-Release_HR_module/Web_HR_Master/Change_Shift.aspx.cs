using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class Change_Shift : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                load_Branch();
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
        public void load_Shiftdetails(object sender, EventArgs e)
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
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DataTable dtt = new DataTable();
            dtt = objService.Get_staffShiftDetails(ddl_Branch.SelectedValue.ToString()).Tables[0];
            GridView1.DataSource = dtt;
            GridView1.DataBind();
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            DropDownList EditddlShift = (DropDownList)row.FindControl("ddl_SHIFT");
            if (EditddlShift != null)
            {
                DataTable dt_Shift = objService.Get_shiftDetails().Tables[0];


                EditddlShift.DataSource = dt_Shift;
                EditddlShift.DataTextField = "shift";
                EditddlShift.DataValueField = "shift_id";
                EditddlShift.DataBind();

            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lblUsername = ((Label)GridView1.Rows[e.RowIndex].FindControl("Lbl_username")).Text;
            //string ddlShift = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("SHIFT")).SelectedValue.ToString();
            //DropDownList EditddlShift = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddl_SHIFT");
            //if (EditddlShift != null)
            //{
            //    DataTable dt_Shift = objService.Get_shiftDetails().Tables[0];


            //    EditddlShift.DataSource = dt_Shift;
            //    EditddlShift.DataTextField = "shift";
            //    EditddlShift.DataValueField = "shift_id";
            //    EditddlShift.DataBind();

            //}
            DropDownList ddlShift = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddl_SHIFT");
            string selectedShift = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddl_SHIFT")).SelectedValue.ToString();
            if (!string.IsNullOrEmpty(ddlShift.ToString()))
            {
                selectedShift = ddlShift.Text;
            }
            else
            {
                Response.Write("DropDownList not found");
            }

            int result = objService.UpdateStaffShift(lblUsername, selectedShift);
            GridView1.EditIndex = -1;


            if (result > 0)
            {
                DataTable dtt = new DataTable();
                dtt = objService.Get_staffShiftDetails(ddl_Branch.SelectedValue.ToString()).Tables[0];
                if (dtt.Rows.Count > 0)
                {
                    GridView1.DataSource = dtt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Updated....');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured ........');", true);

            }

        }

        protected void GridView1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DataTable dtt = new DataTable();
            dtt = objService.Get_staffShiftDetails(ddl_Branch.SelectedValue.ToString()).Tables[0];
            GridView1.DataSource = dtt;
            GridView1.DataBind();

        }
    }

}