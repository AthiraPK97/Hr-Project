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
    public partial class Shiftchange_report : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_view_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = objservice.shiftreport_details(txt_fromdate.Text, txt_todate.Text);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Report2.rdlc");
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            ReportViewer1.LocalReport.Refresh();
        }
    }
}