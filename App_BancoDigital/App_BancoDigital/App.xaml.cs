using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App_BancoDigital
{
    public partial class App : Application
    {
        /**
        * Propriedade que Armazena os dados do Correntista após o login.
        */
        public static Model.Correntista DadosCorrentista { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Acesso.Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
