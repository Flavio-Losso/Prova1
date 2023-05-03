using ControleDeBar.Produtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Conta
{
    internal class GuardaConta
    {
        private ArrayList listaContas;
        private int id = 0;
        public GuardaConta(ArrayList listaContas)
        {
            this.listaContas = listaContas;
        }

        public void Inserir(Conta conta)
        {
            id++;
            conta.Id = id;
            conta.Aberta = true;
            ArrayList aux = conta.QuantProduto;
            double tot = 0;
            foreach (Produto p in aux)
            {
                tot += p.Valor;
            }
            conta.Total = tot;
            listaContas.Add(conta);
        }

        public void Fechar(int id)
        {
            Conta conta = SelecionarId(id);
            if(conta != null)
            {
                conta.Aberta=false;
            }
        }

        public Conta SelecionarId(int id)
        {
            Conta Selecionado = null;

            foreach (Conta c in listaContas)
            {
                if (c.Id == id)
                {
                    Selecionado = c;
                    break;
                }
            }

            return Selecionado;
        }

        public ArrayList SelecionaTodos()
        {
            return listaContas;
        }

        public void Editar(int id, Conta ContaAtualizada)
        {
            Conta Conta = SelecionarId(id);
            if (ContaAtualizada != null)
            {
                Conta.Total = ContaAtualizada.Total;
                Conta.Garcom = ContaAtualizada.Garcom;
                Conta.Mesa = ContaAtualizada.Mesa;
                Conta.QuantProduto = ContaAtualizada.QuantProduto;
            }
        }

        public double TotalFaturado()
        {
            ArrayList conta = SelecionaTodos();
            double total = 0;
            foreach (Conta c in conta)
            {
                ArrayList prod = c.QuantProduto;
                foreach (Produto produto in prod)
                {
                    total += produto.Valor;
                }
            }
            return total;
        }
        
    }
}
