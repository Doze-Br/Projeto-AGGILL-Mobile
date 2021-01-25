using Mobile.Transações;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Menu_e_Submenus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ethereum : ContentPage
    {
        public Ethereum()
        {
            InitializeComponent();
        }

        public void Return()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage = new NavigationPage(new PaginaPrincipal());
            });
        }
        public void Sair()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage = new MainPage();
            });
        }

        public bool Log_Out()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var exit = await this.DisplayAlert("Alerta", "Você deseja efetuar Logout?", "Sim", "Não").ConfigureAwait(false);

                if (exit)
                    Sair();
            });
            return true;
        }

        public void Close_App(object sender, EventArgs e)
        {
            Log_Out();
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var exit = await this.DisplayAlert("Aviso", "Deseja retornar ao Menu principal?", "Sim", "Não").ConfigureAwait(false);

                if (exit)
                    Return();
            });
            return true;
        }

        public void Abrir_Carteira(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Carteira();
        }
        private void Open_Swipe(object sender, EventArgs e)
        {
            MainSwipeView.Open(OpenSwipeItem.LeftItems);
        }
        private void Close_Swipe(object sender, EventArgs e)
        {
            MainSwipeView.Close();
        }

        private void Abrir_MeuPerfil(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new MeuPerfil());
        }

        private void Abrir_Ethereum(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Ethereum());
        }

        private void Abrir_Bitcoin(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Bitcoin());
        }

        private void Abrir_Sobre(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Sobre());
        }
        private void Abrir_Assistencia(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Assistência());
        }
        private void Abrir_FaleConosco(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new FaleConosco());
        }
        private void Expansão(object sender, EventArgs e)
        {
            TextoEthereum.IsVisible = false;
            TransactionExpander.IsVisible = true;
        }
        public void FecharExpansão(object sender, EventArgs e)
        {
            TextoEthereum.IsVisible = true;
            TransactionExpander.IsVisible = false;
        }
        private void Open_Productivity(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Rendimentos());
        }
        private void Abrir_Grafico(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Grafico());
        }
        private void Abrir_Relatorio(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Relatorio());
        }

        private void Abrir_Mercado(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Mercado());
        }
    }
}