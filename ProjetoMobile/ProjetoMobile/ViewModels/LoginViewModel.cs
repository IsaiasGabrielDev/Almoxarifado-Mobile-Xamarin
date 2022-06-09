using ProjetoMobile.Views;
using ProjetoMobile.Manager;
using ProjetoMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoMobile.ViewModels
{
    public class ObservableProperty : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class ViewModelBase : ObservableProperty
    {
        public Dictionary<string, ICommand> Commands { get; protected set; }

        public ViewModelBase()
        {
            Commands = new Dictionary<string, ICommand>();
        }
    }

    public class LoginViewModel : ViewModelBase
    {
        public Command LoginCommand { get; }
        string email = "";
        string senha= "";
        bool imgfailvisible = false;
        bool lbfailvisible = false;

        //public static readonly BindableProperty EmailProperty = BindableProperty.Create("Nome", typeof(string), typeof(LoginViewModel));
        //public static readonly BindableProperty SenhaProperty = BindableProperty.Create("Senha", typeof(string), typeof(LoginViewModel));
        //public static BindableProperty ImgfailvisibleProperty = BindableProperty.Create("Imgfailvisible", typeof(bool), typeof(LoginViewModel));
        //public static BindableProperty LbfailProperty = BindableProperty.Create("Lbfailvisible", typeof(bool), typeof(LoginViewModel));

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged("Senha");
            }
        }

        public bool Imgfailvisible
        {
            get { return imgfailvisible; }
            set
            {
                imgfailvisible = value;
                OnPropertyChanged("Imgfailvisible");
            }
        }

        public bool Lbfailvisible
        {
            get { return lbfailvisible; }
            set
            {
                lbfailvisible = value;
                OnPropertyChanged("Lbfailvisible");
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            Imgfailvisible = false;
            Lbfailvisible = false;
            Email = "";
            Senha = "";
        }

        private async void OnLoginClicked(object obj)
        {
            LoginManager loginManager = new LoginManager();
            var resp = await loginManager.FazerLoginAsync(Email, Senha);

            if (resp)
            {
                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
            }
            else
            {
                Imgfailvisible = true;
                Lbfailvisible = true;
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

        }
    }
}
