using App_BancoDigital.Model;
using App_BancoDigital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BancoDigital.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Listagem : ContentPage
	{
        ObservableCollection<Correntista> ListaCorrentistas = new ObservableCollection<Correntista>();
        public Listagem ()
		{
			InitializeComponent ();

            lst_correntistas.ItemsSource = ListaCorrentistas;
        }

        
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.FormAdd());
        }

        protected override void OnAppearing()
        {
            if (ListaCorrentistas.Count == 0)
            {
                /**
                 * Inicializando a Thread que irá buscar o array de objetos no arquivo db3
                 * via classe SQLiteDatabaseHelper encapsulada na propriedade Database da
                 * classe App.
                 */
                System.Threading.Tasks.Task.Run(async () =>
                {
                    /**
                     * Retornando o array de objetos vindos do db3, foi usada uma variável tem do tipo
                     * List para que abaixo no foreach possamos percorrer a lista temporária e add
                     * os itens à ObservableCollection
                     */
                    List<Correntista> temp = await DataServiceCorrentista.GetCorrentistasAsync();

                    foreach (Correntista item in temp)
                    {
                        ListaCorrentistas.Add(item);
                    }

                    /**
                     * Após carregar os registros para a ObservableCollection removemos o loading da tela.
                     */
                    // ref_carregando.IsRefreshing = false;
                });
            }
        }

        private async void getAllRows()
        {
            act_carregando.IsRunning = true;

            try
            {
                //List<Pessoa> arr_pessoa = await DataServicePessoa.GetAllRows();

                ListaCorrentistas.Clear();

                //arr_pessoa.ForEach(i => ListaPessoas.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");

            }
            finally
            {
                act_carregando.IsRunning = false;
            }
        }


        

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;

            try
            {
                List<Correntista> temp = await DataServiceCorrentista.SearchAsync(txt_q.Text);

                ListaCorrentistas.Clear();

                foreach (Correntista item in temp)
                {
                    ListaCorrentistas.Add(item);
                }
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

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;

            try
            {

                MenuItem menu = sender as MenuItem;
                Correntista correntista_selecionada = menu.BindingContext as Correntista;

                await DataServiceCorrentista.DeleteAsync(correntista_selecionada.Id);

                ListaCorrentistas.Remove(correntista_selecionada);
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