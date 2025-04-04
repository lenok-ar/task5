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

            public void GetAndCorrectFile(string passFile)
            {
                string textFile = File.ReadAllText(passFile);
                Console.WriteLine("Содержимое файла до изменений: {0}", textFile);

            }
        }

        public static void Main(string[] args)
        {
            SpellingCorrector corrector = new SpellingCorrector();
            Console.Write("Введите путь к файлу: ");
            string pathFile = Console.ReadLine();
            
            corrector.GetAndCorrectFile(pathFile);
        }
    }
}
   