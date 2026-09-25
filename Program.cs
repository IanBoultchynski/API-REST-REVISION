using API_REST_Revision;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Server=localhost;port=5432;Database=ProduitsDB;uid=postgres;password=postgres;";

builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AddDbContext<ProduitsDbContext>(options => 
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Create the tables automatically in the empty database at startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProduitsDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
// On active Swagger même en production (Azure) pour pouvoir tester facilement
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
