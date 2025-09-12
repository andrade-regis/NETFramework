using GerenciadorDeContatos.Domain.Entities;
using GerenciadorDeContatos.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace GerenciadorDeContatos.Infrastructure.Repositories
{
    public class AgendaUsuárioRepository : IAgendaUsuárioRepository
    {
        public bool AdicionarAgendaUsuário(AgendaUsuário agendaUsuário)
        {
            throw new NotImplementedException();
        }

        public bool AtualizarAgendaUsuário(AgendaUsuário agendaUsuário)
        {
            throw new NotImplementedException();
        }

        public IList<AgendaUsuário> CarregarPorUsuário(Usuário usuário)
        {
            throw new NotImplementedException();
        }

        public bool ExcluirAgendaUsuário(AgendaUsuário agendaUsuário)
        {
            throw new NotImplementedException();
        }
    }
}
