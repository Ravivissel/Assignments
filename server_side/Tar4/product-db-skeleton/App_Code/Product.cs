using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
	public Product()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int categoryId;
    private string title;
    private string imagePath;
    private double price;
    private int inventory;

    public int CategoryId
    {
        get { return categoryId; }
        set { categoryId = value; }
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string ImagePath
    {
        get { return imagePath; }
        set { imagePath = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public int Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }

    public Product(int _categoryId, string _title, string _imagePath, double _price, int _inventory)
    {
        CategoryId = _categoryId;
        Title = _title;
        ImagePath = _imagePath;
        Price = _price;
        Inventory = _inventory;
    }

    public int insert()
    {
        DBServices dbs = new DBServices();
        int numAffected = dbs.insert(this);
        return numAffected;
    }
}