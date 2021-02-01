using System;
using System.Collections.Generic;

namespace CaixaEletronico.Dominio.Entidades
{
    public class Cliente
    {
        public Cliente()
        {
            Contas = new List<Conta>();
        }
        
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<Conta> Contas { get; set; }
    }
}
