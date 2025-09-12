using GerenciadorDeContatos.Domain.Entities;

namespace GerenciadorDeContatos.Domain.Interfaces
{
    public interface IUsuárioRepository
    {
        bool AdicionarUsuário(Usuário usuário);
        bool AtualizarUsuário(Usuário usuário);
        bool ExcluirUsuário(Usuário usuário);
        Usuário CarregarPorEmailSenha(string email, string senha);
    }
}
