using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{

    private string name;

    public Category()
    {
        //
        // TODO: Add constructor logic here
        //

    }


    public Category(string _name)
    {

        Name = _name;

    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }


    public int Insert()
       
    {
        DBServices dbs = new DBServices();
        int numEffected = dbs.insert(this.name);
        return numEffected;
    }


}