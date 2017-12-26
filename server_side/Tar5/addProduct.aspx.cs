using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class addProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            MessageBox.Show("You are not connected, please connect at the login", "Alert");
            Response.Redirect("Login.aspx");
        }
    }

    protected void submitBTN_Click(object sender, EventArgs e)
    {
        //Upload the image to the server
        string name = imageUpload.FileName; // Take the name on the client
        string path = Server.MapPath("."); //Path to the current directory
        imageUpload.SaveAs(path + "/images/" + name); // Must provide a full path
        string image = "images/" + name;

        Product product;

        try
        {
            product = new Product(Convert.ToInt32(categoryDDL.SelectedValue), NameTB.Text, image.ToString(), float.Parse(PriceTB.Text), Convert.ToInt32(InventoryTB.Text), activeTB.Text);
        }
        catch (Exception ex)
        {
            outLBL.Text = "illegal values to the product attributes - error message is " + ex.Message;
            return;
        }

        try
        {
            int numEffected = product.insert();
            outLBL.Text = numEffected.ToString() + " new product was successfully added";
        }
        catch (Exception ex)
        {
            outLBL.Text = "There was an error when trying to insert the Product into the database" + ex.Message;
        }
    }
}
