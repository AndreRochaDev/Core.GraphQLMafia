using System;
using System.Collections.Generic;
using System.Linq;
using GraphQLBoilerplate.Models.Mafia.Types;

namespace GraphQLBoilerplate.Models.Mafia
{
    public class MafiaData
    {
        private readonly Boss _boss;
        private readonly UnderBoss _underBoss;
        private readonly List<Capo> _capos = new List<Capo>();
        private readonly List<Soldier> _soldiers = new List<Soldier>();

        public MafiaData()
        {
            _boss = new Boss
            {
                Stronghold = "La Familia",
                Id = "1",
                Name = "GodFather",
                IdFamily = "1"
            };
            _underBoss = new UnderBoss
            {
                Id = "2",
                IdBoss = "1",
                Name = "Joe Bananas",
                Hits = 40,
                IdFamily = "1",
            };

            _capos.Add(new Capo
            {
                Id = "3", Name = "Ice Pick Willie", IdFamily = "1", Hits = 15,
                ZoneOfOperation = 1,
                Soldiers = new List<Soldier>()
                {
                    new Soldier
                    {
                        Id = "5", Name = "Pistol Pete", IdFamily = "1", Hits = 6
                    },
                    new Soldier
                    {
                        Id = "6", Name = "Baby Shanks", IdFamily = "1", Hits = 1
                    }
                }
            });
            _capos.Add(new Capo
            {
                Id = "4", Name = "Big Tuna", IdFamily = "1", Hits = 10,
                ZoneOfOperation = 2,
                Soldiers = new List<Soldier>()
                {
                    new Soldier
                    {
                        Id = "7", Name = "Johnny Sausage", IdFamily = "1", Hits = 3
                    }
                }
            });

            _underBoss.Capos = _capos;
            _soldiers.AddRange(_capos.SelectMany(c => c.Soldiers).ToList());
        }

        public IEnumerable<Capo> GetCapos(MafiaMember underBoss)
        {
            if (underBoss == null)
                return null;
            return _underBoss.Capos;
        }

        public Capo GetCapoById(string id)
        {
            return _capos.FirstOrDefault(c => c.Id == id);
        }

        public Soldier GetSoldierById(string id)
        {
            return _soldiers.FirstOrDefault(c => c.Id == id);
        }

        public Boss GetFamilyBoss()
        {
            return _boss;
        }

        public UnderBoss GetUnderBoss()
        {
            return _underBoss;
        }

        public IEnumerable<Capo> GetUnderBossCapos(UnderBoss underBoss)
        {
            return _capos;
        }

        public IEnumerable<Soldier> GetCapoSoldiers(string id)
        {
            return _capos.FirstOrDefault(c => c.Id == id)?.Soldiers;
        }

        public IEnumerable<Soldier> GetCapoSoldiers(Capo capo)
        {
            return _capos.FirstOrDefault(c => c.Id == capo.Id)?.Soldiers;
        }

        public Soldier AddSoldierToCapo(string id, Soldier soldier)
        {
            var capo = _capos.FirstOrDefault(c => c.Id == id);
            if (capo == null) return null;
            soldier.Id = Guid.NewGuid().ToString();
            capo.Soldiers.Add(soldier);
            return soldier;
        }
    }
}
