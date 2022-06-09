using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace ProjetoMobile.Models
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string senha { get; set; }

        public Usuario(string usuario, string senha)
        {
            this.usuario = usuario;
            this.senha = senha;
        }
    }

}
