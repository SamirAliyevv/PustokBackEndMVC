    
using Pustok.DAL;
using Microsoft.EntityFrameworkCore;
using Pustok.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddScoped<LayoutServices>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<RelationsBooksShop>(opt => { 

    opt.UseSqlServer("Server=DESKTOP-8R6MOBB\\SQLEXPRESS;Database=PustokBooksStore;Integrated Security=true");

});
var app = builder.Build();



app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );


app.MapControllerRoute("default", "{controller=Home}/{action=index}/{id?}");
app.UseStaticFiles();
app.UseSession();   

app.Run();
