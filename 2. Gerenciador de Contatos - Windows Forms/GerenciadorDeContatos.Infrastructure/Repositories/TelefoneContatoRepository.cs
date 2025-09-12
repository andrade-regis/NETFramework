using GerenciadorDeContatos.Domain.Entities;
using GerenciadorDeContatos.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace GerenciadorDeContatos.Infrastructure.Repositories
{
    public class TelefoneContatoRepository : ITelefoneContatoRepository
    {
        public bool AdicionarTelefoneContato(TelefoneContato telefoneContato)
        {
            throw new NotImplementedException();
        }

        public bool AtualizarTelefoneContato(TelefoneContato telefoneContato)
        {
            throw new NotImplementedException();
        }

        public IList<TelefoneContato> CarregarPorContatoAgenda(ContatoAgenda contatoAgenda)
        {
            throw new NotImplementedException();
        }

        public bool RemoverTelefoneContato(TelefoneContato telefoneContato)
        {
            throw new NotImplementedException();
        }
    }
}
