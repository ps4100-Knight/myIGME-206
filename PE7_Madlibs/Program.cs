using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PE7__MathLib
{
    // Author :- Pruthviraj Solanki (Knight)
    // Purpose :- A game of Madlibs
    class Program
    {
        // Author :- Pruthviraj Solanki (Knight)
        // Purpose :- A method that lets the user play a game of Madlibs
        static void Main(string[] args)
        {
            int libNum = 0; //to store number of stories available
            int cntr = 0; //to control array while doing replacement of //n with /n
            int choice = 0; //to store users choice of story number 
            string cPlay = "null"; // to store users choice about playing the game
            StreamReader input = null;

            string line = null; // to read different lines from the file and store them for counting 
            // instructions to users
            Console.WriteLine("Hello there!!!\n Do you want to play a good game of Madlibs?\n (Please say yes I worked hard on this code)\n");
            // loop to validate their choice for playing or not
            while(true)
            {
                cPlay = Console.ReadLine(); //users choice about playing or not
                if (cPlay.ToLower() == "yes") 
                {
                    Console.WriteLine("lets play Madlibs\n");
                    try //counting available libs
                    {
                        input = new StreamReader("MadLibsTemplate.txt");
                        while ((line = input.ReadLine()) != null)
                        {
                            ++libNum;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error with file: " + e.Message);
                    }
                    finally
                    {
                        if (input != null)
                        {
                            input.Close();
                        }
                    }
                    // Allocate as many strings as there are Mad Libs
                    string[] madLibs = new string[libNum];

                    // replacing \\n with \n
                    try
                    {

                        input = new StreamReader("MadLibsTemplate.txt");
                        line = null;
                        while ((line = input.ReadLine()) != null)
                        {  
                            madLibs[cntr] = line;
                            madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");
                            ++cntr;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error with file: " + e.Message);
                    }
                    finally
                    {
                        if (input != null)
                        {
                            input.Close();
                        }
                    }
                    // prompting user for story number they want to play
                    Console.WriteLine("Which story do you wanna play? \n Enter number from 1 to " + libNum + "\n");
                    while (true)
                    {
                        try //handling non-numaric inputs
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Invalid entry, Please enter a numaric value\n");
                        }
                        // checking if the entered numaric value is in range of available stories 
                        if (choice <= 0 || choice > libNum)
                        {
                            Console.WriteLine("Invalid choice\n");

                        }
                        else 
                        {
                            break;
                        }
                    }
                    choice--; //decrementing the choice by 1 since array starts from 0 to balance it out
                    string[] words = madLibs[choice].Split(' ');
                    string result = "";
                    foreach (string word in words)
                    {
                        // if word is a placeholder
                        // prompt the user for the replacement
                        // and append the user response to the result string
                        // else append word to the result string
                        if (word.StartsWith("{"))
                        {
                            string pword;
                            pword = word.Replace('{', ' ');
                            pword = pword.Replace('}', ' ');
                            pword = pword.Replace('_', ' ');
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
                    break;
                }
                else if (cPlay.ToLower() == "no") //if for some reason user does not want to play
                {
                    Console.WriteLine("Alright, Have a nice day, Goodbye\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice\n Please enter 'Yes' or 'No' \n");
                }
            }    

           
        }
    }
}