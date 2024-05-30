using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHITOPIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            runJawabanNo1();
            runJawabanNo2();
            runJawabanNo3();
        }

        static void runJawabanNo1()
        {
            Console.WriteLine(@"
                                Jawaban No.1");
            CheckWeightedString("abbcccd");
        }

        static void runJawabanNo2()
        {
            Console.WriteLine(@"
                                Jawaban No.2");
            CheckIsBalanceBracket("{ [ ( ) ] }");
            CheckIsBalanceBracket("{ [ ( ] ) }");
            CheckIsBalanceBracket("{ ( ( [ ] ) [ ] ) [ ] }");

        }

        static void runJawabanNo3()
        {
            Console.WriteLine(@"
                                Jawaban No.3");
            HighestPalindrome();
        }

        static void CheckWeightedString(string input)
        {
            
            int[] queries = { 1, 3, 9, 8 };

            HashSet<int> weightString = new HashSet<int>();

            for(int i=0; i<input.Length; i++)
            {
                int weight = input[i] - 'a' + 1; 

                weightString.Add(weight);
                int weightsubstring = weight;
                for(int j = i + 1; j<input.Length && input[i] == input[j]; j++)
                {
                    weightsubstring += weight;
                    weightString.Add(weightsubstring);
                    i = j;
                }
            }

            Console.WriteLine("input : " + input);

            foreach (int q in queries)
            {
                if (weightString.Contains(q))
                {
                    Console.WriteLine(q + " => YES ");
                }
                else
                {
                    Console.WriteLine(q + " => NO ");
                }
            }
        }

        static void CheckIsBalanceBracket(string sample)
        {
            Dictionary<char, char> BracketPairs = new Dictionary<char, char>()
            {
                { '}', '{' },
                { ']', '[' },
                { ')', '(' },
            };

            Stack<char> BracketStack = new Stack<char>();

            foreach(char c in sample)
            {
                if ("[{(".Contains(c))
                {
                    BracketStack.Push(c);
                }
                else if (")}]".Contains(c))
                {
                    if(BracketStack.Count == 0 || BracketStack.Peek() != BracketPairs[c])
                    {
                        Console.WriteLine(sample + " => NO");
                        break;
                    }

                    BracketStack.Pop();
                }
            }
            if(BracketStack.Count == 0)
            {
                Console.WriteLine(sample + " => YES");
            }

        }

        static void HighestPalindrome()
        {
            string input = "3943";
            int k = 1;

            Console.WriteLine("input : " + input);
            Console.WriteLine("k : " + k);
        }
    }
}
