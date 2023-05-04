using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***************************************************************
* Name        : Product
* Author      : La Gra
* Created     : 4/07/2019
***************************************************************/
/**************************************************************
* Constructors
***************************************************************/
/**************************************************************
* Name: Product
* Description: Default no-arg constructor
* Input parameters: none
***************************************************************/

namespace FinalProject.MVM.Model
{
    public class Product
    {
        // variables (did a different approach for time)
        public int SKU { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public decimal RetailPrice { get; set; }
        public int PointValue { get; set; }

        // constructors
        public Product()
        {
            SKU = 0;
            Name = null;
            Category = null;
            Price = 0;
            RetailPrice = 0;
            PointValue = 0;
        }
        public Product(int s, string n, string c, decimal p, decimal rp, int pv)
        {
            SKU = s; Name = n; Category = c; Price = p; RetailPrice = rp; PointValue = pv;
        }
    }
}
