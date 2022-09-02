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

        #region Split and Reverse methods

        /// <summary>
        /// Reverses string array
        /// </summary>
        /// <param name="sentences">String array to reverse</param>
        static void ReverceSentence(string[] sentences)
        {
            Array.Reverse(sentences);
            string newString = string.Join(" ", sentences);
            
            Print(newString);           // For Reversed string array, prints sentence
        }

        /// <summary>
        /// Splits string into words and adds to array
        /// </summary>
        /// <param name="sentence">string to be splitted</param>
        static void SplitSentence(string sentence)
        {
            string[] sentences = sentence.Split(' ');
            Print(sentences);       // For Splited words, prints words
            ReverceSentence(sentences);
        }
        #endregion

        #region Print methods
        static void Print(string[] sentence)
        {
            foreach (string s in sentence)
            { 
                Console.WriteLine(s); 
            }
        }

        static void Print(string sentence) 
        {
            Console.WriteLine(sentence);
        }
        #endregion
    }
}
