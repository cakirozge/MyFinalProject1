using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; // bir iş kodu newlenemez bu nedenle injeksiyon yaparız.

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları
            return _productDal.GetAll();
           
           
        }
        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id); //filtreleme görevi yapar.
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice >=min && p.UnitPrice <= max);
        }
        public List<Product> GetByUnitsInStock(short unitsInStock)
        {
            return _productDal.GetAll(p=> p.UnitsInStock == unitsInStock);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
  

    //public interface IProductDal
    //{
    //    List<Product> GetAll();
    //}
}











//IProductDal _productDal;
//private InMemoryProductDal ınMemoryProductDal;
//private EfProductDal efProductDal;

//public ProductManager(IProductDal productDal)
//{
//    _productDal = productDal;
//}

//public ProductManager(InMemoryProductDal ınMemoryProductDal)
//{
//    this.ınMemoryProductDal = ınMemoryProductDal;
//}

//public ProductManager(EfProductDal efProductDal)
//{
//    this.efProductDal = efProductDal;
//}
