using System;
using System.Collections.Generic;
using System.Text;

namespace Manacher
{
    class Manacher
    {
        internal static string FindLongestPalindrome(string lines)
        {
            char[] chars = Preprocess(lines);

            int[] lengths = new int[chars.Length];



            int right = 0, center = 0;

            for (int i = 1; i < (chars.Length - 1); i++)
            {

                if (right > i)
                {

                    int mirror = (2 * center) - i;

                    lengths[i] = Math.Min((right - i), lengths[mirror]);

                }

                while (chars[i - 1 - lengths[i]] == chars[i + 1 + lengths[i]])

                    lengths[i]++;

                if ((i + lengths[i]) > right)
                {

                    center = i;

                    right = i + lengths[i];

                }

            }

            return longestPalindromicSubstring(lines, lengths);
        }

        private static char[] Preprocess(String lines)
        {

            char[] chars = new char[(lines.Length * 2) + 3];

            chars[0] = (lines[0] != '$') ? '$' : '@';

            chars[chars.Length - 1] = (lines[lines.Length - 1] != '@') ? '@' : '$';

            for (int i = 0; i < lines.Length; i++)
            {

                chars[(i * 2) + 1] = '#';

                chars[(i * 2) + 2] = lines[i];

            }

            chars[chars.Length - 2] = '#';

            return chars;

        }

        private static String longestPalindromicSubstring(String input, int[] lengths)
        {

            int center = 0;

            int length = 0;

            for (int i = 1; i < (lengths.Length - 1); i++)
            {

                if (lengths[i] > length)
                {

                    length = lengths[i];

                    center = i;

                }

            }

            if (length > 1)
            {

                int leftEnd = (center - 1 - length) / 2;

                int rightEnd = (center - 1 + length) / 2;

                return input.Substring(leftEnd, rightEnd - leftEnd);

            }
            else
            {

                return "";

            }

        }
    }
}
