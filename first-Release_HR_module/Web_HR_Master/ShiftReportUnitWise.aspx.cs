using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.Hosting;

namespace Web_HR_Master
{
    public partial class ShiftReportUnitWise : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_Branch();

                string branch_name = Session["BRANCH_NAME"].ToString();
                string[] parts = branch_name.Split(' ');

                // Get the last element (location name)
                string location = parts[parts.Length - 1];
                DataTable dt_ShiftDt = objService.Get_staffShiftDetailsForUnitwise(location).Tables[0];
                if (dt_ShiftDt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt_ShiftDt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }

        }
        public void load_Branch()
        {
            string branch_name = Session["BRANCH_NAME"].ToString();
            DataTable dt_branch = new DataTable();
            if (Session["USERTYPE"].ToString()== "microlabincharge")
            {
                 dt_branch = objService.Get_branchesMicrolab().Tables[0];
            }
            else if(Session["USERTYPE"].ToString() == "unithead" || Session["USERTYPE"].ToString()=="pharmacy incharge")
            {
                string[] parts = branch_name.Split(' ');

                // Get the last element (location name)
                string location = parts[parts.Length - 1];

                 dt_branch = objService.Get_branchesBasesedName(location).Tables[0];
            }
            else
            {
                string[] parts = branch_name.Split(' ');

                // Get the last element (location name)
                string location = parts[parts.Length - 1];

                dt_branch = objService.Get_branchesBasesedName(location).Tables[0];
            }
            if (dt_branch.Rows.Count > 0)
            {

                ddl_Branch.DataSource = dt_branch;
                ddl_Branch.DataValueField = "BRANCH_ID";
                ddl_Branch.DataTextField = "BRANCH_NAME";
                ddl_Branch.DataBind();
                ddl_Branch.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", "-1"));

            }
        }
        public void load_Shift(object sender, EventArgs e)
        {
            string branch_name = ddl_Branch.SelectedValue.ToString();
            if (ddl_Branch.SelectedValue.ToString()=="-1")
            {
                branch_name= Session["BRANCH_NAME"].ToString();
            }
            DataTable dt_ShiftDt = objService.Get_staffShiftDetails(branch_name).Tables[0];
            if (dt_ShiftDt.Rows.Count > 0)
            {
                GridView1.DataSource = dt_ShiftDt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }

        }

        protected void ButtonsendMail_Click(object sender, EventArgs e)
        {
            try
            {
                Table tb = new Table();
                TableRow tr1 = new TableRow();
                TableCell cell1 = new TableCell();
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.Gray;
                GridView1.HeaderStyle.Font.Bold = true;
                GridView1.HeaderStyle.Font.Size = 12;

                GridView1.RowStyle.Font.Name = "Arial";
                GridView1.RowStyle.Font.Size = 10;
                GridView1.RowStyle.ForeColor = System.Drawing.Color.Black;
                cell1.Controls.Add(GridView1);
                tr1.Cells.Add(cell1);


                tb.Rows.Add(tr1);
                //tb.Rows.Add(tr2);

                Response.ContentType = "application/x-msexcel";
                Response.AddHeader("Content-Disposition", "attachment;filename = Staff_Shift_Report.xls");
                Response.ContentEncoding = Encoding.UTF8;
                StringWriter tw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(tw);
                tb.RenderControl(hw);
                Response.Write(tw.ToString());
                //Response.End();
                //...........................................................
                string textBody = "Respected Sir, <br/>" + "Please Find staff shift details";

                MailMessage mail = new MailMessage();
                System.Net.Mail.SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                DataTable dt_Staffshift = objService.Get_staffShiftDetails(Session["BRANCHID"].ToString()).Tables[0];
                GridView1.DataSource = dt_Staffshift;
                GridView1.DataBind();

                string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
                string filePath = Path.Combine(downloadsFolder, "Staff_Shift_Report.xls");
                //ButtonExport_Click(sender, e);
                Attachment attachment = new Attachment(filePath);
                mail.Attachments.Add(attachment);

                mail.From = new MailAddress("programmer2@macare.in");
                mail.Subject = "Macare Staff Shift Details ";
                mail.Body = textBody;
                mail.IsBodyHtml = true;


               // mail.To.Add("microlabincharge@macare.in, kattoorunithead@macare.in, vadanapallyunithead@macare.in, unitheadvalapad@macare.in,kanjanyunithead@macare.in,unitheadcherpu@macare.in,operation@macare.in,hr@macare.in,hrtraining@macare.in,itcoordinator@macare.in");
                mail.To.Add("programmer2@macare.in");
                //mail.CC.Add("businesshead@macare.in");
                //mail.CC.Add("cfo@macare.in");
                //mail.CC.Add("cs@macare.in");
                //mail.CC.Add("techlead@macare.in");
                //mail.CC.Add("programmer2@macare.in");
                //mail.CC.Add("md@macare.in");

                SecurityProtocolType SecurityProtocolType = new SecurityProtocolType();//new
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.rediffmailpro.com";
                smtp.EnableSsl = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "info@macare.in";
                NetworkCred.Password = "infomacare@78";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;//new // Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;//new
                                                                 //smtp.Port = 586;
                smtp.Port = 587;//for local host
                                //smtp.Port = 465;
                smtp.Send(mail);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Mail sent Successfully ....');", true);
                //..............................
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured ....');", true);

            }
        }
        protected void ButtonExport_Click(object sender, EventArgs e)
        {
            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.White;
            GridView1.HeaderStyle.BackColor = System.Drawing.Color.Gray;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.HeaderStyle.Font.Size = 12;

            GridView1.RowStyle.Font.Name = "Arial";
            GridView1.RowStyle.Font.Size = 10;
            GridView1.RowStyle.ForeColor = System.Drawing.Color.Black;
            cell1.Controls.Add(GridView1);
            tr1.Cells.Add(cell1);


            tb.Rows.Add(tr1);
            //tb.Rows.Add(tr2);

            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename = Staff_Shift_Report.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
    }
}