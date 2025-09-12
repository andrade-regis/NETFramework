using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeContatos.Domain.Entities
{
    public class TelefoneContato
    {
        internal int Id { get; set; }
        internal int ContatoAgendaId { get; set; }
        public string Número { get; set; }
    }
}
