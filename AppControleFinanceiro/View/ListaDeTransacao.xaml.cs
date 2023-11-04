namespace AppControleFinanceiro.View;

public partial class ListaDeTransacao : ContentPage
{
	public ListaDeTransacao()
	{
		InitializeComponent();
	}

	private void IrParaAdicionarTransacao(object sender, EventArgs argumento)
	{
		App.Current.MainPage = new AddTransacao();
	}


    private void IrParaEditarTransacao(object sender, EventArgs e)
    {
        App.Current.MainPage = new EdicaoDeTransacao();
    }
}