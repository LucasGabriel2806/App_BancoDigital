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

        /**
         * Aqui você se cadastra
         */
        private async void Button_Clicked_Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Model.Correntista c = await DataServiceCorrentista.SaveAsync(new Model.Correntista
                {
                    /**
                     * Aqui as propriedades da classe Correntista estão
                     * sendo abastecidas pelos valores capturados na
                     * interface xaml
                     */
                    Nome = txt_nome.Text,
                    Email = txt_email.Text,
                    Data_Nascimento = dtpck_data_nascimento.Date,
                    Cpf = txt_cpf.Text,
                    Senha = txt_senha.Text
                });

                /**
                 * Se Id não for nulo(ou seja, se o banco de dados foi preenchido
                 * com sucesso)
                 */
                if (c.Id != null)
                {
                    /**
                     * Deixando gravado os dados do correntista que acabou de se cadastrar.
                     */ 
                    App.DadosCorrentista = c;
                    /**
                     * await espera a confirmação do DisplayAlert para prosseguir
                     */
                    await DisplayAlert("Sucesso!", "Correntista cadastrado com sucesso!", "OK");
                    /**
                     * Vai pra telaInicial
                     */
                    await Navigation.PushAsync(new View.TelaInicial());
                }   
                else
                    throw new Exception("Ocorreu um erro ao salvar seu cadastro.");
            }
            catch (Exception ex)
            {
                /**
                 * erro aqui
                 */
                await DisplayAlert("Ops!", ex.Message, "OK");
                Console.WriteLine("______________________________________________________");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("______________________________________________________");
            }
        }

        /**
         * Volta para a tela de Login.
         */
        private void Button_Clicked_Login(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}