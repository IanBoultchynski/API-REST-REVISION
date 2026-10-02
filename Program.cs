using API_REST_Revision;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Server=localhost;port=5432;Database=ProduitsDB;uid=postgres;password=postgres;";

builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AddScoped<IMarqueRepository, MarqueRepository>();
builder.Services.AddDbContext<ProduitsDbContext>(options => 
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<API_REST_REVISION.Models.MappingProfile>());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProduitsDbContext>();
    context.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
