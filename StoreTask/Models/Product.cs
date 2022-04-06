using System;
namespace Models
{
    public class Product
    {
        public Product()
        {
            _no++;
            No = _no;
        }

        private static int _no;

        public int No { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductType Type { get; set; }
    }
}
