using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;
using System.Timers;
using System.Diagnostics;
using System.Threading;
namespace FinalQ23
{
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }
    //Author: Pruthviraj Solanki (Knight)
    //Purpose: Question 2 and 3 for the Final exam
    class Program
    {
        static int[,] mCGraph = new int[,]
        {
            //        A        B           D         C           E           G            F             H
            /*A*/{   -1,        1,        -1,       5,          -1,          -1,          -1,           -1  },
            /*B*/{   -1,       -1,         1,      -1,          -1,          -1,           7,           -1  },
            /*D*/{   -1,        1,        -1,       0,          -1,          -1,          -1,           -1  },
            /*C*/{   -1,       -1,         0,      -1,           2,          -1,          -1,           -1  },
            /*E*/{   -1,       -1,        -1,       2,          -1,           2,          -1,           -1  },
            /*G*/{   -1,       -1,        -1,      -1,           2,          -1,           1,           -1  },
            /*F*/{   -1,       -1,        -1,      -1,          -1,          -1,          -1,            4  },
            /*H*/{   -1,       -1,        -1,      -1,          -1,          -1,          -1,           -1  }
        };
        static (int, int)[][] firstListGraph = new (int, int)[][]
        {
            /* listGraph[0] A*/ new (int, int)[] {(1, 1), (3, 5)},
            /* listGraph[1] B*/ new (int, int)[] {(2, 1), (6, 7)},
            /* listGraph[2] D*/ new (int, int)[] {(1, 1), (3, 0)},
            /* listGraph[3] C*/ new (int, int)[] {(2, 0), (4, 2)},
            /* listGraph[4] E*/ new (int, int)[] {(3, 2), (5, 2)},
            /* listGraph[5] G*/ new (int, int)[] {(4, 2), (6, 1)},
            /* listGraph[6] F*/ new (int, int)[] {(7, 4)},
            /* listGraph[7] H*/ null
        };
        static Random rand = new Random();
        static System.Timers.Timer timer;
        static bool bTimedOut;
        static int secondsTaken;
        static string[] states = new string[]
        {
                "Gas",
                "Liquid",
                "Ice",
        };
        static (int, string, int)[][] listGraph = new (int, string, int)[][]
        {
            /* listGraph[0] A*/ new (int, string, int)[] {(1, states[1], 1), (3, states[0], 5)},
            /* listGraph[1] B*/ new (int, string, int)[] {(2, states[2], 1), (6, states[0], 7)},
            /* listGraph[2] D*/ new (int, string, int)[] {(1, states[1], 1), (3, states[0], 0)},
            /* listGraph[3] C*/ new (int, string, int)[] {(2, states[2], 0), (4, states[1], 2)},
            /* listGraph[4] E*/ new (int, string, int)[] {(3, states[0], 2), (5, states[2], 2)},
            /* listGraph[5] G*/ new (int, string, int)[] {(4, states[1], 2), (6, states[0],  1)},
            /* listGraph[6] F*/ new (int, string, int)[] {(7, states[1], 4)},
            /* listGraph[7] H*/ null
        };
        private static void Roomstates()
        {
            int nRoom = 0;
            int i = 0;
            Stopwatch sw = Stopwatch.StartNew();
            do
            {
                while (nRoom != 7)
                {
                    (int, string, int)[] thisRoomsNeighbors = listGraph[nRoom];
                    (int, string, int) nextRoom = thisRoomsNeighbors[0];
                    foreach ((int, string, int) room in thisRoomsNeighbors)
                    {
                        nextRoom = room;
                        if (room.Item2 == states[0])
                        {
                            nextRoom.Item2 = states[1];
                        }
                        else if (room.Item2 == states[1])
                        {
                            nextRoom.Item2 = states[2];
                        }
                        else if (room.Item2 == states[2])
                        {
                            nextRoom.Item2 = states[0];
                        }
                        thisRoomsNeighbors[i] = nextRoom;
                        listGraph[nRoom] = thisRoomsNeighbors;
                        i++;
                    }
                    i = 0;
                    nRoom++;
                }
                nRoom = 0;
                secondsTaken++;
                Thread.Sleep(1000);
            } while (true);     
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(Roomstates);
            thread.Start();
            int nRoom = 0;
            int turnCounter = 0;
            int playerHp = 5;
            int roomChosen = 0;
            string pResponse = null;
            string pState = states[0];
            string[] roomIndexes = new string[]
            {
                "A",
                "B",
                "D",
                "C",
                "E",
                "G",
                "F",
                "H"
            };
            while (nRoom != 7 && playerHp != 0)
            {
                (int, string, int)[] nextRooms = listGraph[nRoom];
                foreach ((int, string, int) n in nextRooms)
                {
                    if (playerHp > n.Item3)
                    {
                        Console.WriteLine("The exit to " + roomIndexes[n.Item1] + " costs " + n.Item3 + " Healthpoints");
                    }
                }
                Console.WriteLine("Your are currently: " + pState);
                Console.WriteLine("And your HP is: " + playerHp);
                Console.WriteLine("If you wish to leave the room press l, if you wanted wager your HP with a question press w and if you want to change your state press c");
                pResponse = Console.ReadLine().ToLower()[0].ToString();
                if (pResponse == "l")
                {
                    turnCounter++;
                    Console.WriteLine("Enter the room letter you want to move to.");
                    pResponse = Console.ReadLine().ToLower()[0].ToString();
                    for (int i = 0; i < roomIndexes.Length; i++)
                    {
                        if (pResponse == roomIndexes[i].ToLower())
                        {
                            roomChosen = i;
                        }
                    }
                    foreach ((int, string, int) neigh in nextRooms)
                    {
                        Console.WriteLine(neigh.Item2);
                        if (neigh.Item1 == roomChosen && pState == neigh.Item2)
                        {
                            nRoom = roomChosen;
                        }
                    }
                    Console.WriteLine("Your current HP is: " + playerHp);
                }
                else if (pResponse == "c")
                {
                    turnCounter++;
                    playerHp--;
                    if (pState == states[0])
                    {
                        pState = states[1];
                    }
                    else if (pState == states[1])
                    {
                        pState = states[2];
                    }
                    else if (pState == states[2])
                    {
                        pState = states[0];
                    }
                    Console.WriteLine("Now you are :" + pState);
                }
                else
                {
                    turnCounter++;
                    string url = null;
                    string s = null;
                    HttpWebRequest request;
                    HttpWebResponse response;
                    StreamReader reader;
                    url = "https://opentdb.com/api.php?amount=1&type=multiple";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream());
                    s = reader.ReadToEnd();
                    reader.Close();
                    Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);
                    trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
                    trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
                    for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
                    {
                        trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
                    }
                    string sWager = null;
                    int nWager = 0;
                    while(true)
                    {
                        Console.Write("Enter the amount of HP you would like to wager: ");
                        sWager = Console.ReadLine();
                        if (!int.TryParse(sWager, out nWager) || (nWager < 0) || (nWager > playerHp))
                        {
                            break;
                        }
                    }
                    Console.WriteLine(trivia.results[0].question);
                    int nAnswer = rand.Next(trivia.results[0].incorrect_answers.Count + 1);
                    int nWrongCntr = 0;
                    for (int i = 0; i < trivia.results[0].incorrect_answers.Count + 1; ++i)
                    {
                        if (i == nAnswer)
                        {
                            Console.WriteLine($"{i + 1}: {trivia.results[0].correct_answer}");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1}: {trivia.results[0].incorrect_answers[nWrongCntr]}");
                            ++nWrongCntr;
                        }
                    }
                    ++nAnswer;
                    timer = new System.Timers.Timer(15000);
                    timer.Elapsed += (o, e) => { bTimedOut = true; timer.Stop(); Console.WriteLine("Time's up. Press enter."); };
                    timer.Start();
                    Console.Write("==> ");
                    string sAnswer = Console.ReadLine();
                    timer.Stop();
                    sAnswer = nAnswer.ToString();
                    // if an incorrect answer
                    if (sAnswer != nAnswer.ToString() || bTimedOut)
                    {
                        Console.WriteLine("That is a wrong answer. The correct answer is :" + nAnswer);
                        playerHp -= nWager;
                    }
                    else
                    {
                        Console.WriteLine("That is the correct answer. You shall gain the HP amount you wagered");
                        playerHp += nWager;
                    }
                }
            }
            if (nRoom == 7)
            {
                Console.WriteLine("You have passed the labyrinth/n and you took " + turnCounter + " turns to do so." + "It took you " + secondsTaken + "Seconds to pass it.");
            }
            if (playerHp == 0)
            {
                Console.WriteLine("Unfortunatly you have run out of HP and are now dead to stay in the labyrinth forever. You wandered around to find the exit for " + secondsTaken + "using " + turnCounter + "turns. But now you are dead and your soul shall stay here forever.");
            }
        }
    }
}