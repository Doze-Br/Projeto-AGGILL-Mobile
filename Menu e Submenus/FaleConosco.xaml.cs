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
    public partial class FaleConosco : ContentPage
    {
        public FaleConosco()
        {
            InitializeComponent();
        }

        private int notaUsuário;

        private int GetNotaUsuário()
        {
            return notaUsuário;
        }

        private void SetNotaUsuário(int value)
        {
            notaUsuário = value;
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

        private void Expansão(object sender, EventArgs e)
        {
            TextoFale.IsVisible = false;
            TransactionExpander.IsVisible = true;
        }
        private void Open_Productivity(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Rendimentos());
        }
        public void FecharExpansão(object sender, EventArgs e)
        {
            TextoFale.IsVisible = true;
            TransactionExpander.IsVisible = false;
        }
        private void Abrir_Assistencia(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Assistência());
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

        public void Anim()
        {
            BtnEnvia1.IsVisible = false;
            BtnEnvia2.IsVisible = true;
            BoxLabel.IsVisible = true;
            EditReport.IsVisible = true;
        }

        private void RadioButtonPress(object sender, CheckedChangedEventArgs e)
        {
            if (R1.IsChecked == true)
            {
                SetNotaUsuário(1);
                Anim();
            }
            if (R2.IsChecked == true)
            {
                SetNotaUsuário(2);
                Anim();
            }
            if (R3.IsChecked == true)
            {
                SetNotaUsuário(3);
                Anim();
            }
            if (R4.IsChecked == true)
            {
                SetNotaUsuário(4);
                Anim();
            }
            if (R5.IsChecked == true)
            {
                SetNotaUsuário(5);
                Anim();
            }
            if (R6.IsChecked == true)
            {
                SetNotaUsuário(6);
                Anim();
            }
            if (R7.IsChecked == true)
            {
                SetNotaUsuário(7);
                Anim();
            }
        }

        private void EnviarBtn(object sender, EventArgs e)
        {
            BtnEnvia1.IsVisible = true;
            BtnEnvia2.IsVisible = false;
            BoxLabel.IsVisible = false;
            EditReport.IsVisible = false;

            DisplayAlert("Obrigado!", "Seu feedback foi enviado com sucesso para nós, muito obrigado! :)", "Ok");
        }

        private void BtnEnfeite(object sender, EventArgs e)
        {
            DisplayAlert("", "Selecione uma nota por favor", "Ok").ConfigureAwait(false);
        }
    }
}