using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***************************************************************
* Name        : ProductCatalog
* Author      : La Gra
* Created     : 4/07/2023
***************************************************************/
/**************************************************************
* Constructors
***************************************************************/
/**************************************************************
* Name: ProductCatalog
* Description: Default no-arg constructor
* Input parameters: none
***************************************************************/

namespace FinalProject.MVM.Model
{
    public class ProductCatalog
    {
        // use dictionary because C# does not suppot map (it has relatively the same function)
        private Dictionary<int, Product> _products = new Dictionary<int, Product>();

        // singleton instance of productcatalog
        public static ProductCatalog Instance { get; internal set; }

        public void AddProduct(Product product)
        {
            // checks if the product already exists with the sku as the key
            if (_products.ContainsKey(product.SKU))
            {
                throw new ArgumentException($"Product with SKU {product.SKU} already exists.");
            }
            // adds the product to the dictionary with SKU as the key
            _products.Add(product.SKU, product);
        }

        public bool RemoveProduct(int sku)
        {
            return _products.Remove(sku); // removes the product with the specified SKU
        }

        public Product GetProductById(int sku)
        {
            if (_products.TryGetValue(sku, out Product product)) // try to get the value by SKU key
            {
                return product;
            }

            return null; // returns null if the product is not found
        }

        public void UpdateProduct(Product product)
        {
            // checks if the product already exists using sku as the key
            if (!_products.ContainsKey(product.SKU))
            {
                throw new ArgumentException($"Product with SKU {product.SKU} does not exist.");
            }
            // update the product informatoin with the sku as the key
            _products[product.SKU] = product;
        }

        public string DisplayProducts()
        {
            // Unique way of appending strings together for the output
            StringBuilder sb = new StringBuilder();

            if (_products.Count == 0)
            {
                return "No products in existing catalog.";
            }

            foreach (var product in _products.Values) // loops through and appends to the string
            {
                sb.Append($"SKU: {product.SKU}, Name: {product.Name}, Category: {product.Category}, Price: {product.Price.ToString("C2")}, RPrice: {product.RetailPrice.ToString("C2")}, Point: {product.PointValue}\n");
            }

            return sb.ToString();
        }

    }
}
