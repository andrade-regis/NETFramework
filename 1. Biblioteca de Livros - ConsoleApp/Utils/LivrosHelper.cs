using BibliotecaDeLivros.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeLivros.Utils
{
    public static class LivrosHelper
    {
        public static Livro PreencherInformações()
        {
            Livro livro = null;

            Console.WriteLine("Preencha os dados do novo livro:");
            Console.WriteLine("");
            
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            if(!ValidarCampo(titulo))
            {
                return null;
            }

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            if (!ValidarCampo(autor))
            {
                return null;
            }

            Console.Write("Ano (4 Dígitos): ");
            string ano = Console.ReadLine();

            if (!ValidarCampo(ano))
            {
                return null;
            }

            if (!int.TryParse(ano, out int anoParse) || anoParse < 0)
            {
                Console.WriteLine("Ano inválido. Operação cancelada.");
                return null;
            }

            Console.Write("Gênero: ");
            string genero = Console.ReadLine();

            if (!ValidarCampo(genero))
            {
                return null;
            }

            livro = new Livro
            {
                Guid = Guid.NewGuid(),
                Titulo = titulo,
                Autor = autor,
                Ano = int.Parse(ano),
                Gênero = genero,
            };

            return livro;
        }

        public static bool ValidarCampo(string campo)
        {
            if (string.IsNullOrWhiteSpace(campo))
            {
                MenuHelper.ExibirMensagemOperaçãoCancelada(campo);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static IList<Livro> LocalizarLivroPorTrechosDeTitulo(IList<Livro> livros, string trechoTitulo)
        {
            return livros.Where(l => l.Titulo.IndexOf(trechoTitulo, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public static Livro LocalizarLivroPorTitulo(IList<Livro> livros, string titulo)
        {
            return livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
