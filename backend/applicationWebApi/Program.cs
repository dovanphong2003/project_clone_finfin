
using BookStore.BLL.Services;
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
        policy.WithOrigins("http://localhost:5173")  // Cho phép origin này
              .AllowAnyHeader()                    // Cho phép bất kỳ header nào
              .AllowAnyMethod()                    // Cho phép tất cả các HTTP methods (GET, POST, PUT, DELETE,...)
              .AllowCredentials();                 // Cho phép sử dụng credentials (cookies, HTTP authentication,...)
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Authorization (optional)
builder.Services.AddAuthorization();

// add dependency injection
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddDataAccessLayer();
builder.Services.AddDataAccess();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS policy
app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
