using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Produtos
{
    internal class Produto
    {
        private int id;
        private string nome;
        private string tipo;
        private string descricao;
        private float valor;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public float Valor { get => valor; set => valor = value; }
    }
}
