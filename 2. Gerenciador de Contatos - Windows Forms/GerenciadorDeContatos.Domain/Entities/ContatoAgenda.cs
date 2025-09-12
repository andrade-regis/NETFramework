using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeContatos.Domain.Entities
{
    public class ContatoAgenda
    {
        internal int Id { get; set; }
        internal int AgendaUsuárioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Endereço { get; set; }
    }
}
