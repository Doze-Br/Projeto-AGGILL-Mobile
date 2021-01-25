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
    public partial class Relatorio : ContentPage
    {
        string nome;
        string link;
        string titulo;
        string placeholdertext;
        string tituloInfomoney;
        public Relatorio()
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
            TextoRelatorio.IsVisible = false;
            TransactionExpander.IsVisible = true;
        }
        public void FecharExpansão(object sender, EventArgs e)
        {
            TextoRelatorio.IsVisible = true;
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
        private void Abrir_Grafico(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Grafico());
        }

        public void AtualizarRelatorio(object sender, EventArgs e)
        {
            var wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            string pagina = wc.DownloadString("https://cointimes.com.br/criptomoedas/bitcoin/analise-tecnica-preco-do-bitcoin");

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pagina);


            foreach (HtmlNode node in htmlDocument.DocumentNode.Descendants("article"))
            {
                if (node.Attributes.Count > 0)
                {
                    nome = node.Attributes["id"].Value;
                    titulo = node.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("post-title")).InnerText.Replace("\n", "");
                    link = "https://cointimes.com.br/" + titulo.Substring(1, titulo.Length - 3).Replace(",", "").Replace(" ", "-").ToLower().Replace("$", "").Replace("ê", "e").Replace("ç", "c");
                    titulo = titulo.Substring(1, titulo.Length - 3);
                    placeholdertext = node.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("post-content")).InnerText.Replace("\n", "").Replace("&#8220;", "").Replace("&#8221;", "").Replace("&#8230;", "") + "...";
                    var placeholdertextBytes = Encoding.UTF8.GetBytes(placeholdertext);
                    var novoplaceholderbytes = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, placeholdertextBytes);
                    placeholdertext = Encoding.ASCII.GetString(novoplaceholderbytes);
                    PlaceholderCointimes.Text = placeholdertext;
                    TituloCointimes.Text = titulo;
                    LinkCointimes.IsVisible = true;


                    break;
                }
            }
            var webclient = new WebClient();
            webclient.Encoding = System.Text.Encoding.UTF8;
            string paginaInfomoney = webclient.DownloadString("https://www.infomoney.com.br/tudo-sobre/bitcoin/");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(paginaInfomoney);

            foreach (HtmlNode node1 in doc.GetElementbyId("infiniteScroll").ChildNodes)
            {
                if (node1.Attributes.Count > 0)
                {
                    tituloInfomoney = node1.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("hl-title hl-title-2")).InnerText;
                    PlaceholderInfomoney.Text = tituloInfomoney;
                    TituloInfomoney.IsVisible = true;
                    LinkInfomoney.IsVisible = true;
                    break;
                }
            }
        }

        public async Task<bool> AbrirUrl2()
        {
            return await Launcher.TryOpenAsync("https://www.infomoney.com.br/tudo-sobre/bitcoin/");
        }

        public async Task<bool> AbrirUrl()
        {
            return await Launcher.TryOpenAsync(link);
        }

        private void Abrir_Cointimes(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await AbrirUrl();
            });
        }

        private void Abrir_Infomoney(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await AbrirUrl2();
            });
        }
    }
}