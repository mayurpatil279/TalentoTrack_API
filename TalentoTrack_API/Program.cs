using Microsoft.EntityFrameworkCore;
using TalentoTrack.Common.Repoitories;
using TalentoTrack.Common.Services;
using TalentoTrack.Dao.Db;
using TalentoTrack.Dao.Repoitories;
using TalentoTrack.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddTransient<IAccountRepoitories, AccountRepositories>();

builder.Services.AddDbContext<TalentoTrack_DbContext>(option =>
 option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"])
);

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
