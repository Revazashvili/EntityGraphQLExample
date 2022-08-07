using EntityGraphQL.AspNet;
using EntityGraphQLExample.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CibContext>(opt => opt.UseInMemoryDatabase("cib"));
builder.Services.AddGraphQLSchema<CibContext>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var cibContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<CibContext>();
await DatabaseSeeder.SeedAsync(cibContext);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();
    routeBuilder.MapGraphQL<CibContext>();
});

app.Run();
