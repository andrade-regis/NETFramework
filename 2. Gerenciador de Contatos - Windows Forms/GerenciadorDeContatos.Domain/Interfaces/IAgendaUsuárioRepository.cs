using GerenciadorDeContatos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDeContatos.Domain.Interfaces
{
    public interface IAgendaUsuárioRepository
    {
        bool AdicionarAgendaUsuário(AgendaUsuário agendaUsuário);
        bool AtualizarAgendaUsuário(AgendaUsuário agendaUsuário);
        bool ExcluirAgendaUsuário(AgendaUsuário agendaUsuário);
        IList<AgendaUsuário> CarregarPorUsuário(Usuário usuário);
    }
}
