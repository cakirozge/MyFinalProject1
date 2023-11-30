using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //her zaman veritabanı tablosunun interface yoksa bile oluştur.
    public interface IProductDal:IEntityRepository<Product> //product için yapılandırdım.
    {
           
    }
}

//code refactoring
