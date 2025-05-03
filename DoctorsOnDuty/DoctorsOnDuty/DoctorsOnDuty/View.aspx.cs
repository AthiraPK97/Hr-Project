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
    public partial class View : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarExtender1.Enabled = false;
            lbl_bill.Visible = false;
            lbl_date.Visible = false;
            lbl_doctor.Visible = false;
            lbl_patient.Visible = false;
            lbl_scanning.Visible = false;
            TextBox1.Visible = false;
            ddl_test.Visible = false;
            Btn_submit.Visible = false;
            GridView1.Visible = false;
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_reportcategory.SelectedItem.Text == "Doctor Name Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = true;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = false;
                ddl_test.Visible = true;
                Btn_submit.Visible = true;
                GridView1.Visible = false;

                DataTable dt = new DataTable();
                dt = objservice.Get_registereddoctors().Tables[0];
                ddl_test.DataSource = dt;
                ddl_test.DataTextField = "name_";
                ddl_test.DataValueField = "doctor_id";
                ddl_test.DataBind();
                ddl_test.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Patient Name Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = true;
                lbl_scanning.Visible = false;
                TextBox1.Text = string.Empty;
                TextBox1.Visible = true;
                ddl_test.Visible = false;
                Btn_submit.Visible = true;
                GridView1.Visible = false;
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Bill Number Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = true;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = true;
                TextBox1.Text = string.Empty;
                ddl_test.Visible = false;
                Btn_submit.Visible = true;
                GridView1.Visible = false;
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Date Wise")
            {
                CalendarExtender1.Enabled = true;
                lbl_bill.Visible = false;
                lbl_date.Visible = true;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = true;
                TextBox1.Text = string.Empty;
                ddl_test.Visible = false;
                Btn_submit.Visible = true;
                GridView1.Visible = false;
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Scanning Type Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = true;
                TextBox1.Visible = false;
                ddl_test.Visible = true;
                Btn_submit.Visible = true;
                GridView1.Visible = false;

                DataTable dt = new DataTable();
                dt = objservice.Get_scanningtypes().Tables[0];
                ddl_test.DataSource = dt;
                ddl_test.DataTextField = "test_name";
                ddl_test.DataValueField = "test_id";
                ddl_test.DataBind();
                ddl_test.Items.Insert(0, new ListItem("---Select---", "0"));
            }
            else
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = false;
                ddl_test.Visible = false;
                Btn_submit.Visible = false;
                GridView1.Visible = false;
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            if (ddl_reportcategory.SelectedItem.Text == "Doctor Name Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = true;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = false;
                ddl_test.Visible = true;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_doctorwise(ddl_test.SelectedValue);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Patient Name Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = true;
                lbl_scanning.Visible = false;
                TextBox1.Visible = true;
                ddl_test.Visible = false;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_patientwise(TextBox1.Text);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Bill Number Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = true;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = true;
                ddl_test.Visible = false;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_billwise(TextBox1.Text);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Date Wise")
            {
                CalendarExtender1.Enabled = true;
                lbl_bill.Visible = false;
                lbl_date.Visible = true;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = true;
                ddl_test.Visible = false;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_datewise(TextBox1.Text);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Scanning Type Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = true;
                TextBox1.Visible = false;
                ddl_test.Visible = true;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_scanningwise(ddl_test.SelectedValue);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string report_id = (row.FindControl("lbl_reportid") as Label).Text;

                DataTable dt = new DataTable();
                dt = objservice.Get_registereddoc(report_id).Tables[0];
                string docpath = dt.Rows[0]["scanning_doc"].ToString();
                Response.Redirect(docpath);
            }
            else if (e.CommandName == "edit")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string report_id = (row.FindControl("lbl_reportid") as Label).Text;
                string bill_id = (row.FindControl("lbl_billid") as Label).Text;

                Response.Redirect("Edit.aspx?report_id=" + report_id + "&bill_id=" + bill_id);
            }
            //else if (e.CommandName == "delete")
            //{
            //    int rowIndex = Convert.ToInt32(e.CommandArgument);
            //    GridViewRow row = GridView1.Rows[rowIndex];
            //    string report_id = (row.FindControl("lbl_reportid") as Label).Text;

            //    DataTable dt = new DataTable();
            //    dt = objservice.Get_registereddoc(report_id).Tables[0];
            //    string dfilename_kra = dt.Rows[0]["scanning_doc"].ToString();
            //    string path = Server.MapPath(dfilename_kra);
            //    FileInfo file = new FileInfo(path);
            //    file.Delete();

            //    objservice.Delete_doc(report_id);
            //    Response.Write("<script>alert('Scanning Document Deleted Successfully...!!')</script>");
            //}
            else if (e.CommandName == "delete")
            {

            }

        }

        protected void GridView1_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label report_id = GridView1.Rows[e.RowIndex].FindControl("lbl_reportid") as Label;

            DataTable dt = new DataTable();
            dt = objservice.Get_registereddoc(report_id.Text).Tables[0];
            string dfilename_kra = dt.Rows[0]["scanning_doc"].ToString();
            string path = Server.MapPath(dfilename_kra);
            FileInfo file = new FileInfo(path);
            file.Delete();

            objservice.Delete_doc(report_id.Text);
            Response.Write("<script>alert('Scanning Document Deleted Successfully...!!')</script>");

            if (ddl_reportcategory.SelectedItem.Text == "Doctor Name Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = true;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = false;
                ddl_test.Visible = true;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_doctorwise(ddl_test.SelectedValue);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Patient Name Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = true;
                lbl_scanning.Visible = false;
                TextBox1.Visible = true;
                ddl_test.Visible = false;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_patientwise(TextBox1.Text);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Bill Number Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = true;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = true;
                ddl_test.Visible = false;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_billwise(TextBox1.Text);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Date Wise")
            {
                CalendarExtender1.Enabled = true;
                lbl_bill.Visible = false;
                lbl_date.Visible = true;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = false;
                TextBox1.Visible = true;
                ddl_test.Visible = false;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_datewise(TextBox1.Text);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else if (ddl_reportcategory.SelectedItem.Text == "Scanning Type Wise")
            {
                CalendarExtender1.Enabled = false;
                lbl_bill.Visible = false;
                lbl_date.Visible = false;
                lbl_doctor.Visible = false;
                lbl_patient.Visible = false;
                lbl_scanning.Visible = true;
                TextBox1.Visible = false;
                ddl_test.Visible = true;
                Btn_submit.Visible = true;
                GridView1.Visible = true;
                DataSet ds = new DataSet();
                ds = objservice.View_scanningwise(ddl_test.SelectedValue);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
}