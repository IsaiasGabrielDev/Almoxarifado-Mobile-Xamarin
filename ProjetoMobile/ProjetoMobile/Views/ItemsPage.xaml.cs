using ProjetoMobile.Manager;
using ProjetoMobile.Models;
using ProjetoMobile.Services;
using ProjetoMobile.ViewModels;
using ProjetoMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoMobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;
        bool interruptor = false;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemsViewModel();
            interruptor = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            Alerta();

        }

        public async void Alerta()
        {
            ProdutoManager produtoManager = new ProdutoManager();
            var items = await produtoManager.Listarprodutos();
            if (interruptor && items.Any(x => x.cordata.Contains("DarkRed")))
            {
                DisplayAlertbox();
                interruptor = false;
            }
        }

        public async Task DisplayAlertbox()
        {
            await DisplayAlert("Importante!", "Existem itens vencidos, consulte a lista", "Ok");
        }
    }
}