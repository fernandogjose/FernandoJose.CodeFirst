using FernandoJose.CodeFirst.Domain.Cliente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Models;
using FernandoJose.CodeFirst.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FernandoJose.CodeFirst.SqlServer.Repositories
{
    public class ClienteSqlServerRepository : IClienteSqlServerRepository
    {
        public void Adicionar(Cliente clienteRequest)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            db.Clientes.Add(clienteRequest);
            db.SaveChanges();
        }

        public void Atualizar(Cliente clienteRequest)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            db.Clientes.Update(clienteRequest);
            db.SaveChanges();
        }

        public void Deletar(Cliente clienteRequest)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            db.Clientes.Remove(clienteRequest);
            db.SaveChanges();
        }

        public Cliente Obter(Cliente clienteRequest)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            Cliente clienteResponse = db.Clientes.FirstOrDefault(x => x.Id == clienteRequest.Id);
            return clienteResponse;
        }

        public List<Cliente> Listar(Expression<Func<Cliente, bool>> predicate)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            List<Cliente> clientesResponse = db.Clientes.Where(predicate).OrderBy(x => x.Nome).ToList();
            return clientesResponse;
        }
    }
}
