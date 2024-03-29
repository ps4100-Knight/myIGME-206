﻿using System.IO;
using System;
using System.Timers;

//Author :- Pruthviraj Solanki(Knight)
//Purpose :- Math quiz
static class Program

{

    static bool bTimeOut = false; //variable to check the timer out trigger
    static Timer timeOutTimer; 
    // Author:- Pruthviraj Solanki(Knight)
    // Purpose:- a math quiz with a timer of 5 seconds on each question 
    // Declaration:- There is a bug where after timer runs out and user presses enter it prompts the same question,
    // I am trying to figure out a way around that limitation of the timer class,
    // But I am running a bit short on time so I have made vairables and have done some experimental logic thats in the comments.
    // I don't know if it will affect my grade or not, hope it doesn't :)
    static void Main()
    {
        //to check if no answer was given in time
       // bool bNoAnswer = false;
        // store user name
        string myName = "";
        

        // string and int of # of questions
        string sQuestions = "";
        int nQuestions = 0;

        // string and base value related to difficulty
        string sDifficulty = "";
        int nMaxRange = 0;

        // constant for setting difficulty with 1 variable
        const int MAX_BASE = 10;

        // question and # correct counters
        int nCntr = 0;
        int nCorrect = 0;

        // operator picker
        int nOp = 0;

        // operands and solution
        int val1 = 0;
        int val2 = 0;
        int nAnswer = 0;

        // string and int for the response
        string sResponse = "";
        Int32 nResponse = 0;

        // boolean for checking valid input
        bool bValid = false;

        // play again?
        string sAgain = "";

        // seed the random number generator
        Random rand = new Random();

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Math Quiz!");
        Console.WriteLine();

        // fetch the user's name into myName
        while (true)
        {
            Console.Write("What is your name-> ");
            myName = Console.ReadLine();

            if (myName.Length > 0)
            {
                break;
            }
        }

    // label to return to if they want to play again
    start:

        // initialize correct responses for each time around
        nCorrect = 0;

        Console.WriteLine();

        do
        {
            Console.Write("How many questions-> ");
            sQuestions = Console.ReadLine();

            try
            {
                nQuestions = int.Parse(sQuestions);
                bValid = true;
            }
            catch
            {
                Console.WriteLine("Please enter an integer.");
                bValid = false;
            }

        } while (!bValid);

        Console.WriteLine();

        do
        {
            Console.Write("Difficulty level (easy, medium, hard)-> ");
            sDifficulty = Console.ReadLine();
        } while (sDifficulty.ToLower() != "easy" &&
                 sDifficulty.ToLower() != "medium" &&
                 sDifficulty.ToLower() != "hard");

        Console.WriteLine();

        // if they choose easy, then set nMaxRange = MAX_BASE, unless myName == "David", then set difficulty to hard
        // if they choose medium, set nMaxRange = MAX_BASE * 2
        // if they choose hard, set nMaxRange = MAX_BASE * 3
        switch (sDifficulty.ToLower())
        {
            case "easy":
                nMaxRange = MAX_BASE;
                if (myName.ToLower() == "david")
                {
                    goto case "hard";
                }
                break;

            case "medium":
                nMaxRange = MAX_BASE * 2;
                break;

            case "hard":
                nMaxRange = MAX_BASE * 3;
                break;
        }

        // ask each question
        for (nCntr = 0; nCntr < nQuestions; ++nCntr)
        {
            // generate a random number between 0 inclusive and 3 exclusive to get the operation
            nOp = rand.Next(0, 3);

            val1 = rand.Next(0, nMaxRange) + nMaxRange;
            val2 = rand.Next(0, nMaxRange);

            // if either argument is 0, pick new numbers
            if (val1 == 0 || val2 == 0)
            {
                // decrement counter to try this one again (because it will be incremented at the top of the loop)
                --nCntr;
                continue;
            }

            // if nOp == 0, then addition
            // if nOp == 1, then subtraction
            // else multiplication
            if (nOp == 0)
            {
                nAnswer = val1 + val2;
                sQuestions = $"Question #{nCntr + 1}: {val1} + {val2} => ";
            }
            else if (nOp == 1)
            {
                nAnswer = val1 - val2;
                sQuestions = $"Question #{nCntr + 1}: {val1} - {val2} => ";
            }
            else
            {
                nAnswer = val1 * val2;
                sQuestions = $"Question #{nCntr + 1}: {val1} * {val2} => ";
            }

            timeOutTimer = new Timer(5000); //creating a timer of 5 seconds

            ElapsedEventHandler elapsedEventHandler;

            elapsedEventHandler = new ElapsedEventHandler(Timesup); //calling the method Timesup in a timeout event

            timeOutTimer.Elapsed += elapsedEventHandler; 

            
            // display the question and prompt for the answer
            do
            {
                Console.Write(sQuestions);
                bTimeOut = false; 
                timeOutTimer.Start();//timer starts at prompt of question
           
                sResponse = Console.ReadLine();



               try
               {
                    if (bTimeOut == false)
                    {
                        nResponse = int.Parse(sResponse);
                    }
                    else
                    {

                        Console.WriteLine("Sorry your time ran out.\n");
                        //bNoAnswer = true;
                        bValid = true;
                    }
               }
               catch
               {
                    Console.WriteLine("Please enter an integer.");
                    bValid = false;
               }
            } while (!bValid);
            timeOutTimer.Stop(); //timer stops

            // if response == answer, output flashy reward and increment # correct
            // else output stark answer
           /* if (bNoAnswer == true)
            {
                Console.WriteLine("You did not attempt to answer the question\n");
            }*/
            if (nResponse == nAnswer && bTimeOut == false) //if answer is right and timer has not run out
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Well done, {0}!!!", myName);

                ++nCorrect;
            }
            else if (nResponse == nAnswer && bTimeOut == true)//if answer is right but timer has run out
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your answer is correct but you ran out of time so it will be considered as a wrong\n");
            }
            else if (nResponse != nAnswer && bTimeOut == true)//if answer is wrong and timer has run out
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your answer is incorrect and you ran out of time so it will be considered as a wrong\n");
            }
     
            else //if answer is wrong and timer has not run out
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm sorry {0}. The answer is {1}", myName, nAnswer);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }

        Console.WriteLine();

        // output how many they got correct and their score
        Console.WriteLine("You got {0} correct out of {1}, which is a score of {2:P2}", nCorrect, nQuestions, Convert.ToDouble(nCorrect) / (double)nCntr);
        Console.WriteLine();

        do
        {
            // prompt if they want to play again
            Console.Write("Do you want to play again? ");

            sAgain = Console.ReadLine();

            if (sAgain.ToLower().StartsWith("y"))
            {
                goto start;
            }
            else if (sAgain.ToLower().StartsWith("n"))
            {
                break;
            }
        } while (true);
    }
    //Author : Pruthviraj Solanki(Knight)
    //Purpose : Handling the timer elapsed event
    static void Timesup(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Times up, Late answer, it will be marked as wrong\n"); 
        bTimeOut = true;
    }
}