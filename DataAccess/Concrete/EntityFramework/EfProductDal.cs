using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet : baskalarıyla ortak kullandığımız ortam
    public class EfProductDal :EfEntityRepositoryBase<Product, NorthwindContext>,IProductDal
    {
        
    }
}
