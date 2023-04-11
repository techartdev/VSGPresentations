using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Test:

            int cnt = 0;
            while (true)
            {
                if (cnt >= 100)
                {
                    goto Test;
                }
                cnt++;
            }
            
            Console.ReadLine();
        }
    }
}
