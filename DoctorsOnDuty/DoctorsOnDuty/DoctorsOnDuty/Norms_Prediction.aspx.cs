using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Norms_Prediction : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddlbranch();
                div_hide.Visible = false;
            }
        }

        private void bindddlarea()
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_Area(Ddl_branch.SelectedValue).Tables[0];
            Ddl_area.DataSource = dt1;
            Ddl_area.DataTextField = "area_name";
            Ddl_area.DataValueField = "area_id";
            Ddl_area.DataBind();
            Ddl_area.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddlbranch()
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_Branch().Tables[0];
            Ddl_branch.DataSource = dt1;
            Ddl_branch.DataTextField = "NAME";
            Ddl_branch.DataValueField = "BRANCH_ID";
            Ddl_branch.DataBind();
            Ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void Ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddlarea();
        }

        private void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctorsfor_Norms(Ddl_branch.SelectedValue, Ddl_area.SelectedItem.Text, txt_fromtime.Text, txt_totime.Text).Tables[0];
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

        protected void Btn_view_Click(object sender, EventArgs e)
        {
            div_hide.Visible = true;
            bindgrid();
            string dr_id;
            string dept_id;
            int extra_staff = 0, pharmacy = 0, nurse = 0, reception = 0;
            DataTable dt_drdtl = new DataTable();
            DataTable dt_patientcount = new DataTable();
            DataTable dt_effectedarea = new DataTable();
            DataTable dt_norms_range_pharma = new DataTable();
            DataTable dt_norms_range_nurse = new DataTable();
            DataTable dt_norms_range_reception = new DataTable();
            dt_drdtl = objservice.Get_Doctorsfor_Norms(Ddl_branch.SelectedValue, Ddl_area.SelectedItem.Text, txt_fromtime.Text, txt_totime.Text).Tables[0];
            if (dt_drdtl.Rows.Count > 0)
            {
                for (int b = 0; b < dt_drdtl.Rows.Count; b++)
                {
                    int patient_count = 0;
                    dr_id = dt_drdtl.Rows[b]["dr_id"].ToString();
                    dept_id = dt_drdtl.Rows[b]["dept_id"].ToString();
                    dt_patientcount = objservice.Get_PatientCount(Ddl_branch.SelectedValue, dr_id).Tables[0];
                    if(dt_patientcount.Rows.Count>0)
                    {
                        dt_effectedarea = objservice.Get_EffectedArea(dept_id).Tables[0];
                        if(dt_effectedarea.Rows.Count>0)
                        {
                            patient_count = Convert.ToInt32(dt_patientcount.Rows[0]["total_patient"]);
                            if (patient_count > 0)
                            {
                                if(Convert.ToInt32(dt_effectedarea.Rows[0]["pharmacy"])>0)
                                {
                                    pharmacy = pharmacy + patient_count;
                                }
                                if (Convert.ToInt32(dt_effectedarea.Rows[0]["reception"]) > 0)
                                {
                                    reception = reception + patient_count;
                                }
                                if (Convert.ToInt32(dt_effectedarea.Rows[0]["nurse"]) > 0)
                                {
                                    nurse = nurse + patient_count;
                                }
                                if (Convert.ToInt32(dt_effectedarea.Rows[0]["extrastaff"]) > 0)
                                {
                                    extra_staff = extra_staff + 1;
                                }
                            }
                        }                        
                    }
                }
            }
            dt_norms_range_pharma = objservice.Get_Normsrange_pharmacy().Tables[0];
            if(dt_norms_range_pharma.Rows.Count>0)
            {
                Label_pharmacy.Text = ((pharmacy / (Convert.ToInt32(dt_norms_range_pharma.Rows[0]["patient_ratio"]))) * Convert.ToInt32(dt_norms_range_pharma.Rows[0]["staff_ratio"])).ToString();
            }

            dt_norms_range_reception = objservice.Get_Normsrange_reception().Tables[0];
            if (dt_norms_range_reception.Rows.Count > 0)
            {
                Label_reception.Text = ((reception / (Convert.ToInt32(dt_norms_range_reception.Rows[0]["patient_ratio"]))) * Convert.ToInt32(dt_norms_range_reception.Rows[0]["staff_ratio"])).ToString();
            }

            dt_norms_range_nurse = objservice.Get_Normsrange_nurse().Tables[0];
            if (dt_norms_range_nurse.Rows.Count > 0)
            {
                Label_nurse.Text = ((nurse / (Convert.ToInt32(dt_norms_range_nurse.Rows[0]["patient_ratio"]))) * Convert.ToInt32(dt_norms_range_nurse.Rows[0]["staff_ratio"])).ToString();
            }

            Label_extrastaff.Text = extra_staff.ToString();
        }
    }
}