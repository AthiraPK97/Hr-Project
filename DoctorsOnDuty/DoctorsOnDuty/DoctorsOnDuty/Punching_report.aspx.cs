using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace DoctorsOnDuty
{
    public partial class Punching_report : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddldoctor();
            }
        }

        private void bindddldoctor()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_Doctorsforpunch().Tables[0];
            Ddl_doctor.DataSource = dt2;
            Ddl_doctor.DataTextField = "NAME";
            Ddl_doctor.DataValueField = "DR_ID";
            Ddl_doctor.DataBind();
            Ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void Btn_view_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = objservice.Get_Drpunchreport(Ddl_doctor.SelectedValue, txt_fromdate.Text, txt_todate.Text);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Dr_Punchreport.rdlc");
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportParameter Prm;
            Prm = new ReportParameter("ReportParameter1");
            Prm.Values.Add("Doctor's Punching Report of " + Ddl_doctor.SelectedItem.Text + " Between " + txt_fromdate.Text + " and " + txt_todate.Text);
            ReportViewer1.LocalReport.SetParameters(Prm);
            ReportViewer1.DataBind();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
        }
    }
}