using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class Inventory : IInventory
    {
        public List<ProductStock> Stock { get; set; }

        public Inventory()
        {
            Stock = new List<ProductStock>();            
        }
        
        public ProductStock GetProduct(string productId)
        {
            return Stock.Find(x => x.ProductId == productId);
        }

        public bool CheckInventory(string productId, int quantity)
        {
            var product = Stock.Find(x => x.ProductId == productId);
            if(product.Quantity >= quantity)
            {
                return true;
            }
            return false;
        }

        public void UpdateQuantity(string productId, int quantity)
        {
            var product = Stock.Find(x => x.ProductId == productId);
            product.Quantity += quantity;            
        }
       
    }
}
