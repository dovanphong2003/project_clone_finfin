using BookStore.DAL.UnitOfWorks;
using BookStore.DAL.Repositories;
using BookStore.BLL.Services;
using BookStore.DataAccess.DataContext;
using BookStore.DAL;
using BookStore.DataAccess;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
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
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
