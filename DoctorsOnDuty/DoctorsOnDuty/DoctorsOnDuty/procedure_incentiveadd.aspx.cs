using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class procedure_incentiveadd : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddldept();
            }
            Btn_submit.Visible = false;
        }

        private void bindddldept()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_department().Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "DEPT_NAME";
            ddl_dept.DataValueField = "DEPT_ID";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctorsforprocincentive(ddl_dept.SelectedValue).Tables[0];
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
            if (dt.Rows.Count > 0)
            {
                Btn_submit.Visible = true;
            }
            else
            {
                Btn_submit.Visible = false;
            }
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in Gridview1.Rows)
            {
                objservice.delete_duplicateprocedurepercent(((Label)gr.Cells[0].FindControl("lbl_drid")).Text);
                objservice.Reg_procdrincentivepercent(ddl_dept.SelectedValue, ((Label)gr.Cells[0].FindControl("lbl_drid")).Text, Convert.ToDecimal(((TextBox)gr.Cells[0].FindControl("txt_incentive")).Text));
            }
            objservice.delete_nulldataproc();
            Response.Write("<script>alert('Doctor Procedure Charge Incentive Percentage Added Successfully')</script>");
            ddl_dept.ClearSelection();
            Gridview1.DataSource = null;
            Gridview1.DataBind();
        }
    }
}