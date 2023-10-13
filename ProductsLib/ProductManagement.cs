using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsLib
{
    public class ProductManagement
    {
        static List<Products> productList = new List<Products>();
       public ProductManagement()
        {
            Products product = new Products();
            product.ProdId = 101;
            product.ProdName = "Soap";
            product.ProdPrice = 30;
            product.ProdQuantity = 2;

            productList.Add(product);

            Products product2 = new Products(104, "chocolate", 45, 1);
            productList.Add(product2);

            productList.Add(new Products(105, "Five Star", 25, 2));
            productList.Add(new Products(106, "Parle G", 10, 3));
          
            productList.InsertRange(1, new List<Products> { new Products(102, "Choco Choco", 10, 1), new Products(103, "Smoodth", 20, 2) });
        }

        public List<Products> ShowProductList()
        {
            return productList;
        }
        public Products FindProductsByName(string name)
        {
            Products p1= productList.Find(pdata => pdata.ProdName == name);
            if (p1 != null)
            {
                return p1;
            }
            return null;
        }
        public Products FindProductsById(int id)
        {
            Products p= productList.Find(pdata => pdata.ProdId == id);
            if (p != null)
            {
                return p;
            }
            return null;
        }


        public int RemoveProducts(int id)
        {
            int count = productList.RemoveAll(pdata => pdata.ProdId == id);
            return count;
        }

        public void AddProduct(Products products)
        {
            productList.Add(products);
            Console.WriteLine($"Product no {products.ProdId} Added");
        }

        public void UpdateProducts(Products newproduct)
        {
            Products found = productList.Find(p => p.ProdId == newproduct.ProdId);
            found.ProdName = newproduct.ProdName;
            found.ProdPrice = newproduct.ProdPrice;
            found.ProdQuantity = newproduct.ProdQuantity;
            Console.WriteLine("Product Updated");
        }
    }
}
