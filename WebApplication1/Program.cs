using AutoPartsStore; 
using Microsoft.EntityFrameworkCore; 
namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

       
            builder.Services.AddControllers();

            // ≈⁄œ«œ Œœ„… ﬁ«⁄œ… «·»Ì«‰«   
            builder.Services.AddDbContext<AutoPartsStoreContext>(options =>
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Car2;");
            });

            //  ”ÃÌ· Ê«ÃÂ«  «·„” Êœ⁄«  ﬂŒœ„«  
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IPartRepository, PartRepository>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();

            }

            // ≈⁄œ«œ «·Ê”Ìÿ«  «·√”«”Ì… ··ÿ·»«  «·Ê«—œ…
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
