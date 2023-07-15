using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AutoPartsStore
{
    public class AutoPartsStoreContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }

        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Car2;";

        public AutoPartsStoreContext( DbContextOptions<AutoPartsStoreContext> options):base(options)
        {
            
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // تعيين سلسلة الاتصال بقاعدة البيانات
                
                optionsBuilder.UseSqlServer(connectionString);
            }
            
        }
        public void ConfigureServices(IServiceCollection services)
        {  

            // تسجيل طبقات الوصول إلى البيانات
            services.AddScoped<CarRepository>();
            services.AddScoped<PartRepository>();
            services.AddScoped<SupplierRepository>();

  
            services.AddControllers();
        }


    }
}
