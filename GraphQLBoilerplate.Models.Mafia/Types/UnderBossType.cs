using GraphQL.Types;

namespace GraphQLBoilerplate.Models.Mafia.Types
{
    public class UnderBossType : ObjectGraphType<UnderBoss>
    {
        public UnderBossType(MafiaData data)
        {
            Name = "UnderBoss";
            Description = "The mamma mia family.";

            Field(d => d.Id).Description("The id of the mafia member.");
            Field(d => d.Name).Description("The name of the mafia member.");
            Field(d => d.IdFamily, nullable: true).Description("The name of the family.");

            Field<ListGraphType<CapoInterface>>(
                "capos",
                resolve: context => data.GetUnderBossCapos(context.Source)
            );

            Interface<UnderBossInterface>();
        }
    }
}
