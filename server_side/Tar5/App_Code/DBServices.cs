using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for DBServices
/// </summary>
public class DBServices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }
 
    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //---------------------------------------------------------------------------------
    // update the dataset into the database
    //---------------------------------------------------------------------------------
    public void Update(DataTable dt)
    {
        // the command build will automatically create insert/update/delete commands according to the select command
        SqlCommandBuilder builder = new SqlCommandBuilder(da);
        da.Update(dt);
    }

    //--------------------------------------------------------------------
    // Read from the DB into a table
    //--------------------------------------------------------------------
    public DataSet ReadFromDataBase(string conString, string tableName)
    {

        DBServices dbS = new DBServices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            String selectStr = "SELECT * FROM " + tableName; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            return ds;

        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

    //--------------------------------------------------------------------
    // create the Insert command for Categroy
    //--------------------------------------------------------------------
    public int insert(string category)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("igroup82_test1ConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String mStr = BuildInsertCommandProduct(category);      // helper method to build the insert string
        cmd = CreateCommand(mStr, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String for Categroy
    //--------------------------------------------------------------------
    private String BuildInsertCommandProduct(string category)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}')", category);
        String prefix = "INSERT INTO Category " + "(Name)";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------
    // create the Insert command for Product
    //--------------------------------------------------------------------
    public int insert(Product prod)
    {
        SqlConnection con;
        SqlCommand cmd;
        //SqlCommand cmd1;

        try
        {
            con = connect("igroup82_test1ConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String mStr = BuildInsertCommandProduct(prod);      // helper method to build the insert string
        //String mStr1 = BuildUpdateCommandProduct(prod);
        cmd = CreateCommand(mStr, con);
        //cmd1 = CreateCommand(mStr1, con);// create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            //int numEffected1 = cmd1.ExecuteNonQuery();// execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }



    //--------------------------------------------------------------------
    // create the Insert command for Product
    //--------------------------------------------------------------------
    public int insert(Sale sale)
    {
        SqlConnection con;
        SqlCommand cmd;
        //SqlCommand cmd1;

        try
        {
            con = connect("igroup82_test1ConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String mStr = BuildInsertCommandProduct(sale);      // helper method to build the insert string
        //String mStr1 = BuildUpdateCommandProduct(prod);
        cmd = CreateCommand(mStr, con);
        //cmd1 = CreateCommand(mStr1, con);// create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            //int numEffected1 = cmd1.ExecuteNonQuery();// execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String for prod
    //--------------------------------------------------------------------
    private String BuildInsertCommandProduct(Product prod)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}')", prod.Title, prod.ImagePath, prod.Price, prod.Inventory, prod.IsActive, prod.CategoryId);
        String prefix = "INSERT INTO ProductN " + "(Name, imgUrl, Price, Inventory, isActive, catID)";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------
    // Build the Insert command String for prod
    //--------------------------------------------------------------------
    private String BuildInsertCommandProduct(Sale sale)
    {   //prodID	QTY	custID	DATE	lineTotal	paymentType
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}')", sale.CustomerId, sale.Quantity, sale.CustomerId, sale.Date, sale.PaymentType);
        String prefix = "INSERT INTO sales " + "(prodID, QTY, custID, DATE, paymentType)";
        command = prefix + sb.ToString();

        return command;
    }
}