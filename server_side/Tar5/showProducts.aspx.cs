using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;

public partial class showProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if ((String)Session["PostSale"] == "SaleSucceeded")
        {
            Response.Write("<script language=javascript>alert('Sale Succeeded');</script>");
            
        }
        else if ((String)Session["PostSale"] == "SaleFailed")
        {
            Response.Write("<script language=javascript>alert('Sale Failed');</script>");
           
        }
        Session["PostSale"] = null;

        if (Session["customer"] == null)
        {
            Session["notConnected"] = "notConnected";
            Response.Redirect("Login.aspx");
        }

        addProducts(getProductsList());

        List<Product> pList = new List<Product>();
        pList = getProductsList();
        Random random = new Random();
        int randomNumber = random.Next(pList.Count);

        if (Request.Cookies["veteranCustomer"] == null)
        {
            VeternCustomer.Text = "This is your first visit, do you want " + pList[randomNumber].Title + " in " + pList[randomNumber].Price * 0.5 + " instead of " + pList[randomNumber].Price + " ?";
            Response.Cookies["veteranCustomer"].Value = "firstVisit";
            Response.Cookies["veteranCustomer"].Expires = DateTime.Now.AddYears(100);
            Response.Cookies["Id"].Value = pList[randomNumber].ProdId.ToString();
        }
        else
        {
            VeternCustomer.Text = "This is not your first visit, do you want " + pList[randomNumber].Title + " in " + pList[randomNumber].Price * 0.8 + " instead of " + pList[randomNumber].Price + " ?";
            Response.Cookies["veteranCustomer"].Value = "secondVisit";
            Response.Cookies["veteranCustomer"].Expires = DateTime.Now.AddYears(100);
            Response.Cookies["Id"].Value = pList[randomNumber].ProdId.ToString();
        }

    }

    protected void addProducts(List<Product> pList, int min = 0)
    {
        for (int i = pList[0].ProdId; i < pList.Count; i++)
        {
            if (pList[i].IsActive == "Yes")
            {
                //Create Controllers
                System.Web.UI.WebControls.Label title = new System.Web.UI.WebControls.Label();
                Image img = new Image();
                System.Web.UI.WebControls.Label price = new System.Web.UI.WebControls.Label();
                System.Web.UI.WebControls.Label inventory = new System.Web.UI.WebControls.Label();
                System.Web.UI.WebControls.CheckBox cb = new System.Web.UI.WebControls.CheckBox();

                //Controllers assign:

                //Title assign
                title.ID = "title" + i.ToString();
                title.Text = "<br/>" + pList[i].Title + "<br/>";

                //Images assign
                img.ID = "img" + i.ToString();
                img.ImageUrl = pList[i].ImagePath;

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
                ph.Controls.Add(price);
                ph.Controls.Add(inventory);
                ph.Controls.Add(cb);
            }

        }
    }

    protected void SubmitBT_Clicked(object sender, EventArgs e)
    {
        List<Product> pList = getProductsList();
        List<Product> pSelectedList = new List<Product>();

        //Checking for selected products
        for (int i = pList[0].ProdId; i < pList.Count; i++)
        {
            System.Web.UI.Control control = new System.Web.UI.Control();
            control = ph.FindControl("cb" + i.ToString());
            System.Web.UI.WebControls.CheckBox cb = new System.Web.UI.WebControls.CheckBox();
            cb = (System.Web.UI.WebControls.CheckBox)control;

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
                    if (pSelectedList[j].ProdId == Id)
                    {
                        if (Request.Cookies["veteranCustomer"].Value == "firstVisit")
                        {
                            pSelectedList[j].Price = (float)(pSelectedList[j].Price * 0.5);
                        }
                        else
                            pSelectedList[j].Price = (float)(pSelectedList[j].Price * 0.8);
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
        Product prod = new Product();
        // read the table into a datatable
        DataTable dt = prod.read();
        List<Product> prodList = new List<Product>();
        foreach (DataRow dr in dt.Rows)
        {
            int prodId = Convert.ToInt32(dr["ID"]);
            string title = dr["Name"].ToString();
            string image = dr["imgURL"].ToString();
            float price = (float)Convert.ToDouble(dr["Price"]);
            int inventory = Convert.ToInt32(dr["Inventory"]);
            string isActive = dr["isActive"].ToString();
            int category = Convert.ToInt32(dr["CatID"]);
            Product p = new Product(prodId, category, title, image, price, inventory, isActive);
            prodList.Add(p);
        }
        return prodList;
    }

    protected void proceedToPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }
}
