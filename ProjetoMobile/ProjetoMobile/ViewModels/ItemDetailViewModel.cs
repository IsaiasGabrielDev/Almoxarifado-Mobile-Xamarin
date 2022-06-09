using ProjetoMobile.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoMobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string _id;
        private string nome;
        private string quantidade;
        private DateTime? datafabricacao;
        private string lote;
        private DateTime? datavencimento;
        private string funcao;
        private string precocusto;
        private string precovendas;
        private string alocado;
        private string nomealocado;

        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }

        public string Quantidade
        {
            get => quantidade;
            set => SetProperty(ref quantidade, value);
        }

        public string Lote
        {
            get => lote;
            set => SetProperty(ref lote, value);
        }

        public DateTime? Datafabricacao
        {
            get => datafabricacao;
            set => SetProperty(ref datafabricacao, value);
        }

        public DateTime? Datavencimento
        {
            get => datavencimento;
            set => SetProperty(ref datavencimento, value);
        }

        public string Funcao
        {
            get => funcao;
            set => SetProperty(ref funcao, value);
        }

        public string Precocusto
        {
            get => precocusto;
            set => SetProperty(ref precocusto, value);
        }

        public string Precovendas
        {
            get => precovendas;
            set => SetProperty(ref precovendas, value);
        }

        public string Alocado
        {
            get => alocado;
            set => SetProperty(ref alocado, value);
        }

        public string Nomealocado
        {
            get => nomealocado;
            set => SetProperty(ref nomealocado, value);
        }


        public string ItemId
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item._id;
                Nome = item.nome;
                Lote = item.lote;
                Quantidade = item.quantidade;
                Datafabricacao = item.datafabricacao;
                Datavencimento = item.datavencimento;
                Funcao = item.funcao;
                Precocusto = item.precocusto;
                Precovendas = item.precovendas;
                Nomealocado = item.nomealocado;
                Alocado = item.alocado;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
