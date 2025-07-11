using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFirstMVCApp.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SqLiteDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("SqLiteConnection")
    )
);

builder.Services.AddDefaultIdentity<IdentityUser>(
        options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Добавлено для поддержки ролей
    .AddEntityFrameworkStores<SqLiteDbContext>();

var app = builder.Build();

// Автоматическое создание базы данных и таблиц по сущностям
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<SqLiteDbContext>();
    db.Database.Migrate();
    db.Database.EnsureCreated();
}

// Инициализация базы данных с начальными данными
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SqLiteDbContext>();
    DbInitializer.Seed(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseRouting();
app.MapStaticAssets();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();



app.Run();