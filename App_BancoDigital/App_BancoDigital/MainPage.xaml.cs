using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_BancoDigital
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_Entrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = txt_email.Text;
                string senha = txt_senha.Text;

                if (PropriedadesApp.list_usuarios.Any(i => (i.Email == email && i.Senha == senha)))
                {
                    App.Current.Properties.Add("usuario_logado", email);
                    App.Current.MainPage = new Protegida();
                }
                else
                    throw new Exception("Dados incorretos, tente novamente.");

            }
            catch (Exception ex)
            {
                DisplayAlert("Ops!", ex.Message, "OK");
            }
        }
    }
}
