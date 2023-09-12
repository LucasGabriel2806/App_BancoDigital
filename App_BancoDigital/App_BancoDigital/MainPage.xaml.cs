using App_BancoDigital.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(TelaInicial)));
        }



    }
}