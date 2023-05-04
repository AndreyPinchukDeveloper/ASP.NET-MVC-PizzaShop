using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data.Services;
using PizzaShop.Domain;
using PizzaShop.Domain.Repositories.Abstract;
using PizzaShop.Domain.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

#region Services
//connect necessary functionality as services
builder.Services.AddTransient<ITextFieldRepository, EFTextFielsRepository>();
builder.Services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddDbContext<AppDbContext>
    (options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnectionString")));

//identity options(password)
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options=>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//prepare authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "myCompanyAuthentication";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});
//add services for controllers and Views
builder.Services.AddControllersWithViews()
    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
    .AddSessionStateTempDataProvider();//set comptability with 3.0 version
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();//connection support for static files like css,js etc

app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
