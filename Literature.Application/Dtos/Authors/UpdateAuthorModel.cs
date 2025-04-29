using Mapster;

namespace Literature.Application.Dtos.Authors
{
    public class UpdateAuthorModel
    {
        public int Id { get; set; }

        [AdaptMember("IdBook")]
        public int BookId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
