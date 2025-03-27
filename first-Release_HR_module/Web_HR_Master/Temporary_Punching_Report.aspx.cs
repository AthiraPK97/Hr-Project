using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class Temporary_Punching_Report : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        private DataTable dtResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (!IsPostBack)
            {
                load_UserDetails();
            }
        }
        protected void Btn_ViewsClick(object sender, EventArgs e)
        {
            getTemporaryPunchingData();

        }

        public void getTemporaryPunchingData()
        {
            panel1.Visible = true;
            string inputDate = Text_frmdate.Text;
            DateTime parsedDate = DateTime.ParseExact(inputDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            string formattedDateFromDate = parsedDate.ToString("dd-MM-yyyy");
            string inputDate2 = Text_todate.Text;
            DateTime parsedDate2 = DateTime.ParseExact(inputDate2, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            string formattedDateToDate = parsedDate2.ToString("dd-MM-yyyy");
            DataTable dtgrid = new DataTable();
            DataTable dt1 = new DataTable();
            if (Session["USERTYPE"].ToString() == "hr" || Session["USERTYPE"].ToString() == "hrhead" || Session["USERTYPE"].ToString() == "developer" || Session["USERTYPE"].ToString() == "techlead" || Session["USERTYPE"].ToString() == "unithead")
            {
                 dt1 = objService.Get_Temporarypunchingdetails(formattedDateFromDate, formattedDateToDate, ddl_name.SelectedValue.ToString()).Tables[0];
            }
            else
            {
                 dt1 = objService.Get_Temporarypunchingdetails(formattedDateFromDate, formattedDateToDate, Session["USERID"].ToString()).Tables[0];

            }
        
            DataTable dt2 = objService.LoginTempData().Tables[0];
            //DataTable dtResult = new DataTable();
            dtResult.Columns.Add("username", typeof(decimal));
            dtResult.Columns.Add("Emp_Name", typeof(string));
            dtResult.Columns.Add("punchin_time", typeof(string));
            dtResult.Columns.Add("punchinimage", typeof(byte[]));
            dtResult.Columns.Add("punchout_time", typeof(string));
            dtResult.Columns.Add("punchoutimage", typeof(byte[]));

            var result = (from dataRows1 in dt1.AsEnumerable()
                         join dataRows2 in dt2.AsEnumerable()
                         on dataRows1.Field<string>("username") equals dataRows2.Field<string>("emp_code")  // Changed to string
                         select new
                         {
                             username = dataRows1.Field<string>("username"),
                             Emp_name = dataRows2.Field<string>("log_user"),
                             punchin_time = dataRows1.Field<string>("punchin_time") ?? string.Empty,
                             punchinimage = dataRows1.Field<byte[]>("punchinimage") ?? new byte[0],  // Handle nulls
                             punchout_time = dataRows1.Field<string>("punchout_time") ?? string.Empty,
                             punchoutimage = dataRows1.Field<byte[]>("punchoutimage") ?? new byte[0],  // Handle nulls
                         }).Distinct().ToList(); 


            foreach (var item in result)
            {
                dtResult.Rows.Add(item.username, item.Emp_name, item.punchin_time, item.punchinimage, item.punchout_time, item.punchoutimage);


            }

            if (dtResult.Rows.Count > 0)
            {

                GridView2.DataSource = dtResult;
                GridView2.DataBind();
            }
            if (dtResult.Rows.Count == 0)
            {
                ClearGrid();
                Console.WriteLine("dtResult is empty after populating.");
            }
        }
        private void ClearGrid()
        {
            GridView2.DataSource = null; // Set the data source to null
            GridView2.DataBind(); // Rebind to refresh the grid
        }

        protected void Export_click(object sender, EventArgs e)
        {
            getTemporaryPunchingData(); // Call your data binding function

            using (MemoryStream ms = new MemoryStream())
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, ms);
                pdfDoc.Open();

                PdfPTable pdfTable = new PdfPTable(6); // Number of columns in your PDF
                pdfTable.WidthPercentage = 100;

                // Adjust column widths (relative size, change values as needed)
                float[] columnWidths = new float[] { 1.5f, 2f, 2f, 2f, 2f, 2f };
                pdfTable.SetWidths(columnWidths);

                // Add header row
                pdfTable.AddCell(new PdfPCell(new Phrase("Username")) { BackgroundColor = BaseColor.LIGHT_GRAY });
                pdfTable.AddCell(new PdfPCell(new Phrase("Emp_Name")) { BackgroundColor = BaseColor.LIGHT_GRAY });
                pdfTable.AddCell(new PdfPCell(new Phrase("Punch-in Time")) { BackgroundColor = BaseColor.LIGHT_GRAY });
                pdfTable.AddCell(new PdfPCell(new Phrase("Punch-in Image")) { BackgroundColor = BaseColor.LIGHT_GRAY });
                pdfTable.AddCell(new PdfPCell(new Phrase("Punch-out Time")) { BackgroundColor = BaseColor.LIGHT_GRAY });
                pdfTable.AddCell(new PdfPCell(new Phrase("Punch-out Image")) { BackgroundColor = BaseColor.LIGHT_GRAY });

                // Assuming 'dtResult' is the DataTable you are using to export
                foreach (DataRow row in dtResult.Rows)
                {
                    pdfTable.AddCell(new Phrase(row["username"].ToString()));
                    pdfTable.AddCell(new Phrase(row["Emp_Name"].ToString()));
                    pdfTable.AddCell(new Phrase(row["punchin_time"].ToString()));

                    // Handle punch-in image
                    if (row["punchinimage"] is byte[] punchinImage && punchinImage.Length > 0)
                    {
                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(punchinImage);
                        pdfImage.ScaleToFit(100f, 100f); // Scale image to fit
                        pdfTable.AddCell(new PdfPCell(pdfImage));
                    }
                    else
                    {
                        pdfTable.AddCell(new Phrase("No Image")); // Placeholder if no image
                    }

                    pdfTable.AddCell(new Phrase(row["punchout_time"].ToString()));

                    // Handle punch-out image
                    if (row["punchoutimage"] is byte[] punchoutImage && punchoutImage.Length > 0)
                    {
                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(punchoutImage);
                        pdfImage.ScaleToFit(100f, 100f); // Scale image to fit
                        pdfTable.AddCell(new PdfPCell(pdfImage));
                    }
                    else
                    {
                        pdfTable.AddCell(new Phrase("No Image")); // Placeholder if no image
                    }
                }

                pdfDoc.Add(pdfTable);
                pdfDoc.Close();

                // Set response for PDF download
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }

        }
        
        protected void GridView1_Pageindexchanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            getTemporaryPunchingData();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // This method is required for controls like GridView to render properly when exporting.
            // No logic is needed here, just the method override to avoid exceptions.
        }

        public void load_UserDetails()
        {
            DataTable dt_userdetails = objService.Get_TEmpName().Tables[0];
            if (dt_userdetails.Rows.Count > 0)
            {
                dt_userdetails.Columns.Add("DisplayText", typeof(string));

                // Populate the new column with concatenated values
                foreach (DataRow row in dt_userdetails.Rows)
                {
                    row["DisplayText"] = row[1].ToString() + "-" + row[8].ToString();
                }
                ddl_name.Items.Clear();
                ddl_name.DataSource = dt_userdetails;
                ddl_name.DataValueField = "username";
                ddl_name.DataTextField = "DisplayText";
                ddl_name.DataBind();


                ddl_name.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", ""));

            }
        }

        protected void ddl_name_changed(object sender, EventArgs e)
        {
            string selectedValue = ddl_name.SelectedValue;
        }
    }


}