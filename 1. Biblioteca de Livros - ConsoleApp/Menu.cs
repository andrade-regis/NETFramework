using BibliotecaDeLivros.Entidades;
using BibliotecaDeLivros.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BibliotecaDeLivros
{
    internal class Menu
    {
        internal void Iniciar()
        {
            int option = 0;

            Biblioteca biblioteca = new Biblioteca();

            while (option != 5)
            {
                MenuHelper.LimparTela();

                MenuHelper.ExibirMenu();

                string userOption = Console.ReadLine();
                Console.WriteLine();

                if(int.TryParse(userOption, out option))
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
                            MenuHelper.AguardarEnter();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    MenuHelper.AguardarEnter();
                }
            }
        }
    }
}
