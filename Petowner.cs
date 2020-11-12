using System;
using System.Collections.Generic;
using System.IO;

namespace JopeFinal
{
    class PetOwner
    {
        protected int age;
        internal List<Animal> pets = new List<Animal> //list av animal, CTOR=attributes
        {
            new Cat("Abby", 4, "Lax", "StrongCat", true),
            new Cat("Ellie", 13, "Fireflies", "SneakyCat", true),
            new Dog("Medi", 10, "Strawberry", "GoodDog", true, 2),
            new Dog("Daisy", 5, "Duck", "YorkieDog", true, 2),
            new Puppy("Daphne", 0, "Turkey", "Puppy", true, 1, 0.6), //finns säkert en bättre sätt konvertera age to months
            new Puppy("Joel", 0, "Beef", "Puppy", true, 1, 0.6)

        };

        internal List<Ball> balls = new List<Ball> //samma som animal
        {
            new Ball("Red", 10),
            new Ball("Blue", 6),
            new Ball("Green", 8),
            new Ball("Yellow", 2),
            new Ball("Black", 0),
            new Ball("White", 4)
        };

        internal List<Food> foods = new List<Food> // samma som animal
        {
            new Food("Lax"),
            new Food("Fireflies"),
            new Food("Strawberry"),
            new Food("Duck"),
            new Food("Turkey"),
            new Food("Beef")
        };
        public PetOwner(int _age) // I program class tilldelas värden
        {
            _age = age;
        }

        public void SaveToTxt()
        {
            using (TextWriter tw = new StreamWriter(@"D:\\notesagain.txt")) // på system drive(C) det funka inte för mig.
            {
                tw.WriteLine("Food List: ");
                foreach (var i in foods)
                {
                    tw.WriteLine(string.Format("{0}", i.Type)); //loopar geno Food listan och skriver till text
                }
                tw.WriteLine("\n"); //outpot hnatering, separerar listorna
                tw.WriteLine("Animal List:");
                foreach(var i in pets)
                {
                    tw.WriteLine(string.Format("{0}, {1}, {2}, {3}",i.Name, i.Age, i.Breed, i.Fav_food));
                }
                tw.WriteLine("\n");
                tw.WriteLine("Boll list:");
                foreach(var i in balls)
                {
                    tw.WriteLine(string.Format("{0}, {1}", i.Color, i.Quality));
                }
                tw.Close(); //Stänger textwriter
            }
            Console.WriteLine("Saved\n");
        }
        public void Menu() // enkelt menu med switch
        {
            int controll;
            bool b = true;
            Console.WriteLine("Heej!! With this program you can manage Joppes farm. \nYou will see a menu and the only thing you need to do is just pressing the right numbers!");
            Console.WriteLine("Have fun!\n");

            do
            {
                Console.WriteLine("Function 1: Fetch the animals" +
                "\nFunction 2: Feed the animals" +
                "\nFunction 3: List of the animals" +
                "\nFunction 4: List of the balls" +
                "\nFunction 5: Check the quality of the balls and fix them" +
                "\nFunction 6: Check food storage" +
                "\nFunction 7: Save list to textfile" +
                "\nFunction 8: Shut down the program\n");
                controll = int.Parse(Console.ReadLine());
                if (controll == 8) //kontroll av loopen
                {
                    b = false;
                }
                switch (controll)
                {
                    case 1:
                        {
                            Fetch();
                        }
                        break;
                    case 2:
                        {
                            Feed();
                        }
                        break;
                    case 3:
                        {
                            List_Animals();
                        }
                        break;
                    case 4:
                        {
                            List_Balls();
                            break;
                        }
                    case 5:
                        {
                            CheckTheBall();
                        }
                        break;
                    case 6:
                        {
                            Check_Food();
                        }
                        break;
                    case 7:
                        {
                            SaveToTxt();
                        }
                        break;
                }
            }
            while (b);
        }
        public void Fetch()
        {
            bool b = true; //loop controll
            Console.WriteLine("\nChoose one animal u wanna play with. Press a number");
            List_Animals();
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("\nChoose a ball too");
            while (b)
            {
                List_Balls();
                int j = int.Parse(Console.ReadLine());
                if (balls[j - 1].Quality < 2) // j - 1 behövs eftersom använderen vet inte att i programmering vi räknar från 0
                {
                    Console.WriteLine("\nThis ball is unuseable, you need to choose another one");
                    balls.Remove(balls[j - 1]);
                    Console.WriteLine("Choose again");
                }
                else
                {
                    pets[i - 1].Interact(balls[j - 1]); // anropar metoden och skickar rätt värde till den
                    b = false;
                }
            }
        }
        public void Feed()
        {
            Console.WriteLine("Choose a pet by number\n");
            List_Animals();
            int petIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose a food by number\n");
            Check_Food();
            int j = int.Parse(Console.ReadLine());
            pets[petIndex - 1].Eat(foods[j - 1].Type); //anropar metoden i animal class
        }
        public void Check_Food() //skriver ut en lista
        {
            foreach (var i in foods)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");
        }
        public void List_Animals() // skriver ut en lista
        {
            int i = 0;
            foreach (var j in pets)
            {
                i++;
                Console.WriteLine(i + ": " + j);
            }
            Console.WriteLine("\n");
        }
        public void List_Balls() // skriver ut en lista
        {
            int i = 0;
            foreach (var j in balls)
            {
                i++;
                Console.WriteLine(i + ": " + j);
            }
        }
        public void CheckTheBall()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].Quality < 2)
                {
                    Console.WriteLine("Too low quality, we need to fix the " + balls[i] + ".\n");
                    balls[i].Quality = +5; //jag valde FOR istället för foreach, eftersom den till låter mer interaktion
                }
            }
            foreach (var i in balls)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");
        }
    }
    class Ball
    {
        private string color;
        private int quality;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public int Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        public Ball(string _color, int _quality)
        {
            color = _color;
            quality = _quality;
        }

        public int LowerQuality(int power)
        {
            quality -= power; //värden av power varieras, beroende av anroparen
            return quality;

        }

        public override string ToString()
        {
            return string.Format("{0} ball", color);
        }

    }
}
