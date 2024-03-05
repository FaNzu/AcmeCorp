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
