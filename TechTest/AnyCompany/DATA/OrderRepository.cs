using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System;
using AnyCompany.Model;

namespace AnyCompany
{
    internal class OrderRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["CustomerOrders"].ConnectionString;
       
        public Order GetOrder(int orderID)
        {
            Order order = new Order();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Variables.GetOrder + orderID, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    order.OrderId = Int32.Parse(reader["Name"].ToString());
                    order.LastTransactionDate = DateTime.Parse(reader["LastTransactionDate"].ToString());
                    order.VAT = Double.Parse(reader["Country"].ToString());
                    order.Amount = Double.Parse(reader["Country"].ToString());
                }

            }

            return order;
        }
       
        public void SaveOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Variables.InsertNewOrder, connection);

                command.Parameters.AddWithValue("@OrderId", order.OrderId);
                command.Parameters.AddWithValue("@CustomerID", order.VAT);
                command.Parameters.AddWithValue("@LastTransactionDate", DateTime.Now);              
                command.Parameters.AddWithValue("@Amount", order.Amount);
                command.Parameters.AddWithValue("@VAT", order.VAT);
                
                command.ExecuteNonQuery();
            }
        }
        public void UpdateOrder(Order order)
        {
            var oldRecold = GetOrder(order.OrderId);
            if (oldRecold != order)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand(Variables.UpdateCustomer, connection);

                    command.Parameters.AddWithValue("@CustomerID", order.VAT);
                    command.Parameters.AddWithValue("@Amount", order.Amount);
                    command.Parameters.AddWithValue("@LastTransactionDate", DateTime.Now);
                    command.Parameters.AddWithValue("@VAT", order.VAT);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int orderID)
        {
          
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand(Variables.DeleteOrder, connection);

                    command.Parameters.AddWithValue("@OrderID", orderID);               

                    command.ExecuteNonQuery();
                }
         }


        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Variables.GetAllOrders, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new Order()
                    {
                        OrderId = Int32.Parse(reader["OrderId"].ToString()),
                        Amount = Double.Parse(reader["Amount"].ToString()),
                        VAT = Double.Parse(reader["VAT"].ToString()),
                        CustomerID = Int32.Parse(reader["CustomerID"].ToString()),
                        LastTransactionDate = DateTime.Parse(reader["LastTransactionDate"].ToString())
                    });
                }

            }

            return orders;
        }
        public   List<Order> GetOrdersByCustomerID(int customerID)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Variables.GetOrdersByCustomerID + customerID, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new Order()
                    {
                        OrderId = Int32.Parse(reader["OrderId"].ToString()),
                        Amount = Double.Parse(reader["Amount"].ToString()),
                        VAT = Double.Parse(reader["VAT"].ToString()),
                        CustomerID = Int32.Parse(reader["CustomerID"].ToString()),
                        LastTransactionDate = DateTime.Parse(reader["LastTransactionDate"].ToString())
                });
                }

            }

            return orders;
        }
        public void DeleteOrdersByCustomerID(int customerID)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Variables.DeleteOrderByCustomerID + customerID, connection);               
            }           
        }
    }
}
