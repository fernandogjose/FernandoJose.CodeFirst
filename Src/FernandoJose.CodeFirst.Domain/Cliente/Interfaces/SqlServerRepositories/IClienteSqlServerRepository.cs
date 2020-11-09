using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FernandoJose.CodeFirst.Domain.Cliente.Interfaces.SqlServerRepositories
{
    public interface IClienteSqlServerRepository
    {
        void Adicionar(Models.Cliente clienteRequest);

        void Atualizar(Models.Cliente clienteRequest);

        void Deletar(Models.Cliente clienteRequest);

        Models.Cliente Obter(Models.Cliente clienteRequest);

        List<Models.Cliente> Listar(Expression<Func<Models.Cliente, bool>> predicate);
    }
}
