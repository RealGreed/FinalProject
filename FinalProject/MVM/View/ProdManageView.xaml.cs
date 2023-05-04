using FinalProject.MVM.Model;
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

namespace FinalProject.MVM.View
{
    /// <summary>
    /// Interaction logic for ProdManageView.xaml
    /// </summary>
    public partial class ProdManageView : UserControl
    {
        public ProdManageView()
        {
            InitializeComponent();
        }

        // event handler for add button
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(skuBox.Text)) // checks if the box is empty
            {
                MessageBox.Show("Please enter a valid SKU.");
                return;
            }

            if (int.TryParse(skuBox.Text, out int sku)) // attempts to parse the text into an int value
            {
                try
                {
                    // sets the variables to the value the user input in each box
                    string name = productBox.Text;
                    string category = categoryBox.Text;
                    decimal.TryParse(priceBox.Text, out decimal price);
                    decimal.TryParse(retailPriceBox.Text, out decimal retail);
                    int.TryParse(pointValueBox.Text, out int points);

                    Product newProduct = new Product(sku, name, category, price, retail, points);
                    MainWindow.products.AddProduct(newProduct); // creates a temp product value and adds it to the map

                    MessageBox.Show($"Product {sku}: {name} added successfully!"); // alerts the user that the product has been added to the database
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid SKU."); // prompts user to enter a number
            }
        }

        // event hanlder for the modify button
        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(skuBox.Text, out int sku)) // attempts to parse the sku into an int
            {
                // Check if product with the specified SKU exists
                Product product = MainWindow.products.GetProductById(sku); // gets the product with the sku from the user
                if (product == null)
                {
                    MessageBox.Show($"Product with SKU {sku} does not exist.");
                    return; // alerts user that the product does not exist
                }

                // Modify product properties
                if (!string.IsNullOrEmpty(productBox.Text))
                {
                    product.Name = productBox.Text; // if product box is not empty, update
                }

                if (!string.IsNullOrEmpty(categoryBox.Text))
                {
                    product.Category = categoryBox.Text; // if category box is not empty, update
                }

                if (decimal.TryParse(priceBox.Text, out decimal price))
                {
                    product.Price = price; // if price is not empty, update
                }

                if (decimal.TryParse(retailPriceBox.Text, out decimal retail))
                {
                    product.RetailPrice = retail; // if retail price is not empty, update
                }

                if (int.TryParse(pointValueBox.Text, out int points))
                {
                    product.PointValue = points; // if the point value is not empty, update
                }

                MainWindow.products.UpdateProduct(product); // updates the product with the new variables
                MessageBox.Show($"Product {sku} modified successfully."); // alerts the user that product was modified successful
            }
            else
            {
                MessageBox.Show("SKU must be a number."); // if user didn't enter number
            }
        }

        // event handler for remove button
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(skuBox.Text, out int sku))
            {
                // Check if product with the specified SKU exists
                Product product = MainWindow.products.GetProductById(sku); // gets the product and assigns it to product
                if (product == null)
                {
                    MessageBox.Show($"Product with SKU {sku} does not exist.");
                    return; // if product does not exist, alerts user
                }

                // Remove product from product catalog
                MainWindow.products.RemoveProduct(sku); // calls the removeProduct function to remove the product
                MessageBox.Show($"Product {sku} removed successfully."); // alerts the user that it has been removed
            }
            else
            {
                MessageBox.Show("SKU must be a number."); // tells user to enter a number
            }
        }

        // display button handler
        private void displayButton_Click(object sender, RoutedEventArgs e)
        {
            // uses the DisplayProducts function of the productcatalog class to output to the label box the products in the map
            databaseProd.Content = MainWindow.products.DisplayProducts();
        }
    }
}
