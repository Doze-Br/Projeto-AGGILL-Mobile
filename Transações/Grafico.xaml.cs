using HtmlAgilityPack;
using Mobile.Menu_e_Submenus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Transações
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Grafico : ContentPage
    {
        public Grafico()
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
            TextoGrafico.IsVisible = false;
            TransactionExpander.IsVisible = true;
        }
        public void FecharExpansão(object sender, EventArgs e)
        {
            TextoGrafico.IsVisible = true;
            TransactionExpander.IsVisible = false;
        }
        private void Open_Productivity(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Rendimentos());
        }

        private void Abrir_Relatorio(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Relatorio());
        }

        private void Abrir_Mercado(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Mercado());
        }

        public async Task<bool> AbrirUrl()
        {
            return await Launcher.TryOpenAsync("https://br.investing.com/charts/cryptocurrency-charts");
        }

        private void Abrir_BitcoinEthereum(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await AbrirUrl();
            });
        }

        private void Abrir_EthereumBitcoin(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await AbrirUrl();
            });
        }

        private void AtualizarGrafico(object sender, EventArgs e)
        {
            BitcoinGraf.IsVisible = true;
            EthereumGraf.IsVisible = true;
            DescBitcoin.Text = "Clique no gráfico para acessar uma versão completa do gráfico Bitcoin/Ethereum no navegador";
            DescEthereum.Text = "Clique no gráfico para acessar uma versão completa do gráfico Ethereum/Bitcoin no navegador";
        }
    }
}