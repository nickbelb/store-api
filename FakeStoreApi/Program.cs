using BLL;
using DAL;
using DAL.UOW;
using Entities.Context;
using Entities.Entities;

namespace FakeStoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Context 
            builder.Services.AddScoped<IFakeStoreApiContext, FakeStoreApiContext>();

            

            //unit of work
            builder.Services.AddScoped<IUnitOfWork<Product>, UnitOfWorks<Product>>();
            builder.Services.AddScoped<IUnitOfWork<Category>,UnitOfWorks<Category>>();

            //Product service and repository

            builder.Services.AddScoped<IProductRepository,ProductRepository>();
            builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
            builder.Services.AddScoped<IProductService, ProductService>();

            //Category Service and repository

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name:"AllowLocalhost",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("AllowLocalhost3000");


            app.MapControllers();

            app.Run();
        }
    }
}
