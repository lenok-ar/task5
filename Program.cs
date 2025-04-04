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
        }
    }
}
   