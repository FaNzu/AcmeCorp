using Microsoft.EntityFrameworkCore;
using AcmeCorp.Web.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AcmeCorpApiContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("AcmeCorpApiContext") ?? throw new InvalidOperationException("Connection string 'SurfBoardApiContext' not found.")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Seeder fills the database with draw serial number objects 
builder.Services.AddScoped<AcmeCorpApiSeeder>(); // Add seeder service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//run the seeder
using (var scope = app.Services.CreateScope()) // Use a scope for seeder
{
    var seeder = scope.ServiceProvider.GetRequiredService<AcmeCorpApiSeeder>();
    await seeder.SeedAsync(); // Seed data with default or custom entry count
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
