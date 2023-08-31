using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaInicial : ContentPage
    {
        public TelaInicial()
        {
            InitializeComponent();

            txt_correntista.Text = App.DadosCorrentista.Nome;
        }

        private void btnFazer_Pix_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Pix.EnviarPix());
        }

        private void btnReceber_Pix_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Pix.ReceberPix());
        }

        private void btn_Sair_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Sair", "Deseja sair da sua conta?", "NÃO", "SIM");
        }

    }
}