namespace CaixaEletronico.Dominio.Entidades
{
    // Apenas débito

    public class Cartao
    {
        public int CartaoId { get; set; }
        public int Numero { get; set; }
        public string Senha { get; set; }
    }
}