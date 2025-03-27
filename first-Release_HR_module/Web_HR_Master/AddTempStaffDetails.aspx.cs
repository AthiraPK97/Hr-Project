using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class AddTempStaffDetails : System.Web.UI.Page
    {

        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                load_UserDetails();
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            DataTable dt_Personaluserdetails = objService.Get_TempStaffPersonalDetails(ddl_empList.SelectedValue.ToString()).Tables[0];
            if (dt_Personaluserdetails.Rows.Count > 0)
            {

                DateTime txtJoinDate = DateTime.ParseExact(txtDateOfJoining.Text, "dd-MM-yyyy", null);
                DateTime txtDOBDate = DateTime.ParseExact(txtDob.Text, "dd-M-yyyy", null);
                string formattedDateJoining = txtJoinDate.ToString("dd-MMM-yyyy");
                string formattedDateDOB = txtDOBDate.ToString("dd-MMM-yyyy");
                int id= objService.UpdateTempPersonalData(txtAddress1.Text, formattedDateJoining, formattedDateDOB, txt_EmpCode.Text);
                if(id>0)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Updated....');", true);
                    clear();
                    ddl_empList.ClearSelection();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured....');", true);
                }
            }
            else
            {

                DateTime txtJoinDate = DateTime.ParseExact(txtDateOfJoining.Text, "dd-MM-yyyy", null);
                DateTime txtDOBDate = DateTime.ParseExact(txtDob.Text, "dd-M-yyyy", null);
                string formattedDateJoining = txtJoinDate.ToString("dd-MMM-yyyy");
                string formattedDateDOB = txtDOBDate.ToString("dd-MMM-yyyy");
                int id = objService.insertTempPersonalData(txtAddress1.Text + "," + txtAddress2.Text + "," + txtAddress3.Text + "," + txtAddress4.Text, formattedDateJoining, formattedDateDOB, txt_EmpCode.Text);
                if (id > 0)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Added Personal Data....');", true);
                    clear();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured....');", true);
                }
            }

            }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void load_UserDetails()
        {
            clear();
            DataTable dt_userdetails = objService.Get_TEmpName().Tables[0];
            if (dt_userdetails.Rows.Count > 0)
            {
                dt_userdetails.Columns.Add("DisplayText", typeof(string));

                // Populate the new column with concatenated values
                foreach (DataRow row in dt_userdetails.Rows)
                {
                    row["DisplayText"] = row[1].ToString() + "-" + row[8].ToString();
                }
                ddl_empList.Items.Clear();
                ddl_empList.DataSource = dt_userdetails;
                ddl_empList.DataValueField = "username";
                ddl_empList.DataTextField = "DisplayText";
                ddl_empList.DataBind();


                ddl_empList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", ""));

            }
        }
        public void load_UserDetails(object sender,EventArgs e)
        {

            DataTable dt_userdetails = objService.Get_TempStaffDetails(ddl_empList.SelectedValue.ToString()).Tables[0];
            if(dt_userdetails.Rows.Count>0)
            {
                txt_EmpCode.Text= dt_userdetails.Rows[0]["username"].ToString();
                txt_EmpName.Text = dt_userdetails.Rows[0]["log_user"].ToString();
                txt_branch.Text = dt_userdetails.Rows[0]["branch_name"].ToString();
                txt_Post.Text = dt_userdetails.Rows[0]["designation"].ToString();
            }

            DataTable dt_Personaluserdetails = objService.Get_TempStaffPersonalDetails(ddl_empList.SelectedValue.ToString()).Tables[0];
            if(dt_Personaluserdetails.Rows.Count>0)
            {
                txtAddress1.Text= dt_Personaluserdetails.Rows[0]["ADDRESS"].ToString();
                txtDateOfJoining.Text= dt_Personaluserdetails.Rows[0]["DATE_OF_JOINING"].ToString();
                txtDob.Text= dt_Personaluserdetails.Rows[0]["DOB"].ToString();
            }


        }
        public void clear()
        {
            txt_EmpName.Text = string.Empty;
            txt_EmpCode.Text = string.Empty;
            txt_branch.Text = string.Empty;
            txt_Post.Text = string.Empty; 
            txtDateOfJoining.Text = string.Empty; 
            txtDob.Text = string.Empty; 
            txtAddress1.Text = string.Empty; 
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtAddress4.Text = string.Empty;
            //ddl_empList.ClearSelection();
        }

        }
}