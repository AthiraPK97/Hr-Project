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
    public partial class Staff_Availablereport : System.Web.UI.Page
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
            ddl_branch.DataSource = dt1;
            ddl_branch.DataTextField = "NAME";
            ddl_branch.DataValueField = "BRANCH_ID";
            ddl_branch.DataBind();
            ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void Btn_view_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ds = objservice.Get_currentdoctors(ddl_branch.SelectedValue);
            ds1 = objservice.Get_currentemployees(ddl_branch.SelectedValue);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Available_staffreport.rdlc");
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);            
            ReportViewer1.LocalReport.DataSources.Add(datasource2);

            ReportViewer1.LocalReport.Refresh();
        }
    }
}