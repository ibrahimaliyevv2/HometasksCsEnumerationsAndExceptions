using System;
namespace Models
{
    public class Store
    {
        private Product[] _products = new Product[0];

        public Product[] Products { get; set; }

        public void AddProduct(Product product)
        {
            Array.Resize(ref _products, _products.Length + 1);
            _products[_products.Length - 1] = product;
        }

        public Product[] RemoveProductByNo(int no)
        {
            Product[] NewProductArr = new Product[0];
            foreach (var item in _products)
            {
                if (item.No != no)
                {
                    Array.Resize(ref NewProductArr, NewProductArr.Length + 1);
                    NewProductArr[NewProductArr.Length - 1] = item;
                }
            }
            _products = NewProductArr;
            return _products;
        }

        public Product[] FilterProductsByType(ProductType type)
        {
            Product[] filteredProducts = new Product[0];
            foreach (var item in _products)
            {
                if (item.Type==type)
                {
                    Array.Resize(ref filteredProducts, filteredProducts.Length + 1);
                    filteredProducts[filteredProducts.Length - 1] = item;
                }
            }
            return filteredProducts;
        }

        public Product[] FilterProductByName(string name)
        {
            Product[] filteredProducts = new Product[0];
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].Name.Contains(name))
                {
                    Array.Resize(ref filteredProducts, filteredProducts.Length + 1);
                    filteredProducts[filteredProducts.Length - 1] = _products[i];
                }
            }
            return filteredProducts;
        }


        public void  GetInfo()
        {
            foreach (var item in Products)
            {
                Console.WriteLine($"Mehsulun adi: {item.Name} | Mehsulun nomresi: {item.No} | Mehsulun qiymeti: {item.Price} | Mehsulun tipi: {item.Type}");
            }
        }

    }
}