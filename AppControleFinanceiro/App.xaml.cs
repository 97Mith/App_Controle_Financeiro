using AppControleFinanceiro.Repositorio;

namespace AppControleFinanceiro
{
    public partial class App : Application
    {
        public App(IRepositorioDeTransacao lista)
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new View.ListaDeTransacao(lista));
        }
    }
}