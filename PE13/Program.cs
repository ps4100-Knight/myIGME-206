using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    public abstract class Pet
    {
        public string name;
        public int age;

        public abstract void Eat();

        public abstract void Play();

        public abstract void GotoVet();
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public Pet()
        {

        }

        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

    }

    public interface ICat
    {
        void Eat();

        void Play();

        void Scratch();

        void Purr();
    }

    public interface IDog
    {
        void Eat();

        void Play();

        void Bark();

        void NeedWalk();

        void GotoVet();
    }

    public class Cat : Pet, ICat
    {
        Cat cat = new Cat();
        public override void Eat()
        {
            Console.WriteLine(cat.Name + "ate a banana\n");
        }

        public override void Play()
        {
            Console.WriteLine(cat.Name + "plays russian roulet\n");
        }

        public void Purr()
        {
            Console.WriteLine(cat.Name + "purrs in german\n");
        }

        public void Scratch()
        {
            Console.WriteLine(cat.Name + "scractchs is back on oven \n");
        }

        public override void GotoVet()
        {
            Console.WriteLine(cat.Name + "Goes to vet because of broken teeth\n");
        }
    }

    public class Dog : Pet, IDog
    {
        
       
      
        public override void Eat()
        {
            Console.WriteLine(Name + "ate a icecream sandwitch\n");
        }

        public override void Play()
        {
            Console.WriteLine(Name + "ate a icecream sandwitch\n");
        }

        public void Bark()
        {
            Console.WriteLine(Name + "barked when a butterfly came in house\n");
        }

        public void NeedWalk()
        {
            Console.WriteLine(Name + "needed a walk so he scrated the door\n");
        }

        public override void GotoVet()
        {
            Console.WriteLine(Name + "goes to vet because of constipation\n");
        }

        public Dog(string szlicense, string szName, int nAge) : base(szName, nAge)
        {
            
            
        }
        

    

    }

    public class Pets
    {
        List<Pet> petList = new List<Pet>();
        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public readonly int r;
        public int Count { get { return petList.Count; } }

        public void Add(Pet pet)
        {
            petList.Add(pet);
        }

        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }

        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();
            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                       
                        string name, inputAge, license;
                        int age;
                        
                        Console.Write("Dog's Name => ");
                        name = Console.ReadLine();
                        do
                        {
                            Console.Write("Age => ");
                            inputAge = Console.ReadLine();
                            if (int.TryParse(inputAge, out age)) break;
                        } while (true);

                        Console.Write("License => ");
                        license = Console.ReadLine();

                        dog = new Dog(license, name, age);
                        pets.Add(dog);
                    }
                    else
                    {
                       
                        cat = new Cat();
                        
                        Console.Write("Cat's Name => ");
                        cat.name = Console.ReadLine();
                        do
                        {
                            Console.Write("Age => ");
                            if (int.TryParse(Console.ReadLine(), out cat.age)) break;
                        } while (true);

                        pets.Add(cat);
                    }
                }
                else
                {
                 
                    int ranPet = rand.Next(0, pets.Count);
                    thisPet = pets[ranPet];
                    if (thisPet == null)
                    {
                        continue;
                    }
                    else
                    {
                        if (thisPet.GetType().Equals(typeof(Cat)))
                        {
                            iCat = (ICat)thisPet;
                            switch (rand.Next(0, 4))
                            {
                                case 0:
                                    iCat.Eat();
                                    break;
                                case 1:
                                    iCat.Play();
                                    break;
                                case 2:
                                    iCat.Purr();
                                    break;
                                case 3:
                                    iCat.Scratch();
                                    break;
                                default:
                                    Console.WriteLine("exception!");
                                    break;
                            }
                        }
                        else if (thisPet.GetType().Equals(typeof(Dog)))
                        {
                            iDog = (IDog)thisPet;
                            switch (rand.Next(0, 5))
                            {
                                case 0:
                                    iDog.Eat();
                                    break;
                                case 1:
                                    iDog.Play();
                                    break;
                                case 2:
                                    iDog.Bark();
                                    break;
                                case 3:
                                    iDog.NeedWalk();
                                    break;
                                case 4:
                                    iDog.GotoVet();
                                    break;
                                default:
                                    Console.WriteLine("exception!");
                                    break;
                            }
                        }

                    }

                }

            }
        }
    }
}
