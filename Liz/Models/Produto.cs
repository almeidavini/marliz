using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liz.Models
{
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public int TpUnidadeId { get; set; }
        public TpUnidade TpUnidade { get; set; }
        public ICollection<ProdutoPedido> ProdutoPedidos { get; set; }
    }
}