using UserService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();
app.UseHttpsRedirection();

//app.MapControllers();

app.MapGet("api/user/{id}", (int id, IUserRepository _repo) => _repo.GetUser(id));
app.MapGet("api/user/all", (IUserRepository _repo) => _repo.GetAll());


app.Run();
