using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    Boolean emailF = false, passwordF = false;
    DataSet ds = new DataSet();
    private static string email1, password1, fullName;
    private string  adminNum;

    protected void Page_Load(object sender, EventArgs e)
    {
        emailError.Visible = false;
        passwordError.Visible = false;
        name.Visible = false;
        logout.Visible = false;

    }
    protected void signInbtn_Click(object sender, EventArgs e)
    {
        if (Session.Count>0)
        {
            title.Text = "Welcome back " + Session["userFullName"];
            emailtxt.Visible = false;
            passwordtxt.Visible = false;
            signInbtn.Visible = false;
        }
        else
        {

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
                email1 = emailtxt.Text;
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
                password1 = passwordtxt.Text;
            }

            if (emailF && passwordF)
            {
                string email, password;
                string QueryString = string.Format("select * from userTbl");
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
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                //הכנסת הנתונים,תוצאת השאילתה,לתוך הדטהסט שבזיכון
                da.Fill(ds, "tbl");
                //סגירת החיבור לדטהביס
                con.Close();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    email = ds.Tables[0].Rows[i]["email"].ToString();
                    password = ds.Tables[0].Rows[i]["password"].ToString();

                    if (email.Equals(email1) == true && password.Equals(password1) == true)
                    {
                        emailtxt.Visible = false;
                        passwordtxt.Visible = false;
                        signInbtn.Visible = false;
                        fullName = ds.Tables[0].Rows[i]["fname"].ToString()+" ";
                        fullName += ds.Tables[0].Rows[i]["lname"].ToString();
                        title.Text = "Welcome back " + fullName;
                        adminNum =ds.Tables[0].Rows[i]["admin"].ToString();
                        logout.Visible = true;
                        signIn.Visible = false;
                        name.Text = fullName;
                        name.Visible = true;
                      


                        Session["userFullName"] = fullName;
                        Session["roleNumber"] = adminNum;
                        Session["email"] = email1;
                        
                        break;
                    }
                }




            }
       
        }
    }
}