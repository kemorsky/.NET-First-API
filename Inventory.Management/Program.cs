using Inventory.Management.Dtos;
using Inventory.Management.Services;
using Microsoft.AspNetCore.Components.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddScoped<IInventoryItemService, InventoryItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// const string GetInventoryEndpointName = "GetInventory";
// const string GetInventoryItemEndpointName = "GetInventoryItem";

// // Ctrl + . will allow us to choose a suitable Dto from the project files

// List<InventoryDto> inventory = [ // M in price tells compiler that it is a decimal
//     new (1, "Chicken Breast", "Meat", 3, 59.95M, new DateOnly(2026, 6, 02), new DateOnly(2026, 5, 29)),
//     new (2, "Apple", "Fruit", 7, 20.75M, new DateOnly(2026, 6, 05), new DateOnly(2026, 5, 27)),
//     new (3, "Milk", "Dairy", 1, 17.85M, new DateOnly(2026, 6, 01), new DateOnly(2026, 5, 27)),
// ];

app.MapGet("/", () => "Hello World!");

// // GET /inventory - return the entire inventory
// app.MapGet("/inventory", () => inventory)
//     .WithName(GetInventoryEndpointName);;

// // GET /inventory/1 - return the first item in the inventory
// app.MapGet("/inventory/{id}", (int id) => inventory.Find(inventory => inventory.Id == id))
//     .WithName(GetInventoryItemEndpointName); // .WithName allows for naming endpoints for easier implementation in later stages

// // POST /inventory - return the first item in the inventory
// app.MapPost("/inventory", (CreateInventoryItemDto newItem) =>
// {
//     InventoryDto item = new(
//         inventory.Count + 1,
//         newItem.Name,
//         newItem.Type,
//         newItem.Quantity,
//         newItem.Price,
//         newItem.ExpirationDate,
//         newItem.LastOrdered
//     );

//     inventory.Add(item);

//     return Results.CreatedAtRoute(GetInventoryItemEndpointName, new {id = item.Id}, item);
//     // return Results.Created($"/inventory/{item.Id}", item);
// });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
