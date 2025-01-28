using libraryManagementSystem.Models;
using libraryManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Ensure controllers are registered
builder.Services.AddEndpointsApiExplorer(); // Enables endpoint discovery for Swagger
builder.Services.AddSwaggerGen(); // Adds Swagger support

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger
    app.UseSwaggerUI(); // Enable Swagger UI
}

app.UseRouting();
app.UseStaticFiles(); // Serve static files

app.MapControllers(); // Map controller endpoints


// Create an instance of the service
var libraryService = new LibraryService();

// API Endpoints
app.MapPost("/add-user", (User user) =>
{
    libraryService.AddUser(user);
    return Results.Ok($"User {user.Name} added successfully.");
});

app.MapPost("/add-book", (PhysicalBook book) =>
{
    libraryService.AddBook(book);
    return Results.Ok($"Book '{book.Title}' added successfully.");
});

app.MapGet("/get-book/{id}", (int id) =>
{
    try
    {
        var book = libraryService.GetBookById(id);
        return Results.Ok(book.GetDescription());
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("/borrow-book", (int bookId, int userId) =>
{
    try
    {
        libraryService.BorrowBook(bookId, userId);
        return Results.Ok($"Book {bookId} borrowed by user {userId}.");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});


/* git*/


app.Run();