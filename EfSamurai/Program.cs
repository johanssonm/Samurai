using System;
using EfSamurai;

namespace EfSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }

        private static void AddOneSamurai()
        {
            var samuari = new Samurai { Name = "Zelda" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samuari);
                context.SaveChanges();
            }
        }
    }
}
