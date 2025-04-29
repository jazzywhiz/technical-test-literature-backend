using Carter;
using Literature.Application.Contracts.Services;
using Literature.Application.Dtos.Books;
using Literature.Application.Exceptions;

namespace Literature.Api.Endpoints
{
    public class BookEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/books")
                           .WithTags("Books")
                           .WithOpenApi();

            // GET: api/books
            group.MapGet("/", async (IBookService bookService) =>
            {
                var books = await bookService.GetAllBooksAsync();
                return Results.Ok(books);
            })
            .WithName("GetAllBooks")
            .Produces<IEnumerable<BookModel>>(StatusCodes.Status200OK);

            // GET: api/books/{id}
            group.MapGet("/{id:int}", async (int id, IBookService bookService) =>
            {
                try
                {
                    var book = await bookService.GetBookByIdAsync(id);
                    return Results.Ok(book);
                }
                catch (NotFoundException)
                {
                    return Results.NotFound();
                }
            })
            .WithName("GetBookById")
            .Produces<BookModel>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            // POST: api/books
            group.MapPost("/", async (CreateBookModel bookDto, IBookService bookService) =>
            {
                if (bookDto is null)
                    return Results.BadRequest("Book data is required");

                var createdBook = await bookService.CreateBookAsync(bookDto);
                return Results.Created($"/api/books/{createdBook.Id}", createdBook);
            })
            .WithName("CreateBook")
            .Produces<BookModel>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            // PUT: api/books
            group.MapPut("/{id:int}", async (int id, UpdateBookModel bookModel, IBookService bookService) =>
            {
                if (bookModel is null)
                    return Results.BadRequest("Book data is required");

                bookModel.Id = id;

                try
                {
                    await bookService.UpdateBookAsync(bookModel);
                    return Results.NoContent();
                }
                catch (NotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("UpdateBook")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            // DELETE: api/books/{id}
            group.MapDelete("/{id:int}", async (int id, IBookService bookService) =>
            {
                try
                {
                    await bookService.DeleteBookAsync(id);
                    return Results.NoContent();
                }
                catch (NotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("DeleteBook")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}