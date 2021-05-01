using System.Collections.Generic;

namespace Task
{
    class Dish
    {
        public string Title { get; set; }        
        public double Price { get; }

        List<Product> products;

        public Dish(string title, List<Product> products)
        {
            Title = title;
            this.products = products;
            Price = 0;

            for (int i = 0; i < products.Count; i++)
            {
                Price += products[i].QuantityKg * products[i].CostPerKg;
            }

            Price *= 1.3; //маржа
        }

        public List<Product> GetListProducts()
        {
            return products;
        }
    }
}
