using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Add_effect_area : System.Web.UI.Page
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
            dt1 = objservice.Get_Areaeffect().Tables[0];
            if (dt1.Rows.Count > 0)
            {
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            objservice.delete_Areaeffect();
            foreach (GridViewRow gr in GridView1.Rows)
            {
                int pharmacy = Convert.ToInt32(((CheckBox)gr.Cells[0].FindControl("CheckBox1")).Checked);
                int reception = Convert.ToInt32(((CheckBox)gr.Cells[0].FindControl("CheckBox2")).Checked);
                int nurse = Convert.ToInt32(((CheckBox)gr.Cells[0].FindControl("CheckBox3")).Checked);
                int extrastaff = Convert.ToInt32(((CheckBox)gr.Cells[0].FindControl("CheckBox4")).Checked);
                objservice.Insert_Area_effect(((Label)gr.Cells[0].FindControl("Label1")).Text, pharmacy, reception, nurse, extrastaff);
            }
            Response.Write("<script>alert('Effected Areas Updated Successfully')</script>");
        }
    }
}