
namespace OpinionesCLientes.Domain.Entities.Db
{
    public class Reviews
    {
        public int ReviewId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateOnly Date { get; set; }
        public required string Comment { get; set; }
        public required int Rating { get; set; } //del 1-5
    }
}
