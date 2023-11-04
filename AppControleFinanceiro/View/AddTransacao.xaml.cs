namespace AppControleFinanceiro.View;

public partial class AddTransacao : ContentPage
{
	public AddTransacao()
	{
		InitializeComponent();
	}

    private void SalvarEVoltar(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ListaDeTransacao());
        
    }
}