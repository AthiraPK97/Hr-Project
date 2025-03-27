using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class LeaveApproval : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_userdata(sender, e);
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelcomePage.aspx");

        }
        public void load_userdata(object sender, EventArgs e)
        {
           string SelectDate = txtselectDate.Text;
            if(string.IsNullOrEmpty(SelectDate))
            {
                SelectDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            DataTable dtleaveData = objService.GetLeaveUserDetails(SelectDate).Tables[0];
            if (dtleaveData.Rows.Count > 0)
            {

                ddl_empList.DataSource = dtleaveData;
                ddl_empList.DataValueField = "userData";
                ddl_empList.DataTextField = "userData";
                ddl_empList.DataBind();
                ddl_empList.Items.Insert(0, new ListItem("---Select---", "-1"));

            }

        }
        public void fill_data(object sender, EventArgs e)
        {
            string SelectDate = txtselectDate.Text;
            if (string.IsNullOrEmpty(SelectDate))
            {
                SelectDate = DateTime.Now.ToString("yyyy-MM-dd");
            }

            DataTable dtleaveData = objService.GetLeaveUserDetailsForuser(ddl_empList.SelectedValue.ToString(),SelectDate).Tables[0];
            if (dtleaveData.Rows.Count > 0)
            {
                txt_EmpName.Text = dtleaveData.Rows[0]["log_user"].ToString();
                txt_AppliedDate.Text= dtleaveData.Rows[0]["apply_date"].ToString();
                txt_fromDate.Text = dtleaveData.Rows[0]["fromDate"].ToString();
                txt_ToDate.Text  = dtleaveData.Rows[0]["toDate"].ToString();
                DateTime fromDate = Convert.ToDateTime(dtleaveData.Rows[0]["fromDate"]);
                DateTime toDate = Convert.ToDateTime(dtleaveData.Rows[0]["ToDate"]);

                int daysDifference = (toDate - fromDate).Days;
                txt_duration.Text = (daysDifference + 1).ToString();
                txtReason.Text = dtleaveData.Rows[0]["reason"].ToString();
                 txt_LeaveType.Text = dtleaveData.Rows[0]["leave_type"].ToString();
                txt_Post.Text = dtleaveData.Rows[0]["designation"].ToString();
                txt_branch.Text = dtleaveData.Rows[0]["branch_name"].ToString();
                txtEmpCode.Text= dtleaveData.Rows[0]["username"].ToString();


            }
            DataTable dtLeaveCount = objService.GetLeaveAppliedCount(dtleaveData.Rows[0]["username"].ToString(),SelectDate).Tables[0];
            if (dtLeaveCount.Rows.Count > 0)
            {
                txt_totalLeave.Text = dtLeaveCount.Rows[0]["applied_count"].ToString();
            }
            DataTable dtSanctionLeaveCount = objService.GetLeaveSanctionedCount(dtleaveData.Rows[0]["username"].ToString(), SelectDate).Tables[0];
            if (dtSanctionLeaveCount.Rows.Count > 0)
            {
                txt_sanctionLeave.Text = dtSanctionLeaveCount.Rows[0]["sanctioned_count"].ToString();
                txt_AvailableLeave.Text = dtSanctionLeaveCount.Rows[0]["Remaining_leaves"].ToString();
            }
        }
            protected void btnApply_Click(object sender, EventArgs e)
        {
            int result = objService.UpdateLeaveApplicationStatus( txtEmpCode.Text,ddl_ApprovedStatus.SelectedValue.ToString(),txt_fromDate.Text,txt_ToDate.Text,txtReMark.Text);
            if(result>0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Updated....');", true);
                load_userdata(sender, e);
                ddl_ApprovedStatus.ClearSelection();
                txt_EmpName.Text = string.Empty;
                txt_AppliedDate.Text = string.Empty;
                txt_fromDate.Text = string.Empty;
                txt_ToDate.Text = string.Empty;
                txtReason.Text = string.Empty;
                txt_LeaveType.Text = string.Empty;
                txt_Post.Text = string.Empty;
                txt_branch.Text = string.Empty;
                txtEmpCode.Text= string.Empty;
                txt_AvailableLeave.Text = string.Empty;
                txt_sanctionLeave.Text = string.Empty;
                txt_totalLeave.Text = string.Empty;
                txtReMark.Text = string.Empty;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured ........');", true);

            }

        }
    }
}