using Microsoft.EntityFrameworkCore;
using parcial1.Data;

namespace parcial1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar servicios al contenedor.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configurar el pipeline de manejo de solicitudes.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Ruta por defecto
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Faculties}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
