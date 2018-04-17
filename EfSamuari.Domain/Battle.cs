using System;
using System.Collections.Generic;
using System.Reflection;

namespace EfSamurai
{
    public class Battle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Brutal { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<SamuraiBattle> SamuraiBattle { get; set; }

        public Battlelog Battlelog { get; set; }


        public Battle(string name, bool brutal, DateTime start, DateTime end, string description)
        {

            Name = name;
            Brutal = brutal;
            Start = start;
            End = end;

            Battlelog = new Battlelog();

        }
    }

    public class Battlelog
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public Battledescription Battledescription { get; set; }

        public Battlelog()
        {
            Battledescription = new Battledescription();
        }

    }

    public class Battledescription
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }

        public Battledescription()
        {


        }

    }
}