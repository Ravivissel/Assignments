using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class inventoryManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Session["notConnected"] = "notConnected";
            Response.Redirect("Login.aspx");
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowState == DataControlRowState.Edit)
        {
            ImageButton lb = e.Row.Cells[0].Controls[0] as ImageButton;
            lb.OnClientClick = "return confirm('Are you sure want to update inventory?');";
        }
    }

    protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            //Show error message
            Console.WriteLine("error: " + e.Exception);

            //Set the exception handled property so it doesn't bubble-up
            e.ExceptionHandled = true;
        }
    }
}