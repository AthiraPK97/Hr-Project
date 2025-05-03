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
    public partial class Alldoctors_report : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt1 = new DataTable();
                dt1 = objservice.Get_Branch().Tables[0];
                ddl_branch.DataSource = dt1;
                ddl_branch.DataTextField = "NAME";
                ddl_branch.DataValueField = "BRANCH_ID";
                ddl_branch.DataBind();
                ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
            }                
        }
        protected void ddl_branchname_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_departmentdetails(ddl_branch.SelectedValue).Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "DEPT_NAME";
            ddl_dept.DataValueField = "DEPT_ID";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = objservice.report_doctors(ddl_branch.SelectedValue,ddl_dept.SelectedValue);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Report3.rdlc");
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            ReportViewer1.LocalReport.Refresh();
        }
    }
}