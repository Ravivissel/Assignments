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


    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        System.Web.UI.WebControls.DropDownList ddl = (System.Web.UI.WebControls.DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1");



        string selected = ddl.SelectedValue;


        Product prod = new Product();


        int prodId = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);

        string isActive = selected;

        prod.ProdId = prodId;
        prod.IsActive = isActive;


        DBServices dbs = new DBServices();
        dbs.UpdateIsActive(prod);


    }
 
}
