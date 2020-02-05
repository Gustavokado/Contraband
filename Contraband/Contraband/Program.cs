using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contraband
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Random generator = new Random();

            Console.WriteLine("Hur många bilar vill du skapa?");
            int amount = 0;

            while (amount<=0)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out amount);

                if (!isNumber || amount==0)
                {
                    Console.WriteLine("Du måste skriva en siffra högre än 0");
                }
            }

            for (int i = 0; i < amount; i++)
            {
                if (generator.Next(2)==0)
                {
                    cars.Add(new CleanCar());
                }
                else
                {
                    cars.Add(new ContrabandCar());
                }
            }

            bool allChecked = false;

            while (!allChecked)
            {
                
                Console.WriteLine("Vilken bil vill du titta på?");
                int car = 0;
                while (car==0 || car>cars.Count)
                {
                    bool isNumber = int.TryParse(Console.ReadLine(), out car);

                    if (!isNumber || car == 0 || car > cars.Count)
                    {
                        Console.WriteLine("Du måste skriva en siffra mellan 1 och "+cars.Count);
                    }
                }

                int carIndex = car - 1;

                if (cars[carIndex].alreadyChecked)
                {
                    Console.WriteLine("Du har redan tittat på den bilen!");
                }
                else
                {
                    if (cars[carIndex].Examine())
                    {
                        Console.WriteLine("Den här bilen har stöldgods i sig!");
                    }
                    else
                    {
                        Console.WriteLine("Den här bilen har inte stöldgods i sig...");
                    }
                }
                

                int checkedCars = 0;
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].alreadyChecked)
                    {
                        checkedCars++;
                    }
                }
                if (checkedCars==cars.Count)
                {
                    allChecked = true;
                }
            }

            Console.WriteLine("Alla bilar har blivit tittade!");
            Console.ReadLine();
        } 
    }
}
