using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace DoctorsOnDuty
{
    public partial class Edit : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            string report_id = Request.QueryString["report_id"].ToString();
            string bill_id = Request.QueryString["bill_id"].ToString();
            DataTable dt = new DataTable();
            dt = objservice.Get_registereddoc(report_id).Tables[0];
            string dfilename_kra = dt.Rows[0]["scanning_doc"].ToString();
            string path = Server.MapPath(dfilename_kra);
            FileInfo file = new FileInfo(path);
            file.Delete();

            string filename_scanning = Path.GetFileName(file_scanning.PostedFile.FileName);
            file_scanning.SaveAs(Server.MapPath("~/Scanning_doc/" + bill_id + filename_scanning));
            objservice.Update_doc(report_id, "~/Scanning_doc/" + bill_id + filename_scanning);
            //Response.Write(" < script language = 'javascript' > window.alert('Document Updated Successfully'); window.location = 'View.aspx';</ script > ");

        }
    }
}