using BusinessLogic.Repository.MovementRepository;
using BusinessLogic.Repository.ProductRepository;
using BusinessLogic.Repository.StockRepository;
using BusinessLogic.Service.MovementService;
using BusinessLogic.Service.ProductService;
using BusinessLogic.Service.StockService;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//подключение к контексту
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

//product
builder.Services.AddTransient<IProductRepository, CProductRepository>();
builder.Services.AddTransient<IProductService, CProductService>();
//stock
builder.Services.AddTransient<IStockRepository, CStockRepository>();
builder.Services.AddTransient<IStockService, CStockService>();
//movement
builder.Services.AddTransient<IMovementRepository, CMovementRepository>();
builder.Services.AddTransient<IMovementService, CMovementService>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
