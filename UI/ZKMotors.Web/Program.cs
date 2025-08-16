using Microsoft.EntityFrameworkCore;
using ZK.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers()
            .AddApplicationPart(typeof(ZK.Presentation.AssemblyReference).Assembly);
builder.Services.AddDbContext<ZKDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ZKMotors")));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
