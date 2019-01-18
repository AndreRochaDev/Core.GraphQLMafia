using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using GraphQLBoilerplate.Models.Mafia.Types;

namespace GraphQLBoilerplate.Models.Mafia
{
    public class MafiaQuery : ObjectGraphType<object>
    {
        public MafiaQuery(MafiaData data)
        {
            Name = "Query";

            Field<BossType>("boss", resolve: context => data.GetFamilyBoss());
            Field<UnderBossType>("underboss", resolve: context => data.GetUnderBoss());

            Field<CapoType>(
                "capo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "id", Description = "id of the capo"}
                ),
                resolve: context => data.GetCapoById(context.GetArgument<string>("id"))
            );

            Field<SoldierType>(
                "soldier",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {Name = "id", Description = "id of the soldier"}
                ),
                resolve: context => data.GetSoldierById(context.GetArgument<string>("id"))
            );

            Field<ListGraphType<CapoType>>(
                "capos",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        { Name = "id", Description = "id of the underboss" }
                ),
                resolve: context => data.GetCapos(new UnderBoss(){Id = context.GetArgument<string>("id")}));

            Field<ListGraphType<SoldierType>>(
                "soldiers",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        { Name = "id", Description = "id of the capo" }
                ),
                resolve: context => data.GetCapoSoldiers(new Capo() { Id = context.GetArgument<string>("id") }));
               

        }
    }
}
