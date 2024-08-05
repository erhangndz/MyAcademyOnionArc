using Microsoft.EntityFrameworkCore;
using Product.Application.Features.CQRS.Handlers.CategoryHandlers;
using Product.Application.Features.Mediator.Handlers.CustomerHandlers;
using Product.Application.Interfaces;
using Product.Persistance.Context;
using Product.Persistance.Repositories;
using Product.WebUI.Extensions;
using Product.WebUI.Mappings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<GetCustomerQueryHandler>();
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddServiceHandlers();

builder.Services.AddDbContext<OnionContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    opt.UseSqlServer(connectionString);
});


builder.Services.AddControllersWithViews();

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

app.Run();
