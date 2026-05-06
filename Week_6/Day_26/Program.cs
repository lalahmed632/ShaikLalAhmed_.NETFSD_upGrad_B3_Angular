using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            ProductDataAccess dal = new ProductDataAccess();


            while (true)
            {
                Console.WriteLine("\n---- PRODUCT MANAGEMENT----- ");
                Console.WriteLine("1. Insert Product");
                Console.WriteLine("2. View All Products"); 
                Console.WriteLine("3. Get Product By Id");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Product p = new Product();

                        Console.Write("Enter Product Name: ");
                        p.ProductName = Console.ReadLine();

                        Console.Write("Enter Category: ");
                        p.Category = Console.ReadLine();

                        Console.Write("Enter Price: ");
                        p.Price = decimal.Parse(Console.ReadLine());

                        dal.InsertProduct(p);
                        break;

                    case 2:
                        Console.WriteLine("\n--- Product List ---");
                        dal.GetAllProducts();
                        break;

                    case 3:
                        Console.Write("Enter Product Id: ");
                        int pid = int.Parse(Console.ReadLine());
                        dal.GetProductById(pid);
                        break;

                    case 4:
                        Product up = new Product();

                        Console.Write("Enter Product Id: ");
                        up.ProductId = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Name: ");
                        up.ProductName = Console.ReadLine();

                        Console.Write("Enter New Category: ");
                        up.Category = Console.ReadLine();

                        Console.Write("Enter New Price: ");
                        up.Price = decimal.Parse(Console.ReadLine());

                        dal.UpdateProduct(up);
                        break;

                    case 5:
                        Console.Write("Enter Product Id to delete: ");
                        int id = int.Parse(Console.ReadLine());

                        dal.DeleteProduct(id);
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }

}
