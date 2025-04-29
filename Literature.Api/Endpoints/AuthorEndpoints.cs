using Carter;
using Literature.Application.Contracts.Services;
using Literature.Application.Dtos.Authors;
using Literature.Application.Exceptions;

namespace Literature.Api.Endpoints
{
    public class AuthorEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/authors")
                           .WithTags("Authors")
                           .WithOpenApi();

            // GET: api/authors
            group.MapGet("/", async (IAuthorService authorService) =>
            {
                var authors = await authorService.GetAllAuthorsAsync();
                return Results.Ok(authors);
            })
            .WithName("GetAllAuthors")
            .Produces<IEnumerable<AuthorModel>>(StatusCodes.Status200OK);

            // GET: api/authors/{id}
            group.MapGet("/{id:int}", async (int id, IAuthorService authorService) =>
            {
                try
                {
                    var author = await authorService.GetAuthorByIdAsync(id);
                    return Results.Ok(author);
                }
                catch (NotFoundException)
                {
                    return Results.NotFound();
                }
            })
            .WithName("GetAuthorById")
            .Produces<AuthorModel>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            // POST: api/authors
            group.MapPost("/", async (CreateAuthorModel authorModel, IAuthorService authorService) =>
            {
                if (authorModel is null)
                    return Results.BadRequest("Author data is required");

                var createdAuthor = await authorService.CreateAuthorAsync(authorModel);
                return Results.Created($"/api/authors/{createdAuthor.Id}", createdAuthor);
            })
            .WithName("CreateAuthor")
            .Produces<AuthorModel>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            group.MapGet("/books/{bookId:int}", async (int bookId, IAuthorService authorService) =>
            {
                try
                {
                    var authors = await authorService.GetAuthorsByBookIdAsync(bookId);

                    if (!authors.Any())
                        return Results.NotFound($"No authors found for book with Id {bookId}");

                    return Results.Ok(authors);
                }
                catch (Exception ex)
                {
                    return Results.Problem(
                        title: "Error retrieving authors",
                        detail: ex.Message,
                        statusCode: 500);
                }
            })
            .WithName("GetAuthorsByBookId")
            .Produces<IEnumerable<AuthorModel>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);

            // PUT: api/authors
            group.MapPut("/{id:int}", async (int id, UpdateAuthorModel authorModel, IAuthorService authorService) =>
            {
                if (authorModel is null)
                    return Results.BadRequest("Author data is required");

                authorModel.Id = id;

                try
                {
                    await authorService.UpdateAuthorAsync(authorModel);
                    return Results.NoContent();
                }
                catch (NotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("UpdateAuthor")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            // DELETE: api/authors/{id}
            group.MapDelete("/{id:int}", async (int id, IAuthorService authorService) =>
            {
                try
                {
                    await authorService.DeleteAuthorAsync(id);
                    return Results.NoContent();
                }
                catch (NotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("DeleteAuthor")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
