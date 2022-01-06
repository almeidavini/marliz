using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liz.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public char Sexo { get; set; }
        public string Email { get; set; }
        public DateTime DtCadastro { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}