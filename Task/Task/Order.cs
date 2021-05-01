using System;
using System.Collections.Generic;

namespace Task
{
    class Order
    {
        public double Price { get; }
        public DateTime Date { get; set; }

        List<Dish> dishes;

        public Order(List<Dish> dishes, DateTime date)
        {
            Date = date;
            this.dishes = dishes;
            Price = 0;

            for (int i = 0; i < dishes.Count; i++)
            {
                Price += dishes[i].Price;
            }
        }

        public string GetStringDishes()
        {
            string allDishes = "";

            for (int i = 0; i < dishes.Count; i++)
            {
                allDishes += dishes[i].Title + " ";
            }

            return allDishes;
        }

        public List<Dish> GetListDishes()
        {  
            return dishes;
        }
    }
}
