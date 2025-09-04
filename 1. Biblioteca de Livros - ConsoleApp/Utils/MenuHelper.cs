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

        public static void ExecutarOpção(Biblioteca biblioteca, int option)
        {
            switch (option)
            {
                case 1:
                    biblioteca.AdicionarLivro();
                    break;
                case 2:
                    biblioteca.ListarLivros();
                    break;
                case 3:
                    biblioteca.BuscarLivro();
                    break;
                case 4:
                    biblioteca.RemoverLivro();
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Thread.Sleep(120);
                    break;
            }
        }

        public static void ExibirMensagemOperaçãoCancelada(string Campo)
        {
            Console.WriteLine($"{Campo} é obrigatório. Operação cancelada.");
            AguardarEnter();
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
