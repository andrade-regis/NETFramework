using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaDeLivros.Entidades;
using BibliotecaDeLivros.Utils;
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
                Console.Clear();

                MenuHelper.ExibirMenu();

                string userOption = Console.ReadLine();
                Console.WriteLine();

                if(int.TryParse(userOption, out option))
                {
                    MenuHelper.ExecutarOpção(biblioteca, option);
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
