using Drivex.Data;
using Drivex.Repositories;
using Drivex.Service;
using Drivex.Services.Cars;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("DriveXPolicy", policy =>
        policy.WithOrigins("http://localhost:4200", "https://drivexre.netlify.app"
).AllowAnyHeader().AllowAnyMethod());
});


builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
    builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddMapster();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();
app.UseCors("DriveXPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
