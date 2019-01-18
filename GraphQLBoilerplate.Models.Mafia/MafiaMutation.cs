using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using GraphQLBoilerplate.Models.Mafia.Types;

namespace GraphQLBoilerplate.Models.Mafia
{
    public class MafiaMutation : ObjectGraphType
    {
        public MafiaMutation(MafiaData data)
        {
            Name = "Mutation";

            Field<SoldierType>(
                "createSoldier",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SoldierInputType>> { Name = "soldier" },
                    new QueryArgument<NonNullGraphType<StringGraphType>>{ Name = "id", Description = "id of the capo" }
                ),
                resolve: context =>
                {
                    var soldier = context.GetArgument<Soldier>("soldier");
                    var id = context.GetArgument<string>("id");
                    return data.AddSoldierToCapo(id, soldier);
                });
        }
    }
}
