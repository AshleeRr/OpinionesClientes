using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpinionesClientes.Api.Data.Entities
{
    [Table("ViewComments", Schema = "dbo")]
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public required string Comment { get; set; }
        public int Rating { get; set; }
        public required string Source { get; set; }
        public DateOnly Date { get; set; }
    }
}
