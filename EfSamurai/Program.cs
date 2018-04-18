using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using EfSamurai;
using EfSamurai.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Remotion.Linq.Clauses;
using static EfSamurai.QuoteType;

namespace EfSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SamuraiContext();

            context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());

            var quote = "citat";

            var from = new DateTime(2018 - 04 - 18);
            var to = new DateTime(2018 - 04 - 18);
            var isBrutal = true;

            //AddSamurais();


            //AddBattles();

            //FindSamurais();

            //FindQuote(context);

            SearchforSamurai("Frank");

            // ReseedAllTables(context);

            ListAllBattles_WithLog(context, from, to, isBrutal);

            // Initialize(context);

            Console.WriteLine();
            Console.WriteLine("Allt är färdigt...");
            Console.ReadKey();
        }
        private static void ReseedAllTables(SamuraiContext _context)
        {
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Samurais', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('SecretIdentity', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Quotes', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Battles', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('BattleLog', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('BattleEvent', RESEED, 0)");
        }

        public static void Initialize(SamuraiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        static void ListAllBattles_WithLog(SamuraiContext context, DateTime from, DateTime to, bool isBrutal)

        {
            var result = new List<string>();

            var query = from b in context.Battle

                where b.Brutal.Equals(isBrutal)

                select new
                {
                    b.Name,
                    b.Battlelog.ID,
                    b.Battledescription.Description
                };

            var sb = new StringBuilder();

            sb.AppendLine("-----------------------------------------**-----------------------------------------------");

            foreach (var tmp in query)
            {
                sb.AppendLine(tmp.Name + " " + tmp.ID + " " + tmp.Description);
            }

            sb.AppendLine("---------------------------------------**-------------------------------------------------");

            Console.WriteLine(sb);
        }

        static void FindQuote(SamuraiContext context)
        {
            var samuraisbyid = context.Samurais.OrderBy(x => x.ID);

            Console.WriteLine("By NAME:");
            foreach (var tmp in samuraisbyid)
            {
                Console.WriteLine(tmp.ID + " " + tmp.Name);

                foreach (var x in tmp.Name)
                {
                    Console.Write(x);
                }
            }

        }

        static List<string> AllSamuariNameWithAlias(SamuraiContext context)
        {
            var result = new List<string>();

            var query = from s in context.Samurais

                select new
                {
                    s.Name,
                    i = s.Identity.Name
                };

            foreach (var tmp in query)
            {
                result.Add(tmp.Name + " alias " + tmp.i);
            }

            return result;
        }




        static void FindSamurais()
        {

            using (var context = new SamuraiContext())
            {

                var samurais = context.Samurais.ToList();
                var samuraisinorder = samurais.OrderByDescending(x => x.Name).Reverse();
                var samuraisbyid = samurais.OrderByDescending(x => x.ID).Reverse();

                Console.WriteLine("By NAME:");
                foreach (var tmp in samuraisinorder)
                {
                    Console.WriteLine(tmp.ID + " " + tmp.Name);
                }

                Console.WriteLine();

                Console.WriteLine("By ID:");

                foreach (var tmp in samuraisbyid)
                {
                    Console.WriteLine(tmp.ID + " " + tmp.Name);
                }
            }

        }

        static void SearchforSamurai(string name)
        {

            using (var context = new SamuraiContext())
            {


                var samurais = context.Samurais.Where(x => x.Identity.Name == name).ToList();


                foreach (var tmp in samurais)
                {
                  // Console.WriteLine("{0} - {1} - {2}", tmp.ID, tmp.Name, tmp.Identity.Name);
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
                Battledescription = new Battledescription() { Event = "Slaget vid Tokyo den 6 november 1632 var ett av de största fältslagen under det trettioåriga kriget.", Description = "Battle of Tokyo"}
            };

            var battle1 = new Battle()
            {
                Name = "Kyoto",
                Brutal = false,
                Battlelog = new Battlelog(),
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(7),
                Battledescription = new Battledescription() { Event = "Slaget vid Kyoto den 6 november 1632 var ett av de största fältslagen under det trettioåriga kriget.", Description = "Battle of Kyoto" }
            };

            var battle2 = new Battle()
            {
                Name = "Hiroshima",
                Brutal = true,
                Battlelog = new Battlelog(),
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(14),
                Battledescription = new Battledescription() { Event = "Slaget vid Hiroshima den 6 november 1632 var ett av de största fältslagen under det trettioåriga kriget.", Description = "Battle of Hiroshima" }

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
                Name = "Bob",
                Quote = new List<Quote> { new Quote { Text = "Nytt citat", Type = Awesome }},
                Hairstyle = HairStyle.Chonmage,
                Identity = new SecretIdentity() { Name = "Perciwall" },
            };

            var samurai1 = new Samurai
            {
                Name = "Quiff",
                Quote = new List<Quote> { new Quote { Text = "Ännu ett citat", Type = Lame } },
                Hairstyle = HairStyle.Western,
                Identity = new SecretIdentity() { Name = "Frank" },
            };

            var samurai2 = new Samurai
            {
                Name = "Page",
                Quote = new List<Quote> { new Quote { Text = "Mer citat ändå", Type = Cheesy } },
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
