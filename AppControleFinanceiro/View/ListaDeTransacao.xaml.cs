namespace AppControleFinanceiro.View;

public partial class ListaDeTransacao : ContentPage
{
	public ListaDeTransacao()
	{
		InitializeComponent();
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