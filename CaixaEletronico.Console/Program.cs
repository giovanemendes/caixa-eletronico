using CaixaEletronico.Dominio.Entidades;
using CaixaEletronico.Dominio.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o Caixa Eletrônico");

            //ICollection<Cliente> clientesDoBanco = new List<Cliente>();
            var contexto = new Contexto();
            
            var cliente1 = new Cliente();
            cliente1.Nome = "Giovane Mendes";
            cliente1.DataNascimento = new DateTime(1990, 5, 20);
            cliente1.Cpf = "01234567890";

            var conta1 = new Conta();
            conta1.Agencia = "01234";
            conta1.Numero = "4321";
            conta1.Saldo = 1000000000;
            conta1.Ativa = true;

            var cartao1 = new Cartao();
            cartao1.Numero = 1234;
            cartao1.Senha = "1234";

            conta1.Cartao = cartao1;

            cliente1.Contas.Add(conta1);
                  
            // cliente 2
                  
            var cliente2 = new Cliente();
            cliente2.Nome = "Josefa Maria";
            cliente2.DataNascimento = new DateTime(1990, 5, 20);
            cliente2.Cpf = "124304957577";
                  
            var conta2 = new Conta();
            conta2.Agencia = "009766";
            conta2.Numero = "1231";
            conta2.Saldo = 1000000000;
            conta2.Ativa = true;

            var cartao2 = new Cartao();
            cartao2.Numero = 1234;
            cartao2.Senha = "1234";

            conta2.Cartao = cartao2;

            cliente2.Contas.Add(conta2);

            var cliente3 = new Cliente();
            cliente3.Nome = "Francisco Antonio";
            cliente3.DataNascimento = new DateTime(1990, 5, 20);
            cliente3.Cpf = "0918237465656";

            //clientesDoBanco.Add(cliente1);
            //clientesDoBanco.Add(cliente2);
            //clientesDoBanco.Add(cliente3);

            contexto.Clientes.Add(cliente1);
            contexto.Clientes.Add(cliente2);
            contexto.Clientes.Add(cliente3);
            contexto.SaveChanges();
            
            Console.WriteLine();
            Console.Write("Pesquisa de Cliente por Nome. Digite o nome do cliente:");
            var nomePesquisa = Console.ReadLine();

            var resultadoClientes = contexto.Clientes.Include(x => x.Contas).Where(c => c.Nome.ToLower().Contains(nomePesquisa.ToLower())).ToList();
            
            Console.WriteLine("Resultado da busca");

            foreach (var cliente in resultadoClientes)
                Console.WriteLine(cliente.Nome + " / " + cliente.Cpf);

            Console.ReadLine();
        }
    }
}
