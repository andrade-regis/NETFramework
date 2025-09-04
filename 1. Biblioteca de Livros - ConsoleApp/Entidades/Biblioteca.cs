using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaDeLivros.Utils;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BibliotecaDeLivros.Entidades
{
    public class Biblioteca
    {
        public Biblioteca()
        {
            CarregarDados();
        }

        private IList<Livro> Livros = new List<Livro>();

        public void AdicionarLivro()
        {
            Livro livro = Utils.LivrosHelper.PreencherInformações();

            if(livro == null)
              return;
            
            Livros.Add(livro);
            
            SalvarDados();

            Console.WriteLine();
            Console.WriteLine("Livro Adicionado");

            MenuHelper.AguardarEnter();
        }

        public void ListarLivros()
        {
            if (Livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }
            else
            {
                Console.WriteLine("--- Livros Cadastrados ---");
                Console.WriteLine("");

                foreach (var livro in Livros)
                {
                    Console.WriteLine(livro);
                    Console.WriteLine();
                }
            }            

            MenuHelper.AguardarEnter();
        }

        public void BuscarLivro()
        {
            Console.Write("Informe o título do livro: ");
            string titulo = Console.ReadLine();
            Console.WriteLine();

            if (!LivrosHelper.ValidarCampo(titulo))
                return;

            var livroEncontrado = LivrosHelper.LocalizarLivroPorTitulo(Livros, titulo);

            if(livroEncontrado != null)
            {
                Console.WriteLine("Livro encontrado: ");

                Console.WriteLine(livroEncontrado);
                return;
            }

            var livrosEncontrados = LivrosHelper.LocalizarLivroPorTrechosDeTitulo(Livros, titulo);

            if (livrosEncontrados != null && livrosEncontrados.Count > 0)
            {
                Console.WriteLine("Livros correspondentes: ");

                foreach (var livro in livrosEncontrados)
                {
                    Console.WriteLine(livro);
                    Console.WriteLine();
                }

                return;
            }

            Console.WriteLine("Livro não localizado.");
            MenuHelper.AguardarEnter();
        }

        public void RemoverLivro()
        {
            Console.Write("Informe o título do livro: ");
            string titulo = Console.ReadLine();
            Console.WriteLine();

            if (!LivrosHelper.ValidarCampo(titulo))
                return;

            var livroEncontrado = LivrosHelper.LocalizarLivroPorTitulo(Livros, titulo);

            if (livroEncontrado != null)
            {
                Livros.Remove(livroEncontrado);

                SalvarDados();

                Console.WriteLine("Livro removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }

            MenuHelper.AguardarEnter();
        }

        private void SalvarDados()
        {
            // Implementar lógica para salvar dados em um arquivo ou banco de dados
        }

        private void CarregarDados()
        {
            // Implementar lógica para carregar dados de um arquivo ou banco de dados
        }
    }
}
