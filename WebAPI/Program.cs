using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Autofac = AOP imkanı verir.
//Autofac, Ninject, CastleWindsor, StructereMap, LightInject, DryInject --IoC Container
//AOP --> [LogAspect]
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductManager>(); //.net7 için startup.cs 
builder.Services.AddSingleton<IProductDal,EfProductDal>();  //.net7 için startup.cs 



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
