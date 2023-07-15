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

            // ����� ���� ����� ��������  
            builder.Services.AddDbContext<AutoPartsStoreContext>(options =>
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Car2;");
            });

            // ����� ������ ���������� ������ 
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

            // ����� �������� �������� ������� �������
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
