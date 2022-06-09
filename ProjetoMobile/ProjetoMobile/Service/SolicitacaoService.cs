using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using ProjetoMobile.Models;
using System.Threading.Tasks;

namespace ProjetoMobile.Manager
{
    public class SolicitacaoService
    {

        public async Task<bool> PostAsync<T>(string url, T objeto)
        {
            // Serializa ou converte o Post criado em uma string JSON
            string content = JsonConvert.SerializeObject(objeto);
            HttpClient httpClient = new HttpClient(GetInsecureHandler());
            try
            {
                var resp = await httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
                var respfinal = JsonConvert.DeserializeObject<bool>(await resp.Content.ReadAsStringAsync());
                return respfinal;
            }
            catch(Exception ex)
            {
                return false;
            } 
        }

        public async Task<T> GetAsync<T>(string url)
        {


            HttpClient httpClient = new HttpClient(GetInsecureHandler());
            var resp = await httpClient.GetAsync(url);
            var stringresult = await resp.Content.ReadAsStringAsync();

            var item = JsonConvert.DeserializeObject<T>(stringresult);

            // Atualiza a UI inserindo um elemento na coleção
            return item;
        }

        public HttpClientHandler GetInsecureHandler()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

    }
}
