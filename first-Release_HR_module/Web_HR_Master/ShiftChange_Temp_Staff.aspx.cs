using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_HR_Master
{
    public partial class ShiftChange_Temp_Staff : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        string hdnSelectedDropdown;
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_shift.Visible = false;
            lbl_change_shift.Visible = false;
            txt_designation.Text = string.Empty;

            if (!IsPostBack) 
            {
                load_UserDetails();
            }
        }
        public void load_UserDetails()
        {
            DataTable dt_userdetails = objService.Get_TEmpName().Tables[0];
            if (dt_userdetails.Rows.Count > 0)
            {
                dt_userdetails.Columns.Add("DisplayText", typeof(string));

                // Populate the new column with concatenated values
                foreach (DataRow row in dt_userdetails.Rows)
                {
                    row["DisplayText"] = row[1].ToString() + "-" + row[8].ToString();
                }
                ddl_name.Items.Clear();
                ddl_name.DataSource = dt_userdetails;
                ddl_name.DataValueField = "username";
                ddl_name.DataTextField = "DisplayText";
                ddl_name.DataBind();

            }
        }

        public void load_currentShift()
        {
            DataTable dt_userdetails = objService.Get_ShiftAndName(ddl_name.SelectedValue.ToString()).Tables[0];
            if (dt_userdetails.Rows.Count > 0)
            {
                if(dt_userdetails.Rows[0]["change_shift"]!=null && dt_userdetails.Rows[0]["change_shift"].ToString() != "")
                {

                    Text_current_shift.Items.Add(new ListItem(Convert.ToString(dt_userdetails.Rows[0]["change_shift"])));
                    Text_current_shift.SelectedItem.Text = dt_userdetails.Rows[0]["change_shift"].ToString();
                    txt_designation.Text = dt_userdetails.Rows[0]["designation"].ToString();


                }
                else
                {
                    Text_current_shift.Items.Add(new ListItem(Convert.ToString(dt_userdetails.Rows[0]["normal_shift"])));
                    Text_current_shift.SelectedItem.Text = dt_userdetails.Rows[0]["normal_shift"].ToString();
                    txt_designation.Text = dt_userdetails.Rows[0]["designation"].ToString();

                }

                ddl_shift.Visible = true;
                lbl_change_shift.Visible = true;
                if (!string.IsNullOrEmpty(Text_current_shift.Text))
                {

                    Text_current_shift.Enabled = false;
                    ddl_shift.Visible = true;
                    lbl_change_shift.Visible = true;
                    Btn_Addshift.Enabled = false;
                    Btn_shift.Enabled = true;
                    setShift();
                }
                else
                {
                    Text_current_shift.Enabled = true;
                    setShift();
                    Btn_shift.Enabled = false;
                    Btn_Addshift.Enabled = true;

                }
            }
            else
            {
                Text_current_shift.Enabled = true;

                Btn_shift.Enabled = false;
                Btn_Addshift.Enabled = true;
                setShift();
            }

        }

        protected void ddl_name_changed(object sender, EventArgs e)
        {
            load_currentShift();
            
        }

        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            int res1 = objService.AddShift(Text_current_shift.SelectedValue.ToString(), ddl_name.SelectedValue.ToString(), Text_current_shift.SelectedItem.ToString());

            if (res1 > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully added...');", true);
                Text_current_shift.SelectedItem.Text = string.Empty;
                txt_designation.Text = string.Empty;
                }
            
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured creation failed..');", true);

            }
        }

        protected void Btn_Change_Click(object sender, EventArgs e)
        {

            int res1 = objService.UpdateShift(ddl_shift.SelectedValue.ToString(), ddl_shift.SelectedItem.ToString(), ddl_name.SelectedValue.ToString(),"");
          if(res1>0)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully added...');", true);
                ddl_shift.SelectedItem.Text = string.Empty;
                Text_current_shift.SelectedItem.Text = string.Empty;
                txt_designation.Text = string.Empty;
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured creation failed..');", true);

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
                    row["Shift_In_and_out"] = row[1].ToString() + "-->" + row[4].ToString() + "-"+row[5].ToString();
                }

                if (Text_current_shift.Enabled == false)
                {
                    ddl_shift.Items.Clear();
                    ddl_shift.DataSource = dt_shift;
                    ddl_shift.DataValueField = "SHIFT_ID";
                    ddl_shift.DataTextField = "Shift_In_and_out";
                    ddl_shift.DataBind();
                }
                else
                {
                    Text_current_shift.Items.Clear();
                    Text_current_shift.DataSource = dt_shift;
                    Text_current_shift.DataValueField = "SHIFT_ID";
                    Text_current_shift.DataTextField = "Shift_In_and_out";
                    Text_current_shift.DataBind();
                }
            }

        }
    }
}