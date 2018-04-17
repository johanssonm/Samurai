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

    public class SamuraiBattle
    {

        public int SamuraiID { get; set; }
        public int BattleID { get; set; }

        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }


    }

}
