using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Add_employeeshift : System.Web.UI.Page
    {
        //ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if(!IsPostBack)
        //    {
        //        bindddlshift();

        //        DataTable dt = new DataTable();
        //        dt = objservice.Get_shift().Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //        }
        //    }
        //}

        //private void bindddlshift()
        //{
        //    DataTable dt = new DataTable();
        //    dt = objservice.Get_allshift().Tables[0];
        //    ddl_shift.DataSource = dt;
        //    ddl_shift.DataTextField = "shift_name";
        //    ddl_shift.DataValueField = "shift_id";
        //    ddl_shift.DataBind();
        //    ddl_shift.Items.Insert(0, new ListItem("---Select---", "0"));
        //}

        //protected void Add_Click(object sender, EventArgs e)
        //{
        //    DataTable dt1 = new DataTable();
        //    dt1 = objservice.Avoid_shiftduplication(ddl_shift.SelectedValue).Tables[0];
        //    if(dt1.Rows.Count>0)
        //    {
        //        Response.Write("<script>alert('Already Added Shift')</script>");
        //    }
        //    else
        //    {
        //        objservice.insert_employeeshift(ddl_shift.SelectedValue, ddl_shift.SelectedItem.Text);
        //        Response.Write("<script>alert('Shift Added Successfully')</script>");
        //        DataTable dt = new DataTable();
        //        dt = objservice.Get_shift().Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //        }
        //    }
            
        //}
    }
}