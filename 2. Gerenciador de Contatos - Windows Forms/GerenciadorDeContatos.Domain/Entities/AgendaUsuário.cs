using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeContatos.Domain.Entities
{
    public class AgendaUsuário
    {
        internal int Id { get; set; }
        internal int UsuárioId { get; set; }
        public string Nome { get; set; }
    }
}
