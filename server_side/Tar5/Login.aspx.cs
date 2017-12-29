using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["notConnected"] != null)
            notConnected.Visible = true;

        if (IsPostBack == false)
        {
            if ((Request.Cookies["pass"] != null) && (Request.Cookies["name"] != null))
            {
                string userName = Request.Cookies["name"].ToString();
                if (userName == "admin")
                    Response.Redirect("inventoryManagement.aspx");
                else
                    Response.Redirect("showProducts.aspx");
            }
        }
    }

    protected void login_Click(object sender, EventArgs e)
    {
        DBServices dbs = new DBServices();
        DataSet ds = new DataSet();
        try
        {
            ds = dbs.ReadFromDataBase("igroup82_test1ConnectionString", "Customers");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to read from the database " + ex.Message);
            return;
        }

        // verify the information against the db
        int exist = 0;
        string userName = username.Text;
        string password = Password.Text;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string name1 = dr["UserName"].ToString();
            string password1 = dr["passWord"].ToString();
            if (name1 == userName && password1 == password)
                exist = 1;
        }

        // data has been validated successfully
        if (exist == 1)
        {
            if (Request.Cookies["pass"] != null && Request.Cookies["name"] != null)
            {
                if (rememberMe.Checked == true)
                {
                    Response.Cookies["name"].Value = userName;
                    Response.Cookies["pass"].Value = password;
                    Response.Cookies["name"].Expires = DateTime.Now.AddMinutes(20);
                    Response.Cookies["pass"].Expires = DateTime.Now.AddMinutes(20);
                }
            }
            if (userName == "admin" && password == "admin") //redirect manager and customer to the right pages
            {
                Session["admin"] = "admin";
                Response.Redirect("inventoryManagement.aspx");
            }
            else
            {
                Session["customer"] = "customer";
                Response.Redirect("showProducts.aspx");
            }
        }
        else
            MessageBox.Show("user does not exist in the system!");
    }
}