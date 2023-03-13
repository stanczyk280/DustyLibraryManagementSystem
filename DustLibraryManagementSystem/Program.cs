using DustLibraryManagementSystem;
using DustyLibraryManagementSystem.Persistence;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Raven.Client.ServerWide.Operations;

var builder = WebApplication.CreateBuilder(args);

var store = new DocumentStore
{
    Urls = new[] { "http://localhost:8080" },
    Database = "LMS_Dusty"
};
store.Initialize();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDocumentStore>(store);
builder.Services.AddScoped(provider => provider.GetService<IDocumentStore>().OpenAsyncSession());

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var session = services.GetRequiredService<IAsyncDocumentSession>();
    await Seed.SeedData(session);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured: " + ex.Message);
}

app.Run();