using ApiExamenAzureCarolina1.Data;
using ApiExamenAzureCarolina1.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("SqlSeries");
builder.Services.AddTransient<RepositorySeries>();
builder.Services.AddDbContext<SeriesContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
    
}
app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.MapGet("/", context =>
{
    context.Response.Redirect("/scalar");
    return Task.CompletedTask;
});
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/openapi/v1.json", "Api Azure Examen");
//    options.RoutePrefix = "";
//});

app.UseAuthorization();

app.MapControllers();

app.Run();