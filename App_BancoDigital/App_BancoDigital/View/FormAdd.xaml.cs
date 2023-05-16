using System;
using App_BancoDigital.Model;
using App_BancoDigital.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAdd : ContentPage
	{
		public FormAdd ()
		{
			InitializeComponent ();
		}

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;

            try
            {
                Correntista p = await DataServiceCorrentista.Cadastrar(new Correntista
                {
                    Nome = txt_nome.Text,
                    Cpf = txt_cpf.Text,
                    Data_Nasc = dtpck_data_nasc.Date,
                    Senha = txt_senha.Text
                });

                string msg = $"Correntista inserido com sucesso. Código gerado: {p.Id} ";

                await DisplayAlert("Sucesso!", msg, "OK");

                await Navigation.PushAsync(new View.Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");

            }
            finally
            {
                act_carregando.IsRunning = false;
                act_carregando.IsVisible = false;
            }
        }
    }
}