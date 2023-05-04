using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinalProject.Core;
using FinalProject.MVM.Model;

namespace FinalProject.MVM.View
{
    /// <summary>
    /// Interaction logic for CustManageView.xaml
    /// </summary>
    public partial class CustManageView : UserControl
    {
        public CustManageView()
        {
            InitializeComponent();
        }

        // Event handler for when user clicks the "Add" button
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(idBox.Text, out int id)) // tries to parse the input as an int
                {
                    foreach (Customer customer in MainWindow.customers.Customers) // iterates through the list of customers
                    {
                        if (id == customer.getNum()) // if a customer already contains the id, alert the user that data already exists
                        {
                            MessageBox.Show($"Customer {id} already exists, please modify or delete before adding.");
                            return;
                        }
                    }

                    // If the code reaches here, it means that the customer does not exist, so create a new one
                    Customer temp = new Customer(); // creates a temporarily customer object
                    temp.setNum(id);
                    temp.setFName(firstNameBox.Text);
                    temp.setLName(lastNameBox.Text); // sets the value of the temp customer with the input of all the boxes
                    temp.setPhone(phoneNumBox.Text);
                    temp.setAddress(addressBox.Text);
                    temp.setDOB(birthdateBox.Text);
                    if (!string.IsNullOrEmpty(pointsBox.Text) && int.TryParse(pointsBox.Text, out int p)) // checks if points box is an int 
                    {
                        temp.setPoints(p); // adds points to the temp customer
                    }
                    MessageBox.Show($"Customer {temp.getNum()} added in the database."); 
                    MainWindow.customers.AddCustomer(temp); // alerts the user and adds the customer to the database
                }
                else
                {
                    throw new Exception("Customer ID must be a number."); // if something else other than a number is inputted
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // event handler for when the user clicks on the modify button
        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(idBox.Text, out int id)) // attempts to parse the id box
                {
                    foreach (Customer customer in MainWindow.customers.Customers) // loops through the customers list
                    {
                        if (id == customer.getNum()) // checks if the customer exists in the loop
                        {
                            if (!string.IsNullOrEmpty(firstNameBox.Text))
                            {
                                customer.setFName(firstNameBox.Text); // if a value has been put for the first name, update
                            }
                            if (!string.IsNullOrEmpty(lastNameBox.Text))
                            {
                                customer.setLName(lastNameBox.Text); // if a value has been put for the last name, update
                            }
                            if (!string.IsNullOrEmpty(phoneNumBox.Text))
                            {
                                customer.setPhone(phoneNumBox.Text); // if a value has been put for the phone num, update
                            }
                            if (!string.IsNullOrEmpty(addressBox.Text))
                            {
                                customer.setAddress(addressBox.Text); // if a value has been put for the address, update
                            }
                            if (!string.IsNullOrEmpty(birthdateBox.Text))
                            {
                                customer.setDOB(birthdateBox.Text); // if a value has been put for the birth date, update
                            }
                            if (!string.IsNullOrEmpty(pointsBox.Text) && int.TryParse(pointsBox.Text, out int p))
                            {
                                customer.setPoints(p); // if the points box contains an integer and has a value, update
                            }
                            MessageBox.Show($"Modified Customer {customer.getNum()} in the database."); // alerts the user that the customer has been modified
                            return;
                        }
                    }
                    MessageBox.Show($"Customer {id} does not exist, please add the customer before modifying."); // if the customer does not exist
                }
                else
                {
                    throw new Exception("Customer ID must be a number."); // if the user enters something other than a number in the id box
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // event handler for when user clicks the remove button
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(idBox.Text, out int id)) // tries to parse the id box into an int
                {
                    bool found = false; // placeholder variable to exit loop
                    foreach (Customer customer in MainWindow.customers.Customers) // iterates through the list
                    {
                        if (id == customer.getNum()) // if a cstomer exists with the id
                        {
                            MainWindow.customers.RemoveCustomer(customer); // removes the customer and alerts the user
                            MessageBox.Show($"Removed Customer {id} from the database.");
                            found = true; // updates found to true so the function exits
                            break;
                        }
                    }
                    if (!found)
                    {
                        MessageBox.Show($"Customer {id} does not exist in the database."); // alerts the user when the customer doesn't exist
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input for ID."); // if the id is not a number
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // event handler for when the user clicks display
        private void displayButton_Click(object sender, RoutedEventArgs e)
        {
            databaseCust.Content = MainWindow.customers.DisplayCustomers(); // sets the label box to display the contents of the customer list
        }
    }
}
