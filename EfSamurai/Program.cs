using System;
using EfSamurai;

namespace EfSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            // AddOneSamurai();

            // AddSomeSamurais();

            AddSomeBattles();

            Console.WriteLine("Allt är kört");

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


        private static void AddSomeSamurais()
        {
            var kolle = new Samurai { Name = "Kolle" };
            var ada = new Samurai { Name = "Ada" };
            var rasmus = new Samurai { Name = "Rasmus" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(kolle,ada,rasmus);
                context.SaveChanges();
            }
        }

        private static void AddSomeBattles()
        {
            var battle = new Battle("Kyoto", true,new DateTime(1977-07-01),new DateTime(77-07-02), "Super epic battle!");
            var battlelog = new Battlelog();
            var battledescription = new Battledescription();

            using (var context = new SamuraiContext())
            {
                context.AddRange(battle,battlelog,battledescription);
                context.SaveChanges();
            }
        }
    }
}
