using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowProductsNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        addProducts(getProductsList());
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

            //Controllers assign

            //Title assign
            title.ID = "title" + i.ToString();
            title.Text = pList[i].Title + "<br/>";

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
                List<Product> pSelectedList = new List<Product>();
                pSelectedList.Add(pList[i]);
                Checkout_Lable.Text += "<br/>" + pList[i].Title;
            }

        }
        //Make all the controls to be invisible
        for (int i = 0; i < ph.Controls.Count; i++)
        {
            Control currentControl = ph.Controls[i];
            currentControl.Visible = false;
        }


        Checkout_Lable.Visible = true;
        SubmitBT.Visible = false;
        BackBT.Visible = true;



    }


    //Back to homepage - not required 
    protected void BackBT_Clicked(object sender, EventArgs e)
    {
        SubmitBT.Visible = true;
        BackBT.Visible = false;
        Checkout_Lable.Text = "<br/> Selected Items";
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
}
