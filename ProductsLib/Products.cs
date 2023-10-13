using System;

namespace ProductsLib
{
    public class Products
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public float ProdPrice { get; set; }
        public float ProdQuantity { get; set; }

        public Products() { }    
        public Products(int id,string name,float rate,float qty) 
        {
            ProdId = id;
            ProdName = name;
            ProdPrice = rate;
            ProdQuantity = qty;
        }

    }
}
