using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5
{
    public class Program
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
        public static string ReverceSentence(string[] sentences)
        {
            Array.Reverse(sentences);
            string newString = string.Join(" ", sentences);
            return newString;
        }

        /// <summary>
        /// Splits string into words and adds to array
        /// </summary>
        /// <param name="sentence">string to be splitted</param>
        public static string[] SplitSentence(string sentence)
        {
            string[] sentences = sentence.Split(' ');
            return sentences;
        }
        #endregion

        #region Print methods
        public static void Print(string[] sentence)
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
