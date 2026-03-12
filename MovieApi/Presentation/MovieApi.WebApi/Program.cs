using MovieApi.Persistence.Context;
using MovieApi.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MovieContext>();

builder.Services
    .AddApplicationServices()
    .AddIdentityServices()
    .AddMediatorServices()
    .AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1"));
}


app.Use(async (context, next) =>
{
    if (context.Request.Path == ("/"))
    {
        context.Response.Redirect("/swagger");
        return;
    }

    await next();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();