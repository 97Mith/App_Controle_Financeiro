using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositorio;
using System.Text;

namespace AppControleFinanceiro.View;

public partial class AddTransacao : ContentPage
{
	public AddTransacao()
	{
		InitializeComponent();
	}

    private void SalvarEVoltar(object sender, EventArgs e)
    {
        bool deuBoa = Validar();
        if (!deuBoa) { return; }

        SalvarDadosNoDataBase();

        Navigation.PopModalAsync();
        
        
    }

    private void SalvarDadosNoDataBase()
    {
        Transacao transacao = new Transacao()
        { //                                "?" é igual a um if e ":" um else
            Tipo = EntradaRdReceita.IsChecked ? TransacaoTipo.Entrada : TransacaoTipo.Saida,
            Nome = EntradaNome.Text,
            Data = EntradaData.Date,
            Valor = decimal.Parse(EntradaValor.Text)
        };

        var _repositorio = this.Handler.MauiContext.Services.GetService<IRepositorioDeTransacao>();
        _repositorio.Add(transacao);
    }

    private void Toque(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
    private bool Validar()
    {
        bool valido = true;
        decimal valor;
        StringBuilder msg = new StringBuilder();

        if (string.IsNullOrEmpty(EntradaNome.Text) || string.IsNullOrWhiteSpace(EntradaNome.Text))
        {
            msg.AppendLine("O campo 'Nome' deve ser preenchido!");
            valido = false; 
        }
        if (string.IsNullOrEmpty(EntradaValor.Text) || string.IsNullOrWhiteSpace(EntradaValor.Text))
        {
            msg.AppendLine("O campo 'Valor' deve ser preenchido!");
            valido = false;
        }
        else
        {
            if(!decimal.TryParse(EntradaValor.Text, out valor))
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

}