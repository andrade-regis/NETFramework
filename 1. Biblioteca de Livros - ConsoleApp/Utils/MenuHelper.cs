using BibliotecaDeLivros.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BibliotecaDeLivros.Utils
{
    public static class MenuHelper
    {
        public static void ExibirMenu()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("=== Mini Biblioteca ===");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("1. Adicionar Livro");
            stringBuilder.AppendLine("2. Listar Livros");
            stringBuilder.AppendLine("3. Buscar Livro");
            stringBuilder.AppendLine("4. Remover Livro");
            stringBuilder.AppendLine("5. Sair");

            Console.WriteLine(stringBuilder.ToString());
            Console.Write("Escolha uma opção:");
        }

        public static void LimparTela()
        {
            Console.Clear();
        }

        public static void AguardarEnter()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }        
    }
}
