using SOFTFISIO.DATA.INTERFACE;
using SOFTFISIO.DATA.REPOSITORY;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuração do Entity Framework Core
builder.Services.AddScoped<IRepositoryEmpresa, RepositoryEmpresa>();

builder.Services.AddScoped<IRepositoryCooperativa, RepositoryCooperativa>();
builder.Services.AddScoped<IRepositoryCooperativa, RepositoryCooperativa>();
builder.Services.AddScoped<IRepositoryAgendamento, RepositoryAgendamento>();
builder.Services.AddScoped<IRepositoryCooperativa, RepositoryCooperativa>();
builder.Services.AddScoped<IRepositoryCooperativa, RepositoryCooperativa>();


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
