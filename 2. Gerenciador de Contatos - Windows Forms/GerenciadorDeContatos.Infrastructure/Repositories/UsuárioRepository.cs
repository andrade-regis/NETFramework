using GerenciadorDeContatos.Domain.Entities;
using GerenciadorDeContatos.Domain.Interfaces;
using System;

namespace GerenciadorDeContatos.Infrastructure.Repositories
{
    public class UsuárioRepository : IUsuárioRepository
    {
        public bool AdicionarUsuário(Usuário usuário)
        {
            throw new NotImplementedException();
        }

        public bool AtualizarUsuário(Usuário usuário)
        {
            throw new NotImplementedException();
        }

        public Usuário CarregarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public bool ExcluirUsuário(Usuário usuário)
        {
            throw new NotImplementedException();
        }
    }
}
