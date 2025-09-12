using GerenciadorDeContatos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDeContatos.Domain.Interfaces
{
    public interface ITelefoneContatoRepository
    {
        bool AdicionarTelefoneContato(TelefoneContato telefoneContato);
        bool AtualizarTelefoneContato(TelefoneContato telefoneContato);
        bool RemoverTelefoneContato(TelefoneContato telefoneContato);
        IList<TelefoneContato> CarregarPorContatoAgenda(ContatoAgenda contatoAgenda);
    }
}
