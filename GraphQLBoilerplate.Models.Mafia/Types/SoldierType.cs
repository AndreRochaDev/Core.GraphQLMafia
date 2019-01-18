using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace GraphQLBoilerplate.Models.Mafia.Types
{
    public class SoldierType : ObjectGraphType<Soldier>
    {
        public SoldierType(MafiaData data)
        {
            Name = "Soldier";
            Description = "A common soldier from the family.";

            Field(d => d.Id).Description("The id of the mafia member.");
            Field(d => d.Name).Description("The name of the mafia member.");
            Field(d => d.IdFamily, nullable: true).Description("The name of the family.");
            Field(d => d.Hits, nullable: true).Description("The hits made.");

            Interface<MafiaMemberInterface>();
        }
    }
}
