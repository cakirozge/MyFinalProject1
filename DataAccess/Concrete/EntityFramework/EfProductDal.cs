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
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // bir class newlendiğinde o bellekten garbage collector belli bi zamanda düzenli olarak gelir ve bellekten onu atar.
            //using : içine yazılan nesneler using bitince anında "garbage collector'e" gelir ve anında atılır.
            //using : IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //1- eklenecek nesne
                addedEntity.State = EntityState.Added; //2- ref yakalama
                context.SaveChanges(); //3- işlemi yapma aşamasıdır.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //1- eklenecek nesne
                deletedEntity.State = EntityState.Deleted; //2- ref yakalama
                context.SaveChanges(); //3- işlemi yapma aşamasıdır.
            }
        }
        //tek data getirecek.
        //standart gördüğümüz her şeyi generic base haline getiririz.
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter==null 
                    ? context.Set<Product>().ToList() //filtre null ise veritabanındaki product tüm tabloyu listeye cevir ve onu bana ver, 
                    : context.Set<Product>().Where(filter).ToList() ;//filtre null değilse yani -filtre varsa- verilen filtreyi döndür.
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //1- eklenecek nesne
                updatedEntity.State = EntityState.Modified; //2- ref yakalama
                context.SaveChanges(); //3- işlemi yapma aşamasıdır.
            }
        }
    }
}
