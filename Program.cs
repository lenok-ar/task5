using System.Collections.Generic;

namespace task5
{
    internal class Program
    {
        public class SpellingCorrector
        {
            private Dictionary<string, string> incorrectWords = new Dictionary<string, string>
            {
                { "првет", "привет" },
                { "првиет", "привет" },
                { "пирвет", "привет" },
                { "здраствуйте", "здравствуйте" },
                { "здрасте", "здравствуйте" },
                { "здаров", "здравствуйте" }
            };

            public string CorrectWord(string word)
            {
                if (incorrectWords.ContainsKey(word))
                {
                    return incorrectWords[word];
                }
                else
                {
                    return word;
                }
            }
        }

        public static void Main(string[] args)
        {
            
        }
    }
}
   