using GerenciadorDeContatos.Domain.Entities;
using GerenciadorDeContatos.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace GerenciadorDeContatos.Infrastructure.Repositories
{
    public class ContatoAgendaRepository : IContatoAgendaRepository
    {
        public bool AdicionarContatoAgenda(ContatoAgenda contatoAgenda)
        {
            throw new NotImplementedException();
        }

        public bool AtualiarContatoAgenda(ContatoAgenda contatoAgenda)
        {
            throw new NotImplementedException();
        }

        public IList<ContatoAgenda> CarregarPorAgendaUsuário(AgendaUsuário agendaUsuário)
        {
            throw new NotImplementedException();
        }

        public bool RemoverContatoAgenda(ContatoAgenda contatoAgenda)
        {
            throw new NotImplementedException();
        }
    }
}
