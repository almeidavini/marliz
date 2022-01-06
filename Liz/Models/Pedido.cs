using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liz.Models
{
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }
        public DateTime DtPedido { get; set; }
        public DateTime DtEntrega { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public ICollection<ProdutoPedido> ProdutoPedidos { get; set; }
    }
}