using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class Leave_Application : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txt_EmpCode.Text = Session["USERID"].ToString();
                txt_EmpName.Text = Session["LOGUSER"].ToString();
                txt_Post.Text = Session["DESIGNATION"].ToString();
                txt_branch.Text = Session["BRANCH_NAME"].ToString();
                txt_AppliedDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                DataTable dtSanctionLeaveCount = objService.GetLeaveSanctionedCount(Session["USERID"].ToString(), DateTime.Now.ToString("yyyy-MM-dd")).Tables[0];
                if (dtSanctionLeaveCount.Rows.Count > 0)
                {
                    txtTotal.Text= dtSanctionLeaveCount.Rows[0]["Remaining_leaves"].ToString();
                }

                }

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            int res=0;
            DateTime fromDate = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null);
            DateTime toDate = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", null);
            // Store dates in a list
            
            for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
            {
                string leave_dates =date.ToString("dd-MMM-yyyy");
                 res = objService.InsertLeaveApplicaton(Session["USERID"].ToString(), txt_AppliedDate.Text, leave_dates.ToString(), txtReason.Text, ddl_leaveType.SelectedValue.ToString());

            }


            if (res > 0)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Applied Leave....');", true);
                ddl_leaveType.ClearSelection();
                txtFromDate.Text = string.Empty;
                txtToDate.Text = string.Empty;
                txtDays.Text = string.Empty;
                txtReason.Text = string.Empty;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something went wrong.');", true);

            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            ddl_leaveType.ClearSelection();
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtDays.Text = string.Empty;
            txtReason.Text = string.Empty;
            Response.Redirect("WelcomePage.aspx");
        }
        public void calculate_date(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null);
            DateTime toDate = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", null);

            int daysDifference = ((toDate - fromDate)).Days;

            txtDays.Text = (daysDifference+1).ToString();

        }
    }
}