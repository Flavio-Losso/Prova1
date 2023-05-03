using ControleDeBar.Visual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Funcionario
{
    internal class TelaGarcom : Tela
    {
        String op="-1";
        GuardaGarcom guardaGarcom;
        public TelaGarcom(GuardaGarcom guardaGarcom)
        {
            this.guardaGarcom = guardaGarcom;
        }

        public void Garcom()
        {
            NewTela();
            String men = "Menu Garçom\r\n";
            UpdateTela(men);
            Console.WriteLine("Digite 1 Para Inserir Garçom\n\rDigite 2 Para Editar Garçom\n\rDigite 3 Para Visualizar Garçom\n\rDigite 4 Para Excluir Garçom");
            op=Console.ReadLine();
            //Console.ReadLine();
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
                    break;
                case "4":
                    Excluir();
                    break;
            }
        }

        private void Editar()
        {
            int g = Visualizar();
            if (g > 0)
            {
                Console.WriteLine("Informe o ID para Editar");
                int i = Convert.ToInt32(Console.ReadLine());
                Garcom gAtualizado = guardaGarcom.SelecionarId(i);
                guardaGarcom.Editar(i, gAtualizado);
            }
        }

        private int Visualizar()
        {
            NewTela();
            UpdateTela("Garçons");
            int i = -1;
            ArrayList garcom=guardaGarcom.SelecionaTodos();
            if(garcom.Count > 0)
            {
                Console.WriteLine("ID  |  Nome");
                foreach (Garcom g in garcom)
                {
                    Console.WriteLine($"{g.Id}  |  {g.Nome}");
                }
                i = 1;
            }
            else
            {
                Console.WriteLine("Não tem garçons Cadastrados");
            }
            Console.ReadKey();
            return i;
        }

        private void Excluir()
        {
            int g=Visualizar();
            if (g > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Informe o ID para Excluir ou escreva todos");
                string opcao = Console.ReadLine();
                if (opcao.Equals("todos", StringComparison.OrdinalIgnoreCase))
                {
                    guardaGarcom.ExcluirTodos();
                }
                else
                {
                    int i = Convert.ToInt32(opcao);
                    guardaGarcom.Excluir(i);
                }
            }
        }

        private void Inserir()
        {
            NewTela();
            UpdateTela("Insere Garçom");
            Garcom garcom = new Garcom();
            Console.WriteLine("Informe o Nome do Garçom: ");
            garcom.Nome = Console.ReadLine();
            guardaGarcom.Inserir(garcom);
        }
    }
}
