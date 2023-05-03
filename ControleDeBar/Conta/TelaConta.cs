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
            Console.WriteLine("Digite 1 Para Abrir Conta\n\rDigite 2 para Registrar ou Editar Pedidos\n\rDigite 3 para Fechar conta\n\rDigite 4 para Visualizar Contas\n\rDigite 5 para Visualizar total Faturado do dia\n\rDigite 6 para Editar produtos em contas");
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
            int m = Visualizar();
            if (m > 0)
            {
                int id=-1;
                Conta c = null;
                Console.WriteLine("Informe o ID da conta");
                while (c == null)
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    if (id != null && id >= 0)
                    {
                        c=guardaConta.SelecionarId(id);
                    }
                    else
                    {
                        Console.WriteLine("Id invalido tente novamente");
                    }
                    if(c == null) Console.WriteLine("Id invalido tente novamente");
                }
                ArrayList a = c.QuantProduto;
                while (true)
                {
                    int prods = 0;
                    foreach (Produto p in a)
                    {
                        Console.WriteLine($"Produto:{prods}  {p.Nome}  {p.Tipo}  {p.Valor}");
                        prods++;
                    }
                    Console.WriteLine("Digite 1 para remover e 2 para adicionar produtos e 3 para cancelar");
                    string aux = Console.ReadLine();
                    if (aux.Equals("1"))
                    {
                        Console.WriteLine("Informe o id do produto");
                        int idprod = Convert.ToInt32(Console.ReadLine());
                        if (idprod < 0 || idprod > a.Count)
                        {
                            Console.WriteLine("ID invalido");
                        }
                        else
                        {
                            a.RemoveAt(idprod);
                            Console.WriteLine("Produto removido com sucesso deseja remover mais algum? S/N");
                            string resposta = Console.ReadLine();
                            if (resposta.Equals("N", StringComparison.OrdinalIgnoreCase)) break;
                            else continue;
                        }
                    }else if (aux.Equals("2"))
                        
                    {
                        Produto prodnew = null;
                        bool continua = true;
                        while (prodnew == null || continua)
                        {
                            NewTela();
                            Console.WriteLine("Informe o ID do Produto : ");
                            int i = Convert.ToInt32(Console.ReadLine());
                            prodnew = guardaProduto.SelecionarId(i);
                            if (prodnew != null && !continua) break;
                            else if (prodnew == null)
                            {
                                Console.WriteLine("Favor Escrever um ID valido");
                                Console.ReadLine();
                            }
                            if (prodnew != null && continua)
                            {
                                int j = 0;
                                while (j <= 0)
                                {
                                    Console.WriteLine("Informe a quantidade de desse produto");
                                    j = Convert.ToInt32(Console.ReadLine());
                                    if (j <= 0)
                                    {
                                        Console.WriteLine("Informe a quantidade de produto não pode ser menor que 0");
                                    }
                                    else
                                    {
                                        for (int x = 0; x < j; x++)
                                        {
                                            a.Add(prodnew);
                                        }
                                        Console.WriteLine("Deseja continuar a adicionar produtos? S/N");
                                        string resposta = Console.ReadLine();
                                        if (resposta.Equals("N", StringComparison.OrdinalIgnoreCase)) continua = false;
                                    }
                                }
                            }
                            
                        }
                        break;
                    }
                    else if (aux.Equals("3"))
                    {
                        break;
                    }
                }
                if (id >= 0)
                {
                    c.QuantProduto = a;
                    guardaConta.Editar(id, c);
                }
            }
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
                bool continua = false;
                if (cAtualizada != null)
                {
                    Mesa mesa = null;
                    Garcom garcom = null;
                    Produto produto = null;
                    produtosMesa = cAtualizada.QuantProduto;
                    Console.WriteLine("Informe o novo ID da mesa");
                    int idmesa = Convert.ToInt32(Console.ReadLine());
                    while (mesa == null) {
                        mesa = guardaMesa.SelecionarId(idmesa);
                        if (mesa == null) Console.WriteLine("ID invalido tente novamente");
                    }
                    cAtualizada.Mesa = mesa;
                    int idgarcom;
                    Console.WriteLine("Informe o novo ID do garcom");
                    idgarcom = Convert.ToInt32(Console.ReadLine());
                    while (garcom == null)
                    {
                        garcom = guardaGarcom.SelecionarId(idgarcom);
                        if (garcom == null) Console.WriteLine("ID invalido tente novamente");
                    }
                    cAtualizada.Garcom = garcom;
                    bool pdA = false;
                    Console.WriteLine("Deseja Atualizar os produtos S/N");
                    string a = Console.ReadLine();
                    if (a.Equals("s", StringComparison.OrdinalIgnoreCase)) pdA = true;
                    if (pdA)
                    {
                        while (produto == null)
                        {
                            Console.WriteLine("Informe o ID do Produto : ");
                            int idprod = Convert.ToInt32(Console.ReadLine());
                            produto = guardaProduto.SelecionarId(i);
                            if (produto != null && !continua) break;
                            else if (produto == null)
                            {
                                Console.WriteLine("Favor Escrever um ID valido");
                                Console.ReadLine();
                            }
                            if (produto != null && continua)
                            {
                                int j = 0;
                                while (j <= 0)
                                {
                                    Console.WriteLine("Informe a quantidade de desse produto");
                                    j = Convert.ToInt32(Console.ReadLine());
                                    if (j <= 0)
                                    {
                                        Console.WriteLine("Informe a quantidade de produto não pode ser menor que 0");
                                    }
                                    else
                                    {
                                        for (int x = 0; x < j; x++)
                                        {
                                            produtosMesaAtualizado.Add(produto);
                                        }
                                        Console.WriteLine("Deseja continuar a adicionar produtos? S/N");
                                        string aux = Console.ReadLine();
                                        if (aux.Equals("N", StringComparison.OrdinalIgnoreCase)) continua = false;
                                    }
                                }
                            }
                            cAtualizada.QuantProduto = produtosMesaAtualizado;
                        }
                    }
                    else
                    {
                        cAtualizada.QuantProduto = produtosMesa;
                    }
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
                Console.WriteLine("ID  |  Cor da Mesa  |  Garçom  |  Total  |  Clientes na mesa  |  status");
                foreach (Conta c in conta)
                {
                    String aberta = "Aberta";
                    if (c.Aberta == false) aberta = "Fechada"; 
                    Console.WriteLine($"{c.Id}  |  Mesa: {c.Mesa.Cor}  |  {c.Garcom.Nome}  |  R${c.Total}  |  {c.Mesa.Clientes}  |  {aberta}");
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
