using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
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

        public IResult Add(Product product) //void: özel bir tip döndürmez.
        {
            //business codes 


            if (product.ProductName.Length < 2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll() //List döndürür
        {
            //iş kodları
            if (DateTime.Now.Hour ==22)
            {
                return new ErrorDataResult();
            }





            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), true, "Ürünler listelendi.");
           
           
        }
        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id); //filtreleme görevi yapar.
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId == productId);    
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


    //WEB API (Restful-  JSON) farklı client ile çalışmamızı sağlar.
    //Request - Response
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
