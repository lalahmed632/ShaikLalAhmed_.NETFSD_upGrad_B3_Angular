/*Assignment
 ~~~~~~~~~~~~~~
  
 Write  a  C# program to process product details using object oriented programming.
 
•	Class should contain private variables:  productId, productName, unitPrice, qty.
•	Constructor should allow productId as parameter
•	 Create properties for all private variables.Property Names :   ProductId, ProductName, UnitPrice, Quantity
•	ProductId – should be readonly property
•	ShowDetails()  method to display all the details along with total amount.*/

using System;
using System.Linq.Expressions;

namespace Problem1
{
	class ProductDetails
	{
		private int _ProductId;	
		private	String _ProductName;
		private double _UnitPrice;
		private int _Qty;

		 public ProductDetails(int ProductId)
		{
			this._ProductId = ProductId;

		}
        public int ProductId
		{
			get {
				return this._ProductId;
			}
        }
        public String ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this._ProductName = value;
            }
        }
        public double UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this._UnitPrice = value;
            }
        }
        public int Quantity
        {
            get
            {
                return this._Qty;
            }
            set
            {
                this._Qty = value;
            }
        }
        public void ShowDetails() {
            double totl = _UnitPrice * _Qty;
            Console.WriteLine("Product Id: " + _ProductId);
            Console.WriteLine("Product Name: " + _ProductName);
            Console.WriteLine("Unit Price: " + _UnitPrice);
            Console.WriteLine("Quantity: " + _Qty);
            Console.WriteLine("Total Amount: " + totl);
        }
        static void Main(string[] args)
		{
            ProductDetails pd = new ProductDetails(2);
            pd.ProductName = "Laptop";
            pd.UnitPrice = 48000;
            Console.WriteLine("Enter qty: ");
            pd.Quantity =  Convert.ToInt32(Console.ReadLine());
            pd.ShowDetails();
            Console.ReadLine();
		}
	}
}

