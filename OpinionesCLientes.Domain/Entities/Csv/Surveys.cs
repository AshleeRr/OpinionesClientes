
namespace OpinionesCLientes.Domain.Entities.Csv
{
    public class Surveys
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateOnly Date { get; set; }
        public required string Comment { get; set; }
        public required string Classification { get; set; }
        public int Rating { get; set; } //Puntuaje de satisfacción 1-5
        public required string Source { get; set; } //Fuente
    }
}
