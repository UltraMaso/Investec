using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Service
{
    public class CustomerService
    {
        public Customer GetCustomer(int customerID) 
        {
            return  CustomerRepository.Load(customerID);
        }
        public void UpdateCustomer(Customer customer)
        {
             CustomerRepository.UpdateCustomer(customer);
        }
        public void DeleteCustomer(int CustomerID)
        {
            CustomerRepository.DeleteCustomer(CustomerID);
        }
        public List<Customer> GetAllCustomers(string customerID)
        {
            return CustomerRepository.GetAallCustomers();
        }
    }
}
