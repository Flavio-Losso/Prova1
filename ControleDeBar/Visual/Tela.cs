using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Visual
{
    internal class Tela
    {
        public void NewTela()
        {
            Console.Clear();
        }

        public void UpdateTela(String mensagem)
        {
            Console.WriteLine(mensagem);
            //Console.ReadLine();
        }
    }
}
