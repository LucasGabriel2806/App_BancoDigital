using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital.View.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PixExibirQrCode : ContentPage
    {
        /**
        * https://github.com/iamlawrencev/QRCodeGenerator-Xamarin.Forms
        */
        public PixExibirQrCode()
        {
            InitializeComponent();
        }
    }
}