using System;
using System.Collections.Generic;

namespace Liz.Models
{
    public class ProdutoPedido
    {
        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}