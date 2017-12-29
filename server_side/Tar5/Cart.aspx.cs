using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customer"] == null)
        {
            Session["notConnected"] = "notConnected";
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
                System.Web.UI.WebControls.Label title = new System.Web.UI.WebControls.Label();
                System.Web.UI.WebControls.Label text = new System.Web.UI.WebControls.Label();
                System.Web.UI.WebControls.Label txt = new System.Web.UI.WebControls.Label();
                DropDownList inventoryDDL = new DropDownList();
                System.Web.UI.WebControls.Label price = new System.Web.UI.WebControls.Label();
                System.Web.UI.WebControls.CheckBox cb = new System.Web.UI.WebControls.CheckBox();

                //Controllers assign

                //Title assign
                title.ID = "title" + i.ToString();
                title.Text = "<br/>" + pSelectedList[i].Title + "<br/>";

                //Images assign
                img.ID = "img" + i.ToString();
                img.ImageUrl = pSelectedList[i].ImagePath;

                //InventoryDDL assign

                List<Product> prodList = new List<Product>();
                prodList = getProductsList();

                txt.Text = "In Stock: ";
                inventoryDDL.AutoPostBack = true;
                inventoryDDL.ID = "inventoryDDL" + i.ToString();
                for (int j = 1; j <= prodList[(pSelectedList[i].ProdId)-1].Inventory; j++)
                {
                    inventoryDDL.Items.Add(j.ToString());
                }

                text.Text = "<br/>Buy:";

                //Price assign
                price.ID = "price" + i.ToString();
                price.Text = "<br/>Price:" + pSelectedList[i].Price.ToString() + "<br/><br/>";

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
                ph.Controls.Add(txt);
                ph.Controls.Add(inventoryDDL); 
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

                    DropDownList inventoryDDL = (DropDownList)ph.FindControl("inventoryDDL" + i.ToString());
                    int selected = Convert.ToInt32(inventoryDDL.Text);
                    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)ph.FindControl("cb" + i.ToString());
                    if (cb.Checked == true)
                    {
                        if (selected >= 5)
                        {
                            prod.Price = (float)(prod.Price * 0.9);
                        }
                        total = total + prod.Price * selected;
                    }
                    if (ph.FindControl("inventoryDDL" + i.ToString()) != null && cb.Checked == true)
                    {
                        if (selected >= 5)
                        {
                            MessageBox.Show("Congratulations! You deserve a 10 percent discount on this product");
                        }
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

        List<Product> newListp = new List<Product>();
        newListp = (List<Product>)(Session["pSelectedList"]);
        int i = 0;
        foreach (Product prod in newListp)
        {
            DropDownList inventoryDDL = (DropDownList)ph.FindControl("inventoryDDL" + i.ToString());
            int selected = Convert.ToInt32(inventoryDDL.Text);
            System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)ph.FindControl("cb" + i.ToString());

            if (cb.Checked == true)
            {

                Session[prod.ProdId.ToString() + "SelectedNum"] = selected;
                Session[prod.ProdId.ToString() + "TotalPrice"] = selected * prod.Price;

            }
        }

    
    Response.Redirect("Payment.aspx");
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
}