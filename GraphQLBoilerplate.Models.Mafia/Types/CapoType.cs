using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace GraphQLBoilerplate.Models.Mafia.Types
{
    public class CapoType : ObjectGraphType<Capo>
    {
        public CapoType(MafiaData data)
        {
            Name = "Capo";
            Description = "A capo from the family.";

            Field(d => d.Id).Description("The id of the mafia member.");
            Field(d => d.Name).Description("The name of the mafia member.");
            Field(d => d.IdFamily, nullable: true).Description("The name of the family.");
            Field(d => d.Hits, nullable: true).Description("The hits made.");

            Field<ListGraphType<CapoInterface>>(
                "soldiers",
                resolve: context => data.GetCapoSoldiers(context.Source)
            );
            Field<ListGraphType<ZoneOfOperationsEnum>>("appearsIn", "Which movie they appear in.");

            Interface<CapoInterface>();
        }
    }
}
