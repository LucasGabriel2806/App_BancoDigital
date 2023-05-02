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

        private async void btnSair_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Display alert retorna bool. sim(true) nao(false) cliquei em sim ele r=executa o if
                if (await DisplayAlert("Tem Certeza?", "Vai sair mesmo?", "Sim", "Não"))
                {
                    App.Current.Properties.Remove("PersistenciaUsuarioLogado");

                    App.Current.MainPage = new Login();
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Desculpe \n ", ex.Message, "OK");
            }
        }
    }
}
