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
        Lista.ItemsSource = _listaDeTransacao.PegarTudo();
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