using AppControleFinanceiro.Repositorio;

namespace AppControleFinanceiro.View;

public partial class ListaDeTransacao : ContentPage
{
	IRepositorioDeTransacao _listaDeTransacao;
	public ListaDeTransacao(IRepositorioDeTransacao listaDeTransacao)
	{
		this._listaDeTransacao = listaDeTransacao;
		
		InitializeComponent();

		Lista.ItemsSource = _listaDeTransacao.PegarTudo();
	}

	private void IrParaAdicionarTransacao(object sender, EventArgs argumento)
	{
		Navigation.PushModalAsync(new AddTransacao());
	}


    private void IrParaEditarTransacao(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new EdicaoDeTransacao());
    }
}