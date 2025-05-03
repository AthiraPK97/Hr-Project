using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Edit_Drdetails : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dt1 = new DataTable();
                dt1 = objservice.Get_drsforpaymentedit().Tables[0];
                ddl_drname.DataSource = dt1;
                ddl_drname.DataTextField = "NAME";
                ddl_drname.DataValueField = "DR_ID";
                ddl_drname.DataBind();
                ddl_drname.Items.Insert(0, new ListItem("---Select---", "0"));

                Text_perpatient_amt.Visible = false;
                Text_pervisit_amt.Visible = false;
                Text_abovemaximum_amt.Visible = false;
                Text_abovemaximum_percent.Visible = false;
                Text_lab_amt.Visible = false;
                Text_lab_percent.Visible = false;
                Text_procedurecharges_amt.Visible = false;
                Text_procedurecharges_percent.Visible = false;
                Text_echo_amt.Visible = false;
                Text_echo_percent.Visible = false;
                Text_tmt_amt.Visible = false;
                Text_tmt_percent.Visible = false;
                Text_scan_amt.Visible = false;
                Text_scan_percent.Visible = false;
                Text_pft_amt.Visible = false;
                Text_pft_percent.Visible = false;
                Text_taall.Visible = false;
                Text_tasunday.Visible = false;

                Text_pervisit_amt.Text = "";
                Text_perpatient_amt.Text = "";
                Text_abovemaximum_amt.Text = "";
                Text_abovemaximum_percent.Text = "";
                Text_lab_amt.Text = "";
                Text_lab_percent.Text = "";
                Text_procedurecharges_amt.Text = "";
                Text_procedurecharges_percent.Text = "";
                Text_echo_amt.Text = "";
                Text_echo_percent.Text = "";
                Text_tmt_amt.Text = "";
                Text_tmt_percent.Text = "";
                Text_scan_amt.Text = "";
                Text_scan_percent.Text = "";
                Text_pft_amt.Text = "";
                Text_pft_percent.Text = "";
                Text_taall.Text = "";
                Text_tasunday.Text = "";
            }
        }

        protected void Ddldr_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_paymenttermforedit(ddl_drname.SelectedValue).Tables[0];
            if(dt.Rows.Count>0)
            {
                Text_paymentterms.Text= dt.Rows[0]["payment_terms"].ToString();
            }
        }

        protected void Pervisit_amt_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_pervisit.Checked == true)
            {
                Check_perpatient.Checked = false;
                Text_pervisit_amt.Visible = true;
                Text_perpatient_amt.Visible = false;
                Text_pervisit_amt.Text = "";
                Text_perpatient_amt.Text = "";
            }
            else
            {
                Text_pervisit_amt.Visible = false;
                Text_perpatient_amt.Visible = false;
                Text_pervisit_amt.Text = "";
                Text_perpatient_amt.Text = "";
            }

        }

        protected void Perpatient_amt_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_perpatient.Checked == true)
            {
                Check_pervisit.Checked = false;
                Text_perpatient_amt.Visible = true;
                Text_pervisit_amt.Visible = false;
                Text_perpatient_amt.Text = "";
                Text_pervisit_amt.Text = "";
            }
            else
            {
                Text_pervisit_amt.Visible = false;
                Text_perpatient_amt.Visible = false;
                Text_pervisit_amt.Text = "";
                Text_perpatient_amt.Text = "";
            }
        }

        protected void Abovemaximum_amt_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_abovemaximum_amt.Checked == true)
            {
                Check_abovemaximum_percent.Checked = false;
                Text_abovemaximum_amt.Visible = true;
                Text_abovemaximum_percent.Visible = false;
                Text_abovemaximum_amt.Text = "";
                Text_abovemaximum_percent.Text = "";
            }
            else
            {
                Text_abovemaximum_amt.Visible = false;
                Text_abovemaximum_percent.Visible = false;
                Text_abovemaximum_amt.Text = "";
                Text_abovemaximum_percent.Text = "";
            }

        }

        protected void Abovemaximum_percent_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_abovemaximum_percent.Checked == true)
            {
                Check_abovemaximum_amt.Checked = false;
                Text_abovemaximum_amt.Visible = false;
                Text_abovemaximum_percent.Visible = true;
                Text_abovemaximum_amt.Text = "";
                Text_abovemaximum_percent.Text = "";
            }
            else
            {
                Text_abovemaximum_amt.Visible = false;
                Text_abovemaximum_percent.Visible = false;
                Text_abovemaximum_amt.Text = "";
                Text_abovemaximum_percent.Text = "";
            }
        }

        protected void Lab_amt_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_lab_amt.Checked == true)
            {
                Check_lab_percent.Checked = false;
                Text_lab_amt.Visible = true;
                Text_lab_percent.Visible = false;
                Text_lab_amt.Text = "";
                Text_lab_percent.Text = "";
            }
            else
            {
                Text_lab_amt.Visible = false;
                Text_lab_percent.Visible = false;
                Text_lab_amt.Text = "";
                Text_lab_percent.Text = "";
            }
        }

        protected void Lab_percent_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_lab_percent.Checked == true)
            {
                Check_lab_amt.Checked = false;
                Text_lab_amt.Visible = false;
                Text_lab_percent.Visible = true;
                Text_lab_amt.Text = "";
                Text_lab_percent.Text = "";
            }
            else
            {
                Text_lab_amt.Visible = false;
                Text_lab_percent.Visible = false;
                Text_lab_amt.Text = "";
                Text_lab_percent.Text = "";
            }
        }

        protected void Procedurecharges_amt_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_procedurecharges_amt.Checked == true)
            {
                Check_procedurecharges_percent.Checked = false;
                Text_procedurecharges_amt.Visible = true;
                Text_procedurecharges_percent.Visible = false;
                Text_procedurecharges_amt.Text = "";
                Text_procedurecharges_percent.Text = "";
            }
            else
            {
                Text_procedurecharges_amt.Visible = false;
                Text_procedurecharges_percent.Visible = false;
                Text_procedurecharges_amt.Text = "";
                Text_procedurecharges_percent.Text = "";
            }
        }

        protected void Procedurecharges_percent_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_procedurecharges_percent.Checked == true)
            {
                Check_procedurecharges_amt.Checked = false;
                Text_procedurecharges_amt.Visible = false;
                Text_procedurecharges_percent.Visible = true;
                Text_procedurecharges_amt.Text = "";
                Text_procedurecharges_percent.Text = "";
            }
            else
            {
                Text_procedurecharges_amt.Visible = false;
                Text_procedurecharges_percent.Visible = false;
                Text_procedurecharges_amt.Text = "";
                Text_procedurecharges_percent.Text = "";
            }
        }

        protected void Echo_amt_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_echo_amt.Checked == true)
            {
                Check_echo_percent.Checked = false;
                Text_echo_amt.Visible = true;
                Text_echo_percent.Visible = false;
                Text_echo_amt.Text = "";
                Text_echo_percent.Text = "";
            }
            else
            {
                Text_echo_amt.Visible = false;
                Text_echo_percent.Visible = false;
                Text_echo_amt.Text = "";
                Text_echo_percent.Text = "";
            }
        }

        protected void Echo_percent_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_echo_percent.Checked == true)
            {
                Check_echo_amt.Checked = false;
                Text_echo_amt.Visible = false;
                Text_echo_percent.Visible = true;
                Text_echo_amt.Text = "";
                Text_echo_percent.Text = "";
            }
            else
            {
                Text_echo_amt.Visible = false;
                Text_echo_percent.Visible = false;
                Text_echo_amt.Text = "";
                Text_echo_percent.Text = "";
            }
        }

        protected void Tmt_amt_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_tmt_amt.Checked == true)
            {
                Check_tmt_percent.Checked = false;
                Text_tmt_amt.Visible = true;
                Text_tmt_percent.Visible = false;
                Text_tmt_amt.Text = "";
                Text_tmt_percent.Text = "";
            }
            else
            {
                Text_tmt_amt.Visible = false;
                Text_tmt_percent.Visible = false;
                Text_tmt_amt.Text = "";
                Text_tmt_percent.Text = "";
            }
        }

        protected void Tmt_percent_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_tmt_percent.Checked == true)
            {
                Check_tmt_amt.Checked = false;
                Text_tmt_amt.Visible = false;
                Text_tmt_percent.Visible = true;
                Text_tmt_amt.Text = "";
                Text_tmt_percent.Text = "";
            }
            else
            {
                Text_tmt_amt.Visible = false;
                Text_tmt_percent.Visible = false;
                Text_tmt_amt.Text = "";
                Text_tmt_percent.Text = "";
            }
        }

        protected void Opticalreference_amt_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_scan_amt.Checked == true)
            {
                Check_scan_percent.Checked = false;
                Text_scan_amt.Visible = true;
                Text_scan_percent.Visible = false;
                Text_scan_amt.Text = "";
                Text_scan_percent.Text = "";
            }
            else
            {
                Text_scan_amt.Visible = false;
                Text_scan_percent.Visible = false;
                Text_scan_amt.Text = "";
                Text_scan_percent.Text = "";
            }
        }

        protected void Opticalreference_percent_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_scan_percent.Checked == true)
            {
                Check_scan_amt.Checked = false;
                Text_scan_amt.Visible = false;
                Text_scan_percent.Visible = true;
                Text_scan_amt.Text = "";
                Text_scan_percent.Text = "";
            }
            else
            {
                Text_scan_amt.Visible = false;
                Text_scan_percent.Visible = false;
                Text_scan_amt.Text = "";
                Text_scan_percent.Text = "";
            }
        }

        protected void Pft_amt_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_pft_amt.Checked == true)
            {
                Check_pft_percent.Checked = false;
                Text_pft_amt.Visible = true;
                Text_pft_percent.Visible = false;
                Text_pft_amt.Text = "";
                Text_pft_percent.Text = "";
            }
            else
            {
                Text_pft_amt.Visible = true;
                Text_pft_percent.Visible = false;
                Text_pft_amt.Text = "";
                Text_pft_percent.Text = "";
            }
        }

        protected void Pft_percent_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_pft_percent.Checked == true)
            {
                Check_pft_amt.Checked = false;
                Text_pft_amt.Visible = false;
                Text_pft_percent.Visible = true;
                Text_pft_amt.Text = "";
                Text_pft_percent.Text = "";
            }
            else
            {
                Text_pft_amt.Visible = false;
                Text_pft_percent.Visible = false;
                Text_pft_amt.Text = "";
                Text_pft_percent.Text = "";
            }
        }

        protected void Ta_all_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_taall.Checked == true)
            {
                Check_tasunday.Checked = false;
                Text_taall.Visible = false;
                Text_tasunday.Visible = true;
                Text_taall.Text = "";
                Text_tasunday.Text = "";
            }
            else
            {
                Text_taall.Visible = false;
                Text_tasunday.Visible = false;
                Text_taall.Text = "";
                Text_tasunday.Text = "";
            }

        }

        protected void Ta_sunday_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_tasunday.Checked == true)
            {
                Check_taall.Checked = false;
                Text_taall.Visible = false;
                Text_tasunday.Visible = true;
                Text_taall.Text = "";
                Text_tasunday.Text = "";
            }
            else
            {
                Text_taall.Visible = false;
                Text_tasunday.Visible = true;
                Text_taall.Text = "";
                Text_tasunday.Text = "";
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            objservice.Update_paymentterms(ddl_drname.SelectedValue, Text_paymentterms.Text, Text_pervisit_amt.Text, Text_patientlimit.Text, Text_perpatient_amt.Text, Text_abovemaximum_amt.Text, Text_abovemaximum_percent.Text, Text_lab_amt.Text, Text_lab_percent.Text, Text_procedurecharges_amt.Text, Text_procedurecharges_percent.Text, Text_echo_amt.Text, Text_echo_percent.Text, Text_tmt_amt.Text, Text_tmt_percent.Text, Text_scan_amt.Text, Text_scan_percent.Text, Text_pft_amt.Text, Text_pft_percent.Text, Text_taall.Text, Text_tasunday.Text);
            Response.Write("<script>alert('Payment Terms Updated Successfully')</script>");

            ddl_drname.ClearSelection();
            Text_paymentterms.Text = "";

            Text_perpatient_amt.Visible = false;
            Text_pervisit_amt.Visible = false;
            Text_abovemaximum_amt.Visible = false;
            Text_abovemaximum_percent.Visible = false;
            Text_lab_amt.Visible = false;
            Text_lab_percent.Visible = false;
            Text_procedurecharges_amt.Visible = false;
            Text_procedurecharges_percent.Visible = false;
            Text_echo_amt.Visible = false;
            Text_echo_percent.Visible = false;
            Text_tmt_amt.Visible = false;
            Text_tmt_percent.Visible = false;
            Text_scan_amt.Visible = false;
            Text_scan_percent.Visible = false;
            Text_pft_amt.Visible = false;
            Text_pft_percent.Visible = false;
            Text_taall.Visible = false;
            Text_tasunday.Visible = false;

            Check_perpatient.Checked = false;
            Check_pervisit.Checked = false;
            Check_abovemaximum_amt.Checked = false;
            Check_abovemaximum_percent.Checked = false;
            Check_lab_amt.Checked = false;
            Check_lab_percent.Checked = false;
            Check_procedurecharges_amt.Checked = false;
            Check_procedurecharges_percent.Checked = false;
            Check_echo_amt.Checked = false;
            Check_echo_percent.Checked = false;
            Check_tmt_amt.Checked = false;
            Check_tmt_percent.Checked = false;
            Check_scan_amt.Checked = false;
            Check_scan_percent.Checked = false;
            Check_pft_amt.Checked = false;
            Check_pft_percent.Checked = false;
            Check_taall.Checked = false;
            Check_tasunday.Checked = false;

            Text_patientlimit.Text = "";
            Text_perpatient_amt.Text = "";
            Text_pervisit_amt.Text = "";
            Text_abovemaximum_amt.Text = "";
            Text_abovemaximum_percent.Text = "";
            Text_lab_amt.Text = "";
            Text_lab_percent.Text = "";
            Text_procedurecharges_amt.Text = "";
            Text_procedurecharges_percent.Text = "";
            Text_echo_amt.Text = "";
            Text_echo_percent.Text = "";
            Text_tmt_amt.Text = "";
            Text_tmt_percent.Text = "";
            Text_scan_amt.Text = "";
            Text_scan_percent.Text = "";
            Text_pft_amt.Text = "";
            Text_pft_percent.Text = "";
            Text_taall.Text = "";
            Text_tasunday.Text = "";

        }

    }
}