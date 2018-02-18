namespace WpfMvvm
{
    internal class Customer
    {
        public Customer()
        {
        }

        public string Married { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }
      

        public double Tax { get; set; }
        
        public void CalculateTax()
        {
            if (Amount > 2000)
            {
                Tax= 20;
            }
            else if (Amount > 1000)
            {
                Tax= 10;
            }
            else
            {
                Tax= 5;
            }
        }
    }
}
