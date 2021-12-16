using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalQ1
{
    //Author:- Pruthviraj Solanki
    //Purpose:- Satisfy the needs for Final exam q1
    public class Program
    {
        //Author:- Pruthviraj Solanki
        //Purpose:- Count the number of character occurances in a string
        static void Main(string[] args)
        {
            string inputraw; 
            inputraw = Console.ReadLine().ToLower();//takibg input from user and converting it to lower case
            char[] inputChars = inputraw.ToCharArray();// storying it in a character array
            int[] count = new int[26];//creating an array to store count of each aphabet
            char temp = 'a';//temp variable to compare the string alphabets
            StringProperties stringRecord = new StringProperties(inputChars, count);//call to the structure 
            for (temp = 'a'; temp<='z'; temp++ )//going through all alphabets
            {
                foreach(char i in stringRecord.str)//goting though all characters in the character array
                {
                    if(i == temp)//comparing the characters with the one in temp
                    {
                        stringRecord.num[(int)i-'a']++; //to store the count at the right index the character's ascci value is substracted from the value of 'a' to bring it into 0-25 range.
                    }
                }
            }
            for (int i = 0; i < stringRecord.num.Length; i++) //printing the same
            {
                Console.WriteLine((char)('a' + i) + ": " + stringRecord.num[i]); //this time adding 'a' to i to bring it back to the original ascci value of the character.
            }
        }

        struct StringProperties
        {
            public char[] str;
            public int[] num;

            public StringProperties(char[] str, int[] num)
            {
                this.str = str;
                this.num = num;
            }
        }
    }
}