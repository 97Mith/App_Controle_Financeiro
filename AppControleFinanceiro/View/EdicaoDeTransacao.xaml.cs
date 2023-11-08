using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositorio;
using CommunityToolkit.Mvvm.Messaging;
using System.Text;
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
        bool deuBoa = Validar();
        if (!deuBoa) { return; }

        SalvarDadosNoDataBase();

        Navigation.PopModalAsync();

        //se for salvo ele envia uma mensagem que será usada para recarregar a pagina
        WeakReferenceMessenger.Default.Send<string>("");
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

    private bool Validar()
    {
        bool valido = true;
        decimal valor;
        StringBuilder msg = new StringBuilder();

        if (string.IsNullOrEmpty(EdicNome.Text) || string.IsNullOrWhiteSpace(EdicNome.Text))
        {
            msg.AppendLine("O campo 'Nome' deve ser preenchido!");
            valido = false;
        }
        if (string.IsNullOrEmpty(EdicValor.Text) || string.IsNullOrWhiteSpace(EdicValor.Text))
        {
            msg.AppendLine("O campo 'Valor' deve ser preenchido!");
            valido = false;
        }
        else
        {
            if (!decimal.TryParse(EdicValor.Text, out valor))
            {
                msg.AppendLine("O campo 'Valor' é inválido!");
                valido = false;
            }
        }
        if (valido == false)
        {
            MensagemErro.IsVisible = true;
            MensagemErro.Text = msg.ToString();
        }
        return valido;
    }

    private void SalvarDadosNoDataBase()
    {
        Transacao transacao = new Transacao()
        { //                                "?" é igual a um if e ":" um else
            Id = _transaction.Id,
            Tipo = EdicRdEntrada.IsChecked ? TransacaoTipo.Entrada : TransacaoTipo.Saida,
            Nome = EdicNome.Text,
            Data = EdicData.Date,
            Valor = decimal.Parse(EdicValor.Text)
        };

        var _repositorio = this.Handler.MauiContext.Services.GetService<IRepositorioDeTransacao>();
        _repositorio.Update(transacao);
    }
}