using Coding.Exam.RainFallAPI.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var openAPIDoc = builder.Configuration.GetSection("OpenAPIDoc").Get<OpenAPIDoc>();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = openAPIDoc.Title,
		Version = openAPIDoc.Version,
		Description = openAPIDoc.Description,
		Contact = new OpenApiContact()
		{
			Name = openAPIDoc.Contract.Name,
			Url = new Uri(openAPIDoc.Contract.Url)
		}
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.yaml", "RainFall v1.0"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
