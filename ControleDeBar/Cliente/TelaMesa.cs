using ControleDeBar.Visual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Cliente
{
    internal class TelaMesa : Tela
    {
        String op = "-1";
        GuardaMesa guardaMesa;
        public TelaMesa(GuardaMesa guardaMesa)
        {
            this.guardaMesa = guardaMesa;
        }

        public void Mesa()
        {
            NewTela();
            String men = "Menu Mesa\r\n";
            UpdateTela(men);
            Console.WriteLine("Digite 1 Para Inserir Mesa\n\rDigite 2 Para Editar Mesa\n\rDigite 3 Para Visualizar Mesa\n\rDigite 4 Para Excluir Mesa");
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
                Mesa mAtualizada = guardaMesa.SelecionarId(i);
                guardaMesa.Editar(i, mAtualizada);
            }
        }

        private int Visualizar()
        {
            NewTela();
            UpdateTela("Mesas");
            int i = -1;
            ArrayList mesa = guardaMesa.SelecionaTodos();
            if (mesa.Count > 0)
            {
                Console.WriteLine("ID  |  Nome  |  Clientes");
                foreach (Mesa m in mesa)
                {
                    Console.WriteLine($"{m.Id}  |  {m.Cor}  |  {m.Clientes}");
                }
                i = 1;
            }
            else
            {
                Console.WriteLine("Não tem Mesas Cadastradas");
            }
            return i;
        }

        private void Excluir()
        {
            int m = Visualizar();
            if (m > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Informe o ID para Excluir ou escreva todos");
                string opcao = Console.ReadLine();
                if (opcao.Equals("todos", StringComparison.OrdinalIgnoreCase))
                {
                    guardaMesa.ExcluirTodos();
                }
                else
                {
                    int i = Convert.ToInt32(opcao);
                    guardaMesa.Excluir(i);
                }
            }
        }

        private void Inserir()
        {
            NewTela();
            UpdateTela("Insere Mesa");
            Mesa mesa = new Mesa();
            Console.WriteLine("Informe a cor da Mesa: ");
            mesa.Cor = Console.ReadLine();
            Console.WriteLine("Informe o total de clientes na mesa");
            mesa.Clientes=Convert.ToInt32(Console.ReadLine());
            guardaMesa.Inserir(mesa);
        }
    }
}
