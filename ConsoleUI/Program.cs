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
            //DTOs: Data Transformation Object
            ProductTest();
            //IoC 
            //CategortyTest();
        }

        private static void CategortyTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
    }
}


