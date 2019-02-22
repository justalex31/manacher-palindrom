using System;
using System.IO;
using System.Text;

namespace Manacher
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = "";

            var projectLocation = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

            var t = DateTime.Now;

            using (StreamReader str = new StreamReader(projectLocation.Replace("bin", "") + "\\7.txt", Encoding.Default))
                lines = str.ReadToEnd();

            Console.WriteLine(Manacher.FindLongestPalindrome(lines));

            TimeSpan s = DateTime.Now - t;

            Console.WriteLine(s.TotalMilliseconds);
        }
    }
}
