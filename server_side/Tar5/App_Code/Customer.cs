using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{

    int id;
    string userName;
    string password;
    string userType;

    public Customer()
    {

        //
        // TODO: Add constructor logic here
        //
    }

    public Customer(int _id,string _username,string _password,string _userType)
    {
        Id = _id;
        UserName = _username;
        Password = _password;
        UserType = _userType;
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string UserName
    {
        get
        {
            return userName;
        }

        set
        {
            userName = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public string UserType
    {
        get
        {
            return userType;
        }

        set
        {
            userType = value;
        }
    }
}