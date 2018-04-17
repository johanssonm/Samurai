using System;
using System.Collections.Generic;

namespace EfSamurai
{
    
    public class Samurai
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Quote> Quote { get; set; }

        public HairStyle Hairstyle { get; set; }

        public SecretIdentity Identity { get; set; }

        public List<SamuraiBattle> SamuraisBattles { get; set; }


    }

    public class Quote
    {

        public int ID { get; set; }
        public QuoteType Type { get; set; }

        public string Text { get; set; }

    }

    public enum QuoteType
    {
        Lame,
        Cheesy,
        Awesome
    }

    public class Hair
    {
        public int ID { get; set; }
        public string Style { get; set; }
    }

    public enum HairStyle
    {
        Chonmage,
        Oicho,
        Western
    }

    public class SecretIdentity
    {
        public int ID { get; set; }
        public int SamuraiID { get; set; }
        public string Name { get; set; }

    }

    public class Battle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Brutal { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<SamuraiBattle> SamuraisBattles { get; set; }

        public Battlelog Battlelog { get; set; }
        
    }

    public class Battlelog
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public Battledescription Battledescription { get; set; }

    }

    public class Battledescription
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }

    }

    public class SamuraiBattle
    {

        public int SamuraiID { get; set; }
        public int BattleID { get; set; }

        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }


    }

}
