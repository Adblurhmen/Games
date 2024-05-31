using Games.Components;
using Games.Contaxt.Database;
using Games.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using GamsIRep.IRepositry;
using GamesRep.Repositry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContextPool<GamesContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("GamesConnection")));
builder.Services.AddScoped<IVenueRep, VenueRep>();
builder.Services.AddScoped<IRoomRep, RoomRep>();
builder.Services.AddScoped<IGameRep, GameRep>();
//builder.Services.AddScoped<IUserRep, UserRep>();
//builder.Services.AddScoped<IBookingRep, BookingRep>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
