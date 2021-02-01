using System;

namespace CaixaEletronico.Dominio.Entidades
{
    public class Conta
    {
        public int ContaId { get; set; }
        public string Numero { get; set; }
        public string Agencia { get; set; }
        public decimal Saldo { get; set; }
        public bool Ativa { get; set; }
        public Cartao Cartao { get; set; }

        public Comprovante Sacar()
        {
            throw new NotImplementedException();
        }

        public Comprovante Depositar()
        {
            throw new NotImplementedException();
        }

        public Comprovante Transferir(string agenciaConta, string numeroConta, decimal valor)
        {
            throw new NotImplementedException();
        }

        public Comprovante PagarBoleto(string codigoBarras)
        {
            throw new NotImplementedException();
        }

        public Extrato ObterExtrato(DateTime inicio, DateTime fim)
        {
            throw new NotImplementedException();
        }

        public bool EncerrarConta()
        {
            if (Saldo >= 0)
            {
                Ativa = false;
                return true;
            }
            else
            {
                Ativa = true;
                return false;
            }
        }
    }
}