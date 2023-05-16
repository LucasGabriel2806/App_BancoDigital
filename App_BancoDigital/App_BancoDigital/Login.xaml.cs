using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        private string usuario_correto = "lucas";
        private string senha_correta = "123";
        public Login()
        {
            InitializeComponent();
        }

        private async void btnEntrar_Clicked(object sender, EventArgs e)
        {

            try
            {
                //Pegando o que o cara digitou e vendo se é igual o usuário correto
                if (usuario_correto.Equals(txt_usuario.Text) && senha_correta.Equals(txt_senha.Text))
                {
                    //Adicionando informando que o usuário está logado.
                    App.Current.Properties.Add("PersistenciaUsuarioLogado", txt_usuario.Text);

                    //Trocando para a página principal
                    App.Current.MainPage = new View.Listagem();
                }
                else
                {
                    throw new Exception("Dados incorretos");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Desculpe \n ", ex.Message, "OK");
            }

        }
    }
}