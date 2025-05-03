using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Doctors_attendance : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt1 = new DataTable();
                dt1 = objservice.Get_Branch().Tables[0];
                Ddl_branch.DataSource = dt1;
                Ddl_branch.DataTextField = "NAME";
                Ddl_branch.DataValueField = "BRANCH_ID";
                Ddl_branch.DataBind();
                Ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            Button2.Visible = false;

        }

        protected void ButtonView_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_duplicateforupdateattendance(txt_date.Text, Ddl_branch.SelectedValue).Tables[0];
            if(dt1.Rows.Count>0)
            {
                GridView2.DataSource = dt1;
                GridView2.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                dt = objservice.Get_detailsforattendance(txt_date.Text, Ddl_branch.SelectedValue).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            Button2.Visible = true;
            
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_duplicateforupdateattendance(txt_date.Text, Ddl_branch.SelectedValue).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                objservice.delete_duplicateforupdateattendance(txt_date.Text, Ddl_branch.SelectedValue);
                foreach (GridViewRow gr in GridView2.Rows)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("CheckBox1")).Checked == true)
                    {
                        objservice.Insert_drattendance(txt_date.Text, ((Label)gr.Cells[0].FindControl("lbl_ID")).Text, ((Label)gr.Cells[0].FindControl("lbl_Name")).Text, "PRESENT", 1);
                    }
                    else
                    {
                        objservice.Insert_drattendance(txt_date.Text, ((Label)gr.Cells[0].FindControl("lbl_ID")).Text, ((Label)gr.Cells[0].FindControl("lbl_Name")).Text, "LEAVE", 0);
                    }
                }
            }
            else
            {
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("CheckBox1")).Checked == true)
                    {
                        objservice.Insert_drattendance(txt_date.Text, ((Label)gr.Cells[0].FindControl("lbl_ID")).Text, ((Label)gr.Cells[0].FindControl("lbl_Name")).Text, "PRESENT", 1);
                    }
                    else
                    {
                        objservice.Insert_drattendance(txt_date.Text, ((Label)gr.Cells[0].FindControl("lbl_ID")).Text, ((Label)gr.Cells[0].FindControl("lbl_Name")).Text, "LEAVE", 0);
                    }
                }
            }


            Button2.Visible = true;
            Response.Write("<script>alert('Doctors Attendance Updated Successfully')</script>");
        }

    }
}