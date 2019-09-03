using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            name.Visible = false;
            logout.Visible = false;
        }
        else
        {
            logout.Visible = true;
            signIn.Visible = false;
            name.Text = Session["userFullName"].ToString();
            name.Visible = true;
        }
    }
}