using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using App.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryService,CategoryService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
