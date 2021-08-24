using System;


namespace cadastroProdutos
{
    class Program
    {
        static ProdutoRepositorio repositorio = new ProdutoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarProdutos();
                        break;
                    case "2":
                        InserirProduto();
                        break;
                    case "3":
                        AtualizarProduto();
                        break;
                    case "4":
                        ExcluirProduto();
                        break;
                    case "5":
                        VisualizarProduto();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Cadastro de Produtos a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar produtos");
            Console.WriteLine("2- Inserir novo produto");
            Console.WriteLine("3- Atualizar produto");
            Console.WriteLine("4- Excluir produto");
            Console.WriteLine("5- Visualizar produto");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarProdutos()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("=====  Listar produtos  =====");
            Console.WriteLine("=============================");
            Console.WriteLine();
            var lista = repositorio.FindAll();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            foreach (var produto in lista)
            {
                var excluido = produto.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", produto.retornaId(), produto.retornaNome(), (excluido ? "*Excluído*" : ""));
            }
        }


        private static void InserirProduto()
        {

            Console.WriteLine("==============================");
            Console.WriteLine("==  Adicionar novo produto  ==");
            Console.WriteLine("==============================");

            foreach (int i in Enum.GetValues(typeof(Categorias)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categorias), i));
            }

            Console.Write("Escolha uma categoria entre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Produto: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Valor do Produto: ");
            float entradaValor = float.Parse(Console.ReadLine());

            Console.Write("Digite a Quantidade de Unidades: ");
            int entradaQuantidade = int.Parse(Console.ReadLine());


            Produto novoProduto = new Produto(id: repositorio.NextId(),
                                        Categorias: (Categorias)entradaCategoria,
                                        Nome: entradaNome,
                                        Preco: entradaValor,
                                        Quantidade: entradaQuantidade);

            repositorio.Create(novoProduto);
        }

        private static void AtualizarProduto()
        {

            Console.WriteLine("==============================");
            Console.WriteLine("=====  Atualizar Produto  ====");
            Console.WriteLine("==============================");

            Console.Write("Digite o id do Produto: ");
            int indiceProduto = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Categorias)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categorias), i));
            }

            Console.Write("Escolha uma categoria entre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Produto: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Valor do Produto: ");
            float entradaValor = float.Parse(Console.ReadLine());

            Console.Write("Digite a Quantidade de Unidades: ");
            int entradaQuantidade = int.Parse(Console.ReadLine());


            Produto atualizarProduto = new Produto(id: indiceProduto,
                                        Categorias: (Categorias)entradaCategoria,
                                        Nome: entradaNome,
                                        Preco: entradaValor,
                                        Quantidade: entradaQuantidade);

            repositorio.Update(indiceProduto, atualizarProduto);
        }


        private static void ExcluirProduto()
        {

            try
            {
                Console.Write("Digite o id do Produto: ");
                int indiceProduto = int.Parse(Console.ReadLine());

                repositorio.Destroy(indiceProduto);
            }
            catch (Exception error)
            {
                Console.Write("Ocorreu um erro ao tentar excluir o produto, verifique o ID e tente novamente mais tarde..");
                Console.WriteLine();
            }


        }

        private static void VisualizarProduto()
        {

            try
            {
                Console.Write("Digite o id do produto: ");
                int indiceProduto = int.Parse(Console.ReadLine());

                var produto = repositorio.RetornaPorId(indiceProduto);

                Console.WriteLine(produto);
            }
            catch (Exception error)
            {

                Console.Write("Produto não encontrado, ou não existe fovar tentar novamente mais tarde.");
                Console.WriteLine();
            }


        }

    }
}
