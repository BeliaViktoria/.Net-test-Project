namespace EmployeestWeb;

using BLL;
using DAL;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

public static class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddBLL();
        builder.Services.AddDAL();

        builder.Services.AddDbContext<TestDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DbConnString"),
                sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: new List<int> { 4060 });
                }));


        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Authorization}/{action=Login}/{id?}");

        app.Run();
    }
}
