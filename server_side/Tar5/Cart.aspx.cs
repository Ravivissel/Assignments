using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customer"] == null)
        {
            MessageBox.Show("You are not connected, please connect at the login", "Alert");
            Response.Redirect("Login.aspx");
        }
        if (Request.Cookies["cartFirstTime"] == null)
        {
            Response.Cookies["cartFirstTime"].Value = "firstVisit";
            Response.Cookies["cartFirstTime"].Expires = DateTime.Now.AddYears(100);
            msgLBL.Text = "You came to the cart page for the first time...";
        }
        else
        {
            msgLBL.Text = "This is not the first time you came to the cart page...";
        }

        if (Session["pSelectedList"] != null)
        {
            List<Product> pSelectedList = new List<Product>();
            pSelectedList = ((List<Product>)(Session["pSelectedList"]));
            double totalPrice = 0;
            if (pSelectedList.Count == 0)
            {
                confirm.Visible = false;
            }
            else
            {
                confirm.Visible = true;
            }

            for (int i = 0; i < pSelectedList.Count; i++)
            {
                //Create Controllers
                Image img = new Image();
                Label title = new Label();
                Label text = new Label();
                Label price = new Label();
                CheckBox cb = new CheckBox();

                //Controllers assign

                //Title assign
                title.ID = "title" + i.ToString();
                title.Text = "<br/>" + pSelectedList[i].Title + "<br/>";

                //Images assign
                img.ID = "img" + i.ToString();
                img.ImageUrl = pSelectedList[i].ImagePath;

                //Inventory assign
                //inventory.ID = "inventory" + i.ToString();
                text.Text = "<br/>Buy:";

                //Price assign
                price.ID = "price" + i.ToString();
                price.Text = "<br/>Price:" + pSelectedList[i].Price.ToString();

                //CheckBox assign
                cb.ID = "cb" + i.ToString();
                cb.Checked = true;
                cb.Text = "<br/><br/>";
                cb.AutoPostBack = true;

                //Price assigh
                totalPrice += pSelectedList[i].Price;

                //Add controlers to place holder
                ph.Controls.Add(title);
                ph.Controls.Add(img);
                ph.Controls.Add(price);
                ph.Controls.Add(text);
                ph.Controls.Add(cb);

                finalPrice.Text = "<br/><br/>The total price is " + totalPrice.ToString();
                Session["totalPrice"] = totalPrice;
            }
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    { // PreRender is called when it still "sees" the previous controls
        if (IsPostBack)
        {
            msgLBL.Text = "The change has been saved!";
            List<Product> newListp = new List<Product>();
            newListp = (List<Product>)(Session["pSelectedList"]);
            int i = 0;
            double total = 0;
            foreach (Product prod in newListp)
            {

                if (ph.FindControl("cb" + i.ToString()) != null)
                {
                    CheckBox cb = (CheckBox)ph.FindControl("cb" + i.ToString());
                    if (cb.Checked == true)
                    {
                        total = total + prod.Price;
                    }
                }
                i++;
            }
            finalPrice.Text = "<br/><br/>The total price is " + total.ToString();
            Session["totalPrice1"] = total;
        }
    }

    protected void confirm_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payment.aspx");
    }
}