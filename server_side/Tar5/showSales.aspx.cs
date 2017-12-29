using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class showSales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Session["notConnected"] = "notConnected";
            Response.Redirect("Login.aspx");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        string catName = DropDownList1.Text;

        string command = "SELECT s.* from sales s join productN p on p.ID=s.prodID join Category cat on cat.id = p.catID ";
        if (catName != "All")
            command += "where cat.name='" + catName + "'";

        SqlDataSource1.SelectCommand = command;

    }

}
