using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using UI.ToDoList.Startup;

namespace UI.ToDoList
{
    public class Program
    {
        private static WebApplicationBuilder _builder;
        private static WebApplication _app;

        public static void Main(string[] args)
        {
            _builder = WebApplication.CreateBuilder(args);
            ConfigureServices();

            _app = _builder.Build();
            ConfigureApplication();

            _app.Run();
        }

        private static void ConfigureServices()
        {
            //_builder.Services.AddSeriLog(_builder);

            //_builder.Services.AddOptions<EcoConfigOptions>()
            //    .Bind(_builder.Configuration.GetSection(EcoConfigOptions.EcoConfig))
            //    .ValidateDataAnnotations();

            //_builder.Services.AddRepository(options =>
            //{
            //    options.ConnectionString = _builder.Configuration.GetConnectionString("DefaultConnection");
            //    options.EnableSensitiveDataLogging = _builder.Environment.IsDevelopment();
            //});

            //_builder.Services.AddDataService();
            //_builder.Services.RegisterServices(_builder); //??

            _builder.Services.AddDistributedMemoryCache();

            //_builder.Services.AddEcoSecurity(_builder);
            //_builder.Services.AddScoped<ISessionManager>(provider => new SessionManager(provider, TSystem.Web));
            //_builder.Services.AddScoped<IMessageManager, MessageManager>();
            //_builder.Services.AddScoped<IFileService, FileService>();
            _builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            _builder.Services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
            _builder.Services.AddHttpContextAccessor();

            _builder.Services.AddMemoryCache();
            _builder.Services.AddControllersWithViews();
        }

        private static void ConfigureApplication()
        {
            if (!_app.Environment.IsDevelopment())
            {
                _app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _app.UseHsts();
            }
            //_app.UseHttpsRedirection();
            _app.UseStaticFiles();
            _app.UseRouting();
            _app.UseAuthorization();

            _app.UseCulturePtBr();
            //_app.UseSession();

            _app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            _app.Run();

        }
    }
}