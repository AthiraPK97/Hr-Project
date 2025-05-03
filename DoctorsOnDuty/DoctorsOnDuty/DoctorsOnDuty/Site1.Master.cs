using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorsOnDuty
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERTYPE"] == null && Session["USERID"] == null && Session["LOGUSER"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void redirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44315/Upload_scanningdoc.aspx?USERTYPE=" + Session["USERTYPE"]+"&USERID="+ Session["USERID"]+ "&LOGUSER="+ Session["LOGUSER"]);
        }
    }
}