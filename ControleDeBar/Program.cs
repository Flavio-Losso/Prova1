using ControleDeBar.Cliente;
using ControleDeBar.Conta;
using ControleDeBar.Funcionario;
using ControleDeBar.Produtos;
using ControleDeBar.Visual;
using System.Collections;

namespace ControleDeBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GuardaGarcom guardaGarcom = new GuardaGarcom(new ArrayList());
            GuardaMesa guardaMesa = new GuardaMesa(new ArrayList());
            GuardaProduto guardaProduto = new GuardaProduto(new ArrayList());
            GuardaConta guardaConta = new GuardaConta(new ArrayList());
            TelaInicial T = new TelaInicial();
            TelaGarcom telaGarcom = new TelaGarcom(guardaGarcom);
            TelaMesa telaMesa = new TelaMesa(guardaMesa);
            TelaProduto telaProduto = new TelaProduto(guardaProduto);
            TelaConta telaConta = new TelaConta(guardaConta,guardaMesa,guardaGarcom,guardaProduto);

            while (true)
            {
                String op = T.MenuInicial();
                switch (op)
                {
                    case "1":
                        telaGarcom.Garcom();
                        break;
                    case "2":
                        telaMesa.Mesa();
                        break;
                    case "3":
                        telaProduto.Produto();
                        break;
                    case "4":
                        telaConta.Conta();
                        break;
                    case "s":
                        return;
                }
            }
        }
    }
}