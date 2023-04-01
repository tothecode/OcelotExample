using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

IConfiguration configuration = new ConfigurationBuilder()
                                    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                                    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot(configuration);

var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("OcelotAuthenticationApiKey"));
builder.Services.AddAuthentication()
                .AddJwtBearer("AuthScheme", x =>
                {
                    x.Audience = "test";
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateActor = false,
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OcelotAuthenticationApiKey")),
                    };
                    
                });


var app = builder.Build();
app.UseHttpsRedirection();
await app.UseOcelot();
app.UseAuthorization();
app.Run();
