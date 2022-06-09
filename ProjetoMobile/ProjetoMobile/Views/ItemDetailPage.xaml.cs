using ProjetoMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjetoMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}