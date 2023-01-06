using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{

    class ReverseString
    {
        public static void Reverse()
        {
            String name = Utilities.Prompt("Enter the sentence");
            string[] temp = name.Split(' ');
            String store = "";
            for(int i=temp.Length-1;i>=0;i--)
            {
                store = string.Concat(store, temp[i]," ");
            }
            Console.WriteLine(store);
        }
        static void Main(string[] args)
        {
            Reverse();
        }
    }
}
