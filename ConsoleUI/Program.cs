
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //O : Open Closed Principle - mevcut koda(iş kodları hariç) yeni bir özellik ekliyorsak mevcut koda hiçbir şekilde dokunamazsın.
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitsInStock(15))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}


