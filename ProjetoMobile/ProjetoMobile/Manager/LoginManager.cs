using ProjetoMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMobile.Manager
{
    public class LoginManager
    {
        public async Task<bool> FazerLoginAsync(string usuariotext, string senha)
        {
            Usuario usuario = new Usuario(usuariotext, senha);
            SolicitacaoService solicitacaoService = new SolicitacaoService();
            var resp = await solicitacaoService.PostAsync<Usuario>("http://10.0.2.2:3000/login", usuario);

            return resp;

        }       
    }
}
