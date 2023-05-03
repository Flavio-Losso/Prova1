using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Produtos
{
    internal class GuardaProduto
    {
        private ArrayList listaProduto;
        private int id = 0;
        public GuardaProduto(ArrayList listaProduto)
        {
            this.listaProduto = listaProduto;
        }

        public void Inserir(Produto produto)
        {
            id++;
            produto.Id = id;

            listaProduto.Add(produto);
        }

        public Produto SelecionarId(int id)
        {
            Produto Selecionado = null;

            foreach (Produto p in listaProduto)
            {
                if (p.Id == id)
                {
                    Selecionado = p;
                    break;
                }
            }

            return Selecionado;
        }

        public ArrayList SelecionaTodos()
        {
            return listaProduto;
        }

        public void Editar(int id, Produto ProdutoAtualizado)
        {
            Produto produto = SelecionarId(id);
            if (ProdutoAtualizado != null)
            {
                produto.Nome = ProdutoAtualizado.Nome;
                produto.Tipo = ProdutoAtualizado.Tipo;
                produto.Valor = ProdutoAtualizado.Valor;
                produto.Descricao = ProdutoAtualizado.Descricao;
            }
        }

        public void Excluir(int id)
        {
            Produto produto = SelecionarId(id);

            listaProduto.Remove(produto);
        }
        public void ExcluirTodos()
        {
            listaProduto.Clear();
        }
    }
}
