using ProjetoMobile.ViewModels;
using ProjetoMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ProjetoMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            this.CurrentItem.CurrentItem = new LoginPage();
        }

        private void OnMenuItemClicked(object sender, EventArgs e)
        {
            this.CurrentItem.CurrentItem = new LoginPage();
            Shell.Current.FlyoutIsPresented = false; 
        }


    }
}
