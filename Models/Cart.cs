using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tema2_2.Models
{
    public class Cart
    {
        public Product[] products { get; set; }
        public double TotalPrice { get; set; }
        public int Len = 0;

        public Cart()
        {
            products = new Product[100];
        }

        public void AddToCart(Product p)
        {
            //Console.WriteLine("-----Adaugare in cart!--------");
            products[Len] = new Product();
            products[Len] = p;
            Len++;
        }

        public double CalculateTotalCost()
        {
            double cost = 0;
            for(int i=0; i<Len; i++)
            {
                cost += products[i].Price;
            }
            return cost;
        }

        public String CartProducts()
        {
            //Console.WriteLine("-----Afisare PRODUSE CART!!!--------");
            if(products == null)
            {
                return "Cart is empty!";
            }

            String s = "Products:\n";
            
            for(int i=0; i<Len; i++)
            {
                s = s + products[i].Name + products[i].Price + "\n";
            }
            return s +";Total cost: "+ CalculateTotalCost();
        }
    }
}