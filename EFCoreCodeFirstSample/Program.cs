using EFCoreCodeFirstSample.Data;
using Microsoft.EntityFrameworkCore;
using EFCoreCodeFirstSample.Models.Repository;
using EFCoreCodeFirstSample.Models.DataManager;
using EFCoreCodeFirstSample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDataRepository<Employee>,EmployeeManager>();
builder.Services.AddDbContext<EmployeeContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:EmployeeDB"]));
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
