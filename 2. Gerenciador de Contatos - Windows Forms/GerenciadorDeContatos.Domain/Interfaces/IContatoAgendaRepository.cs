using GerenciadorDeContatos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDeContatos.Domain.Interfaces
{
    public interface IContatoAgendaRepository
    {
        bool AdicionarContatoAgenda(ContatoAgenda contatoAgenda);
        bool AtualiarContatoAgenda(ContatoAgenda contatoAgenda);
        bool RemoverContatoAgenda(ContatoAgenda contatoAgenda);
        IList<ContatoAgenda> CarregarPorAgendaUsuário(AgendaUsuário agendaUsuário);
    }
}
