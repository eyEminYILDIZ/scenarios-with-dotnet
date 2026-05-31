using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
	serverOptions.Limits.MaxConcurrentConnections = 100;
	serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(6);
	serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(6);
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Long Live Requests", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.RoutePrefix = "";
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Long Live Requests");
	});
}

app.UseAuthorization();
app.MapControllers();

app.Run();
