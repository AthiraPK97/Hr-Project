using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class Punching_registration : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Puncheddoctors(Session["BRNACHID"].ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            if(!IsPostBack)
            {
                bindddldoctor();
            }
        }

        private void bindddldoctor()
        {
            DataTable dt = new DataTable();
            //dt = objservice.Get_Doctorsfrmcrm(Session["BRNACHID"].ToString()).Tables[0];
            dt = objservice.Get_Doctorsfrmcrm(Session["BRNACHID"].ToString()).Tables[0];
            Ddl_doctor.DataSource = dt;
            Ddl_doctor.DataTextField = "dr_name";
            Ddl_doctor.DataValueField = "dr_id";
            Ddl_doctor.DataBind();
            Ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void Btn_punchin_Click(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] == null && Session["USERID"] == null && Session["LOGUSER"] == null && Session["BRNACHID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Ddl_doctor.SelectedValue == "0")
                {
                    Response.Write("<script>alert('Please Select a Doctor !!!')</script>");
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    dt1 = objservice.Get_Duplicationforpunchin(Session["BRNACHID"].ToString(), Ddl_doctor.SelectedValue).Tables[0];
                    if (dt1.Rows.Count > 0)
                    {
                        Response.Redirect("Punching_registration.aspx");
                    }
                    else
                    {
                        string time = (Convert.ToDateTime(DateTime.Now.TimeOfDay.ToString())).ToString("HH:mm:ss");
                        objservice.insert_punchin(Ddl_doctor.SelectedValue, Session["BRNACHID"].ToString(), time, Session["USERID"].ToString());
                        DataTable dt = new DataTable();
                        dt = objservice.Get_Puncheddoctors(Session["BRNACHID"].ToString()).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        Response.Write("<script>alert('" + Ddl_doctor.SelectedItem.Text + "'+' Punched Successfully')</script>");
                        Ddl_doctor.ClearSelection();
                        bindddldoctor();
                        //Page.Redirect(Request.RawUrl);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('" + Ddl_doctor.SelectedItem.Text + "'+'Punched Successfully'); window.open('Punching_registration.aspx');", true);
                        
                    }
                    
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Puncheddoctors(Session["BRNACHID"].ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["USERTYPE"] == null && Session["USERID"] == null && Session["LOGUSER"] == null && Session["BRNACHID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (e.CommandName == "punchout")
                {
                    string time = (Convert.ToDateTime(DateTime.Now.TimeOfDay.ToString())).ToString("HH:mm:ss");
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[rowIndex];
                    string punch_id = (row.FindControl("lbl_punchid") as Label).Text;
                    string date = (row.FindControl("lbl_date") as Label).Text;
                    string dr_name = (row.FindControl("lbl_drname") as Label).Text;
                    objservice.update_punchout(punch_id, time, Session["USERID"].ToString());
                    DataTable dt = new DataTable();
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    bindddldoctor();
                    dt = objservice.Get_Puncheddoctors(Session["BRNACHID"].ToString()).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('" + dr_name + "'+'Punch out Successfully'); window.open('Punching_registration.aspx');", true);
                    Response.Write("<script>alert('" + dr_name + "'+' Punch out Successfully')</script>");
                    //Response.Redirect("Punching_registration.aspx");
                }
                else if (e.CommandName == "delete")
                {
                    //string message = "Do you want to delete?";
                    //ClientScript.RegisterOnSubmitStatement(this.GetType(), "confirm", "return confirm('" + message + "');");
                }
            }           
        }
        protected void GridView1_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["USERTYPE"] == null && Session["USERID"] == null && Session["LOGUSER"] == null && Session["BRNACHID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                string punch_id = (row.FindControl("lbl_punchid") as Label).Text;
                Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_punchid") as Label;

                objservice.delete_drfrompunch(id.Text);

                GridView1.DataSource = null;
                GridView1.DataBind();
                DataTable dt = new DataTable();
                bindddldoctor();
                dt = objservice.Get_Puncheddoctors(Session["BRNACHID"].ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Punching Deleted Successfully...!!'); window.open('Punching_registration.aspx');", true);
                //Response.Write("<script>alert('Punching Deleted Successfully...!!')</script>");
                //Response.Redirect("Punching_registration.aspx");
            }           
        }
    }
}