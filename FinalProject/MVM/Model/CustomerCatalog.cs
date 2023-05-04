using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Core;
/***************************************************************
* Name        : CustomerCatalog
* Author      : La Gra
* Created     : 3/30/2023
***************************************************************/
/**************************************************************
* Constructors
***************************************************************/
/**************************************************************
* Name: CustomerCatalog
* Description: Default no-arg constructor
* Input parameters: none
***************************************************************/

namespace FinalProject.MVM.Model
{
    public class CustomerCatalog
    {
        // list of customer objects
        public List<Customer> Customers { get; } = new List<Customer>();
        // singleton instance of catalog
        public static CustomerCatalog Instance { get; internal set; }
        // adds customer to the catalog
        public void AddCustomer(Customer customer)
        {
            // checks if the customer with the same ID already exists
            if (Customers.Exists(c => c.getNum() == customer.getNum()))
            {
                return; // do not add customer if it does
            }
            Customers.Add(customer);// adds customer
        }

        // remove customer from the catalog
        public void RemoveCustomer(Customer customer)
        {
            Customers.Remove(customer);
        }

        // displays all the ustomers in the catalog
        public string DisplayCustomers()
        {
            String msg = "";
            if (Customers.Count == 0)
            {
                return "No customers in existing database.";
            }
            foreach (Customer customer in Customers)
            {
                // formats the string and returns it
                msg += $"Name: {customer.getFName()} {customer.getLName()}, {customer.getPhoneNum()}, {customer.getAddress()}, {customer.getDOB()}" +
                    $", {customer.getPoints()}\n";
            }
            return msg;
        }
    }
}
