
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddScoped<IBoardGameNightRepository, BoardGameNightRepository>();
//builder.Services.AddScoped<IBoardGameNightPlayerRepository, BoardGameNightPlayerRepository>();
//builder.Services.AddScoped<IBoardGameNightBoardGameRepository, BoardGameNightBoardGameRepository>();
//builder.Services.AddScoped<IBoardGameRepository, BoardGameRepository>();
//builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();



//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnectionString")
//    ));
//builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("AuthConnectionString")
//    ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
