using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUp : System.Web.UI.Page
{
    Boolean fnameF = false, lnameF = false, addressF = false, emailF = false, passwordF = false; 

    protected void Page_Load(object sender, EventArgs e)
    {
        fnameError.Visible = false;
        lnameError.Visible = false;
        emailError.Visible = false;
        passwordError.Visible = false;
        addressError.Visible = false;

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
    protected void signUpbtn_Click(object sender, EventArgs e)
    {


        if (fnametxt.Text == "")
        {
            fnameError.Visible = true;
            fnameError.Text = "Insert your first name please.";
            fnameError.ForeColor = Color.Red;

        }
        else
        {
            fnameError.Visible = false;
            fnameF = true;
        }
        if (lnametxt.Text == "")
        {
            lnameError.Visible = true;
            lnameError.Text = "Insert your last name please";
            lnameError.ForeColor = Color.Red;
        }
        else
        {
            lnameError.Visible = false;
            lnameF = true;
        }

        if (emailtxt.Text == "")
        {
            emailError.Visible = true;
            emailError.Text = "Insert your email please";
            emailError.ForeColor = Color.Red;
        }
        else
        {
            emailError.Visible = false;
            emailF = true;
            try
            {
                MailAddress flag = new MailAddress(emailtxt.Text);
            }
            catch
            {
                emailError.Visible = true;
                emailError.ForeColor = Color.Red;
                emailError.Text = "Invalid mail";
            }
        }
        if (passwordtxt.Text == "")
        {
            passwordError.Visible = true;
            passwordError.Text = "Insert a password please";
            passwordError.ForeColor = Color.Red;
        }
        else
        {
            passwordError.Visible = false;
            passwordF = true;
        }
        if (addresstxt.Text == "")
        {
            addressError.Visible = true;
            addressError.Text = "Insert your address please";
            addressError.ForeColor = Color.Red;
        }
        else
        {
            addressError.Visible = false;
            addressF = true;
        }

        if (addressF && fnameF && lnameF && passwordF && emailF)
        {
            try
            {
                string QueryString = string.Format("insert into userTbl values('{0}','{1}','{2}','{3}','{4}',{5})", emailtxt.Text, fnametxt.Text, lnametxt.Text, passwordtxt.Text, addresstxt.Text, 0);
                //---------
                string dbPath = HttpContext.Current.Server.MapPath("~\\App_Data\\" + "website.mdb");
                //מחרוזת התחברות לקובץ אקסס 2003
                string connectionString = @"Data Source='" + dbPath + "';Provider='Microsoft.Jet.OLEDB.4.0';";
                //יצירת אוביקט התחברות בהתאם למחרות ההתחברות
                OleDbConnection con = new OleDbConnection(connectionString);
                //פתיחת החיבור 
                con.Open();
                //יצירת אוביקט הפקודה להרצת השאילתה עבור החיבור הנתון
                OleDbCommand cmd = new OleDbCommand(QueryString, con);
                //הפעלת הפקודה
                //   cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

                //סגירת החיבור לדטהביס
                con.Close();

                fnametxt.Visible = false;
                lnametxt.Visible = false;
                emailtxt.Visible = false;
                passwordtxt.Visible = false;
                addresstxt.Visible = false;
                signUpbtn.Visible = false;

                title.Text = "You've been added successfully :)";
                Session["userFullName"] = fnametxt.Text + " " + lnametxt.Text;
            }
            catch
            {
                title.Text = "Something went wrong, try again!";
            }
       
        }

    }

}