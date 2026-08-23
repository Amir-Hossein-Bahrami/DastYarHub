using DastYarHub.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ICategoryApiService, CategoryApiService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

    if (string.IsNullOrWhiteSpace(apiBaseUrl))
    {
        throw new InvalidOperationException("آدرس API در appsettings.json تنظیم نشده است.");
    }

    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddHttpClient<IToolUsageService, ToolUsageService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

    if (string.IsNullOrWhiteSpace(apiBaseUrl))
    {
        throw new InvalidOperationException("آدرس API در appsettings.json تنظیم نشده است.");
    }

    client.BaseAddress = new Uri(apiBaseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
