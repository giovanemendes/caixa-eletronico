using CaixaEletronico.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Dominio.Infraestrutura.Persistencia
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CaixaEletronico;Trusted_Connection=True;");
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
