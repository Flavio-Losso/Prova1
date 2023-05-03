using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Funcionario
{
    internal class GuardaGarcom
    {
        private ArrayList listaGarcom;
        private int id = 0;
        public GuardaGarcom(ArrayList listaGarcom)
        {
            this.listaGarcom = listaGarcom;
        }

        public void Inserir(Garcom garcom)
        {
            id++;
            garcom.Id= id;

            listaGarcom.Add(garcom);
        }

        public Garcom SelecionarId(int id)
        {
            Garcom Selecionado = null;

            foreach (Garcom c in listaGarcom)
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
            return listaGarcom;
        }

        public void Editar(int id, Garcom GarcomAtualizado)
        {
            Garcom Garcom = SelecionarId(id);
            if (GarcomAtualizado != null)
            {
                Garcom.Nome = GarcomAtualizado.Nome;
            }
        }

        public void Excluir(int id)
        {
            Garcom garcom = SelecionarId(id);

            listaGarcom.Remove(garcom);
        }
        public void ExcluirTodos()
        {
            listaGarcom.Clear();
        }
    }
}
