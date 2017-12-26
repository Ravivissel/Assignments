using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customer"] == null)
        {
            MessageBox.Show("You are not connected, please connect at the login", "Alert");
            Response.Redirect("Login.aspx");
        }
        if (Session["totalPrice1"] != null)
        {
            List<Product> pSelectedList = new List<Product>();
            pSelectedList = ((List<Product>)(Session["pSelectedList"]));
            if (pSelectedList.Count == 0)
            {
                finalPrice.Text = "The current price is 0";
            }
            else
            {
                double currentPrice = 0;
                currentPrice = ((double)(Session["totalPrice1"]));
                finalPrice.Text = "The current price is " + currentPrice;
            }
        }
        else
        {
            if (Session["totalPrice"] != null)
            {
                List<Product> pSelectedList = new List<Product>();
                pSelectedList = ((List<Product>)(Session["pSelectedList"]));
                if (pSelectedList.Count == 0)
                {
                    finalPrice.Text = "The current price is 0";
                }
                else
                {
                    double currentPrice = 0;
                    currentPrice = ((double)(Session["totalPrice"]));
                    finalPrice.Text = "The current price is " + currentPrice;
                }
            }
        }
    }

    protected void submitBTN_Click1(object sender, EventArgs e)
    {
        //Upload the image to the server
        string name = imageUpload.FileName; // Take the name on the client
        string path = Server.MapPath("."); //Path to the current directory
        imageUpload.SaveAs(path + "/images/" + name); // Must provide a full path
        imgsign.ImageUrl = "images/" + name; // Note that this is a relative link
    }

}