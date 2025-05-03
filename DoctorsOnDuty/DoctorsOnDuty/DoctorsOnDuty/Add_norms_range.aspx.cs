using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Add_norms_range : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gridbind();
            }
        }
        private void gridbind()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            DataTable dt1 = new DataTable();
            //dt1 = objservice.Get_Areaeffectdummy().Tables[0];
            dt1 = objservice.Get_Normsrange().Tables[0];
            if (dt1.Rows.Count > 0)
            {
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in GridView1.Rows)
            {
                string norms_area = ((string)((Label)gr.Cells[0].FindControl("Label2")).Text);
                int patient_ratio = Convert.ToInt32(((TextBox)gr.Cells[0].FindControl("TextBox1")).Text);
                int staff_ratio = Convert.ToInt32(((TextBox)gr.Cells[0].FindControl("TextBox2")).Text);
                objservice.Update_norms_range1(norms_area, patient_ratio, staff_ratio);
               // objservice.Update_norms_range(norms_area, patient_ratio, staff_ratio);
            }
            Response.Write("<script>alert('Norms Range Updated Successfully')</script>");
        }
    }
}