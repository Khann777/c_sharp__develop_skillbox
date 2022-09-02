using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            SplitSentence(sentence);
            Console.ReadKey();
        }

        static void ReverceSentence(string[] sentences)
        {
            Array.Reverse(sentences);
            Print(sentences);
        }

        static void SplitSentence(string sentence)
        {
            string[] sentences = sentence.Split(' ');
            ReverceSentence(sentences);
        }

        static void Print(string[] sentence)
        {
            foreach (string s in sentence) { Console.WriteLine(s); }
        }
    }
}
