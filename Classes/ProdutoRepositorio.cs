using System;
using System.Collections.Generic;


namespace cadastroProdutos
{
    public class ProdutoRepositorio : IRepositorio<Produto>
    {
        private List<Produto> listaProduto = new List<Produto>();

        public List<Produto> FindAll()
        {
            return listaProduto;
        }
        public Produto Find(int id)
        {
            return listaProduto[id];
        }
        public void Create(Produto objeto)
        {
            listaProduto.Add(objeto);
        }
        public void Destroy(int id)
        {
            listaProduto[id].Excluir();
        }
        public void Update(int id, Produto objeto)
        {
            listaProduto[id] = objeto;
        }
        public int NextId()
        {
            return listaProduto.Count;
        }
        public Produto RetornaPorId(int id)
        {
            return listaProduto[id];
        }
    }
}