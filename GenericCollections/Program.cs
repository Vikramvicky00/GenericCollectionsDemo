using ProductsLib;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO.Pipes;
using System.Linq.Expressions;

namespace GenericCollections
{
    internal class Program
    {

        public static ProductManagement pm=new ProductManagement();
        private static void showList()
        {

            Console.WriteLine("The employee list");
            List<Products> prodList = new List<Products>();
            prodList = pm.ShowProductList();
            foreach (var item in prodList)
            {
                Console.WriteLine(item.ProdId);
                Console.WriteLine(item.ProdName);
                Console.WriteLine(item.ProdPrice);
                Console.WriteLine(item.ProdQuantity);
                Console.WriteLine("----------");
            }
        }
        private static void FoundDisplay(Products found)
        {
            if (found == null)
            {
                Console.WriteLine("Product Not Found");
            }
            else
            {
                Console.WriteLine("Product Found");
                Console.WriteLine(found.ProdId);
                Console.WriteLine(found.ProdName);
                Console.WriteLine(found.ProdPrice);
                Console.WriteLine(found.ProdQuantity);
                Console.WriteLine("----------");
            }
        }



        static void Main(string[] args)
        {
            string ot = null;
            do 
            { 
                Console.WriteLine("Menu For Products :");
                Console.WriteLine(" 1. Display Products \n 2. Add Product \n 3. Update Product \n 4. Delete Product \n 5. Find Product \n 6. Exit");
                Console.WriteLine("Enter Your Choice :");
                int ch=Convert.ToInt32(Console.ReadLine());
            
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Displaying Products");
                        showList();
                        break;
                    case 2:
                        Console.WriteLine("Adding Product");
                        Products p = new Products();
                        Console.WriteLine("Enter Product Id");
                        p.ProdId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Product Name");
                        p.ProdName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter Product Price");
                        p.ProdPrice = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Enter Product Quantity");
                        p.ProdQuantity = Convert.ToSingle(Console.ReadLine());
                        pm.AddProduct(p);
                        Console.WriteLine("Showing the added product");
                        showList();
                        break;
                    case 3:
                        Console.WriteLine("Update Product Menu");
                        Products p1 = new Products();
                        Console.WriteLine("Enter Product Id");
                        p1.ProdId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Product Name");
                        p1.ProdName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter Product Price");
                        p1.ProdPrice = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Enter Product Quantity");
                        p1.ProdQuantity = Convert.ToSingle(Console.ReadLine());
                        pm.UpdateProducts(p1);
                        break;
                    case 4:
                        Console.WriteLine("Delete Product");
                        Console.WriteLine("Enter Product Id");
                        int id = Convert.ToInt32(Console.ReadLine());
                        int c = pm.RemoveProducts(id);
                        Console.WriteLine($"{c} products removed .");
                        break;
                    case 5:
                        Console.WriteLine("Finding Products:");
                        Console.WriteLine(" 1. Find by Product Name \n 2. Find by Product ID");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        if (opt == 1)
                        {
                            Console.WriteLine("You choose Find By Product Name");
                            Console.WriteLine("Enter Product Name :");
                            string name = Console.ReadLine();
                            Products f2 = pm.FindProductsByName(name);
                            FoundDisplay(f2);
                        }
                        else if (opt == 2)
                        {
                            Console.WriteLine("You choose Find By Product ID");
                            Console.WriteLine("Enter Product ID : ");
                            int id1 = Convert.ToInt32(Console.ReadLine());
                            Products f1 = pm.FindProductsById(id1);
                            FoundDisplay(f1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option");
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Do You want to do it again..");
                ot = Console.ReadLine();
            } while (ot == "Yes" || ot == "yes");
            Console.ReadLine();
        }
    }
}
