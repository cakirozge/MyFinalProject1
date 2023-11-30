using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//namespace : class, interface bunları belli bir isimuzayı içinde bırakıyoruzki onlara rahat ulaşabilelim.
namespace Core.DataAccess
{
    //generic constraint -T- sınırlandırıyoruz.
    //class: referans tip.
    //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new() : newlenebilir olmalı -- IEntity parametre olarak çağırıp kullanmamızı engeller.
    public interface IEntityRepository<T> where T : class,IEntity, new() // class demek referans tip demektir, class demek değildir.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);// burası bizim filtre yazabilmemizi sağlar. örn: şu kategorideki ürünü getir, su fiyattakileri getir.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId);
    }
}
