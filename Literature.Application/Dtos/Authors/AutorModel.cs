namespace Literature.Application.Dtos.Authors
{
    public class AuthorModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
