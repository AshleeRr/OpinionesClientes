
namespace OpinionesCLientes.Domain.Entities.Api
{
    public class Comments
    {
        public int CommentId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public required string Source { get; set; } //fuente
        public DateOnly Date { get; set; }
        public required string Comment { get; set; }
    }
}
