using System.Collections.Generic;
using System.Text.RegularExpressions;

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
                return word;              
            }

            public void GetAndCorrectFile(string passFile)
            {
                string textFile = File.ReadAllText(passFile);
                Console.WriteLine("\nСодержимое файла до изменений: \n{0}\n", textFile);

                string[] words = textFile.Split(new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                for (int word = 0; word < words.Length; ++word)
                {
                    words[word] = CorrectWord(words[word]);              
                }
                textFile = string.Join(" ", words);

                string pattern = @"\(\d{3}\)\s\d{3}-\d{2}-\d{2}";
                textFile = Regex.Replace(textFile, pattern, "+380 $&".Replace("(0", "").Replace(") ", " ").Replace("-", " "));

                Console.WriteLine("Содержимое файла после изменений: \n{0}", textFile);
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
   