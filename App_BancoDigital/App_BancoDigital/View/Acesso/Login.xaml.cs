using App_BancoDigital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital.View.Acesso 
{ 

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {


        public Login()
        {
            InitializeComponent();
        }

        private async void btn_Entrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Model.Correntista c = await DataServiceCorrentista.LoginAsync(new Model.Correntista
                {
                    /**
                     * Aqui os dados da digitados estão sendo atribuidos para
                     * as propriedades da classe Correntista.
                     */
                    Cpf = txt_cpf.Text,
                    Senha = txt_senha.Text,
                });

                /**
                 * Se o Id não for nulo, então fez o registro no banco de dados, 
                 * Se for nulo, não fez.
                 */
                if (c.Id != null)
                {
                    /**
                     * A propriedade DadosCorrentista da app.xaml.cs está recebendo esses
                     * dados. E depois indo pra TelaInicial
                     */
                    App.DadosCorrentista = c;
                    App.Current.MainPage = new NavigationPage(new View.TelaInicial());
                    //App.Current.MainPage = new View.TelaInicial();
                }
                else
                    throw new Exception("Dados de login inválidos.");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops!", ex.Message, "OK");
            }
        }

        private void btn_Cadastro_Clicked(object sender, EventArgs e)
        {
            /**
             * Botão que redireciona pra página de cadastro
             */
            Navigation.PushAsync(new View.Correntista.Cadastro());
        }
    }
}