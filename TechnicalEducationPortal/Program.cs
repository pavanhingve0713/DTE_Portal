using Microsoft.AspNetCore.Mvc.Razor;
using TechnicalEducationPortal.Configurations;
using HRMS.Infrastructure.Contract;
using HRMS.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true);
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<RazorViewEngineOptions>(o =>
{
    o.ViewLocationFormats.Clear();
    o.ViewLocationFormats.Add("/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    o.ViewLocationFormats.Add("/Views/HRMS/{1}/{0}" + RazorViewEngine.ViewExtension);
  
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
