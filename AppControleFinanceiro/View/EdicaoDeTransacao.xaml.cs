using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositorio;
using System.Transactions;

namespace AppControleFinanceiro.View;

public partial class EdicaoDeTransacao : ContentPage
{
    private Transacao _transaction;
    private IRepositorioDeTransacao _repository;
    public EdicaoDeTransacao(IRepositorioDeTransacao repository)
    {
        InitializeComponent();
        _repository = repository;
    }

    private void SalvarVoltar(object sender, EventArgs e)
    {
        //App.Current.MainPage = new ListaDeTransacao();
    }

    private void Toque(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
    public void SetTransactionToEdit(Transacao transaction)
    {
        _transaction = transaction;

        if (transaction.Tipo == TransacaoTipo.Entrada)
            EdicRdEntrada.IsChecked = true;
        else
            EdicRdDespesa.IsChecked = true;

        EdicNome.Text = transaction.Nome;
        EdicData.Date = transaction.Data.Date;
        EdicValor.Text = transaction.Valor.ToString();
    }
}