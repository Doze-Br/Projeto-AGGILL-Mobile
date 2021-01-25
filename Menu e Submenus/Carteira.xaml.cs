using Microcharts;
using Mobile.Menu_e_Submenus;
using Mobile.Transações;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carteira : ContentPage
    {
        string Ethereum = "300";
        string Dólar = "100";
        string Bitcoin = "200";
        private readonly ChartEntry[] entries = new[]
{
    new ChartEntry(100)
    {
        Label = "Dólar",
        ValueLabel = "100",
        Color = SKColor.Parse("#b455b6"),
        ValueLabelColor = SKColor.Parse("#b455b6"),
        TextColor = SKColor.Parse("#ffffff")
    },
        new ChartEntry(200)
    {
        Label = "Bitcoin",
        ValueLabel = "200",
        Color = SKColor.Parse("#77d065"),
        ValueLabelColor = SKColor.Parse("#77d065"),
        TextColor = SKColor.Parse("#ffffff")
    },
    new ChartEntry(300)
    {
        Label = "Ethereum",
        ValueLabel = "300",
        Color = SKColor.Parse("#3498db"),
        ValueLabelColor = SKColor.Parse("#3498db"),
        TextColor = SKColor.Parse("#ffffff")
    }
    };
    public Carteira()
        {
            InitializeComponent();
            Chart1.Chart = new PieChart() { Entries = entries, AnimationDuration = TimeSpan.FromSeconds(3.0), BackgroundColor = SKColor.Parse("#00ffffff"),
            LabelColor = SKColor.Parse("#ffffff"), LabelTextSize = 45, Margin = 35.0f};
            ItemsCarteira.Text = "Seu saldo é de: " + Dólar + " Dólares, " + Bitcoin + " Bitcoins e " + Ethereum + " Ethereums";
        }

        public void Return()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage = new NavigationPage(new PaginaPrincipal());
            });
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

        private void Open_Productivity(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Rendimentos());
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
            TextoCarteira.IsVisible = false;
            TransactionExpander.IsVisible = true;
        }
        public void FecharExpansão(object sender, EventArgs e)
        {
            TextoCarteira.IsVisible = true;
            TransactionExpander.IsVisible = false;
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