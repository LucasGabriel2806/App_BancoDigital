using App_BancoDigital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital.View.Correntista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
		public Cadastro ()
		{
			InitializeComponent ();
		}

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                Model.Correntista c = await DataServiceCorrentista.SaveAsync(new Model.Correntista
                {
                    Nome = txt_nome.Text,
                    Email = txt_email.Text,
                    Data_Nascimento = dtpck_data_nascimento.Date,
                    Cpf = txt_cpf.Text,
                    Senha = txt_senha.Text,
                });

                if (c.Id != null)
                {
                    await Navigation.PushAsync(new View.TelaInicial());
                }
                else
                    throw new Exception("Ocorreu um erro ao salvar seu cadastro.");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops!", ex.Message, "OK");
            }
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}