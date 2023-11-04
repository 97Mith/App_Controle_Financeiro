namespace AppControleFinanceiro.View;

public partial class EdicaoDeTransacao : ContentPage
{
	public EdicaoDeTransacao()
	{
		InitializeComponent();
	}

    private void SalvarVoltar(object sender, EventArgs e)
    {
        App.Current.MainPage = new ListaDeTransacao();
    }
}