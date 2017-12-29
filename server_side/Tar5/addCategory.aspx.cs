using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows.Forms;

public partial class addCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
<<<<<<< HEAD
            Session["notConnected"] = "notConnected";
            Response.Redirect("Login.aspx");            
=======
            MessageBox.Show("You are not connected, please connect at the login", "Alert");
            Response.Redirect("Login.aspx");
>>>>>>> 41d88bcaa961cf0316dc2ddf7278d5c2638f7a0b
        }
        DBServices dbs = new DBServices();
        DataSet ds = dbs.ReadFromDataBase("igroup82_test1ConnectionString", "Category");

        Session["DataSet"] = ds;

        // connect the controls to the data source        
        categoryDDL.DataSource = ds;
        DataBind(); //must call this method in order to bind the  
                    //data to the control and render the HTML
    }

    protected void Page_PreRender(object sender, EventArgs e)
    { // PreRender is called when it still "sees" the previous controls
        if (IsPostBack)
        {
            DBServices dbs = new DBServices();
            DataSet ds = dbs.ReadFromDataBase("igroup82_test1ConnectionString", "Category");

            Session["DataSet"] = ds;

            // connect the controls to the data source        
            categoryDDL.DataSource = ds;
            DataBind(); //must call this method in order to bind the  
                        //data to the control and render the HTML
        }
    }

    protected void submitBTN_Click(object sender, EventArgs e)
    {
        categoryTB.AutoPostBack = true;
        string category = categoryTB.Text;
        if (Session["DataSet"] != null)
        {
            //make sure that the new category doesn't alreloady exist in the data base
            DataSet ds = (DataSet)(Session["DataSet"]);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["Name"].ToString() == category)
                {
                    string info = "This Category allready exsist, please add a different category";
                    categoryMessage.Text = info;
                    return;
                }

            }

            try
            {
                Category c = new Category(category);

                int numEffected = c.Insert();
                categoryMessage.Text = numEffected.ToString() + " new category was successfully added"; ;
            }
            catch (Exception ex)
            {
                Response.Write("There was an error when trying to insert the new category into the database" + ex.Message);
            }
        }
    }
}