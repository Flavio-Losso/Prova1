using ControleDeBar.Cliente;
using ControleDeBar.Funcionario;
using ControleDeBar.Produtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Conta
{
    internal class Conta
    {
        private int id;
        private double total;
        private Mesa mesa;
        private Garcom garcom;
        private bool aberta;
        private ArrayList quantProduto;

        public double Total { get => total; set => total = value; }
        public bool Aberta { get => aberta; set => aberta = value; }
        public ArrayList QuantProduto { get => quantProduto; set => quantProduto = value; }
        public int Id { get => id; set => id = value; }
        internal Mesa Mesa { get => mesa; set => mesa = value; }
        internal Garcom Garcom { get => garcom; set => garcom = value; }
    }
}
