using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_HR_Master
{
    public partial class PostWisePuchingReport : System.Web.UI.Page
    {
        ServiceReference1.WebService_HRMasterSoapClient objService = new ServiceReference1.WebService_HRMasterSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_Branch();
            }
        }

        public void load_Branch()
        {
            DataTable dt_branch = objService.Get_branches().Tables[0];
            if (dt_branch.Rows.Count > 0)
            {

                ddl_Branch.DataSource = dt_branch;
                ddl_Branch.DataValueField = "BRANCH_ID";
                ddl_Branch.DataTextField = "BRANCH_NAME";
                ddl_Branch.DataBind();
                ddl_Branch.Items.Insert(0, new ListItem("---Select---", "-1"));

            }
        }
        //public void load_postname(object sender, EventArgs e)
        //{
        //    DataTable dt_Post = objService.Get_Post_Details(ddl_Branch.SelectedValue.ToString()).Tables[0];
        //    if (dt_Post.Rows.Count > 0)
        //    {

        //        ddl_Post.DataSource = dt_Post;
        //        ddl_Post.DataValueField = "POST_ID";
        //        ddl_Post.DataTextField = "POST_NAME";
        //        ddl_Post.DataBind();
        //        ddl_Post.Items.Insert(0, new ListItem("---Select---", "-1"));

        //    }

        //}
        public void load_punchingReport(object sender, EventArgs e)
        {
          


            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("EMPLOYEE CODE", typeof(string));
            dtResult.Columns.Add("EMPLOYEE NAME", typeof(string));
            dtResult.Columns.Add("BRANCH ID", typeof(decimal));
            dtResult.Columns.Add("BRANCH NAME", typeof(string));
            dtResult.Columns.Add("CURRENT DATE", typeof(string)); 
            dtResult.Columns.Add("POST NAME", typeof(string)); 



            DataTable dt_Punchdt = objService.Get_staffPunchingDetails(ddl_Branch.SelectedValue.ToString()).Tables[0];

            DataTable dt2 = objService.Get_user_Details(ddl_Post.SelectedItem.ToString()).Tables[0];
            var result = from dataRows1 in dt_Punchdt.AsEnumerable()
                         join dataRows2 in dt2.AsEnumerable()
   on new
   {
       emp_code = dataRows1.Field<string>("emp_code").ToString(),
      
   }
             equals new
             {
                  emp_code = dataRows2.Field<decimal>("unique_username").ToString(),
             }
                         select new
                         {
                             Emp_code = dataRows1.Field<string>("emp_code"),
                             Emp_name = dataRows2.Field<string>("emp_name"),
                             Branch_id = dataRows1.Field<decimal>("branch_id"),
                             Branch_name = dataRows1.Field<string>("branch_name"),
                             CURR_DATE = dataRows1.Field<string>("CURR_DATE"),
                             Post_name = dataRows1.Field<string>("POST_NAME")
                         };
            foreach (var datas in result)

            {
                dtResult.Rows.Add( datas.Emp_code,datas.Emp_name,datas.Branch_id,datas.Branch_name,datas.CURR_DATE,datas.Post_name);
            }
            if (dtResult.Rows.Count > 0)
            {
                GridView1.DataSource = dtResult;
                GridView1.DataBind();

            }
        }
    }
        
}