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
    public partial class Upload_scanningdoc : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["userid"] != null && Request.QueryString["role"] != null || Request.QueryString["menu"] != null)
                {
                    Session["USERID"] = Request.QueryString["USERID"];
                    Session["ROLE"] = Request.QueryString["ROLE"];
                    Session["USERTYPE"] = Request.QueryString["USERTYPE"];
                }
                bindddlscanning();
                bindddldoctor();
                div_hide.Visible = false;
            }
        }
        private void bindddlscanning()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_scanningtypes().Tables[0];
            ddl_scanning.DataSource = dt;
            ddl_scanning.DataTextField = "test_name";
            ddl_scanning.DataValueField = "test_id";
            ddl_scanning.DataBind();
            ddl_scanning.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddldoctor()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_registereddoctors().Tables[0];
            ddl_doctor.DataSource = dt;
            ddl_doctor.DataTextField = "name_";
            ddl_doctor.DataValueField = "doctor_id";
            ddl_doctor.DataBind();
            ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void Btn_view_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_patientdtl(txt_billid.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                //DataTable dt1 = new DataTable();
                //dt1 = objservice.Get_duplicate(txt_billid.Text).Tables[0];
                //if(dt1.Rows.Count>0)
                //{
                //    Response.Write("<script>alert('Scanning Document Already Uploaded...!!')</script>");
                //    div_hide.Visible = false;
                //}
                //else
                //{
                txt_patientname.Text = dt.Rows[0]["name"].ToString();
                lbl_patientid.Text = dt.Rows[0]["patient_id"].ToString();
                div_hide.Visible = true;
                //}               
            }
            else
            {
                Response.Write("<script>alert('Invalid Bill ID...!!')</script>");
                div_hide.Visible = false;
            }

        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            string filename_scanning = Path.GetFileName(file_scanning.PostedFile.FileName);
            //string duplicate_file = "~/Scanning_doc/" + txt_billid.Text + filename_scanning;
            DataTable dt = new DataTable();
            dt = objservice.Get_duplicatedoc(txt_billid.Text, ddl_scanning.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('" + ddl_scanning.SelectedItem.Text + " scanning document of this bill id is already exists...!!')</script>");
            }
            else
            {
                file_scanning.SaveAs(Server.MapPath("~/Scanning_doc/" + txt_billid.Text + filename_scanning));
                objservice.insert_scanningdoc(txt_billid.Text, lbl_patientid.Text, ddl_scanning.SelectedValue, ddl_doctor.SelectedValue, "~/Scanning_doc/" + txt_billid.Text + filename_scanning, Session["USERID"].ToString());
                Response.Write("<script>alert('Scanning Document Uploaded Successfully...!!')</script>");
                txt_billid.Text = string.Empty;
                div_hide.Visible = false;
                ddl_doctor.ClearSelection();
                ddl_scanning.ClearSelection();
            }
        }
    }
}