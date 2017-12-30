using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Sale
/// </summary>
public class Sale
{
    private int productId;
    private Double totalPrice;
    private int quantity;
    private int customerId;
    private DateTime date;
    private int paymentType;


    public Sale()
    {
    }

    public Sale(int _product, Double _totalPrice, int _quantity, int _customerId, DateTime _date, int _paymentType)
    {
        ProductId = _product;
        TotalPrice = _totalPrice;
        Quantity = _quantity;
        CustomerId = _customerId;
        Date = _date;
        PaymentType = _paymentType;

    }

    public int ProductId
    {
        get
        {
            return productId;
        }

        set
        {
            productId = value;
        }
    }

    public Double TotalPrice
    {
        get
        {
            return totalPrice;
        }

        set
        {
            totalPrice = value;
        }
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }

        set
        {
            quantity = value;
        }
    }

    public int CustomerId
    {
        get
        {
            return customerId;
        }

        set
        {
            customerId = value;
        }
    }

    public DateTime Date
    {
        get
        {
            return date;
        }

        set
        {
            date = value;
        }
    }

    public int PaymentType
    {
        get
        {
            return paymentType;
        }

        set
        {
            paymentType = value;
        }
    }
}