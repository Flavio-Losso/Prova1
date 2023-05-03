using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Visual
{
    internal class TelaInicial
    {
        public string MenuInicial()
        {
            Console.Clear();
            Console.WriteLine("\nBar da Galera\n\r");
            Console.WriteLine("Digite 1 para Menu Funcionarios");
            Console.WriteLine("Digite 2 para Menu Mesas");
            Console.WriteLine("Digite 3 para Menu Produtos");
            Console.WriteLine("Digite 4 para Menu Contas");
            Console.WriteLine("Digite s para sair");
            String op = Console.ReadLine();
            return op;
        }
    }
}
