using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class insertProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        //Upload the image to the server
        string name = imageUpload.FileName; // Take the name on the client
        string path = Server.MapPath("."); //Path to the current directory
        imageUpload.SaveAs(path + "/images/" + name); // Must provide a full path
        string image = "images/" + name;

        Product product;

        try
        {
            product = new Product(Convert.ToInt32(categoryDDL.SelectedValue), prodNameTB.Text, image.ToString(), Convert.ToDouble(prodPriceTB.Text), Convert.ToInt32(inventoryDDL.SelectedValue));
        }
        catch (Exception ex)
        {
            prodMessage.Text = "illegal values to the product attributes - error message is " + ex.Message;
            return;
        }

        try
        {
            int numEffected = product.insert();
            prodMessage.Text = "הוספת בהצלחה  " + numEffected.ToString() + " אחד מוצר חדש";
        }
        catch (Exception ex)
        {
            prodMessage.Text = "There was an error when trying to insert the Product into the database" + ex.Message;
        }
    }
}