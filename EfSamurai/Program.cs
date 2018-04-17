using System;
using System.Collections.Generic;
using System.Linq;
using EfSamurai;
using Microsoft.EntityFrameworkCore.Internal;
using static EfSamurai.QuoteType;

namespace EfSamurai
{
    class Program
    {
        static void Main(string[] args)
        {

            //AddSamurais();
            //AddBattles();

            FindSamurais();

            Console.WriteLine();
            Console.WriteLine("Allt är kört...");
            Console.ReadKey();
        }

        static void FindSamurais()
        {

            using (var context = new SamuraiContext())
            {

                var samurais = context.Samurais.ToList();
                var tmplist = samurais.ToList().OrderByOrdinal();

                foreach (var tmp in tmplist)
                {
                    Console.WriteLine(tmp.Name);
                }
            }

        }


        private static void AddBattles()
        {
            var battle = new Battle()
            {
                Name = "Tokyo",
                Brutal = true,
                Battlelog = new Battlelog(),
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1),
                Battledescription = new Battledescription() { Title = "Tokyo", Description = "Battle of Tokyo"}
            };

            var battle1 = new Battle()
            {
                Name = "Kyoto",
                Brutal = false,
                Battlelog = new Battlelog(),
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(7),
                Battledescription = new Battledescription() { Title = "Kyoto", Description = "Battle of Kyoto" }
            };

            var battle2 = new Battle()
            {
                Name = "Hiroshima",
                Brutal = true,
                Battlelog = new Battlelog(),
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(14),
                Battledescription = new Battledescription() { Title = "Hiroshima", Description = "Battle of Hiroshima" }

            };


            using (var context = new SamuraiContext())
            {
                context.Battle.AddRange(battle, battle1, battle2);
                context.SaveChanges();
            }
        }

        private static void AddSamurais()
        {
            var samuari = new Samurai
            {
                Name = "Zelda",
                Quote = new Quote() {Text = "Citatet", Type = Awesome },
                Hairstyle = HairStyle.Chonmage,
                Identity = new SecretIdentity() { Name = "Perciwall" },
            };

            var samurai1 = new Samurai
            {
                Name = "Quiff",
                Quote = new Quote() { Text = "Citatet", Type = Cheesy },
                Hairstyle = HairStyle.Western,
                Identity = new SecretIdentity() { Name = "Frank" },
            };

            var samurai2 = new Samurai
            {
                Name = "Databas",
                Quote = new Quote() { Text = "Citatet", Type = Lame },
                Hairstyle = HairStyle.Oicho,
                Identity = new SecretIdentity() { Name = "Kasaban" },
            };


            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samuari,samurai1,samurai2);
                context.SaveChanges();
            }
        }
    }
}
