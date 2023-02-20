using DotStarkProjectBLL.Interface;
using DotStarkProjectBLL.Repository;
using DotStarkProjectBLL.SPWorks;
using DotStarkProjectData.Context;
using DotStarkProjectData.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<ISPWorks, SPWorks>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseTriggers(triggerOptions =>
    {
        triggerOptions.AddTrigger<SetUpdatedOnDate>();
    });
});

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
