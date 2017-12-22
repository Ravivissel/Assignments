using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ShowProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        addProducts(getProductsList());

        DBServices db1 = new DBServices();
        List<Product> pList = new List<Product>();
        pList = db1.getList();
        Random random = new Random();
        int randomNumber = random.Next(pList.Count);
        
        if (Request.Cookies["veteranCustomer"] == null)
        {
            VeternCustomer.Text = "This is your first visit, do you want " + pList[randomNumber].Title + " in " + pList[randomNumber].Price * 0.5 + " instead of " + pList[randomNumber].Price + " ?";
            Response.Cookies["veteranCustomer"].Value = "firstVisit";
            Response.Cookies["veteranCustomer"].Expires = DateTime.Now.AddYears(100);
            Response.Cookies["Id"].Value = pList[randomNumber].Id.ToString();
        }
        else
        {
            VeternCustomer.Text = "This is not your first visit, do you want " + pList[randomNumber].Title + " in " + pList[randomNumber].Price * 0.8 + " instead of " + pList[randomNumber].Price + " ?";
            Response.Cookies["veteranCustomer"].Value = "secondVisit";
            Response.Cookies["veteranCustomer"].Expires = DateTime.Now.AddYears(100);
            Response.Cookies["Id"].Value = pList[randomNumber].Id.ToString();
        }
        
    }

    protected void addProducts(List<Product> pList, int min = 0)
    {
        for (int i = min; i < pList.Count; i++)
        {
            //Create Controllers
            Image img = new Image();
            Label title = new Label();
            Label price = new Label();
            Label inventory = new Label();
            Label attributes = new Label();
            CheckBox cb = new CheckBox();

            //Controllers assign:

            //Title assign
            title.ID = "title" + i.ToString();
            title.Text = "<br/>" + pList[i].Title + "<br/>";

            //Images assign
            img.ID = "img" + i.ToString();
            img.ImageUrl = pList[i].ImagePath;

            //Attributes assign
            attributes.ID = "attribute" + i.ToString();

            Dictionary<string, string> atDict = new Dictionary<string, string>();
            atDict = pList[i].Attributes;
            foreach (KeyValuePair<string, string> kvp in atDict)
            {
                attributes.Text += "<br/>" + kvp.Key.ToString() + " - " + kvp.Value;
            }

            //Price assign
            price.ID = "price" + i.ToString();
            price.Text = "<br/>Price:" + pList[i].Price.ToString();

            //Inventory assign
            inventory.ID = "inventory" + i.ToString();
            inventory.Text = "<br/>In Stock: " + pList[i].Inventory.ToString() + "<br/>Buy:";

            //CheckBox assign
            cb.ID = "cb" + i.ToString();
            if (pList[i].Inventory == 0)
            {
                cb.Enabled = false;
            }
            cb.Text = "<br/><br/>";

            //Add controlers to place holder
            ph.Controls.Add(title);
            ph.Controls.Add(img);
            ph.Controls.Add(attributes);
            ph.Controls.Add(price);
            ph.Controls.Add(inventory);
            ph.Controls.Add(cb);
        }
    }

    protected void SubmitBT_Clicked(object sender, EventArgs e)
    {
        List<Product> pList = getProductsList();
        List<Product> pSelectedList = new List<Product>();

        //Checking for selected products
        for (int i = 0; i < pList.Count; i++)
        {
            Control control = new Control();
            control = ph.FindControl("cb" + i.ToString());
            CheckBox cb = new CheckBox();
            cb = (CheckBox)control;
            
            if (cb.Checked)
            {
                //Assign selected products list and adding the titles to checkout lable               
                pSelectedList.Add(pList[i]);
                Checkout_Lable.Text += "<br/>" + pList[i].Title;

                //checking if the product with the discount was selected and update the price if so
                string Id1 = Request.Cookies["Id"].Value;
                int Id = Convert.ToInt32(Id1);

                for (int j = 0; j < pSelectedList.Count; j++)
                {
                    if (pSelectedList[j].Id == Id)
                    {
                        if (Request.Cookies["veteranCustomer"].Value == "firstVisit")
                        {
                            pSelectedList[j].Price = pSelectedList[j].Price * 0.5;
                        }
                        else
                            pSelectedList[j].Price = pSelectedList[j].Price * 0.8;
                    }

                }
                //insert selected products to Session
                Session["pSelectedList"] = pSelectedList;
            }
        }

        //Remove all the controls 
        ph.Controls.Clear();

        Checkout_Lable.Visible = true;
        SubmitBT.Visible = false;
        BackBT.Visible = true;
        VeternCustomer.Visible = false;
        proceedToPayment.Visible = true;

        //checking if items were selected
        if (pSelectedList.Count == 0)
        {
            Checkout_Lable.Text = "<br/>There are no selected items...";
            Session["pSelectedList"] = pSelectedList;
            proceedToPayment.Visible = false;
        }
    }

    //Back to homepage - not required 
    protected void BackBT_Clicked(object sender, EventArgs e)
    {
        proceedToPayment.Visible = false;
        VeternCustomer.Visible = true;
        SubmitBT.Visible = true;
        BackBT.Visible = false;
        Checkout_Lable.Text = "<br/>The Selected Items Are:";
        Checkout_Lable.Visible = false;

        addProducts(getProductsList());
    }

    protected List<Product> getProductsList()
    {
        Product p = new Product();
        List<Product> pList = new List<Product>();
        pList = p.getProducts();
        return pList;
    }

    protected void proceedToPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }
}
