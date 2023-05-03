using ControleDeBar.Cliente;
using ControleDeBar.Funcionario;
using ControleDeBar.Produtos;
using ControleDeBar.Visual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Conta
{
    internal class TelaConta : Tela 
    {
        String op = "-1";
        GuardaConta guardaConta;
        GuardaMesa guardaMesa;
        GuardaGarcom guardaGarcom;
        GuardaProduto guardaProduto;
        public TelaConta(GuardaConta guardaConta,GuardaMesa guardaMesa, GuardaGarcom guardaGarcom, GuardaProduto guardaProduto)
        {
            this.guardaConta = guardaConta;
            this.guardaMesa = guardaMesa;
            this.guardaGarcom = guardaGarcom;
            this.guardaProduto = guardaProduto;
        }

        public void Conta()
        {
            NewTela();
            String men = "Menu Conta\r\n";
            UpdateTela(men);
            Console.WriteLine("Digite 1 Para Abrir Conta\n\rDigite 2 para Registrar ou Editar Pedidos\n\rDigite 3 para Fechar conta\n\rDigite 4 para Visualizar total Faturado do dia");
            op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    Abrir();
                    break;
                case "2":
                    Editar();
                    break;
                case "3":
                    Fechar();
                    break;
                case "4":
                    Visualizar();
                    Console.ReadKey();
                    break;
                case "5":
                    VerTotal();
                    break;
                case "6":
                    InserirProdutos();
                    break;
            }
        }

        private void InserirProdutos()
        {
            throw new NotImplementedException();
        }

        private void Fechar()
        {
            int m = Visualizar();
            if (m > 0)
            {
                Console.WriteLine("Informe o ID para Fechar");
                int i = Convert.ToInt32(Console.ReadLine());
                guardaConta.Fechar(i);
            }
        }

        private void Editar()
        {
            int m = Visualizar();
            if (m > 0)
            {
                Console.WriteLine("Informe o ID para Editar");
                int i = Convert.ToInt32(Console.ReadLine());
                Conta cAtualizada = guardaConta.SelecionarId(i);
                ArrayList produtosMesa = null;
                ArrayList produtosMesaAtualizado = new ArrayList();
                bool continua = true;
                if (cAtualizada != null)
                {
                    Mesa mesa = null;
                    Garcom garcom = null;
                    Console.WriteLine("Informe o novo ID da mesa");
                    int idmesa= Convert.ToInt32(Console.ReadLine());
                    while (mesa == null) {
                        mesa = guardaMesa.SelecionarId(idmesa);
                        if (mesa == null) Console.WriteLine("ID invalido tente novamente");
                    }
                    cAtualizada.Mesa = mesa;
                    
                    conta.QuantProduto = produtosMesa;
                }
                guardaConta.Editar(i, cAtualizada);
            }
        }

        private int Visualizar()
        {
            NewTela();
            UpdateTela("Conta");
            int i = -1;
            ArrayList conta = guardaConta.SelecionaTodos();
            if (conta.Count > 0)
            {
                Console.WriteLine("ID  |  Cor da Mesa  |  Garçom  |  Total  |  Clientes na mesa");
                foreach (Conta c in conta)
                {
                    Console.WriteLine($"{c.Id}  |  Mesa: {c.Mesa.Cor}  |  {c.Garcom}  |  {c.Total}  |  {c.Mesa.Clientes}");
                }
                i = 1;
            }
            else
            {
                Console.WriteLine("Não tem Contas Cadastradas");
            }
            return i;
        }

        private void VerTotal()
        {
            double d=guardaConta.TotalFaturado();
            Console.WriteLine($"O total faturado do dia foi R${d}");
            Console.ReadKey();
        }

        private void Abrir()
        {
            Conta conta = new Conta();
            Mesa m = null;
            Garcom g = null;
            Produto p = null;
            NewTela();
            UpdateTela("Abre Conta");
            Console.ReadLine();
            while (m == null)
            {
                NewTela();
                Console.WriteLine("Informe o ID da mesa: ");
                int i = Convert.ToInt32(Console.ReadLine());
                m=guardaMesa.SelecionarId(i);
                if (m != null) break;
                else { Console.WriteLine("Favor Escrever um ID valido");
                    Console.ReadLine();
                }
            }
            conta.Mesa = m;
            while (g == null)
            {
                NewTela();
                Console.WriteLine("Informe o ID do garçom : ");
                int i = Convert.ToInt32(Console.ReadLine());
                g = guardaGarcom.SelecionarId(i);
                if (g != null) break;
                else
                {
                    Console.WriteLine("Favor Escrever um ID valido");
                    Console.ReadLine();
                }
            }
            conta.Garcom = g;
            ArrayList produtosMesa = new ArrayList();
            bool continua = true;
            while (p == null || continua)
            {
                NewTela();
                Console.WriteLine("Informe o ID do Produto : ");
                int i = Convert.ToInt32(Console.ReadLine());
                p = guardaProduto.SelecionarId(i);
                if (p != null && !continua) break;
                else if(p== null)
                {
                    Console.WriteLine("Favor Escrever um ID valido");
                    Console.ReadLine();
                }
                if(p != null &&  continua)
                {
                    int j = 0;
                    while (j <= 0)
                    {
                        Console.WriteLine("Informe a quantidade de desse produto");
                        j = Convert.ToInt32(Console.ReadLine());
                        if(j <= 0)
                        {
                            Console.WriteLine("Informe a quantidade de produto não pode ser menor que 0");
                        }
                        else
                        {
                            for(int x=0; x < j; x++)
                            {
                                produtosMesa.Add(p);
                            }
                            Console.WriteLine("Deseja continuar a adicionar produtos? S/N");
                            string aux= Console.ReadLine();
                            if(aux.Equals("N",StringComparison.OrdinalIgnoreCase)) continua = false;
                        }
                    }
                }
            }
            conta.QuantProduto = produtosMesa;
            guardaConta.Inserir(conta);
        }
    }
}
