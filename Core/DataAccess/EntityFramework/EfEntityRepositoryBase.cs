using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // bir class newlendiğinde o bellekten garbage collector belli bi zamanda düzenli olarak gelir ve bellekten onu atar.
            //using : içine yazılan nesneler using bitince anında "garbage collector'e" gelir ve anında atılır.
            //using : IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //1- eklenecek nesne
                addedEntity.State = EntityState.Added; //2- ref yakalama
                context.SaveChanges(); //3- işlemi yapma aşamasıdır.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //1- eklenecek nesne
                deletedEntity.State = EntityState.Deleted; //2- ref yakalama
                context.SaveChanges(); //3- işlemi yapma aşamasıdır.
            }
        }
        //tek data getirecek.
        //standart gördüğümüz her şeyi generic base haline getiririz.
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() //filtre null ise veritabanındaki product tüm tabloyu listeye cevir ve onu bana ver, 
                    : context.Set<TEntity>().Where(filter).ToList();//filtre null değilse yani -filtre varsa- verilen filtreyi döndür.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //1- eklenecek nesne
                updatedEntity.State = EntityState.Modified; //2- ref yakalama
                context.SaveChanges(); //3- işlemi yapma aşamasıdır.
            }
        }
    }
}
