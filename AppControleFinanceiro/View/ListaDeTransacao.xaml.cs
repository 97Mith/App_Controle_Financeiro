using AppControleFinanceiro.Models;
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


    private void TapGestureRecognizerTapped_To_TransactionEdit(object sender, TappedEventArgs e)
    {
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer)grid.GestureRecognizers[0];
        Transacao transaction = (Transacao)gesture.CommandParameter;

        var transactionEdit = Handler.MauiContext.Services.GetService<EdicaoDeTransacao>();
        transactionEdit.SetTransactionToEdit(transaction);
        Navigation.PushModalAsync(transactionEdit);
    }

    private async void Deletar(object sender, TappedEventArgs e)
    {
		await AnimacaoX((Border)sender, true);
		bool resultado = await App.Current.MainPage.DisplayAlert("Excluir!", "Tem certeza que deseja excluir a transação?", "Sim","Não");
		
		if (resultado)
		{
			Transacao transacao = (Transacao)e.Parameter;
			_listaDeTransacao.Deletar(transacao);

			recarregar();
		}
		else
		{
            await AnimacaoX((Border)sender, false);
        }
	}
	private async Task AnimacaoX(Border borda, bool confirmar)
	{
		if(confirmar)
		{
			await borda.RotateYTo(180, 500);
			borda.BackgroundColor = Colors.Red;

			
		}
		else
		{
			await borda.RotateYTo(-180, 500);
            borda.BackgroundColor = Colors.LemonChiffon;
        }
	}
}