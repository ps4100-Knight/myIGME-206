using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PE7__MathLib
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLibs = 0;
            int cntr = 0;
            int nChoice = 0;

            StreamReader input;

            // open the template file to count how many Mad Libs it contains
            input = new StreamReader("MadLibsTemplate.txt");

            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                ++numLibs;
            }

            // close it
            input.Close();
            // only allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs];

            input = new StreamReader("MadLibsTemplate.txt");

            line = null;
            while ((line = input.ReadLine()) != null)
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = line;

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");

                ++cntr;
            }

            input.Close();


            string[] words = madLibs[nChoice].Split(' ');
            string result = "";
            foreach (string word in words)
            {
                // if word is a placeholder
                // prompt the user for the replacement
                // and append the user response to the result string
                // else append word to the result string
                if (word.StartsWith("{"))
                {
                    string pword = word;
                    pword.Replace('{', ' ');
                    pword.Replace('}', ' ');
                    Console.WriteLine("Enter a " + pword);
                    string add = Console.ReadLine();
                    result += " " + add;
                }
                else
                {
                    result += " " + word;
                }
            }
            Console.WriteLine(result);
        }
    }
}