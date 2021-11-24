using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT3Q1
{
    //Author:- Pruthviraj Solanki
    //Purpose:- Create a program that satisfies the needs of question 1 of unit test 3
    class Program
    {
        //Author:- Pruthviraj Solanki (Knight)
        //Purpose:- Count the occurances of the characters in the string.
        static void Main(string[] args)
        {
            //prompt user for string input
            Console.WriteLine("Enter a string\n");
            string str = Console.ReadLine();
            string cstr = str;
            
            Console.WriteLine("String: " + str);
            while (str.Length > 0)
            {
                Console.Write(str[0] + " = ");
                int cal = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[0] == str[j])
                    {
                        cal++;
                    }
                }
                Console.WriteLine(cal);
                str = str.Replace(str[0].ToString(), string.Empty); //replace the character that has been counter with an empty.
            }
            string rstr = stringReverse(cstr);
            Console.WriteLine("The reversed string is \n " + rstr + "\n");
            checkPalindrom(cstr);
            
        }
        public static string stringReverse(string s)
        {
            char[] cArray = s.ToCharArray();
            Array.Reverse(cArray);
            return new string(cArray);
        }
        public static void checkPalindrom(string s)
        {
            StringBuilder strippedString = new StringBuilder();
            string nospaces;
            string stripped;
            string nospacesrev;
            foreach(char c in s)
            {
                if(!char.IsPunctuation(c))
                {
                    strippedString.Append(c);
                }
            }
           // Console.WriteLine("stripped string is \n" + strippedString);
            stripped = strippedString.ToString();
            nospaces = String.Concat(stripped.Where(c => !Char.IsWhiteSpace(c)));
           // Console.WriteLine("No spaces string is \n " + nospaces);
            nospacesrev = stringReverse(nospaces);
            if(string.Equals(nospaces.ToLower(),nospacesrev.ToLower()))
            {
                Console.WriteLine("The given string is palindrome\n");
            }
        }
    }
}
