using GraphQL.Types;

namespace GraphQLBoilerplate.Models.Mafia.Types
{
    public class MafiaMemberInterface : InterfaceGraphType<MafiaMember>
    {
        public MafiaMemberInterface()
        {
            Name = "MafiaMember";

            Field(d => d.Id).Description("The id of the mafia member.");
            Field(d => d.Name).Description("The name of the mafia member.");
            Field(d => d.Hits, nullable: true).Description("The number of hits made.");
            Field(d => d.IdFamily, nullable: true).Description("The id of the family.");

        }
    }

    public class CapoInterface : InterfaceGraphType<MafiaMember>
    {
        public CapoInterface()
        {
            Name = "Capo";

            Field(d => d.Id).Description("The id of the mafia member.");
            Field(d => d.Name).Description("The name of the mafia member.");
            Field(d => d.Hits, nullable: true).Description("The number of hits made.");
            Field(d => d.IdFamily, nullable: true).Description("The id of the family.");
            Field<ListGraphType<MafiaMemberInterface>>("soldiers");
            Field<ListGraphType<ZoneOfOperationsEnum>>("zonesofoperation", "The zone where the capo operates.");
        }
    }

    public class UnderBossInterface : InterfaceGraphType<MafiaMember>
    {
        public UnderBossInterface()
        {
            Name = "UnderBoss";

            Field(d => d.Id).Description("The id of the mafia member.");
            Field(d => d.Name).Description("The name of the mafia member.");
            Field(d => d.Hits, nullable: true).Description("The number of hits made.");
            Field(d => d.IdFamily, nullable: true).Description("The id of the family.");
            Field<ListGraphType<CapoInterface>>("capos");
        }
    }
}
