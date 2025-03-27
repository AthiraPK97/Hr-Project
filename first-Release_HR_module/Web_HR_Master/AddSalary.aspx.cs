using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class AddSalary : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_weekoffDays.Text = "4";
                txt_casualLeaveDays.Text = "1";
                load_Designation();
                DataTable dt_user = objService.Get_salaryDetails().Tables[0];
                if (dt_user.Rows.Count > 0)
                {
                    GridView1.DataSource = dt_user;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
        }

        public void load_Designation()
        {
            DataTable dt_branch = objService.Get_designationDetails().Tables[0];
            if (dt_branch.Rows.Count > 0)
            {

                ddl_Designation.DataSource = dt_branch;
                ddl_Designation.DataValueField = "DES_ID";
                ddl_Designation.DataTextField = "DESIGNATION";
                ddl_Designation.DataBind();
                ddl_Designation.Items.Insert(0, new ListItem("---Select---", "-1"));

            }
        }
        public void load_Userdetails(string designation)
        {
            DataTable dt_user = objService.Get_userDetails(designation).Tables[0];
            if (dt_user.Rows.Count > 0)
            {
                ddl_userName.DataSource = dt_user;
                ddl_userName.DataValueField = "username";
                ddl_userName.DataTextField = "log_user";
                ddl_userName.DataBind();
                ddl_userName.Items.Insert(0, new ListItem("---Select User---", "-1"));

            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {

            if (ddl_userName.SelectedIndex == -1)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Choose USER NAME...');", true);
            else if (ddl_Designation.SelectedIndex == 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Choose designation...');", true);
            int LeaveDays = Convert.ToInt32(txt_weekoffDays.Text) + Convert.ToInt32(txt_casualLeaveDays.Text);
            DataTable dt_userDetails = objService.Get_salaryDetailsWithUsername(ddl_userName.SelectedValue.ToString()).Tables[0];
            if (dt_userDetails.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('UserName Already registered.... You can update Data ....');", true);
                ddl_Designation.ClearSelection();
                ddl_userName.ClearSelection();
                txt_montlySalary.Text = string.Empty;
            }
            else
            {

                int res = objService.InsertSalary(ddl_userName.SelectedValue.ToString(), txt_montlySalary.Text, LeaveDays.ToString());

                if (res > 0)
                {
                    DataTable dt_user = objService.Get_salaryDetails().Tables[0];
                    if (dt_user.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt_user;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Registered....');", true);
                    ddl_Designation.ClearSelection();
                    ddl_userName.ClearSelection();
                    txt_montlySalary.Text = string.Empty;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured ........');", true);

                }
            }


        }

        protected void load_username(object sender, EventArgs e)
        {
            
                load_Userdetails(ddl_Designation.SelectedItem.ToString());
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DataTable dtt = new DataTable();
            dtt = objService.Get_salaryDetails().Tables[0];
            GridView1.DataSource = dtt;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string strUsername = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUsername")).Text;

            string strMonthlySalary = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMonthlySalary")).Text;
            string strLeaveDays = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLeaveDays")).Text;

            int result = objService.UpdateSalary(id, strUsername, strMonthlySalary, strLeaveDays);
            GridView1.EditIndex = -1;
            if (result > 0)
            {
                DataTable dtt = objService.Get_salaryDetails().Tables[0];
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

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
     
    
}