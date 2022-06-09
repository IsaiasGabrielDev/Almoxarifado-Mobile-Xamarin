using ProjetoMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMobile.Manager
{
    public class ProdutoManager
    {
        public async Task<List<Item>> Listarprodutos()
        {
            SolicitacaoService solicitacaoService = new SolicitacaoService();
            var lista = await solicitacaoService.GetAsync<List<Item>>("http://10.0.2.2:3000/listarprodutos");


            var itensvencidos = lista.Where(x => x.datavencimento != null && DateTime.Now >= x.datavencimento.Value.AddDays(-7)).ToList();

            foreach (var item in lista)
            {
                item.cordata = "Gray";
            }

            foreach (var itemvencido in itensvencidos)
            {
                itemvencido.cordata = "DarkRed";
                lista.Remove(itemvencido);
            }

            lista = lista.OrderBy(x => x.datavencimento).ToList();

            itensvencidos.AddRange(lista);

            return itensvencidos;
        }
    }
}
