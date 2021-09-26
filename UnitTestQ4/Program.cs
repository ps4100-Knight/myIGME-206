
using System;
using System.Timers;

namespace UnitTestQ4
{
    //Author:- Pruthviraj Solanki (Knight)
    //Purpose:- Recreates 3questions program
    class Program
    {
        static Timer timer;
        static string[] sAnswer;
        static int nQ;
        static bool bElapsed;

        //Author:- Pruthviraj Solanki (Knight)
        //Purpose:- A method that recreates the given 3questions.exe file
        public static void Main(string[] args)
        {  
            string[] sQuestions = new string[3];
            sQuestions[0] = "What is your favorite color?";
            sQuestions[1] = "What is the answer to life, the universe and everything?";
            sQuestions[2] = "What is the airspeed velocity of an unladen swallow?";
            sAnswer = new string[3];
            sAnswer[0] = "black";
            sAnswer[1] = "42";
            sAnswer[2] = "What do you mean? African or European swallow?";
            timer = new Timer(5000.0);
            timer.Elapsed += new ElapsedEventHandler(TimesUp);
            string sRePlay = null; 
            do
            {
                Console.WriteLine();
                do
                {

                    Console.Write("Choose your question (1-3): ");
                    try
                    {
                        nQ = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Enter an interger between 1 and 3\n");
                    }
                }
                while ( nQ < 1 || nQ > 3);
                bElapsed = false;
                Console.WriteLine("You have 5 seconds to answer the following question:");
                Console.WriteLine(sQuestions[nQ - 1]);
                timer.Start();
                string sUserAnswer = Console.ReadLine();
                timer.Stop();
                if (!bElapsed)
                {
                    if (sUserAnswer == sAnswer[nQ - 1])
                    {
                        Console.WriteLine("Well done!");
                    }
                    else
                    { 
                        Console.WriteLine("Wrong!  The answer is: " + sAnswer[nQ - 1]);
                    }
                }
                while(true)
                {

                    if (sRePlay.Length < 1 || !sRePlay.ToLower().StartsWith("n") && !sRePlay.ToLower().StartsWith("y"))
                    {
                        Console.Write("Play again? ");
                        sRePlay = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            while (sRePlay.ToLower().StartsWith("y"));
        }

        public static void TimesUp(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            Console.WriteLine("Time's up!");
            Console.WriteLine("The answer is: " + sAnswer[nQ - 1]);
            Console.WriteLine("Please press enter.");
            bElapsed = true;
        }
    }
}

