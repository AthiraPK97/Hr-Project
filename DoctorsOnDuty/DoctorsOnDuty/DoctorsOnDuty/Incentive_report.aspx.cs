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
    public partial class Incentive_report : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void view_click(object sender, EventArgs e)
        {
            if(ddl_type.SelectedValue=="Lab Incentive")
            {
                DataSet ds = new DataSet();
                ds = objservice.Get_labincentivereport1(txt_fromdate.Text, txt_todate.Text);
                String header;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Report6.rdlc");
                ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("paramtr_frmdate");
                Prm.Values.Add("LAB INCENTIVE REPORT FROM ");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("paramtr_todate");
                header =  txt_fromdate.Text + " TO " + txt_todate.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource1);


                //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/NewPurchase.rdlc");
                //ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                //ReportParameter Prm;
                //Prm = new ReportParameter("prm_head1");
                //Prm.Values.Add("NEWPURCHASE REPORT ");
                //ReportViewer1.LocalReport.SetParameters(Prm);
                //Prm = new ReportParameter("prm_head2");
                //header = "AS ON  " + txtfrmdt.Text + " to " + txttodate.Text;
                //Prm.Values.Add(header);
                //ReportViewer1.LocalReport.SetParameters(Prm);
                //ReportViewer1.DataBind();
                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(datasource);

            }
            else if(ddl_type.SelectedValue=="Scanning/Mammogram Incentive")
            {
                DataSet ds = new DataSet();
                ds = objservice.Get_incentivereport(txt_fromdate.Text, txt_todate.Text);

                String header;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Report4.rdlc");
                ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("paramtr_frmdate");
                Prm.Values.Add("SCANNING / MAMMOGRAM INCENTIVE REPORT FROM ");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("paramtr_todate");
                header = txt_fromdate.Text + " TO " + txt_todate.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
            }
            else if(ddl_type.SelectedValue=="CT Incentive")
            {
                DataSet ds = new DataSet();
                ds = objservice.Get_ctincentivereport(txt_fromdate.Text, txt_todate.Text);

                String header;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Report7.rdlc");
                ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("paramtr_frmdate");
                Prm.Values.Add("CT INCENTIVE REPORT FROM ");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("paramtr_todate");
                header = txt_fromdate.Text + " TO " + txt_todate.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
            }
            else if (ddl_type.SelectedValue == "Procedure Charges Incentive")
            {
                DataSet ds = new DataSet();
                ds = objservice.Get_procedureincentivereport(txt_fromdate.Text, txt_todate.Text);

                String header;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Report8.rdlc");
                ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("paramtr_frmdate");
                Prm.Values.Add("PROCEDURE CHARGES INCENTIVE REPORT FROM ");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("paramtr_todate");
                header = txt_fromdate.Text + " TO " + txt_todate.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
            }
        }

        protected void view_click1(object sender, EventArgs e)
        {
            
        }
        protected void labview_click(object sender, EventArgs e)
        {
            
        }

        protected void ctview_click(object sender, EventArgs e)
        {
            
        }
    }
}