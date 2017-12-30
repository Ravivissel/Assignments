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
            Session["notConnected"] = "notConnected";
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
    {      //Upload the image to the server
        if (Session["pSelectedList"] != null)
        {
            List<Product> pSelectedList = new List<Product>();
            pSelectedList = ((List<Product>)(Session["pSelectedList"]));
            int numEffected = 0;
            int errorCount = 0;

            ///Product _product, float _totalPrice, int _quantity, int _customerId, DateTime _date, bool _paymentType
            ///

            foreach (Product p in pSelectedList)
            {

                int quantity = Convert.ToInt32(Session[p.ProdId.ToString() + "SelectedNum"]);
                Double totalPrice = Convert.ToDouble(Session[p.ProdId.ToString() + "TotalPrice"]);
                Customer customer = (Customer)(Session["customer"]);
                DateTime saleDate = DateTime.Now;
                int paymentType;


                if (PhoneCB.Checked)
                    paymentType = 1;
                else
                    paymentType = 2;

                Sale sale = new Sale(p.ProdId, totalPrice, quantity, customer.Id, saleDate, paymentType);

                p.Inventory -= sale.Quantity;

                DBServices dbs = new DBServices();
                try
                {
                    numEffected += dbs.Update(p);
                    numEffected += dbs.insert(sale);
                }

                catch (Exception err)
                {
                    Console.WriteLine(err);
                    throw err;

                }

            }

            if (numEffected > 0)
            {
                Response.Write("alert('Thanks for buying with us')");

            }
            if (errorCount > 0)
            {

                Response.Write("alert('There was error with the ')");
            }
            Response.Redirect("showProducts.aspx");


            //Upload the image to the server
            /*
            string name = imageUpload.FileName; // Take the name on the client
            string path = Server.MapPath("."); //Path to the current directory
            imageUpload.SaveAs(path + "/images/" + name); // Must provide a full path
            imgsign.ImageUrl = "images/" + name; // Note that this is a relative link
            */
        }
    }

}