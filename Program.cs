using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    class Program
    {
        private static Inventory inventory;        
        private static PaymentService paymentService;
        static void Main(string[] args)
        {
            Initialize();
            var runProgram = true;

            while (runProgram)
            {
                string productId;
                int quantityOrdered;
                string ccNum;

                Console.Write("Enter ProductId : ");
                productId = Console.ReadLine();                

                Console.Write("Enter quantity required : ");
                bool isQuantityValid = int.TryParse(Console.ReadLine(), out quantityOrdered);
                if (!isQuantityValid)
                {
                    Console.WriteLine("Enter a valid number");
                    continue;
                }

                Console.Write("Enter credit card number : ");
                ccNum = Console.ReadLine();
                bool isCcValid = ccNum.Length == 16 ? true : false;
                if (!isCcValid)
                {
                    Console.WriteLine("Enter a valid credit card number");
                    continue;
                }              
                
                var result = ProcessOrder(productId, quantityOrdered, ccNum);

                Console.WriteLine(result);

                Console.WriteLine("Do you want to continue (Yes\\No) ? ");
                var continueToRunProgram = Console.ReadLine();
                if(continueToRunProgram.ToLower() != "yes")
                {
                    runProgram = false;
                }
            }
        }

        private  static string ProcessOrder(string productId, int quantity, string ccNum)
        {
            bool isStockAvailable = inventory.CheckInventory(productId, quantity);           
            if (isStockAvailable)
            {
                var product = inventory.GetProduct(productId);
                var totalCost = quantity * product.UnitCost;

                bool isPaymentDone = paymentService.ChargePayment(ccNum, totalCost);

                if (isPaymentDone)
                {
                    inventory.UpdateQuantity(productId, -1 * quantity);
                    
                    return "Order processed successfully";
                }
            }
            return "Failed to process order";
        }
        static private void Initialize()
        {
            inventory = new Inventory();
            inventory = AddInventory();
            paymentService = new PaymentService();
        }

        private static Inventory AddInventory()
        {
            var inventory = new Inventory();
            var product = new ProductStock { ProductId = "1", ProductName = "abc", Quantity = 10, UnitCost=2.99M };
            inventory.Stock.Add(product);
            product = new ProductStock { ProductId = "2", ProductName = "def", Quantity = 5, UnitCost = 4.99M};
            inventory.Stock.Add(product);
            return inventory;
        }

       
    }
}
