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

        public SamuraiInfo SamuraiInfo { get; set; }


    }

    public class SamuraiInfo
    {
        public string Name { get; set; }
        public string RealName { get; set; }
        public string BattleNames { get; set; }

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
}