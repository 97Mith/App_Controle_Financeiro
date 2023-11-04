using AppControleFinanceiro.Models;

namespace AppControleFinanceiro.Repositorio
{
    public interface IRepositorioDeTransacao
    {
        void Add(Transacao transacao);
        void Deletar(Transacao transacao);
        List<Transacao> PegarTudo();
    }
}