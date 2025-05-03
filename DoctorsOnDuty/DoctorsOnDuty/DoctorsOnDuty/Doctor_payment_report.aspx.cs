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
    public partial class Doctor_payment_report : System.Web.UI.Page
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
            Ddl_branch.DataSource = dt1;
            Ddl_branch.DataTextField = "NAME";
            Ddl_branch.DataValueField = "BRANCH_ID";
            Ddl_branch.DataBind();
            Ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = objservice.Get_payment_report(Ddl_branch.SelectedValue, txt_fromdate.Text, txt_todate.Text);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Doctor_payment.rdlc");
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportParameter Prm;
            Prm = new ReportParameter("ReportParameter1");
            Prm.Values.Add("DOCTOR PAYMENT DETAILS OF " + Ddl_branch.SelectedItem.Text + " BETWEEN " + txt_fromdate.Text + " AND " +txt_todate.Text);
            ReportViewer1.LocalReport.SetParameters(Prm);
            ReportViewer1.DataBind();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
        }
    }
}