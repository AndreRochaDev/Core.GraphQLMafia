using System.Collections.Generic;

namespace GraphQLBoilerplate.Models.Mafia.Types
{
    public abstract class MafiaMember
    {
        public string Id { get; set; }
        public string IdFamily { get; set; }
        public string Name { get; set; }
        public int Hits { get; set; }
    }

    public class Boss : MafiaMember
    {
        public string Stronghold { get; set; }
    }

    public class UnderBoss : MafiaMember
    {
        public string IdBoss { get; set; }
        public List<Capo> Capos { get; set; }
    }

    public class Capo : MafiaMember
    {
        public List<Soldier> Soldiers { get; set; }
        public int ZoneOfOperation { get; set; }
    }

    public class Soldier : MafiaMember
    {
        public string StreetCred { get; set; }
    }
}
