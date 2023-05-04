using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Core;

namespace FinalProject.MVM.Model
{
    class CustomerCatalog
    {
        private class Node
        {
            public Customer customer;
            public Node next;

            public Node(Customer customer)
            {
                this.customer = customer;
                next = null;
            }
        }
        private Node head;

        public CustomerCatalog()
        {
            head = null;
        }

        public void AddCustomer(int cNum, string fName, string lName, string pNum, string add, string DOB, int p)
        {
            Customer newCustomer = new Customer(cNum, fName, lName, pNum, add, DOB, p);
            Node newNode = new Node(newCustomer);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
        }

        public void RemoveCustomer(int custID)
        {
            if (head == null)
            {
                Console.WriteLine("No customers in the list.");
                return;
            }
            if (head.customer.getID() == custID)
            {
                Node temp = head;
                head = head.next;
                return;
            }
            Node current = head;
            while (current.next != null && current.next.customer.getID() != custID)
            {
                current = current.next;
            }
            if (current.next == null)
            {
                Console.WriteLine($"Customer {custID} not found.");
                return;
            }
            current.next = current.next.next;
        }


        public void DisplayCustomers()
        {
            if (head == null)
            {
                Console.WriteLine("No customers in the list.");
                return;
            }
            Node current = head;
            while (current != null)
            {
                Console.WriteLine($"Name: {current.customer.getFName()} {current.customer.getLName()}, Phone Number: {current.customer.getPhoneNum()}, Address: {current.customer.getAddress()}, Date of Birth: {current.customer.getDOB()}");
                current = current.next;
            }
        }
    }
}
