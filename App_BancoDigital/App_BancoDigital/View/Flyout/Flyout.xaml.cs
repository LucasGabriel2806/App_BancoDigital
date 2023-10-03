using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital.View.Flyout
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Flyout : FlyoutPage
	{
		public Flyout ()
		{
			InitializeComponent ();
		}

		/** Botão sair da conta */
        private void btn_Sair_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Sair", "Deseja sair da sua conta?", "NÃO", "SIM");
			

        }

        private void btn_Voltar_Clicked(object sender, EventArgs e)
        {

        }
    }
}