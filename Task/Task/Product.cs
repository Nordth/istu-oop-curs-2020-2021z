namespace Task
{
    class Product
    {
        public string Title { get; set; }
        public double CostPerKg { get; set; }
        public double QuantityKg { get; set; }        

        public Product(string title, double costPerKg, double quantityKg)
        {
            Title = title;
            CostPerKg = costPerKg;
            QuantityKg = quantityKg;            
        }

        public Product()
        {

        }
    }
}
