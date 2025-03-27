using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class Leave_cancel : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_EmpCode.Text = Session["USERID"].ToString();
                txt_EmpName.Text = Session["LOGUSER"].ToString();
                load_userdata(sender,e);

            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelcomePage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int res = objService.UpdateLeaveCancelStatus(txt_EmpCode.Text ,"1", txtFromDate.Text, txtToDate.Text);
            if(res>0)
                {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Updated....');", true);
             
                clear_data();


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured....');", true);
            }
        }

        public void load_userdata(object sender, EventArgs e)
        {
          
                String SelectDate = DateTime.Now.ToString("yyyy-MM-dd");
           
            DataTable dtleaveData = objService.GetLeaveUserDetailsForCancel(SelectDate, txt_EmpCode.Text).Tables[0];
            if (dtleaveData.Rows.Count > 0)
            {

                ddl_empList.DataSource = dtleaveData;
                ddl_empList.DataValueField = "userData";
                ddl_empList.DataTextField = "userData";
                ddl_empList.DataBind();
                ddl_empList.Items.Insert(0, new ListItem("---Select---", "-1"));

            }
            else
            {
                Label1.Visible = true;
                Label1.InnerText = "No Leave To Cancel";
            }

        }

        public void fill_data(object sender, EventArgs e)
        {
            string SelectDate = DateTime.Now.ToString("yyyy-MM-dd");



            DataTable dtleaveData = objService.GetLeaveUserDetailsForuser(ddl_empList.SelectedValue.ToString(), SelectDate).Tables[0];
            if (dtleaveData.Rows.Count > 0)
            {
                txt_EmpName.Text = dtleaveData.Rows[0]["log_user"].ToString();
                txtLeaveApplyDate.Text = dtleaveData.Rows[0]["apply_date"].ToString();
                txtFromDate.Text = dtleaveData.Rows[0]["fromDate"].ToString();
                txtToDate.Text = dtleaveData.Rows[0]["toDate"].ToString();
                DateTime fromDate = Convert.ToDateTime(dtleaveData.Rows[0]["fromDate"]);
                DateTime toDate = Convert.ToDateTime(dtleaveData.Rows[0]["ToDate"]);

                int daysDifference = (toDate - fromDate).Days;
                txtReason.Text = dtleaveData.Rows[0]["reason"].ToString();
                txtLeaveType.Text = dtleaveData.Rows[0]["leave_type"].ToString();
            }
        }
        public void clear_data()
        {
            txtLeaveType.Text = string.Empty;
            txtLeaveApplyDate.Text = string.Empty;
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtReason.Text = string.Empty;
        }

        }
}