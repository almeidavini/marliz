using System.ComponentModel.DataAnnotations.Schema;

namespace Liz.Models
{
    public class Telefone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTelefone { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}