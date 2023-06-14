using AnyCompany.Model;
using System.Collections.Generic;

namespace AnyCompany
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository = new OrderRepository();

        public bool PlaceOrder(Order order, int customerId)
        {
            Customer customer = CustomerRepository.Load(customerId);

            if (order.Amount == 0)
                return false;

            if (customer.Country == "UK")
                order.VAT = 0.2d;
            else
                order.VAT = 0;
            order.CustomerID = customerId;
            orderRepository.SaveOrder(order);

            return true;
        }

        public List<Order> GetOrdersByCustomerID(int customerId)
        {
           return orderRepository.GetOrdersByCustomerID(customerId);
        }

        public List<Order> DeleteAllOrdersByCustomerID(int customerId)
        {
            return orderRepository.GetOrdersByCustomerID(customerId);
        }

        public List<CustomerOrders> getAllCustomersAndOrders()
        {
            var customers = CustomerRepository.GetAallCustomers();
            var orders = new List<CustomerOrders>();
            if (customers != null)
            {
                foreach(var cust in customers)
                {
                    orders.Add(new CustomerOrders() { 
                    CustomerID = cust.CustomerID,
                    Orders = orderRepository.GetOrdersByCustomerID(cust.CustomerID)
                    });
                }
            }
            return orders;
        }

        public bool EditOrder(Order order)
        {          
            orderRepository.UpdateOrder(order);
            return true;
        }
        public bool DeleteOrder(int orderID)
        {
            orderRepository.DeleteOrder(orderID);
            return true;
        }
    }
}
