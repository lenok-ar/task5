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

            public void GetDirectory(string pathDirectory)
            {
                foreach (string pathFile in Directory.GetFiles(pathDirectory, "*.txt", SearchOption.AllDirectories))
                {
                    GetAndCorrectFile(pathFile);
                }
            }

            public void GetAndCorrectFile(string pathFile)
            {
                try
                {
                    string textFile = File.ReadAllText(pathFile);
                    Console.WriteLine("\nСодержимое файла до изменений: \n{0}\n", textFile);

                    List<string> words = Regex.Split(textFile, @"(\W+)").ToList();
                    for (int word = 0; word < words.Count; ++word)
                    {
                        if (!Regex.IsMatch(words[word], @"^\W+$"))
                        {
                            words[word] = CorrectWord(words[word]);
                        }
                    }
                    textFile = string.Join("", words);

                    string pattern = @"\(\d{3}\)\s\d{3}-\d{2}-\d{2}";
                    textFile = Regex.Replace(textFile, pattern, "+380 $&".Replace("(0", "").Replace(") ", " ").Replace("-", " "));

                    File.WriteAllText(pathFile, textFile);

                    Console.WriteLine("Содержимое файла после изменений: \n{0}", textFile);                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                SpellingCorrector corrector = new SpellingCorrector();
                Console.Write("Введите путь к файлу: ");
                string pathFile = Console.ReadLine();
                corrector.GetAndCorrectFile(pathFile);
            } 
        }
    }
}
   