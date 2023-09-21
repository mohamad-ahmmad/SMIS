using BL;
using Common;
using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
   
    static class Executor
    {
        //Configuration
        private static InventoryService _inventoryService = new InventoryService(new DocumentProductRepository("mongodb://localhost:27017"));

        public static void Execute(string command)
        {
            string[] args = command.Split(" ");

            switch (args[0])
            {
                case "exit":
                    Environment.Exit(0);
                    break;
                case "add": AddProductCommand(args);
                    break;
                case "view": ViewAllProducts();
                    break;
                case "edit": EditProduct(args);
                    break;
                case "delete": DeleteProduct(args[1]);
                    break;
                case "search": SearchWithProductName(args);
                    break;
            } 
        }
        public static void SearchWithProductName(string[] args)
        {
            string productName= args[1];
            Product? res = _inventoryService.Search(productName);
            if (res == null)
                Console.WriteLine($"There's no product with \"{productName}\" name.");
            else
                Logger.LogToConsole(res);
        }
        public static void DeleteProduct(string productName) {
            Product? res =_inventoryService.DeleteProduct(productName);
            if (res is not null)
                Console.WriteLine("Deleted Successfully.");
            else
                Console.WriteLine($"There's no product with the specified \"{res.Name}\" product.");
        }
        public static void ViewAllProducts()
        {
            foreach(Product product in _inventoryService.GetAllProducts())
                Logger.LogToConsole(product);
        }
        public static void EditProduct(string[] args)
        {
            (string productToUpdate, string newProductName, decimal price, int quantity) 
                = (args[1], args[2], decimal.Parse(args[3]), int.Parse(args[4]));

            Product p = new Product()
            {
                Name = newProductName,
                Price = price,
                Quantity = quantity
            };
            
            Product? res =_inventoryService.EditProduct(productToUpdate, p);

            if (res is not null)
                Console.WriteLine("Updated Successfully.");
            else
                Console.WriteLine($"The item with {productToUpdate} name is not in the inventory or the new name is already taken.");
        }
        public static void AddProductCommand(string[] args)
        {
            Product product = new Product()
            {
                Name = args[1],
                Price = decimal.Parse(args[2]),
                Quantity = int.Parse(args[3])
            };
            bool res = _inventoryService.AddProduct(product);
            if (res)
                Console.WriteLine("Added Successfully");
            else
                Console.WriteLine("The Product is already in the inventory !!");
        }
    }
}
