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
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime); //bakım zamanı.
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id)); //filtreleme görevi yapar.
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));    
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>
                ( _productDal.GetAll(p=>p.UnitPrice >=min && p.UnitPrice <= max));
        }
        public IDataResult<List<Product>> GetByUnitsInStock(short unitsInStock)
        {
            return new SuccessDataResult<List<Product>>
                ( _productDal.GetAll(p=> p.UnitsInStock == unitsInStock));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime); //bakım zamanı.
            //}
            return new SuccessDataResult<List<ProductDetailDto>>
                (_productDal.GetProductDetails());
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
