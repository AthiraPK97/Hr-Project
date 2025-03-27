using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class Add_Temp_Staff : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                load_branch();
                load_designation();
                set_EmpCode();
                setShift();
            }
        }

        public void load_branch()
        {
            DataTable dt_branch = objService.Get_branchOfUsers().Tables[0];
            if(dt_branch.Rows.Count>0)
            {
                ddl_branch.DataSource = dt_branch;
                ddl_branch.DataValueField = "branch_id";
                ddl_branch.DataTextField = "branch_name";
                ddl_branch.DataBind();
            }
        }

        public void set_EmpCode()
        {
            DataTable dt_Empode = objService.Get_Employee_Code().Tables[0];
            if(dt_Empode.Rows.Count>0)
            {
                Text_uname.Text=dt_Empode.Rows[0]["NEXTVAL"].ToString();
                
            }
        }
        public void setShift()
        {
            DataTable dt_shift = objService.Get_shift().Tables[0];
            if (dt_shift.Rows.Count > 0)
            {
                dt_shift.Columns.Add("Shift_In_and_out", typeof(string));

                // Populate the new column with concatenated values
                foreach (DataRow row in dt_shift.Rows)
                {
                    row["Shift_In_and_out"] = row[1].ToString() + "-->" + row[4].ToString() + "-" + row[5].ToString();
                }
                ddlshift.Items.Clear();
                ddlshift.DataSource = dt_shift;
                ddlshift.DataValueField = "SHIFT_ID";
                ddlshift.DataTextField = "Shift_In_and_out";
                ddlshift.DataBind();
            }

        }
        public void load_designation()
        {
            DataTable dt_desig = objService.Get_designation().Tables[0];
            if (dt_desig.Rows.Count > 0)
            {
                ddldesignation.DataSource = dt_desig;
                ddldesignation.DataValueField = "type";
                ddldesignation.DataTextField = "designation";
                ddldesignation.DataBind();
            }
        }
        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            if (ddl_branch.SelectedIndex == -1)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Choose Branch...');", true);
            else if (ddldesignation.SelectedIndex == 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Choose designation...');", true);

            int res = objService.createLogin(Text_uname.Text, Text_Pswd.Text, ddldesignation.SelectedValue, ddldesignation.SelectedItem.Text, Text_mail.Text, RadioButtonList1.SelectedValue, ddl_branch.SelectedValue, Text_Loguser.Text, Session["USERID"].ToString());

            if (res > 0)
            {
                int res1 = objService.AddShift(ddlshift.SelectedValue.ToString(),Text_uname.Text, ddlshift.SelectedItem.ToString());
                if (res1 > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully added new user...');", true);
                    Text_uname.Text = string.Empty;
                    Text_Pswd.Text = string.Empty;
                    Text_mail.Text = string.Empty;
                    Text_Loguser.Text = string.Empty;
                    ddldesignation.SelectedIndex = 0;
                    set_EmpCode();
                }
            }
            else if (res == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already existing username....');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured creation failed..');", true);

            }
        }
    }
}