using System;
using System.Collections.Generic;
using EfSamurai;
using static EfSamurai.QuoteType;

namespace EfSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            AddSamurais();
            Console.WriteLine("Allt är kört");
            Console.ReadKey();
        }

        private static void AddSamurais()
        {
            var samuari = new Samurai
            {
                Name = "Zelda",
                Quote = new Quote() {Text = "Citatet", Type = Awesome },
                Hairstyle = HairStyle.Chonmage,
                Battle = new Battle(),
                Identity = new SecretIdentity()
            };

            var samurai1 = new Samurai
            {
                Name = "Quiff",
                Quote = new Quote() { Text = "Citatet", Type = Awesome },
                Hairstyle = HairStyle.Chonmage,
                Battle = new Battle(),
                Identity = new SecretIdentity()
            };

            var samurai2 = new Samurai
            {
                Name = "Databas",
                Quote = new Quote() { Text = "Citatet", Type = Awesome },
                Hairstyle = HairStyle.Chonmage,
                Battle = new Battle(),
                Identity = new SecretIdentity()
            };


            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samuari,samurai1,samurai2);
                context.SaveChanges();
            }
        }
    }
}
