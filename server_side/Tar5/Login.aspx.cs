using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Request.Cookies["adminPassword"] != null && Request.Cookies["adminUserName"] != null)
            {
                DialogResult result = MessageBox.Show("Hi Admin, Do you want to connect automatically?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                    Response.Redirect("inventoryManagement.aspx");
            }
            if (Request.Cookies["customerPassword"] != null && Request.Cookies["customerUserName"] != null)
            {
                DialogResult result = MessageBox.Show("Hi Customer, Do you want to connect automatically?", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
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
            if (userName == "admin" && password == "admin") //redirect manager and customer to the right pages
            {
                Session["admin"] = "admin";
                if (Request.Cookies["adminPassword"] != null && Request.Cookies["adminUserName"] != null)
                {
                    if (rememberMe.Checked == true)
                    {
                        Response.Cookies["adminUserName"].Value = userName;
                        Response.Cookies["adminPassword"].Value = password;
                        Response.Cookies["adminUserName"].Expires = DateTime.Now.AddMinutes(20);
                        Response.Cookies["adminPassword"].Expires = DateTime.Now.AddMinutes(20);
                    }
                }                    
                Response.Redirect("inventoryManagement.aspx");
            }
            else
            {
                Session["customer"] = "customer";
                if (Request.Cookies["customerPassword"] != null && Request.Cookies["customerUserName"] != null)
                {
                    if (rememberMe.Checked == true)
                    {
                        Response.Cookies["customerUserName"].Value = userName;
                        Response.Cookies["customerPassword"].Value = password;
                        Response.Cookies["customerUserName"].Expires = DateTime.Now.AddMinutes(20);
                        Response.Cookies["customerPassword"].Expires = DateTime.Now.AddMinutes(20);
                    }
                }
                Response.Redirect("showProducts.aspx");
            }
        }
        else
            MessageBox.Show("user does not exist in the system!");
    }
}