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
	public partial class FormAdd : ContentPage
	{
		public FormAdd ()
		{
			InitializeComponent ();
		}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;

            try
            {
                Correntista p = await DataServiceCorrentista.Cadastrar(new Correntista
                {
                    Nome = txt_nome.Text,
                    Cpf = txt_cpf.Text,
                    Data_Nasc = dtpck_data_nasc.Date
                });

                string msg = $"Pessoa inserida com sucesso. Código gerado: {p.Id} ";

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