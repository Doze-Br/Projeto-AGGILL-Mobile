using Mobile.Transações;
using MySqlConnector;
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
    public partial class MeuPerfil : ContentPage
    {
        public MeuPerfil()
        {
            MySqlConnection conexao;
            string strSQL;
            MySqlDataReader dr;
            MySqlCommand comando;

            MainPage main = new MainPage();
            string Emailperfil = main.GetEmail();

            InitializeComponent();

            Email.Text = Emailperfil;

            conexao = new MySqlConnection("Server=191.193.71.253;Port=3306;Database=aggill;Uid=raull;Pwd=ti7brgh4;");

            try
            {

                strSQL = "SELECT CAD_STR_NOME, CAD_STR_NASCIMENTO, CAD_STR_TELEFONE FROM aggill.cadastro where CAD_STR_EMAIL = @Email";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@Email", Emailperfil);
                conexao.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    Telefone.Text = Convert.ToString(dr["CAD_STR_TELEFONE"]);
                    NomeUsuario.Text = Convert.ToString(dr["CAD_STR_NOME"]);
                    DataNascimento.Text = Convert.ToString(dr["CAD_STR_NASCIMENTO"]);
                }
                conexao.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexao.Close();
                dr = null;
                comando = null;
                strSQL = null;
            }
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


        public void Abrir_Carteira(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Carteira();
        }
        private void Open_Swipe(object sender, EventArgs e)
        {
            Perfil.IsVisible = true;
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

        private void Expansão(object sender, EventArgs e)
        {
            Perfil.IsVisible = false;
            TransactionExpander.IsVisible = true;
        }
        private void Open_Productivity(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Rendimentos());
        }
        public void FecharExpansão(object sender, EventArgs e)
        {
            Perfil.IsVisible = true;
            TransactionExpander.IsVisible = false;
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