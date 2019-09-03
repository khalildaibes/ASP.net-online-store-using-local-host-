using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Airlines : System.Web.UI.Page
{

    public string str;
    public static int i = 0;
    public string img = "Images/";
    public string str1 = "";
    DataSet ds = new DataSet();

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
        string QueryString = string.Format("select * from airlinesTbl");
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
        if (i < ds.Tables[0].Rows.Count)
        {
            airlineImg.ImageUrl = img;
            airlineNametxt.Text = ds.Tables[0].Rows[i]["name"].ToString();
            airlineImg.ImageUrl += ds.Tables[0].Rows[i]["picture"].ToString();

            if (i == ds.Tables[0].Rows.Count - 1)
                i = -1;
        }
    }

    protected void nextButton_Click(object sender, EventArgs e)
    {
        i = i + 1;

    }
   
}