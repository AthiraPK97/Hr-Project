using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class AddStaffNorms : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!IsPostBack)
            {
                load_Branch();
                DataTable dt_user = objService.Get_staffNormsDetails().Tables[0];
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
        public void load_postname(object sender, EventArgs e)
        {

            DataTable dt_Post = objService.Get_Post_Details(ddl_Branch.SelectedValue.ToString()).Tables[0];
            if (dt_Post.Rows.Count > 0)
            {

                ddl_Post.DataSource = dt_Post;
                ddl_Post.DataValueField = "POST_ID";
                ddl_Post.DataTextField = "POST_NAME";
                ddl_Post.DataBind();
                ddl_Post.Items.Insert(0, new ListItem("---Select---", "-1"));

            }

        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            int res = 0;
            if (ddl_Branch.SelectedIndex == -1)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Choose ...');", true);
            else if (ddl_Post.SelectedIndex == 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Choose designation...');", true);

            DataTable dt_Norms = objService.Get_staffNormsDetails().Tables[0];
            if (dt_Norms.Rows.Count > 0)
            {
                bool postExists = dt_Norms.AsEnumerable()
                                  .Any(row => row["post_name"].ToString() == ddl_Post.SelectedItem.Text);

                if (postExists)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Added This Post ...');", true);
                    return;

                }
                else
                {

                     res = objService.InsertNorms(ddl_Branch.SelectedValue.ToString(), ddl_Post.SelectedValue.ToString(), txtNorms.Text);
                }
            }


            if (res > 0)
            {
                DataTable dt_user = objService.Get_staffNormsDetails().Tables[0];
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
               // ddl_Branch.SelectedItem.Text = string.Empty;
                ddl_Post.SelectedItem.Text = string.Empty;
                txtNorms.Text = string.Empty;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured ........');", true);

            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DataTable dtt = new DataTable();
            dtt = objService.Get_staffNormsDetails().Tables[0];
            GridView1.DataSource = dtt;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string strNorms = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNorms")).Text;

            int result = objService.UpdateNorms(id,strNorms);
            GridView1.EditIndex = -1;
            if (result > 0)
            {
                DataTable dtt = objService.Get_staffNormsDetails().Tables[0];
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