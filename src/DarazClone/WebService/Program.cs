using DarazClone.WebService.ServiceRegistrations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBootstrapServices();
builder.Services.RegisterApplicationServices(builder.Configuration);

var app = builder.Build();

app.AddApplicationMiddleware(app.Environment);
app.MapControllers();


app.Run();