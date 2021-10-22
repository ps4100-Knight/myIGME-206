using System;

namespace StructToClass
{
    // Author : Pruthviraj Solanki (Knight)
    // Purpose : Modifying the code to use class instread of struct
    class Friend //  struct to class
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;
        public Friend()  // default constructor
        {
        }
        public Friend(Friend f)  // Constructor passing an object
        {
            f.name = name;
            f.greeting = greeting;
            f.birthdate = birthdate;
            f.address = address;
        }
    }



    class Program
    {

        static void Main(string[] args)
        {
            Friend friend = new Friend();  //  new object of the class initiated


            // create my friend Charlie Sheen
            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            Friend enemy = new Friend(friend);  // Initializing new objects of the class
            //enemy = friend;

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }
}