using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

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

    private int prodId;
    public int ProdId
    {
        get { return prodId; }
        set { prodId = value; }
    }

    private int categoryId;

    public int CategoryId
    {
        get { return categoryId; }
        set { categoryId = value; }
    }

    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    private string imagePath;

    public string ImagePath
    {
        get { return imagePath; }
        set { imagePath = value; }
    }

    private float price;

    public float Price
    {
        get { return price; }
        set { price = value; }
    }

    private int inventory;

    public int Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }

    private string isActive;

    public string IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    public Product(int _categoryId, string _title, string _imagePath, float _price, int _inventory, string _isActive)
    {
        CategoryId = _categoryId;
        Title = _title;
        ImagePath = _imagePath;
        Price = _price;
        Inventory = _inventory;
        IsActive = _isActive;
    }

    public Product(int _prodId, int _categoryId, string _title, string _imagePath, float _price, int _inventory, string _isActive)
    {
        ProdId = _prodId;
        CategoryId = _categoryId;
        Title = _title;
        ImagePath = _imagePath;
        Price = _price;
        Inventory = _inventory;
        IsActive = _isActive;
    }

    public int insert()
    {
        DBServices dbs = new DBServices();
        int prod = dbs.insert(this);
        return prod;

    }

    public DataTable read()
    {
        // read it using the DAL layer (DBServices)
        DBServices dbs = new DBServices();
        DataSet ds = new DataSet();
        ds = dbs.ReadFromDataBase("igroup82_test1ConnectionString", "ProductN");
        // return the DataTable
        return ds.Tables[0];
    }
}