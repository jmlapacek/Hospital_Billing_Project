using Microsoft.EntityFrameworkCore;
using Hospital_Billing_Project.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add configuration for appsettings.json (already done by default)

// ✅ Register services
builder.Services.AddControllers();
builder.Services.AddHttpClient(); // For CMS API

// ✅ Register ApplicationDbContext using SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Add Swagger for API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Add CORS for frontend integration (optional but recommended)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// ✅ Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Enable HTTPS redirection and CORS
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

// ✅ Map API endpoints
app.MapControllers();

app.Run();
