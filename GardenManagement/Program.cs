using Garden.Management.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddDbContext<GardenDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GardenDbConnectionString"));
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

    // This needed the database should be pre-existed . Commented below code as it gets invoked each call
    /*using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<GardenDbContext>();
    db.Database.Migrate();
    */
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();