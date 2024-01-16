using Net14Web.Services;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.Services.RealEstate;
using Net14Web.Services.Movies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=Net14Web; Integrated Security=True";
builder.Services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));
//builder.Services.AddScoped<WebDbContext>();

builder.Services.AddScoped<HeroBuilder>(diContainer =>
{
    var randomHelper = diContainer.GetService<RandomHelper>();
    return new HeroBuilder(randomHelper);
});

// builder.Services.AddTransient<RandomHelper>();
builder.Services.AddScoped<RandomHelper>();
// builder.Services.AddSingleton<RandomHelper>();

builder.Services.AddScoped<CommentBuilder>();
builder.Services.AddScoped<ErrorBuilder>();
builder.Services.AddScoped<MovieBuilder>();
builder.Services.AddScoped<Net14Web.Services.Movies.UserBuilder>();
builder.Services.AddScoped<UserEditHelper>();
builder.Services.AddScoped<MovieEditHelper>();
builder.Services.AddScoped<LoginHelper>();

builder.Services.AddScoped<DeleteUser>();
builder.Services.AddScoped<IdBuilder>();
builder.Services.AddScoped<UpdateUser>();
builder.Services.AddScoped<Net14Web.Services.RealEstate.UserBuilder>();
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
