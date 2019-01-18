using GraphQL.Types;
using GraphQLBoilerplate.Models.Mafia.Types;

namespace GraphQLBoilerplate.Models.Mafia
{
    public class SoldierInputType : InputObjectGraphType<Soldier>
    {
        public SoldierInputType()
        {
            Name = "SoldierInput";

            Field(s => s.Name);
            Field(s => s.IdFamily);
            Field(s => s.Id);
            Field(s => s.Hits, nullable: true);
        }
    }
}
