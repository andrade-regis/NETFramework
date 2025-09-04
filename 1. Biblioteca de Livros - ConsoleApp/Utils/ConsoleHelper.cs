using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeLivros.Utils
{
    public static class ConsoleHelper
    {
        public static void ExibirMensagemComParagrafoAntes(string mensagem)
        {
            Console.WriteLine();
            Console.WriteLine(mensagem);
        }

        public static void ExibirMensagemComParagrafoDepois(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.WriteLine();
        }

        public static void ExibirMensagemOperaçãoCancelada(string Campo)
        {
            Console.WriteLine($"{Campo} é obrigatório. Operação cancelada.");
            MenuHelper.AguardarEnter();
        }
    }
}
