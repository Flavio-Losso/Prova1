using ControleDeBar.Visual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Produtos
{
    internal class TelaProduto : Tela
    {
        String op = "-1";
        GuardaProduto guardaProduto;
        public TelaProduto(GuardaProduto guardaProduto)
        {
            this.guardaProduto = guardaProduto;
        }

        public void Produto()
        {
            NewTela();
            String men = "Menu Produto\r\n";
            UpdateTela(men);
            Console.WriteLine("Digite 1 Para Inserir Produto\n\rDigite 2 Para Editar Produto\n\rDigite 3 Para Visualizar Produto\n\rDigite 4 Para Excluir Produto");
            op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    Inserir();
                    break;
                case "2":
                    Editar();
                    break;
                case "3":
                    Visualizar();
                    Console.ReadKey();
                    break;
                case "4":
                    Excluir();
                    break;
            }
        }

        private void Editar()
        {
            int m = Visualizar();
            if (m > 0)
            {
                Console.WriteLine("Informe o ID para Editar");
                int i = Convert.ToInt32(Console.ReadLine());
                Produto pAtualizado = guardaProduto.SelecionarId(i);
                guardaProduto.Editar(i, pAtualizado);
            }
        }

        private int Visualizar()
        {
            NewTela();
            UpdateTela("Produtos");
            int i = -1;
            ArrayList produto = guardaProduto.SelecionaTodos();
            if (produto.Count > 0)
            {
                Console.WriteLine("ID  |  Nome  |  Tipo  |  Descrição  |  Valor");
                foreach (Produto p in produto)
                {
                    Console.WriteLine($"{p.Id}  |  {p.Nome}  |  {p.Tipo}  |  {p.Descricao}  |  {p.Valor}");
                }
                i = 1;
            }
            else
            {
                Console.WriteLine("Não tem Produtos Cadastrados");
            }
            return i;
        }

        private void Excluir()
        {
            int p = Visualizar();
            if (p > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Informe o ID para Excluir ou escreva todos");
                string opcao = Console.ReadLine();
                if (opcao.Equals("todos", StringComparison.OrdinalIgnoreCase))
                {
                    guardaProduto.ExcluirTodos();
                }
                else
                {
                    int i = Convert.ToInt32(opcao);
                    guardaProduto.Excluir(i);
                }
            }
        }

        private void Inserir()
        {
            NewTela();
            UpdateTela("Insere Produto");
            Produto produto = new Produto();
            Console.WriteLine("Informe o nome do produto: ");
            produto.Nome = Console.ReadLine();
            Console.WriteLine("Informe o tipo do produto: ");
            produto.Tipo = Console.ReadLine();
            Console.WriteLine("Informe a descrição do produto: ");
            produto.Descricao = Console.ReadLine();
            Console.WriteLine("Informe o Valor do produto: ");
            produto.Valor = (float)Double.Parse(Console.ReadLine());
            guardaProduto.Inserir(produto);
        }
    }
}
