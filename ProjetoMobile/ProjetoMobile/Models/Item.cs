using System;

namespace ProjetoMobile.Models
{
    public class Item
    {
        public string _id { get; set; }
        public string nome { get; set; }
        public string quantidade { get; set; }
        public string lote { get; set; }
        public DateTime? datafabricacao { get; set; }
        public DateTime? datavencimento { get; set; }
        public string funcao { get; set; }
        public string precocusto { get; set; }
        public string precovendas { get; set; }
        public string nomealocado { get; set; }
        public string alocado { get; set; }
        public string cordata { get; set; }
    }
}