using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Countries : System.Web.UI.Page
{
    public static int i = 0;
    public string QueryString;
    public string dbPath;
    public string countryCode;
    public string img = "Images/";
    DataSet ds = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {

        userTbl.Visible = true;
        mangTbl.Visible = false;

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
        
        if (userTbl.Visible == true)
        {
            QueryString = string.Format("select * from countryTbl");
            //---------
            dbPath = HttpContext.Current.Server.MapPath("~\\App_Data\\" + "website.mdb");
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
                countryImg.ImageUrl = img;
                countryNametxt.Text = ds.Tables[0].Rows[i]["name"].ToString();
                countryImg.ImageUrl += ds.Tables[0].Rows[i]["picture"].ToString();
                historyLab.Text = ds.Tables[0].Rows[i]["desc"].ToString();
                countryCode = ds.Tables[0].Rows[i]["code"].ToString();

                if (i == ds.Tables[0].Rows.Count - 1)
                    i = -1;
            }
        }
        if (mangTbl.Visible == true)
        {
            QueryString = string.Format("select * from countryTbl");
            //---------
            dbPath = HttpContext.Current.Server.MapPath("~\\App_Data\\" + "website.mdb");
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
                countryNameUpd.Text = ds.Tables[0].Rows[i]["name"].ToString();
                countryDescUpd.Text = ds.Tables[0].Rows[i]["desc"].ToString();
                countryCode = ds.Tables[0].Rows[i]["code"].ToString();

                if (i == ds.Tables[0].Rows.Count - 1)
                    i = -1;
            }
        }
           
    }

    protected void nextButton_Click(object sender, EventArgs e)
    {
        i = i + 1;

    }

    protected void updateButton_Click(object sender, EventArgs e)
    {

        string QueryString = string.Format("UPDATE  countryTbl set name='{0}',desc='{1}' WHERE code='{2}'", countryNameUpd.Text, countryDescUpd.Text, countryCode);
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
        //הפעלת הפקודה
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //יצירת דטהסט לאיחסון הנתונים
        //   DataSet ds = new DataSet();
        //הכנסת הנתונים,תוצאת השאילתה,לתוך הדטהסט שבזיכון
        //   da.Fill(ds, "tbl");
        cmd.ExecuteNonQuery();
        con.Close();
    }


    protected void nextUpdButton_Click(object sender, EventArgs e)
    {
        i=i + 1;

    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {

        string QueryString = string.Format("DELETE FROM countryTbl WHERE code='{0}'",countryCode);
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
        //הפעלת הפקודה
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //יצירת דטהסט לאיחסון הנתונים
        //   DataSet ds = new DataSet();
        //הכנסת הנתונים,תוצאת השאילתה,לתוך הדטהסט שבזיכון
        //   da.Fill(ds, "tbl");
        cmd.ExecuteNonQuery();
        con.Close();
    }

}
