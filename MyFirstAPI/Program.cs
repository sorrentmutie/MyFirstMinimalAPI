using MyFirstAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/orders", () =>
{
    var orders = new List<Order>
    {
         new Order { Id = 1, ProductName = "Laptop", Quantity = 1, Price = 500, OrderDate = DateTime.Now },
         new Order { Id = 2, ProductName = "Laptop 2", Quantity = 1, Price = 500, OrderDate = DateTime.Now },
    };
    return Results.Ok(orders);
})
.WithOpenApi();

app.Run();


