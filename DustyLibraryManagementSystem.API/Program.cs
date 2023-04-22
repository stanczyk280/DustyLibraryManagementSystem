using DustyLibraryManagementSystem.API.Common;
using Raven.Identity;
using Raven.Client.Documents.Session;
using Raven.DependencyInjection;
using DustyLibraryManagementSystem.Domain;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRavenDbDocStore();
builder.Services.AddRavenDbAsyncSession();
builder.Services.AddIdentity<AppUser, IdentityRole>();

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/login", () => Results.SignIn(
    new ClaimsPrincipal(
        new ClaimsIdentity(
            new[] { new Claim("user_id", Guid.NewGuid().ToString()) },
            "cookie"
            )
        ),
    authenticationScheme: "cookie"
    ));

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var session = services.GetRequiredService<IAsyncDocumentSession>();
    await session.SeedData();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured: " + ex.Message);
}

app.Run();