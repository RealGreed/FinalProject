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
using FinalProject.MVM.ViewModel;
using FinalProject.MVM.Model;
/**************************************************************
* Name        : Final Project
* Author      : La Gra
* Created     : 3/27/2023
* Course      : CIS 152 - Data Structures
* Version     : 1.0
* OS          : Windows 10
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : The program demonstrates the use of two data structures (linked list) and (map) to mimic a database management system
* for a retail, specifically for Customers and Products
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access to
* my program.         
***************************************************************/


namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static CustomerCatalog customers = CustomerCatalog.Instance;
        public static ProductCatalog products = ProductCatalog.Instance;
        public MainWindow()
        {
            InitializeComponent();
            customers = new CustomerCatalog();
            products = new ProductCatalog();
    }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
