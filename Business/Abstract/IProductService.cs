using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    //interface service olarak isimlendirirz.
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //ürün listesi döndürür.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<Product>> GetByUnitsInStock(short unitsInStock);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);

        IResult Add(Product product);  
    }
}
