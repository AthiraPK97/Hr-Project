using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoctorsOnDuty
{
    public partial class View_payment : System.Web.UI.Page
    {
        ServiceReference1.Service_DoctorsondutySoapClient objservice = new ServiceReference1.Service_DoctorsondutySoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            div_hide2.Visible = false;
            if(!IsPostBack)
            {
                bindddlbranch();
            }
            
        }

        private void bindddlbranch()
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_Branch().Tables[0];
            ddl_branch.DataSource = dt1;
            ddl_branch.DataTextField = "NAME";
            ddl_branch.DataValueField = "BRANCH_ID";
            ddl_branch.DataBind();
            ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            DataTable dt = new DataTable();
            dt = objservice.Get_drtotalcollection1(txt_date.Text,txt_date.Text,ddl_branch.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            div_hide.Visible = true;
            div_hide2.Visible = false;
        }

        protected void LinkAdditional_Click(object sender, EventArgs e)
        {
            objservice.Get_abovemaxpayment();
            div_hide.Visible = false;
            div_hide2.Visible = true;
            div_hide2_1.Visible = true;
            Check_payment.Checked = false;

            DataSet ds = new DataSet();
            ds = objservice.Get_payment_mstduplicate(Label_drid.Text, txt_date.Text, ddl_branch.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string status = ds.Tables[0].Rows[0]["status"].ToString();
                if(status== "Payment Initiated")
                {
                    Check_payment.Checked = true;
                }
            }

            string amount;
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();
            DataTable dt8 = new DataTable();
            dt1 = objservice.Get_payment().Tables[0];
            if (dt1.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt1.Rows[0]["perpatient_payment"]) > 0)
                {
                    amount = dt1.Rows[0]["perpatient_payment"].ToString();
                    txt_payment.Text = amount;
                    dt=objservice.Get_ttlpayment().Tables[0];
                    if(dt.Rows.Count>0)
                    {
                        Text_abovemax.Text = dt.Rows[0]["totalpayment"].ToString();
                    }

                    dt2 = objservice.Get_lab(txt_date.Text, txt_date.Text, Label_drid.Text,ddl_branch.SelectedValue).Tables[0];
                    if (dt2.Rows.Count > 0)
                    {
                        Text_lab.Text = dt2.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_lab.Text = "0";
                    }

                    dt3 = objservice.Get_echo(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt3.Rows.Count > 0)
                    {
                        Text_echo.Text = dt3.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_echo.Text = "0";
                    }

                    dt4 = objservice.Get_tmt(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt4.Rows.Count > 0)
                    {
                        Text_tmt.Text = dt4.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_tmt.Text = "0";
                    }

                    dt5 = objservice.Get_scan(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt5.Rows.Count > 0)
                    {
                        Text_scan.Text = dt5.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_scan.Text = "0";
                    }

                    dt6 = objservice.Get_procedure(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt6.Rows.Count > 0)
                    {
                        Text_procedure.Text = dt6.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_procedure.Text = "0";
                    }

                    dt7 = objservice.Get_pft(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt7.Rows.Count > 0)
                    {
                        Text_pft.Text = dt7.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_pft.Text = "0";
                    }

                    dt8 = objservice.Get_ta().Tables[0];
                    if (dt8.Rows.Count > 0)
                    {
                        Text_ta.Text = dt8.Rows[0]["ta"].ToString();
                    }
                    else
                    {
                        Text_ta.Text = "0";
                    }

                    Text_grndttl.Text = (Convert.ToInt32( txt_payment.Text )+Convert.ToInt32( Text_lab.Text) +Convert.ToInt32( Text_echo.Text) +Convert.ToInt32( Text_tmt.Text) +Convert.ToInt32( Text_scan.Text )+Convert.ToInt32( Text_pft.Text) +Convert.ToInt32( Text_abovemax.Text)+ Convert.ToInt32(Text_procedure.Text)+ Convert.ToInt32(Text_ta.Text)).ToString();
                }
                else
                {
                    amount = dt1.Rows[0]["pervisit_payment"].ToString();
                    txt_payment.Text = amount;
                    dt = objservice.Get_ttlpayment().Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Text_abovemax.Text = dt.Rows[0]["totalpayment"].ToString();
                    }

                    dt2 = objservice.Get_lab(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt2.Rows.Count > 0)
                    {
                        Text_lab.Text = dt2.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_lab.Text = "0";
                    }

                    dt3 = objservice.Get_echo(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt3.Rows.Count > 0)
                    {
                        Text_echo.Text = dt3.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_echo.Text = "0";
                    }

                    dt4 = objservice.Get_tmt(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt4.Rows.Count > 0)
                    {
                        Text_tmt.Text = dt4.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_tmt.Text = "0";
                    }

                    dt5 = objservice.Get_scan(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt5.Rows.Count > 0)
                    {
                        Text_scan.Text = dt5.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_scan.Text = "0";
                    }

                    dt6 = objservice.Get_procedure(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt6.Rows.Count > 0)
                    {
                        Text_procedure.Text = dt6.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_procedure.Text = "0";
                    }
                    dt7 = objservice.Get_pft(txt_date.Text, txt_date.Text, Label_drid.Text, ddl_branch.SelectedValue).Tables[0];
                    if (dt7.Rows.Count > 0)
                    {
                        Text_pft.Text = dt7.Rows[0]["total_collection"].ToString();
                    }
                    else
                    {
                        Text_pft.Text = "0";
                    }
                    dt8 = objservice.Get_ta().Tables[0];
                    if (dt8.Rows.Count > 0)
                    {
                        Text_ta.Text = dt8.Rows[0]["ta"].ToString();
                        if(Text_ta.Text=="")
                        {
                            Text_ta.Text = "0";
                        }
                    }
                    else
                    {
                        Text_ta.Text = "0";
                    }

                    Text_grndttl.Text = (Convert.ToInt32(txt_payment.Text) + Convert.ToInt32(Text_lab.Text) + Convert.ToInt32(Text_echo.Text) + Convert.ToInt32(Text_tmt.Text) + Convert.ToInt32(Text_scan.Text) + Convert.ToInt32(Text_procedure.Text) + Convert.ToInt32(Text_abovemax.Text)+ Convert.ToInt32(Text_pft.Text) + Convert.ToInt32(Text_ta.Text)).ToString();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                div_hide.Visible = false;
                div_hide2.Visible = true;
                div_hide2_1.Visible = false;

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string dr_id = (row.FindControl("lbl_drid") as Label).Text;
                Label_drid.Text = dr_id;

                DataTable dt = new DataTable();
                dt = objservice.Get_drindividualcollection(txt_date.Text, txt_date.Text,dr_id, ddl_branch.SelectedValue).Tables[0];
                //if (dt.Rows.Count > 0)
                //{
                //    GridView2.DataSource = dt;
                //    GridView2.DataBind();
                //}

                DataTable dt1 = new DataTable();
                dt1 = objservice.Get_payment().Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    if(Convert.ToInt32(dt1.Rows[0]["perpatient_payment"])>0)
                    {
                        txt_payment.Text = dt1.Rows[0]["perpatient_payment"].ToString()+ " + Additional";
                    }
                    else
                    { 
                        txt_payment.Text = dt1.Rows[0]["pervisit_payment"].ToString() + " + Additional";
                    }                   
                }
            }
        }

        protected void Button_payment_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (Check_payment.Checked==true)
            {
                ds = objservice.Get_payment_mstduplicate(Label_drid.Text, txt_date.Text, ddl_branch.SelectedValue);
                if(ds.Tables[0].Rows.Count>0)
                {
                    objservice.Update_paymentmst(txt_date.Text, ddl_branch.SelectedValue, Label_drid.Text, Text_grndttl.Text, "Payment Initiated");
                }
                else
                {
                    objservice.insert_payment_mst(txt_date.Text, ddl_branch.SelectedValue, Label_drid.Text, Text_grndttl.Text, "Payment Initiated");
                }
                div_hide.Visible = true;
                div_hide2.Visible = false;
                GridView1.DataSource = null;
                GridView1.DataBind();
                DataTable dt = new DataTable();
                dt = objservice.Get_drtotalcollection(txt_date.Text, txt_date.Text, ddl_branch.SelectedValue).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            else
            {
                ds = objservice.Get_payment_mstduplicate(Label_drid.Text, txt_date.Text, ddl_branch.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objservice.Update_paymentmst(txt_date.Text, ddl_branch.SelectedValue, Label_drid.Text, Text_grndttl.Text, "Not Paid");
                }
                else
                {
                    objservice.insert_payment_mst(txt_date.Text, ddl_branch.SelectedValue, Label_drid.Text, Text_grndttl.Text, "Not Paid");
                }
                div_hide.Visible = true;
                div_hide2.Visible = false;
                GridView1.DataSource = null;
                GridView1.DataBind();
                DataTable dt = new DataTable();
                dt = objservice.Get_drtotalcollection1(txt_date.Text, txt_date.Text, ddl_branch.SelectedValue).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
}