using System;
using System.Threading;

namespace JopeFinal
{
    abstract class Animal
    {
        protected int age;
        protected string name;
        protected string fav_food;
        protected string breed;
        protected bool hungry = false;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }
        public string Fav_food
        {
            get { return fav_food; }
            set { fav_food = value; }
        }

        public bool Hungry
        {
            get { return hungry; }
            set { hungry = value; }
        }

        public Animal(string _name, int _age, string _fav_food, string _breed, bool _hungry)
        {
            name = _name;
            age = _age;
            fav_food = _fav_food;
            breed = _breed;
            hungry = _hungry;
        }

        public void Eat(string food) //string foods värde varieras, beroende av Type
        {
            if (food == fav_food)
            {
                Hungry = false;
                Console.WriteLine("\nThe pet ate its favorite food, not hungry for now\n");
            }
            else
            {
                Hungry = true;
                Console.WriteLine("\nThe pet didnt liked the food, still hungry\n");
            }
        }
        public abstract void Interact(Ball ball);
        public abstract void Hungry_Animal();

    }

    class Cat : Animal
    {
        public Cat(string _name, int _age, string _fav_food, string _breed, bool _hungry) : base(_name, _age, _fav_food, _breed, _hungry)
        {
            name = _name;
            age = _age;
            fav_food = _fav_food;
            breed = _breed;
            hungry = _hungry;

        }
        public override void Hungry_Animal()
        {
            Random rnd = new Random();
            int hunger = rnd.Next(100, 102); //33% chans
            Console.WriteLine("{0} is on hunt", name);
            Thread.Sleep(5000);
            if (hunger == 101)
            {
                Hungry = true;
            }
            else
            {
                Hungry = false;
            }
        }

        public override void Interact(Ball ball) //egentilgen ball har inte så mycket betydelse här.
        {
            Console.WriteLine("\nWe need to check if {0} is in the mood to play. Depends on how hungry the cat is", name);
            Hungry_Animal();
            if (Hungry == true)
            {
                Console.WriteLine("Sadly the cat is still hungry and not in the mood\n");
            }
            else
            {
                Console.WriteLine("{0} found a mice and willing to play with the {1}\n", name, ball);
                Thread.Sleep(5000);
            }
        }

        public override string ToString() //visar endast name och breed
        {
            return string.Format("{0} {1}", name, breed);
        }
    }

    class Dog : Animal
    {
        protected int powerLevel; // denna var kommer att användes i lowerQuality metod
        public Dog(string _name, int _age, string _fav_food, string _breed, bool _hungry, int _powerLevel) : base(_name, _age, _fav_food, _breed, _hungry)
        {
            name = _name;
            age = _age;
            fav_food = _fav_food;
            breed = _breed;
            hungry = _hungry;
            powerLevel = _powerLevel;

        }
        public override void Hungry_Animal()
        {
            Random rnd = new Random();
            int hunger = rnd.Next(100, 102);
            Thread.Sleep(5000);
            if (hunger == 101)
            {
                Hungry = true;
            }
            else
            {
                Hungry = false;
            }
        }

        public override void Interact(Ball ball)
        {
            Console.WriteLine("\nWe need to check if {0} is hungry", name);
            Hungry_Animal();
            Console.WriteLine("It seems likee.....");
            Thread.Sleep(2000);
            if (Hungry == true)
            {
                Console.WriteLine("Sadly the dog is hungry, wont play now\n");
            }
            else
            {
                Console.WriteLine("{0} is ready to play\n", name);
                ball.LowerQuality(powerLevel); //skickar värden till parametern i Ball class --> metod
                Thread.Sleep(5000);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", name, breed);
        }
    }

    class Puppy : Dog
    {
        protected double months;
        public Puppy(string _name, int _age, string _fav_food, string _breed, bool _hungry, int _powerLevel, double _months) : base(_name, _age, _fav_food, _breed, _hungry, _powerLevel)
        {
            name = _name;
            age = _age;
            fav_food = _fav_food;
            breed = _breed;
            hungry = _hungry;
            powerLevel = _powerLevel;
            months = _months;

        }
        public override void Hungry_Animal()
        {
            Random rnd = new Random();
            int hunger = rnd.Next(100, 102);
            Thread.Sleep(5000);
            if (hunger == 101)
            {
                Hungry = true;
            }
            else
            {
                Hungry = false;
            }
        }

        public override void Interact(Ball ball)
        {
            Console.WriteLine("\nWe need to check if {0} is hungry", name);
            Hungry_Animal();
            Console.WriteLine("It seems likee.....");
            Thread.Sleep(2000);
            if (Hungry == true)
            {
                Console.WriteLine("Sadly the puppy is hungry\n");
            }
            else
            {
                Console.WriteLine("{0} is ready to play\n", name);
                ball.LowerQuality(powerLevel);
                Thread.Sleep(5000);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", name, breed);
        }
    }
}
