using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace Web_HR_Master
{
    public partial class Employee_Master : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getHrData();
                //DataTable dtAo = objService.Get_HRMaster_AO().Tables[0];
                //dtAo.Columns.Remove("firm_id"); 
                //DataTable dtGrid = objService.Get_HRMaster_Dashboard().Tables[0];
                //dtGrid.Columns.Remove("firm_id");
                //var dt = dtAo.AsEnumerable().Union(dtGrid.AsEnumerable()).OrderBy(d => d.Field<string>("branch_name"));
                //DataTable dt_new = dt.CopyToDataTable();
            }
        }
        public void getHrData()
        {
            DataTable dtResult = new DataTable();
            //dtResult.Columns.Add("firm_id", typeof(decimal));
            dtResult.Columns.Add("Emp_code", typeof(decimal));
            dtResult.Columns.Add("Name", typeof(string)); dtResult.Columns.Add("Caste", typeof(string));
            dtResult.Columns.Add("Religion", typeof(string)); dtResult.Columns.Add("Identity_name", typeof(string));
            dtResult.Columns.Add("Idproof_number", typeof(string)); dtResult.Columns.Add("Blood_group", typeof(string));
            dtResult.Columns.Add("Spouse_name", typeof(string)); dtResult.Columns.Add("Father_name", typeof(string));
            dtResult.Columns.Add("Email", typeof(string)); dtResult.Columns.Add("Gender", typeof(string));
             dtResult.Columns.Add("Date_Of_Birth", typeof(string));
              dtResult.Columns.Add("Age", typeof(decimal));
            dtResult.Columns.Add("Permanent_addr", typeof(string)); dtResult.Columns.Add("Present_addr", typeof(string));
            dtResult.Columns.Add("Cont_phone", typeof(string)); dtResult.Columns.Add("Res_phone", typeof(string));
            dtResult.Columns.Add("State", typeof(string)); // dtResult.Columns.Add("Shift", typeof(string));
            dtResult.Columns.Add("In_time", typeof(string)); dtResult.Columns.Add("Out_time", typeof(string));
            dtResult.Columns.Add("Join_Date", typeof(string));// dtResult.Columns.Add("Experience", typeof(string));
            dtResult.Columns.Add("Designation", typeof(string)); dtResult.Columns.Add("Department", typeof(string));
            dtResult.Columns.Add("Basic_pay", typeof(decimal)); dtResult.Columns.Add("Post_Name", typeof(string));
            dtResult.Columns.Add("Year_pass", typeof(string));
            dtResult.Columns.Add("Qualification", typeof(string));
            dtResult.Columns.Add("Branch_name", typeof(string));


            DataTable dt1 = objService.Get_HRMaster().Tables[0];

            DataTable dt2 = objService.Get_Qualifn().Tables[0];
            var result = from dataRows1 in dt1.AsEnumerable()
                         join dataRows2 in dt2.AsEnumerable()
                         on dataRows1.Field<decimal>("emp_code") equals dataRows2.Field<decimal>("emp_code")
                         select new
                         {
                             emp_code = dataRows1.Field<decimal>("emp_code"),
                             emp_name = dataRows1.Field<string>("emp_name"),
                             caste = dataRows1.Field<string>("caste"),
                             religion = dataRows1.Field<string>("religion"),
                             identity = dataRows1.Field<string>("identity_name"),
                             id_proof = dataRows1.Field<string>("idproof_number"),
                             bloodgroup = dataRows1.Field<string>("blood_group"),
                             spouse = dataRows1.Field<string>("spouse_name"),
                             father = dataRows1.Field<string>("father_name"),
                             email = dataRows1.Field<string>("emp_email"),
                             gender = dataRows1.Field<string>("gender"),
                             dob = dataRows1.Field<string>("Date_Of_Birth"),
                             age = dataRows1.Field<decimal>("age"),
                             per_addr = dataRows1.Field<string>("permanent_addr"),
                             pre_addr = dataRows1.Field<string>("present_addr"),
                             cont_phn = dataRows1.Field<string>("cont_phone"),
                             res_phn = dataRows1.Field<string>("res_phone"),
                             state = dataRows1.Field<string>("state"),
                             // shift = dataRows1.Field<string>("shift"),
                             in_time = dataRows1.Field<string>("in_time"),
                             out_time = dataRows1.Field<string>("out_time"),
                             join_dt = dataRows1.Field<string>("join_dt"),
                             // exp=dataRows1.Field<string>("exp"),
                             desgn = dataRows1.Field<string>("designation"),
                             dep = dataRows1.Field<string>("dep_name"),
                             basic_pay = dataRows1.Field<decimal>("basic_pay"),
                             post = dataRows1.Field<string>("post_name"),
                             year = dataRows1.Field<string>("year_pass"),
                             qualifn = dataRows2.Field<string>("qualification"),
                             branch = dataRows1.Field<string>("branch_name")
                         };
            foreach (var item in result)
            {
                dtResult.Rows.Add(item.emp_code, item.emp_name, item.caste, item.religion, item.identity, item.id_proof, item.bloodgroup, item.spouse, item.father, item.email, item.gender,item.dob,item.age, item.per_addr, item.pre_addr, item.cont_phn, item.res_phn, item.state, item.in_time, item.out_time, item.join_dt,  item.desgn, item.dep, item.basic_pay, item.post, item.year, item.qualifn, item.branch); //,,item.age,item.per_addr,item.pre_addr,item.cont_phn,item.res_phn,item.state,item.shift, 
                                                                                                                                                                                                                                                                                                                                                                                                                                                 //Console.WriteLine(String.Format("ID = {0}, ColX = {1}, ColY = {2}, ColZ = {3}", item.CustID, item.ColX, item.ColY, item.ColZ));
            }
            if (dtResult.Rows.Count > 0)
            {
                GridView2.DataSource = dtResult;
                GridView2.DataBind();
            }


            //.............................................................................................................
            //var result1 = from dataRows1 in dt1.AsEnumerable()
            //             join dataRows2 in dt2.AsEnumerable()
            //             on dataRows1.Field<string>("emp_code") equals dataRows2.Field<string>("emp_code")
            //             select dtResult.LoadDataRow(new object[]
            //             {

            //dataRows1.Field<decimal>("firm_id"),
            //dataRows1.Field<string>("emp_code"),
            //dataRows1.Field<string>("emp_name"),
            //dataRows1.Field<string>("caste"),
            //dataRows1.Field<string>("religion"),
            //dataRows1.Field<string>("identity_name"),
            //dataRows1.Field<string>("idproof_number"),
            //dataRows1.Field<string>("blood_group"),
            //dataRows1.Field<string>("spouse_name"),
            //dataRows1.Field<string>("father_name"),
            //dataRows1.Field<string>("emp_email"),
            //dataRows1.Field<string>("gender"),
            //dataRows1.Field<DateTime>("birth_date"),
            //dataRows1.Field<decimal>("age"),
            //dataRows1.Field<string>("permanent_addr"),
            //dataRows1.Field<string>("present_addr"),
            //dataRows1.Field<string>("cont_phone"),
            //dataRows1.Field<string>("res_phone"),
            //dataRows1.Field<string>("state"),
            //dataRows1.Field<string>("shift"),
            //dataRows1.Field<string>("in_time"),
            //dataRows1.Field<string>("out_time"),
            //dataRows1.Field<string>("join_dt"),
            //dataRows1.Field<string>("exp"),
            //dataRows1.Field<string>("designation"),
            //dataRows1.Field<string>("dep_name"),
            //dataRows1.Field<decimal>("basic_pay"),
            //dataRows1.Field<string>("post_name"),
            //dataRows1.Field<string>("year_pass"),
            //dataRows2.Field<string>("qualification"),
            //dataRows1.Field<string>("branch_name")
            //              }, false);
            //result1.CopyToDataTable();
            //........................................................................................................


        }
        
        protected void Export_click(object sender, EventArgs e)
        {
            GridView2.AllowPaging = false;
            GridView2.DataSource = objService.Get_HRMaster().Tables[0];  // Rebind the full data
            GridView2.DataBind();


            GridView2.HeaderStyle.ForeColor = System.Drawing.Color.White;
            GridView2.HeaderStyle.BackColor = System.Drawing.Color.Gray;
            GridView2.HeaderStyle.Font.Bold = true;
            GridView2.HeaderStyle.Font.Size = 12;

            GridView2.RowStyle.Font.Name = "Arial";
            GridView2.RowStyle.Font.Size = 10;
            GridView2.RowStyle.ForeColor = System.Drawing.Color.Black;

            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            //cell1.Text = "EMPLOYEES MASTER DATA";
            //tr1.Cells.Add(cell1);

            //GridView grid1 = new GridView();
            //grid1.DataSource = dtSymCash;
            //grid1.DataBind();
            //TableRow tr2 = new TableRow();
            //TableCell cell2 = new TableCell();
            cell1.Controls.Add(GridView2);
            tr1.Cells.Add(cell1);


            tb.Rows.Add(tr1);
            //tb.Rows.Add(tr2);
            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename = Employee_Report.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
            
            GridView2.AllowPaging = true;
           
        }
        protected void GridView1_Pageindexchanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            getHrData();


        }
       
    }
}