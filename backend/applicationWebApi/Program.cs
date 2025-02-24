
using BookStore.BLL;
using Microsoft.AspNetCore.Cors;
using BookStore.DAL;
using BookStore.DataAccess;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()                    
              .AllowAnyMethod()                   
              .AllowCredentials(); 
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen(o => o.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
{
    Title = "API WEB BOOK STORE",
    Version = "V1",
    Description = "API"
}));

// Add Authorization (optional)
builder.Services.AddAuthorization();

// add dependency injection
builder.Services.AddBussinessLogicLayer();
builder.Services.AddDataAccessLayer();
builder.Services.AddDataAccess();



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/V1/swagger.json","My API V1"));
}

// Use CORS policy
app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
