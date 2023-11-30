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
        List<Product> GetAll(); //ürün listesi döndürür.
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
        List<Product> GetByUnitsInStock(short unitsInStock);
        List<ProductDetailDto> GetProductDetails();
        Product GetById(int productId);

        IResult Add(Product product);  
    }
}
