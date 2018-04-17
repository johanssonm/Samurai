using System;
using System.Collections.Generic;

namespace EfSamurai
{
    public class Battle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Brutal { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<SamuraiBattle> SamuraisBattles { get; set; }

        public Battlelog Battlelog { get; set; }
        public Battledescription Battledescription { get; set; }

        public Battle()
        {

         }
        
    }


    public class Battlelog
    {
        public int ID { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public Battledescription Battledescription { get; set; }

    }

    public class Battledescription
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public Battledescription()
        {
                      
        }

    }

    public class SamuraiBattle
    {

        public int SamuraiID { get; set; }
        public int BattleID { get; set; }

        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }

        public SamuraiBattle()
        {
            
        }


    }

}

