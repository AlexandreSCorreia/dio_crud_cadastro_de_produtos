using System;


namespace cadastroProdutos
{
    public class Produto : EntidadeBase
    {
        // Atributos
        private string Nome { get; set; }
        private Categorias Categorias { get; set; }
        private int Quantidade { get; set; }
        private float Preco { get; set; }
        private bool Excluido { get; set; }


        public Produto(int id, Categorias Categorias, string Nome, float Preco, int Quantidade)
        {
            this.Id = id;
            this.Categorias = Categorias;
            this.Nome = Nome;
            this.Preco = Preco;
            this.Quantidade = Quantidade;
            this.Excluido = false;
        }

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Categoria: " + this.Categorias + Environment.NewLine;
            retorno += "Preço: " + this.Preco + Environment.NewLine;
            retorno += "Quantidade: " + this.Quantidade + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}




