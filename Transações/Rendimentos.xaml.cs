using Mobile.Menu_e_Submenus;
using Mobile.Transações;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rendimentos : ContentPage
    {
        public Rendimentos()
        {
            InitializeComponent();
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

        public void Abrir_Carteira(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Carteira());
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

        private void Expansão(object sender, EventArgs e)
        {
            TextoRendimento.IsVisible = false;
            TransactionExpander.IsVisible = true;
        }
        private void Open_Productivity(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Rendimentos());
        }
        public void FecharExpansão(object sender, EventArgs e)
        {
            TextoRendimento.IsVisible = true;
            TransactionExpander.IsVisible = false;
        }

        private void Abrir_Assistencia(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Assistência());
        }

        private void Abrir_FaleConosco(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new FaleConosco());
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

        private static string valor;

        public static string GetValor()
        {
            return valor;
        }

        private static void SetValor(string value)
        {
            valor = value;
        }

        private void RecarregarGrafico(object sender, EventArgs e)
        {
            Chart1.Chart = new BarChart
            {
                Entries = entries,
                LabelTextSize = 35,
                ValueLabelOrientation = Orientation.Vertical,
                BackgroundColor = SKColor.Parse("#00ffffff"),
                LabelOrientation = Orientation.Vertical,
                LabelColor = SKColor.Parse("#ffffff"),
                AnimationDuration = TimeSpan.FromSeconds(3.0),
                Margin = 35.0f
            };
            VisualizarGraficoLabel.IsVisible = false;
        }

        private readonly ChartEntry[] entries = new[]
{
        new ChartEntry(10)
    {
        Label = "Janeiro",
        ValueLabel = "10",
        Color = SKColor.Parse("#2c3e50"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
    new ChartEntry(-20)
    {
        Label = "Fevereiro",
        ValueLabel = "-20",
        Color = SKColor.Parse("#77d065"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
    new ChartEntry(40)
    {
        Label = "Março",
        ValueLabel = "40",
        Color = SKColor.Parse("#b455b6"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
    new ChartEntry(50)
    {
        Label = "Abril",
        ValueLabel = "50",
        Color = SKColor.Parse("#3498db"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
        new ChartEntry(30)
    {
        Label = "Maio",
        ValueLabel = "30",
        Color = SKColor.Parse("#77d065"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
    new ChartEntry(40)
    {
        Label = "Junho",
        ValueLabel = "40",
        Color = SKColor.Parse("#b455b6"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
    new ChartEntry(-10)
    {
        Label = "Julho",
        ValueLabel = "-10",
        Color = SKColor.Parse("#3498db"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
        new ChartEntry(100)
    {
        Label = "Agosto",
        ValueLabel = "100",
        Color = SKColor.Parse("#77d065"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
    new ChartEntry(80)
    {
        Label = "Setembro",
        ValueLabel = "80",
        Color = SKColor.Parse("#b455b6"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
    new ChartEntry(80)
    {
        Label = "Outubro",
        ValueLabel = "80",
        Color = SKColor.Parse("#3498db"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
        new ChartEntry(60)
    {
        Label = "Novembro",
        ValueLabel = "60",
        Color = SKColor.Parse("#77d065"),
        ValueLabelColor = SKColor.Parse("#ffffff")
    },
    new ChartEntry(-200)
    {
        Label = "Dezembro",
        ValueLabel = "200",
        Color = SKColor.Parse("#3498db"),
        ValueLabelColor = SKColor.Parse("#ffffff"),
    }
    };
    }
}