using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liz.Models
{
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DtPedido { get; set; }
        public DateTime DtEntrega { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public ICollection<ProdutoPedido> ProdutoPedidos { get; set; }
    }
}