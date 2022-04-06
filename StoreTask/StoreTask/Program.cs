using System;
using Models;
namespace StoreTask
{
    class Program
    {
        static void Main(string[] args)
        {
            char answer;
            Store store1 = new Store();

            do
            {

                Console.WriteLine(" 1. Mehsul elave etmek \n 2. Mehsulun novune gore filterlemek \n 3. Mehsullarin listini goster \n 4. Secilmis mehsulu silmek \n 0. Proqrami sonlandir");
                string strAnswer = Console.ReadLine();
                answer = char.Parse(strAnswer);

                switch (answer)
                {
                    case '1':
                        string name;
                        do
                        {
                            Console.WriteLine("Mehsulun adini yazin:");
                            name = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(name));

                        string strPrice;
                        double price;
                        do
                        {
                            Console.WriteLine("Mehsulun qiymetini daxil edin:");
                            strPrice = Console.ReadLine();

                        } while (!double.TryParse(strPrice, out price));

                        Console.WriteLine("Mehsullarin asagidaki novleri movcuddur:");
                        foreach (var item in Enum.GetValues(typeof(ProductType)))
                        {
                            Console.WriteLine((int)item + ": " + item);
                        }

                        string strVal;
                        int val;
                        do
                        {
                            Console.WriteLine("Mehsulun novunu sec:");
                            strVal = Console.ReadLine();
                        } while (!int.TryParse(strVal, out val));

                        while (!Enum.IsDefined(typeof(ProductType), val))
                        {
                            Console.WriteLine("Dogru secim edin!");
                            strVal = Console.ReadLine();
                            while (!int.TryParse(strVal, out val))
                            {
                                Console.WriteLine("Yalniz reqem daxil edin!");
                                strVal = Console.ReadLine();
                            }
                        }

                        Product product = new Product();
                        product.Name = name;
                        product.Price = price;
                        product.Type = (ProductType)val;
                        store1.AddProduct(product);

                        break;

                    case '2':
                        Console.WriteLine("Mehsul novleri:");
                        foreach (var item in Enum.GetValues(typeof(ProductType)))
                        {
                            Console.WriteLine((int)item + " - " + item);
                        }

                        string strType;
                        int intType;
                        do
                        {
                            Console.WriteLine("Mehsulun novunu sec:");
                            strType = Console.ReadLine();
                        } while (!int.TryParse(strType, out intType));

                        while (!Enum.IsDefined(typeof(ProductType), intType))
                        {
                            Console.WriteLine("Dogru secim edin!");
                            strType = Console.ReadLine();
                            while (!int.TryParse(strType, out intType))
                            {
                                Console.WriteLine("Reqem daxil edin!");
                                strType = Console.ReadLine();
                            }
                        }

                        foreach (var item in store1.FilterProductsByType((ProductType)intType))
                        {
                            Console.WriteLine(item.Name);
                        }
                        break;

                    case '3':
                        store1.GetInfo();
                        break;

                    case '4':
                        int intAns;
                        string strAns;
                        do
                        {
                            Console.WriteLine("Silmek istediyiniz mehsulun nomresini daxil edin:");
                            strAns = Console.ReadLine();
                        } while (!int.TryParse(strAns, out intAns));

                        store1.RemoveProductByNo(intAns);
                        break;
                    default:
                        break;
                }
            } while (answer != '0');
        }
    }
}
