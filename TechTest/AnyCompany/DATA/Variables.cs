using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
    internal class Variables
    {
        #region Customer
        public static readonly string GetCustomer = "SELECT * FROM Orders WHERE CustomerId = ";
        public static readonly string CreateCustomer = "INSERT INTO Customer VALUES (@CustomerID, @Country, @DateOfBirth,@Name)";
        public static readonly string UpdateCustomer = "Update Customer set Countr = @Country,DateOfBirth = @DateOfBirth,Name = @Name * FROM Customer";
    
        //Delete all orders that are linked to the customer then the customer row
        public static readonly string DeleteCustomer = "DELETE Customer , Orders  FROM Customer  INNER JOIN Orders WHERE Customer.CustomerID= Orders.CustomerID and Customer.CustomerID = @CustomerID";

        public static readonly string GetAllCustomers = "SELECT * FROM Customer";
        public static readonly string GetCustopmerByID = "SELECT * FROM Customer WHERE CustomerId = ";
        #endregion

        #region Orders
        public static readonly string InsertNewOrder = "INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT,@CustomerID)";
        public static readonly string GetOrder = "SELECT * FROM Orders WHERE CustomerId = ";
        public static readonly string GetAllOrders = "SELECT * FROM Orders";
        public static readonly string UpdateNewOrder = "Update Orders   set Amount = @Amount,VAT = @VAT)";
        public static readonly string DeleteOrder = "DELETE from Orders where OrderId = @OrderId";

        //deletes all orders linked to a customer
        public static readonly string DeleteOrderByCustomerID = "DELETE from Orders where @CustomerID";
        //all orders from the customer by their customer id
        public static readonly string GetOrdersByCustomerID = "SELECT * FROM Orders WHERE CustomerId = ";
        #endregion
    }
}
