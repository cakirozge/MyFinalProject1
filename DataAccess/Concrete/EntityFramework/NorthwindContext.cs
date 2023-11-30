using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //context : demek veriğtabanı ile kendi classlarımızı "entities" ilişkilendirmek demektir.
    //context : db tabloları ile proje classlarını bağlamak.
    public class NorthwindContext:DbContext //DbContext: bizim contextimizin kendisidir.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // hangi veritabanıyla ilişkili belirttiğimiz yer.
        {
            //Trusted_Connection=true : kullanıcı adı ve şifresi olmadan bağlanabilmemizi sağlar.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true"); //@ koyduğumuzda normal / algılatır.
        }
        public DbSet<Product> Products { get; set; } //DbSet: nesnedir. -- hangi nesnemiz hangi nesneye geleceksebunu "DbSet" ile sağlarız. hangi classım hangi tabloya karsılık geliyor.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

}

