using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travels : System.Web.UI.Page
{
    public static int i = 0;
    public string QueryString;
    public string dbPath;
    public string countryCode, airlineCode, countryName, airlinesName,price,date;
    public string img = "Images/";
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {

        doneLab.Visible = false;
        errorLab.Visible = false;

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

     
        QueryString = string.Format("select * from travelTbl");
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
            traImg.ImageUrl = img;
            countryCode = ds.Tables[0].Rows[i]["countryCode"].ToString();
            airlineCode = ds.Tables[0].Rows[i]["airlineCode"].ToString();
            price = ds.Tables[0].Rows[i]["price"].ToString();
            date = ds.Tables[0].Rows[i]["date"].ToString();
            traImg.ImageUrl += ds.Tables[0].Rows[i]["picture"].ToString();


            QueryString = string.Format("select name from countryTbl where code='{0}'", countryCode);
            //---------
            dbPath = HttpContext.Current.Server.MapPath("~\\App_Data\\" + "website.mdb");
            //מחרוזת התחברות לקובץ אקסס 2003
            string connectionString1 = @"Data Source='" + dbPath + "';Provider='Microsoft.Jet.OLEDB.4.0';";
            //יצירת אוביקט התחברות בהתאם למחרות ההתחברות
            OleDbConnection con1 = new OleDbConnection(connectionString);
            //פתיחת החיבור 
            con.Open();
            //יצירת אוביקט הפקודה להרצת השאילתה עבור החיבור הנתון
            OleDbCommand cmd1 = new OleDbCommand(QueryString, con1);
            //הפעלת הפקודה
            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);

            //הכנסת הנתונים,תוצאת השאילתה,לתוך הדטהסט שבזיכון
            da1.Fill(ds1, "tbl");
            //סגירת החיבור לדטהביס
            con.Close();

            countryName = ds1.Tables[0].Rows[0]["name"].ToString();
            traCountry.Text = "Country: " + countryName;

            QueryString = string.Format("select name from airlinesTbl where code='{0}'", airlineCode);
            //---------
            dbPath = HttpContext.Current.Server.MapPath("~\\App_Data\\" + "website.mdb");
            //מחרוזת התחברות לקובץ אקסס 2003
            string connectionString2 = @"Data Source='" + dbPath + "';Provider='Microsoft.Jet.OLEDB.4.0';";
            //יצירת אוביקט התחברות בהתאם למחרות ההתחברות
            OleDbConnection con2 = new OleDbConnection(connectionString);
            //פתיחת החיבור 
            con.Open();
            //יצירת אוביקט הפקודה להרצת השאילתה עבור החיבור הנתון
            OleDbCommand cmd2 = new OleDbCommand(QueryString, con2);
            //הפעלת הפקודה
            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd2);

            //הכנסת הנתונים,תוצאת השאילתה,לתוך הדטהסט שבזיכון
            da2.Fill(ds2, "tbl");
            //סגירת החיבור לדטהביס
            con.Close();

            airlinesName = ds2.Tables[0].Rows[0]["name"].ToString();
            traAirline.Text = "Airline: " + airlinesName;

            traPrice.Text = "Price per ticket: " + price;
            traDate.Text = "Travel Date: " + date;
        }
        else
            i = -1;

        
    }

    protected void nextButton_Click(object sender, EventArgs e)
    {
        i = i + 1;

    }

    protected void BookButton_Click(object sender, EventArgs e)
    {
        if (Session.Count > 0)
        {
 
                string QueryString = string.Format("insert into userInTravel values('{0}','{1}')", countryCode, Session["email"].ToString());
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
                doneLab.Visible = true;
                travelsTbl.Visible = false;
                title.Visible = false;

        }
        else
        {
            errorLab.Visible = true;
            travelsTbl.Visible = false;
            title.Visible = false;
        }

    }

}