using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Core
{
    public class Keyboard
    {
        const int keyCount = 40;

        public char[] GenerateLetters(string word)
        {
            var letters = new char[keyCount];
            var lowercase = word.ToUpper();
            var random = new Random();

            for (int i = 0; i < word.Length; i++)
            {
                letters[i] = lowercase[i];
            }

            for (int i = word.Length; i < keyCount; i++)
            {
                letters[i] = (char)random.Next('А', 'Я' + 1);
            }

            for (int i = letters.Length - 1; i >= 1; i--)
            {
                int rnd = random.Next(i + 1);
                var temp = letters[rnd];
                letters[rnd] = letters[i];
                letters[i] = temp;
            }

            return letters;
        }
    }
}
