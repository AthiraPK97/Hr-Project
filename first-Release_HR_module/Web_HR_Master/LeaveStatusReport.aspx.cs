using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class LeaveStatusReport : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void load_data(object sender,EventArgs e)
        {
            string username= Session["USERID"].ToString();
            DataTable dt = objService.ViewStatusOfLeave(username, txtFromDate.Text, txtToDate.Text).Tables[0];
            if(dt.Rows.Count>0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

    }
}