using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Cliente
{
    internal class Mesa
    {
        private int id;
        private string cor;
        private int clientes;

        public int Id { get => id; set => id = value; }
        public string Cor { get => cor; set => cor = value; }
        public int Clientes { get => clientes; set => clientes = value; }
    }
}
