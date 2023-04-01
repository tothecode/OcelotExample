using ProductService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("api/product/all", (IProductRepository _repo) => _repo.GetAll());

app.Run();
