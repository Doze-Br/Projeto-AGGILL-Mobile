using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        string confirmasenha;
        public static string email;

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string value)
        {
            email = value;
        }

        public MainPage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }
        public void Efetuar_Login(object sender, EventArgs e)
        {
            MySqlConnection conexao;
            string strSQL;
            MySqlDataReader dr;
            MySqlCommand comando;


            SetEmail(EmailEntry.Text);
            var senha = PasswordEntry.Text;

            conexao = new MySqlConnection("Server=191.193.71.253;Port=3306;Database=aggill;Uid=raull;Pwd=ti7brgh4;");
            try
            {
                strSQL = "SELECT CAD_STR_SENHA FROM aggill.cadastro where CAD_STR_EMAIL = @Email";
                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@Email", GetEmail());
                conexao.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    confirmasenha = Convert.ToString(dr["CAD_STR_SENHA"]);
                }
                conexao.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conexao.Close();
                strSQL = null;
                comando = null;
                dr = null;
            }

            if (senha != null && senha != "" && GetEmail() != null && GetEmail() != "" && EmailEntry.TextColor == Color.Black && senha == confirmasenha)
            {
                Application.Current.MainPage = new NavigationPage(new PaginaPrincipal());
            }
            else if (GetEmail() == null || GetEmail() == "")
            {
                GridEmail.IsVisible = true;
                ErrorMessageEmail.IsVisible = true;
                if (senha == null || senha == "")
                {
                    GridPassword.IsVisible = true;
                    ErrorMessagePassword.IsVisible = true;
                }
            }
            else if (GetEmail() != null || GetEmail() != "")
            {
                if (senha == null || senha == "")
                {
                    GridPassword.IsVisible = true;
                    ErrorMessagePassword.IsVisible = true;
                }
                else if (confirmasenha == null || confirmasenha == "")
                {
                    GridEmail.IsVisible = true;
                    ErrorMessageEmail.IsVisible = true;
                    ErrorMessageEmail.Text = "Esse e-mail não está cadastrado no sistema!";
                }
                else if (senha != confirmasenha)
                {
                    GridPassword.IsVisible = true;
                    ErrorMessagePassword.IsVisible = true;
                    ErrorMessagePassword.Text = "Senha incorreta!";
                }
                else if (EmailEntry.TextColor == Color.DarkRed)
                {
                    GridEmail.IsVisible = true;
                    ErrorMessageEmail.IsVisible = true;
                    ErrorMessageEmail.Text = "O formato de email não é válido!";
                }
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage = new MainPage();
                });
            }
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var exit = await this.DisplayAlert("Alerta", "Você deseja sair da aplicação?", "Sim", "Não").ConfigureAwait(false);

                if (exit)
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            });
            return true;
        }

        private void Close_ErrorPassword(object sender, EventArgs e)
        {
            PasswordEntry.Focus();
            GridPassword.IsVisible = false;
            ErrorMessagePassword.IsVisible = false;
        }

        private void Close_ErrorEmail(object sender, EventArgs e)
        {
            EmailEntry.Focus();
            GridEmail.IsVisible = false;
            ErrorMessageEmail.IsVisible = false;
        }
    }
}
