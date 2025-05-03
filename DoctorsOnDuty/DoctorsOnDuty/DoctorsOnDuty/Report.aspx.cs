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
    public partial class Report : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_view_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.report_details(txt_fromdate.Text, txt_todate.Text).Tables[0];
            for(int i=0;i<dt.Rows.Count;i++)
            {
                string duty_id= dt.Rows[i]["duty_id"].ToString();
                string date = dt.Rows[i]["date_"].ToString();
                DataTable dt1 = new DataTable();
                dt1 = objservice.Get_dr_id(duty_id).Tables[0];
                string dr_id = dt1.Rows[0]["dr_id"].ToString();
                DataTable dt2 = new DataTable();
                dt2 = objservice.Get_count_sum(dr_id, date).Tables[0];
                string sum = dt2.Rows[0]["sum"].ToString();
                string count = dt2.Rows[0]["count"].ToString();
                objservice.Update_count_sum(sum, count, duty_id, date);
            }

            DataSet ds = new DataSet();
            ds = objservice.report_details(txt_fromdate.Text, txt_todate.Text);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Report1.rdlc");
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            ReportViewer1.LocalReport.Refresh();
        }
    }
}