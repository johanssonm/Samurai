﻿using System;
using System.Collections.Generic;
using EfSamurai;
using static EfSamurai.QuoteType;

namespace EfSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            // AddSamurais();

            AddBattles();

            Console.WriteLine("Allt är kört");
            Console.ReadKey();
        }

        private static void AddBattles()
        {
            var battle = new Battle()
            {
                Name = "Tokyo",
                Brutal = true,
                Battlelog = new Battlelog(),
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1)
            };

            var battle1 = new Battle()
            {
                Name = "Kyoto",
                Brutal = false,
                Battlelog = new Battlelog(),
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(14)
            };

            var battle2 = new Battle()
            {
                Name = "Hiroshima",
                Brutal = true,
                Battlelog = new Battlelog(),
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(14)
            };


            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(battle, battle1, battle2);
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
                Battle = new Battle(),
                Identity = new SecretIdentity() { Name = "Perciwall" },
            };

            var samurai1 = new Samurai
            {
                Name = "Quiff",
                Quote = new Quote() { Text = "Citatet", Type = Cheesy },
                Hairstyle = HairStyle.Western,
                Battle = new Battle(),
                Identity = new SecretIdentity() { Name = "Frank" },
            };

            var samurai2 = new Samurai
            {
                Name = "Databas",
                Quote = new Quote() { Text = "Citatet", Type = Lame },
                Hairstyle = HairStyle.Oicho,
                Identity = new SecretIdentity() { Name = "Kasaban" },
                Battle = new Battle()
            };


            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samuari,samurai1,samurai2);
                context.SaveChanges();
            }
        }
    }
}
