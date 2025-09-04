using System;

namespace BibliotecaDeLivros.Entidades
{
    public class Livro
    {
        internal Guid Guid { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public string Gênero{ get; set; }

        public override string ToString()
        {
            return $" Título: {Titulo},\n Autor: {Autor},\n Ano: {Ano},\n Gênero: {Gênero}";
        }
    }
}
