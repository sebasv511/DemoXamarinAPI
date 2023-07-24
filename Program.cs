using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DemoXamarinAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DemoXamarinDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoXamarinDbContext") ?? throw new InvalidOperationException("Connection string 'DemoXamarinDbContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SeedDb>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seedDb = services.GetRequiredService<SeedDb>();
    await seedDb.SeedAsync();
}


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
