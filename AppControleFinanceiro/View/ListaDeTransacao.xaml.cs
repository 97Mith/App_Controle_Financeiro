using AppControleFinanceiro.Repositorio;
using CommunityToolkit.Mvvm.Messaging;

namespace AppControleFinanceiro.View;

public partial class ListaDeTransacao : ContentPage
{
	IRepositorioDeTransacao _listaDeTransacao;
	public ListaDeTransacao(IRepositorioDeTransacao listaDeTransacao)
	{
		this._listaDeTransacao = listaDeTransacao;
		
		InitializeComponent();

		recarregar();
		
		WeakReferenceMessenger.Default.Register<string>(this, (e, msg)=>{
			recarregar();
		});
	}

	public void recarregar()
	{
		var itens = _listaDeTransacao.PegarTudo();
		Lista.ItemsSource = itens;

		decimal receita = itens.Where(a => a.Tipo == Models.TransacaoTipo.Entrada).Sum(a => a.Valor);
		decimal despesa = itens.Where(a => a.Tipo == Models.TransacaoTipo.Saida).Sum(a => a.Valor);
		decimal balanco = receita - despesa;

		TotalReceita.Text = receita.ToString("C");
		TotalDespesas.Text = despesa.ToString("C");
		Saldo.Text = balanco.ToString("C");

	}

	private void IrParaAdicionarTransacao(object sender, EventArgs argumento)
	{
		Navigation.PushModalAsync(new AddTransacao());
	}


    private void IrParaEditarTransacao(object sender, EventArgs e)
    {
		var editarTransacao = Handler.MauiContext.Services.GetService<EdicaoDeTransacao>();
        Navigation.PushModalAsync(editarTransacao);
    }
}