using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitBTN_Click(object sender, EventArgs e)
    {
        string _price = Price.Text;

        string name = NameTB.Text;
        int id = Convert.ToInt32(IdTB.Text);
        double price = Convert.ToDouble(_price);
        int category = Convert.ToInt32(categoryDDL.SelectedValue);
        int inventory = Convert.ToInt32(InventoryTB.Text);

        Product product = new Product(name, id, category, price, inventory);

        string info = product.getInfo();
        outLBL.Text = info;
    }
}