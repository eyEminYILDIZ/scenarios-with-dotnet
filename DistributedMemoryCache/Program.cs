using DistributedMemoryCache;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<StudentDatabase>();
builder.Services.AddScoped<StudentCache>();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "CallbackStorage", Version = "v1" });
});
builder.Services.AddStackExchangeRedisCache(options =>
{
	options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.RoutePrefix = "";
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "CallbackStorage v1");
	});
}

app.UseAuthorization();
app.MapControllers();

app.Run();
