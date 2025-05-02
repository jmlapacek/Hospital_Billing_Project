using Microsoft.EntityFrameworkCore;
using Hospital_Billing_Project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddHttpClient(); // ✅ Required for CMS API call

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("PharmacyBillingDB"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
