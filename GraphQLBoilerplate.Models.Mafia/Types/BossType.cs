
using GraphQL.Types;

namespace GraphQLBoilerplate.Models.Mafia.Types
{
    public class BossType : ObjectGraphType<Boss>
    {
        public BossType(MafiaData data)
        {
            Name = "Boss";
            Description = "The family boss.";

            Field(d => d.Id).Description("The id of the mafia member.");
            Field(d => d.Name).Description("The name of the mafia member.");
            Field(d => d.IdFamily, nullable: true).Description("The name of the family.");

            Interface<MafiaMemberInterface>();
        }
       
    }
}
