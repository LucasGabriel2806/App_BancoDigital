using App_BancoDigital.View;
using App_BancoDigital.View.Acesso;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital
{
    [DesignTimeVisible(false)]

    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(TelaInicial)));
        }


        private async void btnFazer_Pix_Clicked(object sender, EventArgs e)
        {
            try
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(View.Pix.EnviarPix)));
                IsPresented = false;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops!", ex.Message, "OK");
            }
        }

        private async void btnReceber_Pix_Clicked(object sender, EventArgs e)
        {

            try
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(View.Pix.ReceberPix)));
                IsPresented = false;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops!", ex.Message, "OK");
            }

        }

        private async void BtnSairConta_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Sair", "Deseja sair da sua conta?", "NÃO", "SIM");
        }

        
    }
}