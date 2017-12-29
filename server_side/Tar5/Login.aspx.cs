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
    const string MANAGER_TYPE = "MANAGER";
    const string CUSTOMER_TYPE = "CUSTOMER";



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["notConnected"] != null)
            notConnected.Visible = true;

        if (IsPostBack == false)
        {
            if ((Request.Cookies["pass"] != null) && (Request.Cookies["name"] != null))
            {
                Customer customer = new Customer();


                customer.UserName = Request.Cookies["name"].ToString();
                customer.Password = Request.Cookies["pass"].ToString();
                customer.UserType = Request.Cookies["userType"].ToString();
                customer.Id = Convert.ToInt32(Request.Cookies["id"]);

                Session["customer"] = customer;

                if (customer.UserType == MANAGER_TYPE)
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
        Customer customer = new Customer();

        customer.UserName = username.Text;
        customer.Password = Password.Text;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string name1 = dr["UserName"].ToString();
            string password1 = dr["passWord"].ToString();
            if (name1 == customer.UserName && password1 == customer.Password)
            {
                exist = 1;
                customer.UserType = dr["userType"].ToString();
                customer.Id = Convert.ToInt32(dr["ID"]);
                Session["customer"] = customer;
            }
        }

        // data has been validated successfully
        if (exist == 1)
        {


            if (Request.Cookies["pass"] != null && Request.Cookies["name"] != null)
            {
                if (rememberMe.Checked == true)
                {
                    Response.Cookies["customer"].Value = customer.UserName;
                    Response.Cookies["pass"].Value = customer.Password;
                    Response.Cookies["type"].Value = customer.UserType;
                    Response.Cookies["ID"].Value = customer.Id.ToString();
                    Response.Cookies["name"].Expires = DateTime.Now.AddMinutes(20);
                    Response.Cookies["pass"].Expires = DateTime.Now.AddMinutes(20);
                }
            }

            Session["customer"] = customer;

            
if (customer.UserType == MANAGER_TYPE) //redirect manager and customer to the right pages
            {
                Session["admin"] = customer.Id;
                Response.Redirect("inventoryManagement.aspx");
            }

            else
                Response.Redirect("showProducts.aspx");
        }
        else
            MessageBox.Show("user does not exist in the system!");
    }
}