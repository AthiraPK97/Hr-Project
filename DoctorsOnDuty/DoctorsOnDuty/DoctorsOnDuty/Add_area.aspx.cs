using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Add_area : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddlbranch();
               
            }
            
        }

        private void bindddlbranch()
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_Branch().Tables[0];
            ddl_branch.DataSource = dt1;
            ddl_branch.DataTextField = "NAME";
            ddl_branch.DataValueField = "BRANCH_ID";
            ddl_branch.DataBind();
            ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Area(ddl_branch.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            objservice.Insert_Area(ddl_branch.SelectedValue, txt_area.Text);
            
            Response.Write("<script>alert('Area Added Successfully')</script>");
            ddl_branch.ClearSelection();
            txt_area.Text = string.Empty;
            bindgrid();
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid();
        }
    }
}