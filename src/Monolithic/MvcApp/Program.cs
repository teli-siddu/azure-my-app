using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAzureAppConfiguration();

// Build configuration
builder.Configuration.AddAzureAppConfiguration(options =>
{
    var url = builder.Configuration["Demo:Url"];
    var token = new DefaultAzureCredential();

    options.Connect(new Uri(url), token)
    .Select("*")
    .ConfigureRefresh(config =>
    {
        config.Register("Demo:Key1",refreshAll:false)
        .SetCacheExpiration(TimeSpan.FromSeconds(10));
    })
    ;
          
});
builder.Logging.AddConsole();
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
app.UseAzureAppConfiguration();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
