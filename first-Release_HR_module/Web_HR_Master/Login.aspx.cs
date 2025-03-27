using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_HR_Master
{
    public partial class Login : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objservice = new ServiceReference1.WebService_HRMasterSoapClient();
        ServiceReference2.WebService_ModuleUsageSoapClient objservice1 = new ServiceReference2.WebService_ModuleUsageSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Login(Text_username.Text, Text_password.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string type = dt.Rows[0]["type"].ToString();
                string username = dt.Rows[0]["username"].ToString();
                string log_user = dt.Rows[0]["log_user"].ToString();
                string designation = dt.Rows[0]["DESIGNATION"].ToString();
                string branch_id = dt.Rows[0]["branchid"].ToString();
                //if (type == "hr" || type == "hrhead" || type == "techlead" || type =="developer")
                //{
                    Session["USERTYPE"] = type;
                    Session["USERID"] = username;
                    Session["LOGUSER"] = log_user;
                    Session["BRANCHID"] = branch_id;

                Session["DESIGNATION"] = designation;
                DataTable dtBranch = objservice.Get_branchName(branch_id).Tables[0];
                string branch_name = dtBranch.Rows[0]["BRANCH_NAME"].ToString();
                Session["BRANCH_NAME"] = branch_name;
               objservice1.insert_Module_Log("HR Master", username, DateTime.Now.ToString("dd-MM-yyyy"));
                    //objservice.Insert_Usage(username);
                    Response.Redirect("WelcomePage.aspx");
                    Session.RemoveAll();
                //}
                //else
                //{
                //    Label1.Visible = true;
                //    Label1.Text = "You can't access this !..........";
                //    Label1.ForeColor = System.Drawing.Color.Red;
                //}
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Employee Id and Password is incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}