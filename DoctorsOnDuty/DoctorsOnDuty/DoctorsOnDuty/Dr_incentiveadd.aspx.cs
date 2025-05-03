using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Dr_incentiveadd : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddldept();
            }
            Btn_submit.Visible = false;

            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
            LinkButton3.Visible = false;
            LinkButton4.Visible = false;
            LinkButton5.Visible = false;
            LinkButton6.Visible = false;
            LinkButton7.Visible = false;
            LinkButton8.Visible = false;
            LinkButton9.Visible = false;
            LinkButton10.Visible = false;
            LinkButton11.Visible = false;
            LinkButton12.Visible = false;
            LinkButton13.Visible = false;
        }

        private void bindddldept()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_department().Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "DEPT_NAME";
            ddl_dept.DataValueField = "DEPT_ID";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "-1"));
            ddl_dept.Items.Insert(1, new ListItem("Department null", "0"));
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_dept.SelectedValue=="0")
            {
                LinkButton1.Visible = true;
                LinkButton2.Visible = true;
                LinkButton3.Visible = true;
                LinkButton4.Visible = true;
                LinkButton5.Visible = true;
                LinkButton6.Visible = true;
                LinkButton7.Visible = true;
                LinkButton8.Visible = true;
                LinkButton9.Visible = true;
                LinkButton10.Visible = true;
                LinkButton11.Visible = true;
                LinkButton12.Visible = true;
                LinkButton13.Visible = true;
                Gridview1.DataSource = null;
                Gridview1.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                dt = objservice.Get_Doctorsforincentive(ddl_dept.SelectedValue).Tables[0];
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
            
        }

        protected void AB_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_ABDoctor().Tables[0];
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

        protected void CD_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_CDDoctor().Tables[0];
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
        protected void EF_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_EFDoctor().Tables[0];
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
        protected void GH_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_GHDoctor().Tables[0];
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
        protected void IJ_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_IJDoctor().Tables[0];
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
        protected void KL_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_KLDoctor().Tables[0];
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
        protected void MN_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_MNDoctor().Tables[0];
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
        protected void OP_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_OPDoctor().Tables[0];
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
        protected void QR_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_QRDoctor().Tables[0];
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
        protected void ST_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_STDoctor().Tables[0];
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
        protected void UV_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_UVDoctor().Tables[0];
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
        protected void WX_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_WXDoctor().Tables[0];
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
        protected void YZ_Click(object sender, EventArgs e)
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton5.Visible = true;
            LinkButton6.Visible = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            LinkButton9.Visible = true;
            LinkButton10.Visible = true;
            LinkButton11.Visible = true;
            LinkButton12.Visible = true;
            LinkButton13.Visible = true;
            Gridview1.DataSource = null;
            Gridview1.DataBind();

            DataTable dt = new DataTable();
            dt = objservice.Get_YZDoctor().Tables[0];
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
            //if (ddl_dept.SelectedItem.Text == "---Select---")
            //{
            //    Response.Write("<script>alert('Please Select Department')</script>");
            //}
            //else if (ddl_drname.SelectedItem.Text == "---Select---")
            //{
            //    Response.Write("<script>alert('Please Select Doctor Name')</script>");
            //}
            //else
            //{
            //    DataTable dt = new DataTable();
            //    dt = objservice.Get_duplicationfordrincentivepercent(ddl_drname.SelectedValue).Tables[0];
            //    if (dt.Rows.Count > 0)
            //    {
            //        Response.Write("<script>alert('This Doctor Incentive Percentage Already Added')</script>");
            //    }
            //    else
            //    {
            //        objservice.Reg_drincentivepercent(ddl_dept.SelectedValue, ddl_drname.SelectedValue, Convert.ToDecimal(txt_lab.Text), Convert.ToInt32(txt_mammoscan.Text), Convert.ToDecimal(txt_ct.Text));
            //        Response.Write("<script>alert('Doctor Incentive Percentage Added Successfully')</script>");
            //        ddl_dept.ClearSelection();
            //        ddl_drname.Items.Clear();
            //        txt_lab.Text = "0";
            //        txt_mammoscan.Text = "0";
            //        txt_ct.Text = "0";
            //    }
            //}

            foreach (GridViewRow gr in Gridview1.Rows)
            {
                objservice.delete_duplicatedoctorpercent(((Label)gr.Cells[0].FindControl("lbl_drid")).Text);
                objservice.Reg_drincentivepercent(ddl_dept.SelectedValue, ((Label)gr.Cells[0].FindControl("lbl_drid")).Text, Convert.ToDecimal(((TextBox)gr.Cells[0].FindControl("txt_lab")).Text), Convert.ToInt32(((TextBox)gr.Cells[0].FindControl("txt_scan")).Text), Convert.ToDecimal(((TextBox)gr.Cells[0].FindControl("txt_ct")).Text));
            }
            objservice.delete_nulldata();
            Response.Write("<script>alert('Doctor Incentive Percentage Added Successfully')</script>");
            ddl_dept.ClearSelection();
            Gridview1.DataSource = null;
            Gridview1.DataBind();

        }
    }
}