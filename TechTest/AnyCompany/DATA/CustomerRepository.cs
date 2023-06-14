using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["CustomerOrders"].ConnectionString;

        public static Customer Load(int customerId)
        {
            Customer customer = new Customer();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            { 
                connection.Open();

            SqlCommand command = new SqlCommand(Variables.GetCustopmerByID + customerId, connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                customer.Name = reader["Name"].ToString();
                customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                customer.Country = reader["Country"].ToString();
            }

        }
            return customer;
        }
        public static void UpdateCustomer(Customer customer)
        {
            var oldRecold = Load(customer.CustomerID);
            if (oldRecold != customer)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand(Variables.UpdateCustomer + customer.CustomerID, connection);
                   
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    command.Parameters.AddWithValue("@VAT", customer.Country);

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteCustomer(int customerID)
        {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand(Variables.DeleteCustomer, connection);

                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    command.ExecuteNonQuery();
                }
        }

        public static List<Customer> GetAallCustomers ()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Variables.GetAllCustomers, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                    {
                        customers.Add(new Customer() { 
                            CustomerID = Int32.Parse(reader["CustomerID"].ToString()),
                            Name = reader["Name"].ToString(),
                            DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                            Country = reader["Country"].ToString(),
                    });
                }

            }

            return customers;
        }

    }
}
