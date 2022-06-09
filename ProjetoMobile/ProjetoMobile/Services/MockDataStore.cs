using ProjetoMobile.Manager;
using ProjetoMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMobile.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        public List<Item> items;

        public MockDataStore()
        {
                     
        }

        public async Task<List<Item>> PreencherItems()
        {
            ProdutoManager produtoManager = new ProdutoManager();
            var itens = await produtoManager.Listarprodutos();
    
            return itens;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg._id == item._id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg._id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var itens = await PreencherItems();
            return await Task.FromResult(itens.FirstOrDefault(s => s._id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            var itens = await PreencherItems();
            return await Task.FromResult(itens);
        }
    }
}