using ControleDeBar.Cliente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Cliente
{
    internal class GuardaMesa
    {
        private ArrayList listaMesa;
        private int id = 0;
        public GuardaMesa(ArrayList listaMesa)
        {
            this.listaMesa = listaMesa;
        }

        public void Inserir(Mesa mesa)
        {
            id++;
            mesa.Id= id;
            
            listaMesa.Add(mesa);
        }

        public Mesa SelecionarId(int id)
        {
            Mesa Selecionado = null;

            foreach (Mesa g in listaMesa)
            {
                if (g.Id == id)
                {
                    Selecionado = g;
                    break;
                }
            }

            return Selecionado;
        }

        public ArrayList SelecionaTodos()
        {
            return listaMesa;
        }

        public void Editar(int id, Mesa MesaAtualizada)
        {
            Mesa Mesa = SelecionarId(id);
            if (MesaAtualizada != null)
            {
                Mesa.Cor = MesaAtualizada.Cor;
                Mesa.Clientes = MesaAtualizada.Clientes;
            }
        }

        public void Excluir(int id)
        {
            Mesa mesa = SelecionarId(id);

            listaMesa.Remove(mesa);
        }
        public void ExcluirTodos()
        {
            listaMesa.Clear();
        }
    }
}
