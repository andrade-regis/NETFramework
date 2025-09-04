using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaDeLivros.Utils;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace BibliotecaDeLivros.Entidades
{
    public class Biblioteca
    {
        private readonly string arquivoDados = "livros.json";
        private readonly string diretorioDados = Path.Combine(Path.GetTempPath(), "Data");

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

            ConsoleHelper.ExibirMensagemComParagrafoAntes("Livro Adicionado");

            MenuHelper.AguardarEnter();
        }

        public void ListarLivros()
        {
            if (Livros.Count == 0)
            {
                ConsoleHelper.ExibirMensagemComParagrafoAntes("Nenhum livro cadastrado.");
            }
            else
            {
                ConsoleHelper.ExibirMensagemComParagrafoAntes("--- Livros Cadastrados ---");

                foreach (var livro in Livros)
                {
                    ConsoleHelper.ExibirMensagemComParagrafoAntes(livro.ToString());
                }
            }            

            MenuHelper.AguardarEnter();
        }

        public void BuscarLivro()
        {
            Console.Write("Informe o título do livro: ");
            string titulo = Console.ReadLine();

            if (!LivrosHelper.ValidarCampo(titulo, "Título"))
                return;

            var livroEncontrado = LivrosHelper.LocalizarLivroPorTitulo(Livros, titulo);

            if(livroEncontrado != null)
            {
                ConsoleHelper.ExibirMensagemComParagrafoAntes("Livro encontrado: ");

                ConsoleHelper.ExibirMensagemComParagrafoAntes(livroEncontrado.ToString());

                MenuHelper.AguardarEnter();
                return;
            }

            var livrosEncontrados = LivrosHelper.LocalizarLivroPorTrechosDeTitulo(Livros, titulo);

            if (livrosEncontrados != null && livrosEncontrados.Count > 0)
            {
                Console.WriteLine("Livros correspondentes: ");

                foreach (var livro in livrosEncontrados)
                {
                    ConsoleHelper.ExibirMensagemComParagrafoAntes(livro.ToString());
                }

                MenuHelper.AguardarEnter();
                return;
            }

            ConsoleHelper.ExibirMensagemComParagrafoAntes("Livro não localizado.");
            MenuHelper.AguardarEnter();
        }

        public void RemoverLivro()
        {
            Console.Write("Informe o título do livro: ");
            string titulo = Console.ReadLine();
            Console.WriteLine();

            if (!LivrosHelper.ValidarCampo(titulo, "Título"))
                return;

            var livroEncontrado = LivrosHelper.LocalizarLivroPorTitulo(Livros, titulo);

            if (livroEncontrado != null)
            {
                ConsoleHelper.ExibirMensagemComParagrafoDepois(livroEncontrado.ToString());

                Console.Write("Deseja remover o livro acima? (Sim/Não) ");
                string input = Console.ReadLine();

                if (input.ToLower().Contains("sim"))
                {
                    Livros.Remove(livroEncontrado);

                    SalvarDados();

                    ConsoleHelper.ExibirMensagemComParagrafoAntes("Livro removido com sucesso.");
                    MenuHelper.AguardarEnter();
                }
                else
                {
                    ConsoleHelper.ExibirMensagemComParagrafoAntes("Operação Cancelada.");
                    MenuHelper.AguardarEnter();
                }

                return;
            }

            var livrosEncontrados = LivrosHelper.LocalizarLivroPorTrechosDeTitulo(Livros, titulo);

            if (livrosEncontrados != null && livrosEncontrados.Count > 0)
            {
                var livroSelecionado = LivrosHelper.ExibirMultiplasOpçõesParaRemover(livrosEncontrados);

                if(livroSelecionado != null)
                {
                    Livros.Remove(livroSelecionado);

                    SalvarDados();

                    ConsoleHelper.ExibirMensagemComParagrafoAntes("Livro removido com sucesso.");
                    MenuHelper.AguardarEnter();
                }

                return;
            }

            Console.WriteLine("Livro não encontrado.");

            MenuHelper.AguardarEnter();
        }

        private void SalvarDados()
        {
            if (!Directory.Exists(diretorioDados))
            {
                Directory.CreateDirectory(diretorioDados);
            }

            string arquivoJson = JsonConvert.SerializeObject(Livros, Formatting.Indented);
            File.WriteAllText(Path.Combine(diretorioDados, arquivoDados), arquivoJson);
        }   

        private void CarregarDados()
        {
            if (File.Exists(Path.Combine(diretorioDados, arquivoDados)))
            {
                Livros = JsonConvert.DeserializeObject<IList<Livro>>(File.ReadAllText(Path.Combine(diretorioDados, arquivoDados))) ?? new List<Livro>();
            }
        }
    }
}
