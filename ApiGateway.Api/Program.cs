using ApiGateway.Mobile;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddInfrastructure(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseInfrastructure(app.Environment, config);

app.UseHttpsRedirection();
app.MapControllers();

app.Run();