using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class addCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBServices dbs = new DBServices();
        DataSet ds = dbs.ReadFromDataBase("igroup82_test1ConnectionString", "Category");


        // connect the controls to the data source

        categoryDDL.DataSource = ds;
        DataBind(); //must call this method in order to bind the  
                    //data to the control and render the HTML
    }

    protected void submitBTN_Click(object sender, EventArgs e)
    {
        string category = categoryTB.Text;
        //make sure that the new category doesn't already exist in the data base
    }
}