using Microsoft.EntityFrameworkCore;
using GramAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=gramapi.db")); // Configuring the SQLite db

// Configure API versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true; // reports the API version in the response headers
    options.AssumeDefaultVersionWhenUnspecified = true; // assume default version if not specified
    options.DefaultApiVersion = new ApiVersion(1, 0); // set default version
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

// add controllers 
builder.Services.AddControllers(); // Add MVC controllers

//Add openAPI/Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Gram API", Version = "v1" });
});

var app = builder.Build();

//configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // show detailed errors in development
    app.UseSwagger(); // enabling middleware to serve generated Swagger as a JSON endpoint
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gram API V1"); // Set Swagger UI at the app's root
        c.RoutePrefix = string.Empty; // set swagger UI at the app's root
    });
}

app.UseHttpsRedirection(); // enable HTTPS redirection

//Map your API controllers
app.MapControllers();

app.Run();